﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Wizard;

namespace Hex.TestProject.Wizard.WizardActionDescriptorTests
{
	[TestClass]
	public class WizardActionDescriptor_Name
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			ActionDescriptor actionDescriptor = this.GetWizardAction( typeof( FakeWizardControllerWithWizardStepAttribute ) );

			WizardActionDescriptor wizardActionDescriptor = new WizardActionDescriptor( actionDescriptor );

			Assert.AreEqual( "Name", wizardActionDescriptor.Name );
		}

		[TestMethod]
		public void WithoutWizardStepAttributeReturnsCorrectly()
		{
			ActionDescriptor actionDescriptor = this.GetWizardAction( typeof( FakeWizardController ) );

			WizardActionDescriptor wizardActionDescriptor = new WizardActionDescriptor( actionDescriptor );

			Assert.IsNull( wizardActionDescriptor.Name );
		}

		private ActionDescriptor GetWizardAction( Type wizardControllerType )
		{
			ReflectedControllerDescriptor controllerDescriptor = new ReflectedControllerDescriptor( wizardControllerType );
			return controllerDescriptor.GetCanonicalActions().Single();
		}
	}
}