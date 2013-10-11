using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Routing;
using Hex.Wizard;
using System.Reflection;
using System.Web;
using Rhino.Mocks;

namespace Hex.TestProject.Wizard.WizardControllerTests
{
	[TestClass]
	public class WizardController_Initialize
	{
		[TestMethod]
		public void WithActionSpecifiedInRouteThrowsInvalidOperationException()
		{
			HttpContextBase httpContext = MockRepository.GenerateMock<HttpContextBase>();
			RouteData routeData = new RouteData();
			routeData.Values.Add( "action", "ActionName" );

			RequestContext requestContext = new RequestContext( httpContext, routeData );

			FakeWizardControllerWithNoActions wizardController = new FakeWizardControllerWithNoActions();

			try
			{
				this.InvokeInitialize( wizardController, requestContext );
				Assert.Fail( "InvalidOperationException was expected." );
			}
			catch( InvalidOperationException ex )
			{
				string expectedMessage = "Wizard controllers must not have an action defined in the route.";
				Assert.AreEqual( expectedMessage, ex.Message );
			}
		}



		private void InvokeInitialize( WizardController wizardController, RequestContext requestContext )
		{
			BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;

			object[] parameters = new object[]
			{
				requestContext
			};

			MethodInfo intiailizeMethod = wizardController.GetType().GetMethod( "Initialize", bindingFlags );

			try
			{
				intiailizeMethod.Invoke( wizardController, parameters );
			}
			catch( TargetInvocationException ex )
			{
				throw ex.InnerException;
			}
		}
	}
}
