using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;
using System.Web.Routing;
using System.Web.Mvc;
using Rhino.Mocks;
using System.Globalization;
using Hex.Wizard.LifeCycle;

namespace Hex.TestProject.Wizard.LifeCycle.UpdateWizardFormModelLifeCycleCommandTests
{
	[TestClass]
	public class UpdateWizardFormModelLifeCycleCommand_Execute
	{
		[TestMethod]
		public void UpdatesWizardFormModelCorrectly()
		{
			WizardController<FakeWizardFormModel> wizardController = this.GenerateWizardController();

			WizardLifeCycleContext lifeCycleContext = new WizardLifeCycleContext( wizardController );

			UpdateWizardFormModelLifeCycleCommand lifeCycleCommand = new UpdateWizardFormModelLifeCycleCommand();
			lifeCycleCommand.Execute( lifeCycleContext );

			wizardController.ValueProvider.VerifyAllExpectations();

			Assert.AreEqual( "NewStepOneStringValue", wizardController.WizardFormModel.StepOne.StepOneStringValue );

			Assert.IsNull( lifeCycleContext.ResultActionName );
		}



		private WizardController<FakeWizardFormModel> GenerateWizardController()
		{
			RequestContext requestContext = new RequestContext();
			FakeWizardController wizardController = new FakeWizardController();
			ControllerContext controllerContext = new ControllerContext( requestContext, wizardController );
			wizardController.ControllerContext = controllerContext;

			wizardController.WizardSteps = new WizardStepLinkedList( new WizardStep[] { new WizardStep( "StepOne" ) } );

			ValueProviderResult valueProviderResult = new ValueProviderResult( "NewStepOneStringValue", "NewStepOneStringValue", CultureInfo.CurrentUICulture );

			IValueProvider valueProvider = MockRepository.GenerateMock<IValueProvider>();
			valueProvider.Expect( x => x.ContainsPrefix( null ) )
				.IgnoreArguments()
				.Return( true );
			valueProvider.Expect( x => x.GetValue( "WizardFormModel.StepOne.StepOneStringValue" ) )
				.Return( valueProviderResult );

			wizardController.ValueProvider = valueProvider;

			wizardController.WizardFormModel = new FakeWizardFormModel();

			return wizardController;
		}
	}
}
