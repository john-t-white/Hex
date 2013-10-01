using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard
{
	public class WizardStepViewModel<TWizardFormModel>
		: IWizardStepViewModel<TWizardFormModel>
	{
		public TWizardFormModel WizardFormModel { get; private set; }

		public void SetWizardFormModel( object wizardFormModel )
		{
			if( wizardFormModel == null )
			{
				throw new ArgumentNullException( "wizardFormModel" );
			}

			if( !( wizardFormModel is TWizardFormModel ) )
			{
				string exceptionMessage = string.Format( "WizardFormModel must be of type '{0}'.", typeof( TWizardFormModel ).FullName );
				throw new ArgumentException( exceptionMessage, "wizardFormModel" );
			}

			this.WizardFormModel = ( TWizardFormModel )wizardFormModel;
		}

		public WizardStepLinkedList WizardSteps { get; set; }
	}
}
