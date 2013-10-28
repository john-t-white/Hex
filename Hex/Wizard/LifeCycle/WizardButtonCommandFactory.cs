using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.Wizard.LifeCycle
{
	/// <summary>
	/// Represents the wizard button command factory to handle the button commands.
	/// </summary>
	public interface IWizardButtonCommandFactory
	{
		/// <summary>
		/// Retrieves the <see cref="IWizardButtonCommand"/> to execute.
		/// </summary>
		/// <param name="wizardController">The wizard controller.</param>
		/// <returns>The wizard button command to execute; otherwise null.</returns>
		IWizardButtonCommand GetButtonCommand( WizardController wizardController );
	}

	/// <summary>
	/// Represents the wizard button command factory to handle the button commands.
	/// </summary>
	public class WizardButtonCommandFactory
		: IWizardButtonCommandFactory
	{
		/// <summary>
		/// Retrieves the <see cref="IWizardButtonCommand"/> to execute.
		/// </summary>
		/// <param name="wizardController">The wizard controller.</param>
		/// <returns>The wizard button command to execute; otherwise null.</returns>
		public IWizardButtonCommand GetButtonCommand( WizardController wizardController )
		{
			ValueProviderResult wizardNextButtonValueResult = wizardController.ValueProvider.GetValue( Constants.WIZARD_NEXT_BUTTON_NAME );
			if( wizardNextButtonValueResult != null )
			{
				return new NextWizardButtonCommand();
			}

			ValueProviderResult wizardPreviousButtonValueResult = wizardController.ValueProvider.GetValue( Constants.WIZARD_PREVIOUS_BUTTON_NAME );
			if( wizardPreviousButtonValueResult != null )
			{
				return new PreviousWizardButtonCommand();
			}

			return null;
		}
	}
}
