using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard
{
	public interface IWizardStepViewModel<TWizardFormModel>
		: IWizardStepViewModel
	{
		TWizardFormModel WizardFormModel { get; }
	}

	public interface IWizardStepViewModel
	{
		void SetWizardFormModel( object wizardFormModel );
	}
}
