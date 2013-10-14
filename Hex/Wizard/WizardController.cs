using Hex.Resources;
using Hex.Wizard.LifeCycle;
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

			this.WizardLifeCycle = new WizardLifeCycle( this );
			this.WizardLifeCycle.Initialize();
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
			WizardLifeCycleContext wizardLifeCycleContext = new WizardLifeCycleContext( this );
			foreach( IWizardLifeCycleCommand currentWizardLifeCycleCommand in this.WizardLifeCycle )
			{
				currentWizardLifeCycleCommand.Execute( wizardLifeCycleContext );
				if( !string.IsNullOrWhiteSpace( wizardLifeCycleContext.ResultActionName ) )
				{
					this.RouteData.Values[ ACTION_ROUTE_VALUE_NAME ] = wizardLifeCycleContext.ResultActionName;
					return base.BeginExecuteCore( callback, state );
				}
			}

			throw new InvalidOperationException( "LifeCycle did not return an action name to execute." );
		}

		#endregion

		public WizardLifeCycle WizardLifeCycle { get; set; }

		public abstract Type WizardFormModelType { get; }

		public object WizardFormModel { get; set; }

		public WizardActionDescriptor[] WizardActions { get; set; }

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

		[NotAWizardAction]
		[AllowAnonymous]
		public virtual ActionResult HandleNoAuthorizedWizardActions()
		{
			return new HttpUnauthorizedResult();
		}

		[NotAWizardAction]
		public virtual ActionResult HandleNoWizardSteps()
		{
			string exceptionMessage = string.Format( ExceptionMessages.NO_WIZARD_STEPS, this.GetType().FullName );
			throw new HttpException( ( int )HttpStatusCode.NotFound, exceptionMessage );
		}

		[NotAWizardAction]
		public virtual ActionResult HandleWizardStateNotFound()
		{
			return this.Redirect( this.HttpContext.Request.RawUrl );
		}

		#region Internal Methods

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
				throw new InvalidOperationException( ExceptionMessages.HTML_HELPER_WIZARD_METHODS_MUST_BE_USED_WITH_WIZARD_CONTROLLER );
			}

			return wizardController;
		}

		#endregion
	}
}
