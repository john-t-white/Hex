using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard.LifeCycle
{
	/// <summary>
	/// The wizard life cycle command that handles the wizard buttons.
	/// </summary>
	public class ProcessWizardButtonLifeCycleCommand
		: IWizardLifeCycleCommand
	{
		/// <summary>
		/// Instantiates an instance of <see cref="ProcessWizardButtonLifeCycleCommand"/>.
		/// </summary>
		public ProcessWizardButtonLifeCycleCommand()
		{
			this.WizardButtonCommandFactory = new WizardButtonCommandFactory();
		}

		/// <summary>
		/// Executes the command.
		/// </summary>
		/// <param name="wizardLifeCycleContext">The wizard life cycle context.</param>
		public void Execute( WizardLifeCycleContext wizardLifeCycleContext )
		{
			WizardController wizardController = wizardLifeCycleContext.WizardController;

			IWizardButtonCommand buttonCommand = this.WizardButtonCommandFactory.GetButtonCommand( wizardController );
			if( buttonCommand != null )
			{
				buttonCommand.Execute( wizardController );
			}
		}

		public IWizardButtonCommandFactory WizardButtonCommandFactory { get; set; }
	}
}
