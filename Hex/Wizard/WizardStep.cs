﻿using Hex.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard
{
	public class WizardStep
	{
		public WizardStep( string actionName )
			: this( actionName, null, null )
		{ }

		public WizardStep( string actionName, string name, string description )
		{
			if( string.IsNullOrWhiteSpace( actionName ) )
			{
				throw new ArgumentException( ExceptionMessages.VALUE_CANNOT_BE_NULL_OR_EMPTY );
			}

			this.ActionName = actionName;
			this.Name = name;
			this.Description = description;
		}

		public string ActionName { get; private set; }

		public string Name { get; private set; }

		public string Description { get; private set; }
	}
}