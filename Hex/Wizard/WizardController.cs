using Hex.Extensions;
using Hex.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

		private IWizardStepInitializer _wizardStepInitializer;
		private IWizardStateProvider _wizardStateProvider;

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

			WizardActionDescriptor[] wizardActions = this.ActionInvoker.GetWizardActions( this.ControllerContext );

			this.WizardFormModel = Activator.CreateInstance( this.WizardFormModelType, true );

			ValueProviderResult wizardStateTokenResult = this.ValueProvider.GetValue( Constants.WIZARD_STATE_TOKEN_HIDDEN_FIELD_NAME );
			if( wizardStateTokenResult == null || string.IsNullOrWhiteSpace( wizardStateTokenResult.AttemptedValue ) )
			{
				this.InitializeWizardSteps( requestContext, wizardActions );
			}
			else
			{
				this.LoadWizardState( requestContext, wizardStateTokenResult.AttemptedValue, wizardActions );

				this.ProcessWizardButton();
			}
			
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

		protected virtual IWizardStepInitializer CreateWizardStepInitializer()
		{
			return new WizardStepInitializer();
		}

		protected virtual IWizardStateProvider CreateWizardStateProvider()
		{
			return new FormWizardStateProvider();
		}

		#region Internal Methods

		private void InitializeWizardSteps( RequestContext requestContext, WizardActionDescriptor[] wizardActions )
		{
			IEnumerable<WizardStep> wizardSteps = this.WizardStepInitializer.InitializeWizardSteps( requestContext, wizardActions );
			this.WizardSteps = new WizardStepLinkedList( wizardSteps.ToArray() );
		}



		private void LoadWizardState( RequestContext requestContext, string wizardStateToken, WizardActionDescriptor[] wizardActions )
		{
			WizardState wizardState = this.WizardStateProvider.Load( requestContext, wizardStateToken );

			WizardStep[] wizardSteps = ( from currentWizardStateStep in wizardState.Steps
										 let currentWizardAction = wizardActions.FirstOrDefault( x => x.ActionName == currentWizardStateStep.ActionName )
										 where currentWizardAction != null
										 select new WizardStep( currentWizardAction.ActionName, currentWizardAction.Name, currentWizardAction.Description, currentWizardStateStep.Values ) ).ToArray();

			WizardStep currentWizardStep = wizardSteps.FirstOrDefault( x => wizardState.CurrentStepActionName == x.ActionName );

			this.WizardSteps = new WizardStepLinkedList( wizardSteps, currentWizardStep );
		}

		internal void ProcessWizardButton()
		{
			ValueProviderResult wizardNextButtonValueResult = this.ValueProvider.GetValue( Constants.WIZARD_NEXT_BUTTON_NAME );
			if( wizardNextButtonValueResult != null )
			{
				if( this.ModelState.IsValid )
				{
					WizardStep currentWizardStep = this.WizardSteps.MoveToNextStep();
					this.ModelState.Update( currentWizardStep.Values );
				}

				return;
			}

			ValueProviderResult wizardPreviousButtonValueResult = this.ValueProvider.GetValue( Constants.WIZARD_PREVIOUS_BUTTON_NAME );
			if( wizardPreviousButtonValueResult != null )
			{
				WizardStep currentWizardStep = this.WizardSteps.MoveToPreviousStep();
				this.ModelState.Update( currentWizardStep.Values );

				return;
			}
		}




		internal string SaveWizardState( RequestContext requestContext )
		{
			var wizardStepStates = from currentWizardStep in this.WizardSteps
								   select new WizardStepState( currentWizardStep.ActionName, null );

			WizardState wizardState = new WizardState( this.WizardSteps.CurrentStep.ActionName, wizardStepStates.ToArray() );

			return this.WizardStateProvider.Save( requestContext, wizardState );
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
