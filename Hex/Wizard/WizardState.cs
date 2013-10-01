using Hex.Resources;
using Newtonsoft.Json;
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

			if( !steps.Any( x => x.ActionName == currentStepActionName ) )
			{
				string exceptionMessage = string.Format( ExceptionMessages.CURRENT_STEP_ACTION_NAME_DOES_NOT_EXIST_IN_STEPS, currentStepActionName );
				throw new ArgumentException( exceptionMessage, "currentStepActionName" );
			}

			this.CurrentStepActionName = currentStepActionName;
			this.Steps = steps;
		}

		[JsonProperty( PropertyName = "c" )]
		public string CurrentStepActionName { get; private set; }

		[JsonProperty( PropertyName = "s" )]
		public WizardStepState[] Steps { get; private set; }
	}
}
