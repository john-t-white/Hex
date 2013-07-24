using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Routing;
using Hex.Ajax;

namespace Hex.TestProject.Ajax.LinkExtensionsTests
{
	[TestClass]
	public class LinkExtensions_ActionLink
	{
		[TestMethod]
		public void WithLinkTextActionNameAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string linkText = "LinkText";
			string actionName = "ActionName";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.ActionLink( linkText, actionName, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}\" onclick=\"Sys.Mvc.AsyncHyperlink.handleClick(this, new Sys.UI.DomEvent(event), {{ insertionMode: Sys.Mvc.InsertionMode.replace }});\">{4}</a>", attributeName, attributeValue, AjaxHelperGenerator.DefaultController, actionName, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLinkTextActionNameRouteValuesObjectAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string linkText = "LinkText";
			string actionName = "ActionName";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeValue = "RouteValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.ActionLink( linkText, actionName, routeValues, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}?RouteParameter={4}\" onclick=\"Sys.Mvc.AsyncHyperlink.handleClick(this, new Sys.UI.DomEvent(event), {{ insertionMode: Sys.Mvc.InsertionMode.replace }});\">{5}</a>", attributeName, attributeValue, AjaxHelperGenerator.DefaultController, actionName, routeValue, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLinkTextActionNameRouteValuesDictionaryAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string linkText = "LinkText";
			string actionName = "ActionName";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			var routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.ActionLink( linkText, actionName, routeValues, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}?{4}={5}\" onclick=\"Sys.Mvc.AsyncHyperlink.handleClick(this, new Sys.UI.DomEvent(event), {{ insertionMode: Sys.Mvc.InsertionMode.replace }});\">{6}</a>", attributeName, attributeValue, AjaxHelperGenerator.DefaultController, actionName, routeParameter, routeValue, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLinkTextActionNameControllerNameAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string linkText = "LinkText";
			string actionName = "ActionName";
			string controllerName = "ControllerName";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.ActionLink( linkText, actionName, controllerName, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}\" onclick=\"Sys.Mvc.AsyncHyperlink.handleClick(this, new Sys.UI.DomEvent(event), {{ insertionMode: Sys.Mvc.InsertionMode.replace }});\">{4}</a>", attributeName, attributeValue, controllerName, actionName, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLinkTextActionNameControllerNameRouteValuesObjectAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string linkText = "LinkText";
			string actionName = "ActionName";
			string controllerName = "ControllerName";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeValue = "RouteValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.ActionLink( linkText, actionName, controllerName, routeValues, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}?RouteParameter={4}\" onclick=\"Sys.Mvc.AsyncHyperlink.handleClick(this, new Sys.UI.DomEvent(event), {{ insertionMode: Sys.Mvc.InsertionMode.replace }});\">{5}</a>", attributeName, attributeValue, controllerName, actionName, routeValue, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLinkTextActionNameControllerNameRouteValuesDictionaryAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string linkText = "LinkText";
			string actionName = "ActionName";
			string controllerName = "ControllerName";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			var routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.ActionLink( linkText, actionName, controllerName, routeValues, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}?{4}={5}\" onclick=\"Sys.Mvc.AsyncHyperlink.handleClick(this, new Sys.UI.DomEvent(event), {{ insertionMode: Sys.Mvc.InsertionMode.replace }});\">{6}</a>", attributeName, attributeValue, controllerName, actionName, routeParameter, routeValue, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLinkTextActionNameControllerNameProtocolHostNameFragmentRouteValuesObjectAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string linkText = "LinkText";
			string actionName = "ActionName";
			string controllerName = "ControllerName";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string protocol = "http";
			string hostName = "HostName";
			string fragment = "Fragment";
			string routeValue = "RouteValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.ActionLink( linkText, actionName, controllerName, protocol, hostName, fragment, routeValues, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"{2}://{3}/{4}/{5}?RouteParameter={6}#{7}\" onclick=\"Sys.Mvc.AsyncHyperlink.handleClick(this, new Sys.UI.DomEvent(event), {{ insertionMode: Sys.Mvc.InsertionMode.replace }});\">{8}</a>", attributeName, attributeValue, protocol, hostName, controllerName, actionName, routeValue, fragment, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLinkTextActionNameControllerNameProtocolHostNameFragmentRouteValuesDictionaryAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string linkText = "LinkText";
			string actionName = "ActionName";
			string controllerName = "ControllerName";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string protocol = "http";
			string hostName = "HostName";
			string fragment = "Fragment";
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			var routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.ActionLink( linkText, actionName, controllerName, protocol, hostName, fragment, routeValues, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"{2}://{3}/{4}/{5}?{6}={7}#{8}\" onclick=\"Sys.Mvc.AsyncHyperlink.handleClick(this, new Sys.UI.DomEvent(event), {{ insertionMode: Sys.Mvc.InsertionMode.replace }});\">{9}</a>", attributeName, attributeValue, protocol, hostName, controllerName, actionName, routeParameter, routeValue, fragment, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
