using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard
{
	public interface IWizardButtonCommand
	{
		void ExecuteCommand( WizardController wizardController );
	}
}
