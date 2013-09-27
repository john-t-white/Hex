using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hex.Wizard
{
	public class WizardContext
		: IWizardContext
	{
		public WizardContext( RequestContext requestContext, WizardController wizardController )
			: this( requestContext, wizardController, wizardController.ControllerContext, wizardController.ActionInvoker, wizardController.ValueProvider )
		{ }

		public WizardContext( RequestContext requestContext, WizardController wizardController, ControllerContext controllerContext, IWizardActionInvoker actionInvoker, IValueProvider valueProvider )
		{
			if( requestContext == null )
			{
				throw new ArgumentNullException( "requestContext" );
			}

			if( wizardController == null )
			{
				throw new ArgumentNullException( "wizardController" );
			}

			if( controllerContext == null )
			{
				throw new ArgumentNullException( "controllerContext" );
			}

			if( actionInvoker == null )
			{
				throw new ArgumentNullException( "actionInvoker" );
			}

			if( valueProvider == null )
			{
				throw new ArgumentNullException( "valueProvider" );
			}

			this.RequestContext = requestContext;
			this.WizardController = wizardController;
			this.ControllerContext = controllerContext;
			this.ActionInvoker = actionInvoker;
			this.ValueProvider = valueProvider;
		}

		public RequestContext RequestContext { get; private set; }

		public WizardController WizardController { get; private set; }

		public ControllerContext ControllerContext { get; private set; }

		public IWizardActionInvoker ActionInvoker { get; private set; }

		public IWizardStepCollection WizardSteps { get; private set; }

		public IValueProvider ValueProvider { get; private set; }

		public void Initialize()
		{
			ValueProviderResult wizardStateTokenResult = this.ValueProvider.GetValue( Constants.WIZARD_STATE_TOKEN_HIDDEN_FIELD_NAME );
			if( wizardStateTokenResult == null )
			{
				this.InitializeWizardSteps();
			}
		}

		public void InitializeWizardSteps()
		{
			ActionDescriptor[] actionDescriptors = this.ActionInvoker.GetWizardActions( this.ControllerContext );

			WizardStep[] wizardSteps = ( from ActionDescriptor currentActionDescriptor in actionDescriptors
										 let currentWizardStepAttribute = currentActionDescriptor.GetCustomAttributes( typeof( WizardStepAttribute ), false ).FirstOrDefault() as WizardStepAttribute
										 let currentName = ( currentWizardStepAttribute != null ) ? currentWizardStepAttribute.Name : null
										 let currentDescription = ( currentWizardStepAttribute != null ) ? currentWizardStepAttribute.Description : null
										 select new WizardStep( currentActionDescriptor.ActionName, currentName, currentDescription ) ).ToArray();

			this.WizardSteps = new WizardStepLinkedList( wizardSteps );
		}
	}
}
