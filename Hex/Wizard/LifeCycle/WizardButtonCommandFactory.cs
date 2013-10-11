using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.Wizard.LifeCycle
{
	public interface IWizardButtonCommandFactory
	{
		IWizardButtonCommand GetButtonCommand( WizardController wizardController );
	}

	public class WizardButtonCommandFactory
		: IWizardButtonCommandFactory
	{
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
