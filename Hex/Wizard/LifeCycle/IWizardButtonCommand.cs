using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard.LifeCycle
{
	/// <summary>
	/// Represents a wizard button command.
	/// </summary>
	public interface IWizardButtonCommand
	{
		/// <summary>
		/// Executes the command.
		/// </summary>
		/// <param name="wizardController">The wizard controller.</param>
		void Execute( WizardController wizardController );
	}
}
