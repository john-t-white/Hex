using Hex.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hex.Wizard
{
	public abstract class WizardController<TWizardFormModel>
		: WizardController
	{
		public override Type WizardFormModelType
		{
			get
			{
				return typeof( TWizardFormModel );
			}
		}

		public new TWizardFormModel WizardFormModel
		{
			get
			{
				return ( TWizardFormModel )base.WizardFormModel;
			}
			set
			{
				base.WizardFormModel = value;
			}
		}
	}

	public abstract class WizardController
		: Controller
	{
		private const string ACTION_ROUTE_VALUE_NAME = "action";
		private const string HANDLE_NO_AUTHORIZED_WIZARD_ACTIONS_ACTION_NAME = "HandleNoAuthorizedWizardActions";
		private const string HANDLE_NO_WIZARD_STEPS_ACTION_NAME = "HandleNoWizardSteps";
		
		private IWizardStepInitializer _wizardStepInitializer;
		private IWizardStateProvider _wizardStateProvider;
		private IWizardButtonCommandFactory _wizardButtonCommandFactory;

		protected WizardController()
		{ }

		#region Controller Members

		protected override void Initialize( RequestContext requestContext )
		{
			if( requestContext.RouteData.Values.ContainsKey( ACTION_ROUTE_VALUE_NAME ) )
			{
				throw new InvalidOperationException( ExceptionMessages.WIZARD_CANNOT_CONTAIN_ACTION_IN_ROUTE );
			}

			base.Initialize( requestContext );	
		}

		protected override IActionInvoker CreateActionInvoker()
		{
			return new WizardControllerActionInvoker();
		}

		public new IWizardActionInvoker ActionInvoker
		{
			get
			{
				return ( IWizardActionInvoker )base.ActionInvoker;
			}
			set
			{
				base.ActionInvoker = value;
			}
		}

		protected override IAsyncResult BeginExecuteCore( AsyncCallback callback, object state )
		{
			WizardActionDescriptor[] wizardActions = this.ActionInvoker.GetWizardActions( this.ControllerContext );

			wizardActions = this.ActionInvoker.FilterUnauthorizedWizardActions( this.ControllerContext, wizardActions );
			if( wizardActions == null || wizardActions.Length == 0 )
			{
				this.RouteData.Values[ ACTION_ROUTE_VALUE_NAME ] = HANDLE_NO_AUTHORIZED_WIZARD_ACTIONS_ACTION_NAME;
				return base.BeginExecuteCore( callback, state );
			}

			this.WizardFormModel = Activator.CreateInstance( this.WizardFormModelType, true );

			ValueProviderResult wizardStateTokenResult = this.ValueProvider.GetValue( Constants.WIZARD_STATE_TOKEN_HIDDEN_FIELD_NAME );
			if( wizardStateTokenResult == null || string.IsNullOrWhiteSpace( wizardStateTokenResult.AttemptedValue ) )
			{
				WizardStep[] wizardSteps = this.WizardStepInitializer.InitializeWizardSteps( this.ControllerContext.RequestContext, wizardActions );
				if( wizardSteps == null || wizardSteps.Length == 0 )
				{
					this.RouteData.Values[ ACTION_ROUTE_VALUE_NAME ] = HANDLE_NO_WIZARD_STEPS_ACTION_NAME;
					return base.BeginExecuteCore( callback, state );
				}

				this.WizardSteps = new WizardStepLinkedList( wizardSteps.ToArray() );
			}
			else
			{
				WizardState wizardState = this.WizardStateProvider.Load( this.ControllerContext, wizardStateTokenResult.AttemptedValue );

				this.RestoreWizardState( wizardState, wizardActions );

				this.RestoreWizardFormModel();

				this.UpdateWizardFormModel();

				this.ProcessWizardButton();
			}

			this.RouteData.Values[ ACTION_ROUTE_VALUE_NAME ] = this.WizardSteps.CurrentStep.ActionName;

			return base.BeginExecuteCore( callback, state );
		}

		#endregion

		public abstract Type WizardFormModelType { get; }

		public object WizardFormModel { get; set; }

		public WizardStepLinkedList WizardSteps { get; set; }

		public IWizardStepInitializer WizardStepInitializer
		{
			get
			{
				if( this._wizardStepInitializer == null )
				{
					_wizardStepInitializer = this.CreateWizardStepInitializer();
				}

				return this._wizardStepInitializer;
			}
			set
			{
				this._wizardStepInitializer = value;
			}
		}

		public IWizardStateProvider WizardStateProvider
		{
			get
			{
				if( this._wizardStateProvider == null )
				{
					_wizardStateProvider = this.CreateWizardStateProvider();
				}

				return this._wizardStateProvider;
			}
			set
			{
				this._wizardStateProvider = value;
			}
		}

		public IWizardButtonCommandFactory WizardButtonCommandFactory
		{
			get
			{
				if( this._wizardButtonCommandFactory == null )
				{
					_wizardButtonCommandFactory = this.CreateWizardButtonCommandFactory();
				}

				return this._wizardButtonCommandFactory;
			}
			set
			{
				this._wizardButtonCommandFactory = value;
			}
		}

		protected virtual IWizardStepInitializer CreateWizardStepInitializer()
		{
			return new WizardStepInitializer();
		}

		protected virtual IWizardStateProvider CreateWizardStateProvider()
		{
			return new FormWizardStateProvider();
		}

		protected virtual IWizardButtonCommandFactory CreateWizardButtonCommandFactory()
		{
			return new WizardButtonCommandFactory();
		}

		[NotAWizardStep]
		[AllowAnonymous]
		public virtual ActionResult HandleNoAuthorizedWizardActions()
		{
			return new HttpUnauthorizedResult();
		}

		[NotAWizardStep]
		public virtual ActionResult HandleNoWizardSteps()
		{
			string exceptionMessage = string.Format( ExceptionMessages.NO_WIZARD_STEPS, this.GetType().FullName );
			throw new HttpException( ( int )HttpStatusCode.NotFound, exceptionMessage );
		}

		#region Internal Methods

		private void RestoreWizardState( WizardState wizardState, WizardActionDescriptor[] wizardActions )
		{
			WizardStep[] wizardSteps = ( from currentWizardStateStep in wizardState.Steps
										 let currentWizardAction = wizardActions.FirstOrDefault( x => x.ActionName == currentWizardStateStep.ActionName )
										 where currentWizardAction != null
										 select new WizardStep( currentWizardAction, currentWizardStateStep.Values ) ).ToArray();

			WizardStep currentWizardStep = wizardSteps.FirstOrDefault( x => wizardState.CurrentStepActionName == x.ActionName );

			this.WizardSteps = new WizardStepLinkedList( wizardSteps, currentWizardStep );
		}

		private void RestoreWizardFormModel()
		{
			foreach( WizardStep currentWizardStep in this.WizardSteps.Where( x => x.Values != null ) )
			{
				IValueProvider valueProvider = new WizardStepValueCollectionValueProvider( currentWizardStep.Values, CultureInfo.CurrentUICulture );
				
				this.BindWizardFormModel( new ModelStateDictionary(), valueProvider, null );
			}
		}

		private void UpdateWizardFormModel()
		{
			this.BindWizardFormModel( this.ModelState, this.ValueProvider, Constants.WIZARD_FORM_MODEL_NAME );

			this.WizardSteps.CurrentStep.Values = this.ModelState.ToWizardStepValueCollection( this.ValueProvider );
		}

		private void ProcessWizardButton()
		{
			IWizardButtonCommand buttonCommand = this.WizardButtonCommandFactory.GetButtonCommand( this );
			if( buttonCommand != null )
			{
				buttonCommand.ExecuteCommand( this );
			}
		}

		private void BindWizardFormModel( ModelStateDictionary modelStateDictionary, IValueProvider valueProvider, string modelName )
		{
			IModelBinder binder = System.Web.Mvc.ModelBinders.Binders.GetBinder( this.WizardFormModelType );
			var bindingContext = new ModelBindingContext()
			{
				ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType( () => this.WizardFormModel, this.WizardFormModelType ),
				ModelState = modelStateDictionary,
				ModelName = modelName,
				ValueProvider = valueProvider
			};

			binder.BindModel( this.ControllerContext, bindingContext );
		}

		internal string SaveWizardState( ControllerContext controllerContext )
		{
			var wizardStepStates = from currentWizardStep in this.WizardSteps
								   select new WizardStepState( currentWizardStep.ActionName, currentWizardStep.Values );

			WizardState wizardState = new WizardState( this.WizardSteps.CurrentStep.ActionName, wizardStepStates.ToArray() );

			return this.WizardStateProvider.Save( controllerContext, wizardState );
		}

		internal static WizardController FromHtmlHelper( HtmlHelper htmlHelper )
		{
			WizardController wizardController = htmlHelper.ViewContext.Controller as WizardController;
			if( wizardController == null )
			{
				throw new InvalidOperationException( "Wizard forms can only be used with a wizard controller." );
			}

			return wizardController;
		}

		#endregion
	}
}
