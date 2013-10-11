using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard.LifeCycle;
using Hex.Wizard;
using Rhino.Mocks;
using System.Web.Mvc;
using System.Web.Routing;
using System.Reflection;

namespace Hex.TestProject.Wizard.LifeCycle.InitializeWizardActionsLifeCycleCommandTests
{
	[TestClass]
	public class InitializeWizardActionsLifeCycleCommand_Execute
	{
		[TestMethod]
		public void SetsWizardActionsCorrectly()
		{
			WizardController wizardController = this.GenerateWizardController( true );

			WizardLifeCycleContext wizardLifeCycleContext = new WizardLifeCycleContext( wizardController );

			InitializeWizardActionsLifeCycleCommand lifeCycleCommand = new InitializeWizardActionsLifeCycleCommand();
			lifeCycleCommand.Execute( wizardLifeCycleContext );

			wizardController.ActionInvoker.VerifyAllExpectations();

			Assert.IsNotNull( wizardController.WizardActions );
			Assert.AreEqual( 1, wizardController.WizardActions.Length );

			Assert.IsNull( wizardLifeCycleContext.ResultActionName );
		}

		[TestMethod]
		public void WithNoAuthorizedActionsSetsResultActionNameCorrectly()
		{
			WizardController wizardController = this.GenerateWizardController( false );

			WizardLifeCycleContext wizardLifeCycleContext = new WizardLifeCycleContext( wizardController );

			InitializeWizardActionsLifeCycleCommand lifeCycleCommand = new InitializeWizardActionsLifeCycleCommand();
			lifeCycleCommand.Execute( wizardLifeCycleContext );

			wizardController.ActionInvoker.VerifyAllExpectations();

			Assert.AreEqual( "HandleNoAuthorizedWizardActions", wizardLifeCycleContext.ResultActionName );
		}

		private WizardController GenerateWizardController( bool isAuthorizedForAction )
		{
			FakeWizardControllerWithThreeSteps wizardController = new FakeWizardControllerWithThreeSteps();
			ControllerContext controllerContext = new ControllerContext( new RequestContext(), wizardController );
			wizardController.ControllerContext = controllerContext;

			WizardActionDescriptor[] wizardActions = this.GenerateWizardActionDescriptors( wizardController.GetType() );

			IWizardActionInvoker wizardActionInvoker = MockRepository.GenerateMock<IWizardActionInvoker>();
			wizardActionInvoker.Expect( x => x.GetWizardActions( controllerContext ) )
				.Return( wizardActions );

			if( isAuthorizedForAction )
			{
				wizardActionInvoker.Expect( x => x.FilterUnauthorizedWizardActions( controllerContext, wizardActions ) )
					.Return( wizardActions );
			}
			else
			{
				wizardActionInvoker.Expect( x => x.FilterUnauthorizedWizardActions( controllerContext, wizardActions ) )
					.Return( new WizardActionDescriptor[] {} );
			}

			wizardController.ActionInvoker = wizardActionInvoker;

			return wizardController;
		}

		private WizardActionDescriptor[] GenerateWizardActionDescriptors( Type wizardControllerType )
		{
			MethodInfo wizardActionMethodInfo = wizardControllerType.GetMethods( BindingFlags.Public | BindingFlags.Instance ).FirstOrDefault();
			ReflectedControllerDescriptor controllerDescriptor = new ReflectedControllerDescriptor( wizardControllerType );
			ReflectedActionDescriptor actionDescriptor = new ReflectedActionDescriptor( wizardActionMethodInfo, wizardActionMethodInfo.Name, controllerDescriptor );

			return new WizardActionDescriptor[]
			{
				new WizardActionDescriptor( actionDescriptor )
			};
		}
	}
}
