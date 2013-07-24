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
		[TestMethod]
		public void WithActionNameAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string actionName = "ActionName";
			AjaxOptions ajaxOptions = new AjaxOptions();

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.BeginForm( actionName, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<form {0}=\"{1}\" action=\"/{2}/{3}\" method=\"post\" onclick=\"Sys.Mvc.AsyncForm.handleClick(this, new Sys.UI.DomEvent(event));\" onsubmit=\"Sys.Mvc.AsyncForm.handleSubmit(this, new Sys.UI.DomEvent(event), {{ insertionMode: Sys.Mvc.InsertionMode.replace }});\">", attributeName, attributeValue, AjaxHelperGenerator.DefaultController, actionName );
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

			string expectedResult = string.Format( "<form {0}=\"{1}\" action=\"/{2}/{3}?RouteParameter={4}\" method=\"post\" onclick=\"Sys.Mvc.AsyncForm.handleClick(this, new Sys.UI.DomEvent(event));\" onsubmit=\"Sys.Mvc.AsyncForm.handleSubmit(this, new Sys.UI.DomEvent(event), {{ insertionMode: Sys.Mvc.InsertionMode.replace }});\">", attributeName, attributeValue, AjaxHelperGenerator.DefaultController, actionName, routeValue );
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

			string expectedResult = string.Format( "<form {0}=\"{1}\" action=\"/{2}/{3}?{4}={5}\" method=\"post\" onclick=\"Sys.Mvc.AsyncForm.handleClick(this, new Sys.UI.DomEvent(event));\" onsubmit=\"Sys.Mvc.AsyncForm.handleSubmit(this, new Sys.UI.DomEvent(event), {{ insertionMode: Sys.Mvc.InsertionMode.replace }});\">", attributeName, attributeValue, AjaxHelperGenerator.DefaultController, actionName, routeParameter, routeValue );
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

			string expectedResult = string.Format( "<form {0}=\"{1}\" action=\"/{2}/{3}\" method=\"post\" onclick=\"Sys.Mvc.AsyncForm.handleClick(this, new Sys.UI.DomEvent(event));\" onsubmit=\"Sys.Mvc.AsyncForm.handleSubmit(this, new Sys.UI.DomEvent(event), {{ insertionMode: Sys.Mvc.InsertionMode.replace }});\">", attributeName, attributeValue, controllerName, actionName );
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

			string expectedResult = string.Format( "<form {0}=\"{1}\" action=\"/{2}/{3}?RouteParameter={4}\" method=\"post\" onclick=\"Sys.Mvc.AsyncForm.handleClick(this, new Sys.UI.DomEvent(event));\" onsubmit=\"Sys.Mvc.AsyncForm.handleSubmit(this, new Sys.UI.DomEvent(event), {{ insertionMode: Sys.Mvc.InsertionMode.replace }});\">", attributeName, attributeValue, controllerName, actionName, routeValue );
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

			string expectedResult = string.Format( "<form {0}=\"{1}\" action=\"/{2}/{3}?{4}={5}\" method=\"post\" onclick=\"Sys.Mvc.AsyncForm.handleClick(this, new Sys.UI.DomEvent(event));\" onsubmit=\"Sys.Mvc.AsyncForm.handleSubmit(this, new Sys.UI.DomEvent(event), {{ insertionMode: Sys.Mvc.InsertionMode.replace }});\">", attributeName, attributeValue, controllerName, actionName, routeParameter, routeValue );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}
	}
}
