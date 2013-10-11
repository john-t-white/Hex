﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard.LifeCycle;
using Rhino.Mocks;
using System.Web.Mvc;
using System.Globalization;
using Hex.Wizard;

namespace Hex.TestProject.Wizard.LifeCycle.WizardButtonCommandFactoryTests
{
	[TestClass]
	public class WizardButtonCommandFactory_GetButtonCommand
	{
		[TestMethod]
		public void ReturnsNextWizardButtonCommandCorrectly()
		{
			IValueProvider valueProvider = MockRepository.GenerateMock<IValueProvider>();

			FakeWizardControllerWithNoActions wizardController = new FakeWizardControllerWithNoActions();
			wizardController.ValueProvider = valueProvider;

			valueProvider.Expect( x => x.GetValue( Constants.WIZARD_NEXT_BUTTON_NAME ) )
				.Return( new ValueProviderResult( "Next", "Next", CultureInfo.CurrentUICulture ) );

			WizardButtonCommandFactory buttonCommandFactory = new WizardButtonCommandFactory();
			IWizardButtonCommand buttonCommand = buttonCommandFactory.GetButtonCommand( wizardController );

			valueProvider.VerifyAllExpectations();

			Assert.IsNotNull( buttonCommand );
			Assert.IsInstanceOfType( buttonCommand, typeof( NextWizardButtonCommand ) );
		}

		[TestMethod]
		public void ReturnsPreviousWizardButtonCommandCorrectly()
		{
			IValueProvider valueProvider = MockRepository.GenerateMock<IValueProvider>();

			FakeWizardControllerWithNoActions wizardController = new FakeWizardControllerWithNoActions();
			wizardController.ValueProvider = valueProvider;

			valueProvider.Expect( x => x.GetValue( Constants.WIZARD_PREVIOUS_BUTTON_NAME ) )
				.Return( new ValueProviderResult( "Previous", "Previous", CultureInfo.CurrentUICulture ) );

			WizardButtonCommandFactory buttonCommandFactory = new WizardButtonCommandFactory();
			IWizardButtonCommand buttonCommand = buttonCommandFactory.GetButtonCommand( wizardController );

			valueProvider.VerifyAllExpectations();

			Assert.IsNotNull( buttonCommand );
			Assert.IsInstanceOfType( buttonCommand, typeof( PreviousWizardButtonCommand ) );
		}
	}
}
