using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard.LifeCycle
{
	public interface IWizardLifeCycleCommand
	{
		void Execute( WizardLifeCycleContext wizardLifeCycleContext );
	}
}
