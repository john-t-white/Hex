using Hex.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard
{
	public class WizardStep
	{
		public WizardStep( string actionName )
			: this( actionName, null, null, null, null, null, null )
		{ }

		public WizardStep( string actionName, string name, string description, string prompt, string groupName, string shortName )
			: this( actionName, name, description, prompt, groupName, shortName, null )
		{ }

		public WizardStep( string actionName, string name, string description, string prompt, string groupName, string shortName, WizardStepValueCollection values )
		{
			if( string.IsNullOrWhiteSpace( actionName ) )
			{
				throw new ArgumentException( ExceptionMessages.VALUE_CANNOT_BE_NULL_OR_EMPTY );
			}

			this.ActionName = actionName;
			this.Name = name ?? actionName;
			this.Description = description;
			this.Prompt = prompt;
			this.GroupName = groupName;
			this.ShortName = shortName;
			this.Values = values;
		}

		public string ActionName { get; private set; }

		public string Name { get; private set; }

		public string Description { get; private set; }

		public string Prompt { get; private set; }

		public string GroupName { get; private set; }

		public string ShortName { get; private set; }

		public WizardStepValueCollection Values { get; set; }
	}
}
