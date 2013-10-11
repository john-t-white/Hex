using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;
using System.Web.Routing;
using System.Web.Mvc;

namespace Hex.TestProject.Wizard.FormWizardStateProviderTests
{
	[TestClass]
	public class FormWizardStateProvider_SaveAndLoad
	{
		[TestMethod]
		public void SavesAndLoadsCorrectly()
		{
			RequestContext requestContext = new RequestContext();
			FakeWizardControllerWithNoActions wizardController = new FakeWizardControllerWithNoActions();
			ControllerContext controllerContext = new ControllerContext( requestContext, wizardController );

			WizardStepValueCollection stepOneValues = new WizardStepValueCollection();
			stepOneValues.Add( "StepOneName1", "StepOneName1Value1" );
			stepOneValues.Add( "StepOneName1", "StepOneName1Value2" );

			WizardStepState stepOneWizardStepState = new WizardStepState( "StepOneActionName", stepOneValues );

			WizardStepValueCollection stepTwoValues = new WizardStepValueCollection();
			stepTwoValues.Add( "StepTwoName1", "StepTwoName1Value1" );
			stepTwoValues.Add( "StepTwoName1", "StepTwoName1Value2" );

			WizardStepState stepTwoWizardStepState = new WizardStepState( "StepTwoActionName", stepTwoValues );

			WizardState wizardState = new WizardState( stepOneWizardStepState.ActionName, new WizardStepState[] { stepOneWizardStepState, stepTwoWizardStepState } );

			FormWizardStateProvider wizardStateProvider = new FormWizardStateProvider();
			string wizardStateToken = wizardStateProvider.Save( controllerContext, wizardState );

			WizardState loadedWizardState = wizardStateProvider.Load( controllerContext, wizardStateToken );

			Assert.AreEqual( wizardState.CurrentStepActionName, loadedWizardState.CurrentStepActionName );
			Assert.AreEqual( wizardState.Steps.Length, loadedWizardState.Steps.Length );

			for( int currentWizardStepIndex = 0; currentWizardStepIndex < wizardState.Steps.Length; currentWizardStepIndex++ )
			{
				WizardStepState originalWizardStepState = wizardState.Steps[ currentWizardStepIndex ];
				WizardStepState loadedWizardStepState = loadedWizardState.Steps[ currentWizardStepIndex ];

				Assert.AreEqual( originalWizardStepState.ActionName, loadedWizardStepState.ActionName );
				Assert.AreEqual( originalWizardStepState.Values.Count, loadedWizardStepState.Values.Count );

				foreach( string currentOriginalValueName in originalWizardStepState.Values )
				{
					Assert.IsTrue( loadedWizardStepState.Values.AllKeys.Contains( currentOriginalValueName ) );

					string[] currentOriginalValues = originalWizardStepState.Values.GetValues( currentOriginalValueName );
					string[] currentLoadedValues = loadedWizardStepState.Values.GetValues( currentOriginalValueName );

					Assert.AreEqual( currentOriginalValues.Length, currentLoadedValues.Length );
					
					foreach( string currentOriginalValue in currentOriginalValues )
					{
						Assert.IsTrue( currentLoadedValues.Contains( currentOriginalValue ) );
					}
				}
			}
		}
	}
}
