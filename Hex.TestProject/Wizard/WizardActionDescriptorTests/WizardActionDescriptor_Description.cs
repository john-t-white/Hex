
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Wizard;

namespace Hex.TestProject.Wizard.WizardActionDescriptorTests
{
	[TestClass]
	public class WizardActionDescriptor_Description
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			ActionDescriptor actionDescriptor = this.GetWizardAction( typeof( FakeWizardControllerWithDisplayAttribute ) );

			WizardActionDescriptor wizardActionDescriptor = new WizardActionDescriptor( actionDescriptor );

			Assert.AreEqual( "Description", wizardActionDescriptor.Description );
		}

		[TestMethod]
		public void WithoutDisplayAttributeReturnsCorrectly()
		{
			ActionDescriptor actionDescriptor = this.GetWizardAction( typeof( FakeWizardController ) );

			WizardActionDescriptor wizardActionDescriptor = new WizardActionDescriptor( actionDescriptor );

			Assert.IsNull( wizardActionDescriptor.Description );
		}

		private ActionDescriptor GetWizardAction( Type wizardControllerType )
		{
			ReflectedControllerDescriptor controllerDescriptor = new ReflectedControllerDescriptor( wizardControllerType );
			return controllerDescriptor.GetCanonicalActions().Single( x => x.ActionName == "StepOne" );
		}
	}
}