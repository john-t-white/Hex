
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Wizard;

namespace Hex.TestProject.Wizard.WizardActionDescriptorTests
{
	[TestClass]
	public class WizardActionDescriptor_Order
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			ActionDescriptor actionDescriptor = this.GetWizardAction( typeof( FakeWizardControllerWithOneStepWithDisplayAttribute ) );

			WizardActionDescriptor wizardActionDescriptor = new WizardActionDescriptor( actionDescriptor );

			Assert.AreEqual( 1, wizardActionDescriptor.Order );
		}

		[TestMethod]
		public void WithoutDisplayAttributeReturnsCorrectly()
		{
			ActionDescriptor actionDescriptor = this.GetWizardAction( typeof( FakeWizardControllerWithOneStep ) );

			WizardActionDescriptor wizardActionDescriptor = new WizardActionDescriptor( actionDescriptor );

			Assert.AreEqual( 0, wizardActionDescriptor.Order );
		}

		private ActionDescriptor GetWizardAction( Type wizardControllerType )
		{
			ReflectedControllerDescriptor controllerDescriptor = new ReflectedControllerDescriptor( wizardControllerType );
			return controllerDescriptor.GetCanonicalActions().Single( x => x.ActionName == "StepOne" );
		}
	}
}