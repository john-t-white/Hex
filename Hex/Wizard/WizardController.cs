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

			this.InitializeWizardSteps( requestContext, wizardActions );		
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

		#region Internal Methods

		private void InitializeWizardSteps( RequestContext requestContext, ActionDescriptor[] wizardActions )
		{
			IEnumerable<WizardStep> wizardSteps = this.WizardStepInitializer.InitializeWizardSteps( requestContext, wizardActions );
			this.WizardSteps = new WizardStepLinkedList( wizardSteps.ToArray() );
		}

		#endregion
	}
}
