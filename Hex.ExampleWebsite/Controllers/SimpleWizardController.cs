using Hex.Wizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hex.ExampleWebsite.Controllers
{
    public class SimpleWizardController
		: WizardController
    {
        public ActionResult FirstStep()
        {
            return this.View();
        }

		public ActionResult SecondStep()
		{
			return this.View();
		}

		public ActionResult FinishStep()
		{
			return this.View();
		}
    }
}
