using Hex.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard
{
	[Serializable]
	public class WizardStepState
	{
		public WizardStepState( string actionName, WizardStepValueCollection values )
		{
			if( string.IsNullOrWhiteSpace( actionName ) )
			{
				throw new ArgumentException( ExceptionMessages.VALUE_CANNOT_BE_NULL_OR_EMPTY, "actionName" );
			}

			this.ActionName = actionName;
			this.Values = values;
		}

		[JsonProperty( PropertyName = "a" )]
		public string ActionName { get; private set; }

		[JsonProperty( PropertyName = "v" )]
		public WizardStepValueCollection Values { get; private set; }
	}
}
