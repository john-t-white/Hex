﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard.LifeCycle
{
	public interface IWizardButtonCommand
	{
		void ExecuteCommand( WizardController wizardController );
	}
}