using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard
{
	public interface IWizardStepViewModel<TWizardFormModel>
		: IWizardStepViewModel
	{
		TWizardFormModel WizardFormModel { get; set; }
	}

	public interface IWizardStepViewModel
	{
		void SetWizardFormModel( object wizardFormModel );

		WizardStepLinkedList WizardSteps { get; set; }
	}
}
