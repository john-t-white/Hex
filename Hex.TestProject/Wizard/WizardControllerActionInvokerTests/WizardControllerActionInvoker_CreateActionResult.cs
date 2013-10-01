using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Web.Routing;
using Hex.Wizard;
using System.Reflection;

namespace Hex.TestProject.Wizard.WizardControllerActionInvokerTests
{
	[TestClass]
	public class WizardControllerActionInvoker_CreateActionResult
	{
		[TestMethod]
		public void WithNullModelCreatesWizardStepViewModelCorrectly()
		{
			object wizardFormModel = new object();

			WizardControllerActionInvoker wizardControllerActionInvoker = new WizardControllerActionInvoker();

			ControllerContext controllerContext = this.GenerateControllerContext( wizardFormModel );
			ActionDescriptor actionDescriptor = this.GenerateActionDescriptor( wizardControllerActionInvoker, controllerContext );

			ViewResult actionReturnValue = new ViewResult();
			actionReturnValue.ViewData.Model = null;

			ViewResult actionResult = this.ExecuteCreateActionResult( wizardControllerActionInvoker, controllerContext, actionDescriptor, actionReturnValue ) as ViewResult;

			Assert.IsNotNull( actionResult );
			Assert.AreSame( actionReturnValue, actionResult );

			WizardStepViewModel<object> wizardStepViewModel = actionResult.Model as WizardStepViewModel<object>;
			Assert.IsNotNull( wizardStepViewModel );
			Assert.AreSame( wizardFormModel, wizardStepViewModel.WizardFormModel );

			WizardController wizardController = controllerContext.Controller as WizardController;
			Assert.IsNotNull( wizardController );
			Assert.AreSame( wizardController.WizardSteps, wizardStepViewModel.WizardSteps );
		}

		[TestMethod]
		public void WithIWizardStepViewModelSetsWizardModelAndWizardStepsCorrectly()
		{
			object wizardFormModel = new object();
			IWizardStepViewModel<object> viewModel = new FakeWizardStepViewModel();

			WizardControllerActionInvoker wizardControllerActionInvoker = new WizardControllerActionInvoker();

			ControllerContext controllerContext = this.GenerateControllerContext( wizardFormModel );
			ActionDescriptor actionDescriptor = this.GenerateActionDescriptor( wizardControllerActionInvoker, controllerContext );

			ViewResult actionReturnValue = new ViewResult();
			actionReturnValue.ViewData.Model = viewModel;

			ViewResult actionResult = this.ExecuteCreateActionResult( wizardControllerActionInvoker, controllerContext, actionDescriptor, actionReturnValue ) as ViewResult;

			Assert.IsNotNull( actionResult );
			Assert.AreSame( actionReturnValue, actionResult );

			FakeWizardStepViewModel wizardStepViewModel = actionResult.Model as FakeWizardStepViewModel;
			Assert.IsNotNull( wizardStepViewModel );
			Assert.AreSame( wizardFormModel, wizardStepViewModel.WizardFormModel );

			WizardController wizardController = controllerContext.Controller as WizardController;
			Assert.IsNotNull( wizardController );
			Assert.AreSame( wizardController.WizardSteps, wizardStepViewModel.WizardSteps );
		}

		[TestMethod]
		[ExpectedException( typeof( InvalidOperationException ) )]
		public void WithViewModelWhichDoesNotImplementIWizardSteViewModelThrowsInvalidOperationException()
		{
			object wizardFormModel = new object();
			FakeViewModel viewModel = new FakeViewModel();

			WizardControllerActionInvoker wizardControllerActionInvoker = new WizardControllerActionInvoker();

			ControllerContext controllerContext = this.GenerateControllerContext( wizardFormModel );
			ActionDescriptor actionDescriptor = this.GenerateActionDescriptor( wizardControllerActionInvoker, controllerContext );

			ViewResult actionReturnValue = new ViewResult();
			actionReturnValue.ViewData.Model = viewModel;

			ViewResult actionResult = this.ExecuteCreateActionResult( wizardControllerActionInvoker, controllerContext, actionDescriptor, actionReturnValue ) as ViewResult;
		}

		[TestMethod]
		public void WithActionResultOtherThanViewResultBaseReturnsCorrectly()
		{
			object wizardFormModel = new object();

			WizardControllerActionInvoker wizardControllerActionInvoker = new WizardControllerActionInvoker();

			ControllerContext controllerContext = this.GenerateControllerContext( wizardFormModel );
			ActionDescriptor actionDescriptor = this.GenerateActionDescriptor( wizardControllerActionInvoker, controllerContext );

			ContentResult actionReturnValue = new ContentResult()
			{
				Content = "Content"
			};

			ContentResult actionResult = this.ExecuteCreateActionResult( wizardControllerActionInvoker, controllerContext, actionDescriptor, actionReturnValue ) as ContentResult;

			Assert.IsNotNull( actionResult );
			Assert.AreSame( actionReturnValue, actionResult );
		}



		private ActionResult ExecuteCreateActionResult( WizardControllerActionInvoker wizardControllerActionInvoker, ControllerContext controllerContext, ActionDescriptor actionDescriptor, object actionReturnValue )
		{
			BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;

			object[] parameterValues = new object[]
			{
				controllerContext,
				actionDescriptor,
				actionReturnValue
			};

			MethodInfo createActionResultMethod = typeof( WizardControllerActionInvoker ).GetMethod( "CreateActionResult", bindingFlags );

			try
			{
				return ( ActionResult )createActionResultMethod.Invoke( wizardControllerActionInvoker, parameterValues );
			}
			catch( TargetInvocationException ex )
			{
				throw ex.InnerException;
			}
		}

		private ControllerContext GenerateControllerContext( object wizardFormModel )
		{
			RequestContext requestContext = new RequestContext();
			FakeWizardController wizardController = new FakeWizardController();
			ControllerContext controllerContext = new ControllerContext( requestContext, wizardController );
			wizardController.ControllerContext = controllerContext;
			wizardController.WizardFormModel = wizardFormModel;

			return controllerContext;
		}

		private ActionDescriptor GenerateActionDescriptor( WizardControllerActionInvoker wizardControllerActionInvoker, ControllerContext controllerContext )
		{
			return wizardControllerActionInvoker.GetWizardActions( controllerContext ).First();
		}
	}
}
