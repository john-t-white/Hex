using Hex.Ajax;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Routing;

namespace Hex.TestProject.Ajax.FormExtensionsTests
{
	[TestClass]
	public class FormExtensions_BeginForm
	{
		private const string ONCLICK_SCRIPT = "onclick=\"Sys.Mvc.AsyncForm.handleClick(this, new Sys.UI.DomEvent(event));\"";
		private const string ONSUBMIT_SCRIPT = "onsubmit=\"Sys.Mvc.AsyncForm.handleSubmit(this, new Sys.UI.DomEvent(event), { insertionMode: Sys.Mvc.InsertionMode.replace });\"";

		[TestMethod]
		public void WithActionNameAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string actionName = "ActionName";
			AjaxOptions ajaxOptions = new AjaxOptions();

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.BeginForm( actionName, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<form {0}=\"{1}\" action=\"/{2}/{3}\" method=\"post\" {4} {5}>", attributeName, attributeValue, AjaxHelperGenerator.DefaultController, actionName, ONCLICK_SCRIPT, ONSUBMIT_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameRouteValuesObjectAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string actionName = "ActionName";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string routeValue = "RouteValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.BeginForm( actionName, routeValues, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<form {0}=\"{1}\" action=\"/{2}/{3}?RouteParameter={4}\" method=\"post\" {5} {6}>", attributeName, attributeValue, AjaxHelperGenerator.DefaultController, actionName, routeValue, ONCLICK_SCRIPT, ONSUBMIT_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameRouteValuesDictionaryAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string actionName = "ActionName";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			RouteValueDictionary routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.BeginForm( actionName, routeValues, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<form {0}=\"{1}\" action=\"/{2}/{3}?{4}={5}\" method=\"post\" {6} {7}>", attributeName, attributeValue, AjaxHelperGenerator.DefaultController, actionName, routeParameter, routeValue, ONCLICK_SCRIPT, ONSUBMIT_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameControllerNameAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string actionName = "ActionName";
			string controllerName = "ControllerName";
			AjaxOptions ajaxOptions = new AjaxOptions();

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.BeginForm( actionName, controllerName, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<form {0}=\"{1}\" action=\"/{2}/{3}\" method=\"post\" {4} {5}>", attributeName, attributeValue, controllerName, actionName, ONCLICK_SCRIPT, ONSUBMIT_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameControllerNameRouteValuesObjectAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string actionName = "ActionName";
			string controllerName = "ControllerName";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string routeValue = "RouteValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.BeginForm( actionName, controllerName, routeValues, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<form {0}=\"{1}\" action=\"/{2}/{3}?RouteParameter={4}\" method=\"post\" {5} {6}>", attributeName, attributeValue, controllerName, actionName, routeValue, ONCLICK_SCRIPT, ONSUBMIT_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameControllerNameRouteValuesDictionaryAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string actionName = "ActionName";
			string controllerName = "ControllerName";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			RouteValueDictionary routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.BeginForm( actionName, controllerName, routeValues, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<form {0}=\"{1}\" action=\"/{2}/{3}?{4}={5}\" method=\"post\" {6} {7}>", attributeName, attributeValue, controllerName, actionName, routeParameter, routeValue, ONCLICK_SCRIPT, ONSUBMIT_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}
	}
}
