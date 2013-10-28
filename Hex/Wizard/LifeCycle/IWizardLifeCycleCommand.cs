using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard.LifeCycle
{
	/// <summary>
	/// Represents a wizard life cycle command.
	/// </summary>
	public interface IWizardLifeCycleCommand
	{
		/// <summary>
		/// Executes the command.
		/// </summary>
		/// <param name="wizardLifeCycleContext">The wizard life cycle context.</param>
		void Execute( WizardLifeCycleContext wizardLifeCycleContext );
	}
}
