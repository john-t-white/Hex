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

		private IWizardContext _wizardContext;
		private IWizardStepCollection _wizardSteps;

		#region Controller Members

		protected override void Initialize( RequestContext requestContext )
		{
			base.Initialize( requestContext );

			IWizardContext wizardContext = this.CreateWizardContext( requestContext );
			wizardContext.Initialize();

			this.WizardContext = wizardContext;
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

		public IWizardContext WizardContext { get; set; }

		public IWizardStepCollection WizardSteps
		{
			get
			{
				if( this._wizardSteps != null )
				{
					return this._wizardSteps;
				}

				return this.WizardContext.WizardSteps;
			}
			set
			{
				this._wizardSteps = value;
			}
		}

		protected virtual IWizardContext CreateWizardContext( RequestContext requestContext )
		{
			return new WizardContext( requestContext, this );
		}
	}
}
