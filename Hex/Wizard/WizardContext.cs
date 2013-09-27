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
		{
			if( requestContext == null )
			{
				throw new ArgumentNullException( "requestContext" );
			}

			if( wizardController == null )
			{
				throw new ArgumentNullException( "wizardController" );
			}

			this.RequestContext = requestContext;
			this.WizardController = wizardController;
			this.ActionInvoker = wizardController.ActionInvoker;
		}

		public RequestContext RequestContext { get; private set; }

		public WizardController WizardController { get; private set; }

		public IWizardActionInvoker ActionInvoker { get; set; }

		public IWizardStepCollection WizardSteps { get; set; }

		public void Initialize()
		{
			this.InitializeWizardSteps();
		}

		public void InitializeWizardSteps()
		{
			ControllerContext controllerContext = this.WizardController.ControllerContext;

			ActionDescriptor[] actionDescriptors = this.ActionInvoker.GetWizardActions( controllerContext );

			WizardStep[] wizardSteps = ( from ActionDescriptor currentActionDescriptor in actionDescriptors
										 let currentWizardStepAttribute = currentActionDescriptor.GetCustomAttributes( typeof( WizardStepAttribute ), false ).FirstOrDefault() as WizardStepAttribute
										 let currentName = ( currentWizardStepAttribute != null ) ? currentWizardStepAttribute.Name : null
										 let currentDescription = ( currentWizardStepAttribute != null ) ? currentWizardStepAttribute.Description : null
										 select new WizardStep( currentActionDescriptor.ActionName, currentName, currentDescription ) ).ToArray();

			this.WizardSteps = new WizardStepLinkedList( wizardSteps );
		}
	}
}
