using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard.LifeCycle;
using Hex.Wizard;
using System.Web.Mvc;
using Rhino.Mocks;
using System.Globalization;

namespace Hex.TestProject.Wizard.LifeCycle.WizardLifeCycleTests
{
	[TestClass]
	public class WizardLifeCycle_Initialize
	{
		[TestMethod]
		public void InitializesRequestWithoutWizardStateTokenCorrectly()
		{
			WizardController wizardController = this.GenerateWizardController( null );

			WizardLifeCycle wizardLifeCycle = new WizardLifeCycle( wizardController );
			wizardLifeCycle.Initialize();

			Assert.AreEqual( 4, wizardLifeCycle.Count );
			Assert.IsInstanceOfType( wizardLifeCycle[ 0 ], typeof( InitializeWizardActionsLifeCycleCommand ) );
			Assert.IsInstanceOfType( wizardLifeCycle[ 1 ], typeof( CreateWizardFormModelLifeCycleCommand ) );
			Assert.IsInstanceOfType( wizardLifeCycle[ 2 ], typeof( InitializeWizardStepsLifeCycleCommand ) );
			Assert.IsInstanceOfType( wizardLifeCycle[ 3 ], typeof( CurrentStepLifeCycleCommand ) );
		}

		[TestMethod]
		public void InitializesRequestWithEmptyWizardStateTokenCorrectly()
		{
			WizardController wizardController = this.GenerateWizardController( string.Empty );

			WizardLifeCycle wizardLifeCycle = new WizardLifeCycle( wizardController );
			wizardLifeCycle.Initialize();

			Assert.AreEqual( 4, wizardLifeCycle.Count );
			Assert.IsInstanceOfType( wizardLifeCycle[ 0 ], typeof( InitializeWizardActionsLifeCycleCommand ) );
			Assert.IsInstanceOfType( wizardLifeCycle[ 1 ], typeof( CreateWizardFormModelLifeCycleCommand ) );
			Assert.IsInstanceOfType( wizardLifeCycle[ 2 ], typeof( InitializeWizardStepsLifeCycleCommand ) );
			Assert.IsInstanceOfType( wizardLifeCycle[ 3 ], typeof( CurrentStepLifeCycleCommand ) );
		}

		[TestMethod]
		public void InitializesRequestWithWizardStateTokenCorrectly()
		{
			WizardController wizardController = this.GenerateWizardController( "WizardStateToken" );

			WizardLifeCycle wizardLifeCycle = new WizardLifeCycle( wizardController );
			wizardLifeCycle.Initialize();

			Assert.AreEqual( 8, wizardLifeCycle.Count );
			Assert.IsInstanceOfType( wizardLifeCycle[ 0 ], typeof( InitializeWizardActionsLifeCycleCommand ) );
			Assert.IsInstanceOfType( wizardLifeCycle[ 1 ], typeof( CreateWizardFormModelLifeCycleCommand ) );
			Assert.IsInstanceOfType( wizardLifeCycle[ 2 ], typeof( LoadWizardStateLifeCycleCommand ) );
			Assert.IsInstanceOfType( wizardLifeCycle[ 3 ], typeof( RestoreWizardStateLifeCycleCommand ) );
			Assert.IsInstanceOfType( wizardLifeCycle[ 4 ], typeof( RestoreWizardFormModelLifeCycleCommand ) );
			Assert.IsInstanceOfType( wizardLifeCycle[ 5 ], typeof( UpdateWizardFormModelLifeCycleCommand ) );
			Assert.IsInstanceOfType( wizardLifeCycle[ 6 ], typeof( ProcessWizardButtonLifeCycleCommand ) );
			Assert.IsInstanceOfType( wizardLifeCycle[ 7 ], typeof( CurrentStepLifeCycleCommand ) );
		}



		private WizardController GenerateWizardController( string wizardStateToken )
		{
			ValueProviderResult valueProviderResult = null;
			if( wizardStateToken != null )
			{
				valueProviderResult = new ValueProviderResult( wizardStateToken, wizardStateToken, CultureInfo.CurrentUICulture );
			}

			IValueProvider valueProvider = MockRepository.GenerateMock<IValueProvider>();
			valueProvider.Stub( x => x.GetValue( Constants.WIZARD_STATE_TOKEN_HIDDEN_FIELD_NAME ) )
				.Return( valueProviderResult );

			FakeWizardControllerWithNoActions wizardController = new FakeWizardControllerWithNoActions();
			wizardController.ValueProvider = valueProvider;

			return wizardController;
		}
	}
}
