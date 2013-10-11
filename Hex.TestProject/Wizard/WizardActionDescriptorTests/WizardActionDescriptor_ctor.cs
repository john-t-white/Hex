using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Wizard;
using System.Web.Routing;

namespace Hex.TestProject.Wizard.WizardActionDescriptorTests
{
	[TestClass]
	public class WizardActionDescriptor_ctor
	{
		[TestMethod]
		public void CreatesCorrectly()
		{
			ReflectedControllerDescriptor controllerDescriptor = new ReflectedControllerDescriptor( typeof( FakeWizardControllerWithOneStep ) );
			ActionDescriptor actionDescriptor = controllerDescriptor.GetCanonicalActions().Single( x => x.ActionName == "StepOne" );

			WizardActionDescriptor wizardActionDescriptor = new WizardActionDescriptor( actionDescriptor );

			Assert.AreSame( actionDescriptor, wizardActionDescriptor.ActionDescriptor );
			Assert.AreEqual( actionDescriptor.ActionName, wizardActionDescriptor.ActionName );
		}

		[TestMethod]
		[ExpectedException( typeof( ArgumentNullException ) )]
		public void NullActionDescriptorThrowsArgumentNullException()
		{
			ActionDescriptor actionDescriptor = null;

			new WizardActionDescriptor( actionDescriptor );
		}
	}
}
