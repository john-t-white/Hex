using Hex.TestWebsite.Models.SimpleWizard;
using Hex.Wizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hex.TestWebsite.Controllers
{
	[Authorize]
	public class SimpleWizardController
		: WizardController<SimpleWizardFormModel>
	{
		public ActionResult FirstStep()
		{
			return this.View();
		}

		public ActionResult SecondStep()
		{
			return this.View();
		}

		public ActionResult Finish()
		{
			return this.View();
		}

		//public override ActionResult HandleNoAuthorizedWizardActions()
		//{
		//	return this.Content( "Not Authorized" );
		//}
	}
}