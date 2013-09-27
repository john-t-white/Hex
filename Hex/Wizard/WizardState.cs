using Hex.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard
{
	[Serializable]
	public class WizardState
	{
		public WizardState( string currentStepActionName, WizardStepState[] steps )
		{
			if( string.IsNullOrWhiteSpace( currentStepActionName ) )
			{
				throw new ArgumentException( ExceptionMessages.VALUE_CANNOT_BE_NULL_OR_EMPTY, "currentStepActionName" );
			}

			if( steps == null )
			{
				throw new ArgumentNullException( "steps" );
			}

			this.CurrentStepActionName = currentStepActionName;
			this.Steps = steps;
		}

		public string CurrentStepActionName { get; private set; }

		public WizardStepState[] Steps { get; private set; }
	}
}
