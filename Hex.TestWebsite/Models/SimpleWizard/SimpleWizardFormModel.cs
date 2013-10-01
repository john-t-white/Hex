using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hex.TestWebsite.Models.SimpleWizard
{
	public class SimpleWizardFormModel
	{
		public FirstStepFormModel FirstStep { get; set; }

		public SecondStepFormModel SecondStep { get; set; }
	}
}