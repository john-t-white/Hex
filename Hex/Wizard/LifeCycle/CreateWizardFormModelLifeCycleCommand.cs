using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard.LifeCycle
{
	/// <summary>
	/// The wizard life cycle command that creates the wizard form model.
	/// </summary>
	public class CreateWizardFormModelLifeCycleCommand
		: IWizardLifeCycleCommand
	{
		/// <summary>
		/// Executes the command.
		/// </summary>
		/// <param name="wizardLifeCycleContext">The wizard life cycle context.</param>
		public void Execute( WizardLifeCycleContext wizardLifeCycleContext )
		{
			WizardController wizardController = wizardLifeCycleContext.WizardController;

			wizardController.WizardFormModel = Activator.CreateInstance( wizardController.WizardFormModelType, true );
		}
	}
}
