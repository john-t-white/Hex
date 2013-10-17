using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard
{
	public interface IWizardStepViewModel<TWizardFormModel>
		: IWizardStepViewModel
	{
		new TWizardFormModel WizardFormModel { get; set; }
	}

	public interface IWizardStepViewModel
	{
		object WizardFormModel { get; set; }

		WizardStepLinkedList WizardSteps { get; set; }
	}
}
