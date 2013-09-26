using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard
{
	public interface IWizardStepCollection
		: IEnumerable<WizardStep>
	{
		WizardStep CurrentStep { get; set; }

		WizardStep FirstStep { get; }

		WizardStep LastStep { get; }

		WizardStep NextStep { get; }

		WizardStep PreviousStep { get; }

		bool HasNextStep();

		bool HasPreviousStep();

		WizardStep MoveToNextStep();

		WizardStep MoveToPreviousStep();
	}
}
