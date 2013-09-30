using Hex.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hex.Wizard
{
	public abstract class WizardController
		: Controller
	{
		private const string ACTION_ROUTE_VALUE_NAME = "action";

		private Lazy<IWizardStepInitializer> _wizardStepInitializer;
		private Lazy<IWizardStateProvider> _wizardStateProvider;

		protected WizardController()
		{
			this._wizardStepInitializer = new Lazy<IWizardStepInitializer>( this.CreateWizardStepInitializer );
			this._wizardStateProvider = new Lazy<IWizardStateProvider>( this.CreateWizardStateProvider );
		}

		#region Controller Members

		protected override void Initialize( RequestContext requestContext )
		{
			if( requestContext.RouteData.Values.ContainsKey( ACTION_ROUTE_VALUE_NAME ) )
			{
				throw new InvalidOperationException( ExceptionMessages.WIZARD_CANNOT_CONTAIN_ACTION_IN_ROUTE );
			}

			base.Initialize( requestContext );

			ActionDescriptor[] wizardActions = this.ActionInvoker.GetWizardActions( this.ControllerContext );

			ValueProviderResult wizardStateTokenResult = this.ValueProvider.GetValue( Constants.WIZARD_STATE_TOKEN_HIDDEN_FIELD_NAME );
			if( wizardStateTokenResult == null || string.IsNullOrWhiteSpace( wizardStateTokenResult.AttemptedValue ) )
			{
				this.InitializeWizardSteps( requestContext, wizardActions );
			}
			else
			{
				this.LoadWizardState( requestContext, wizardStateTokenResult.AttemptedValue, wizardActions );
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

		public WizardStepLinkedList WizardSteps { get; set; }




		public IWizardStepInitializer WizardStepInitializer
		{
			get
			{
				return this._wizardStepInitializer.Value;
			}
		}

		public IWizardStateProvider WizardStateProvider
		{
			get
			{
				return this._wizardStateProvider.Value;
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





		public string SaveWizardState( RequestContext requestContext )
		{
			var wizardStepStates = from currentWizardStep in this.WizardSteps
								   select new WizardStepState( currentWizardStep.ActionName, null );

			WizardState wizardState = new WizardState( this.WizardSteps.CurrentStep.ActionName, wizardStepStates.ToArray() );

			return this.WizardStateProvider.Save( requestContext, wizardState );
		}

		#region Internal Methods

		private void InitializeWizardSteps( RequestContext requestContext, ActionDescriptor[] wizardActions )
		{
			IEnumerable<WizardStep> wizardSteps = this.WizardStepInitializer.InitializeWizardSteps( requestContext, wizardActions );
			this.WizardSteps = new WizardStepLinkedList( wizardSteps.ToArray() );
		}



		private void LoadWizardState( RequestContext requestContext, string wizardStateToken, ActionDescriptor[] wizardActions )
		{
			WizardState wizardState = this.WizardStateProvider.Load( requestContext, wizardStateToken );

			WizardStep[] wizardSteps = ( from currentWizardStateStep in wizardState.Steps
										 let currentWizardAction = wizardActions.FirstOrDefault( x => x.ActionName == currentWizardStateStep.ActionName )
										 let currentWizardStepAttribute = currentWizardAction.GetCustomAttributes( typeof( WizardStepAttribute ), false ).FirstOrDefault() as WizardStepAttribute
										 let currentName = ( currentWizardStepAttribute != null ) ? currentWizardStepAttribute.Name : null
										 let currentDescription = ( currentWizardStepAttribute != null ) ? currentWizardStepAttribute.Description : null
										 where currentWizardAction != null
										 select new WizardStep( currentWizardAction.ActionName, currentName, currentDescription ) ).ToArray();

			WizardStep currentWizardStep = wizardSteps.FirstOrDefault( x => wizardState.CurrentStepActionName == x.ActionName );

			this.WizardSteps = new WizardStepLinkedList( wizardSteps, currentWizardStep );
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
