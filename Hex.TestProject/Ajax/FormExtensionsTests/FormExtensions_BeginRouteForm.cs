using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Hex.Ajax;
using System.Web.Routing;

namespace Hex.TestProject.Ajax.FormExtensionsTests
{
	[TestClass]
	public class FormExtensions_BeginRouteForm
	{
		[TestMethod]
		public void WithRouteNameAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			AjaxOptions ajaxOptions = new AjaxOptions();

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelperWithNamedRoute( routeName, routeUrl );

			var result = ajaxHelper.BeginRouteForm( routeName, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<form {0}=\"{1}\" action=\"/{2}\" method=\"post\" onclick=\"Sys.Mvc.AsyncForm.handleClick(this, new Sys.UI.DomEvent(event));\" onsubmit=\"Sys.Mvc.AsyncForm.handleSubmit(this, new Sys.UI.DomEvent(event), {{ insertionMode: Sys.Mvc.InsertionMode.replace }});\">", attributeName, attributeValue, routeUrl );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteNameRouteValuesObjectAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string routeValue = "RouteValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelperWithNamedRoute( routeName, routeUrl );

			var result = ajaxHelper.BeginRouteForm( routeName, routeValues, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<form {0}=\"{1}\" action=\"/{2}?RouteParameter={3}\" method=\"post\" onclick=\"Sys.Mvc.AsyncForm.handleClick(this, new Sys.UI.DomEvent(event));\" onsubmit=\"Sys.Mvc.AsyncForm.handleSubmit(this, new Sys.UI.DomEvent(event), {{ insertionMode: Sys.Mvc.InsertionMode.replace }});\">", attributeName, attributeValue, routeUrl, routeValue );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteNameRouteValuesDictionaryAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			RouteValueDictionary routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelperWithNamedRoute( routeName, routeUrl );

			var result = ajaxHelper.BeginRouteForm( routeName, routeValues, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<form {0}=\"{1}\" action=\"/{2}?{3}={4}\" method=\"post\" onclick=\"Sys.Mvc.AsyncForm.handleClick(this, new Sys.UI.DomEvent(event));\" onsubmit=\"Sys.Mvc.AsyncForm.handleSubmit(this, new Sys.UI.DomEvent(event), {{ insertionMode: Sys.Mvc.InsertionMode.replace }});\">", attributeName, attributeValue, routeUrl, routeParameter, routeValue );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}
	}
}
