using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.Wizard
{
	public class WizardStepValueCollectionValueProvider
		: NameValueCollectionValueProvider
	{
		public WizardStepValueCollectionValueProvider( WizardStepValueCollection wizardStepValueCollection, CultureInfo culture )
			: base( wizardStepValueCollection, culture )
		{ }
	}
}
