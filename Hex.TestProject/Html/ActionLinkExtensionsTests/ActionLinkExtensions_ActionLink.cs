using Hex.Html;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hex.TestProject.Html.ActionLinkExtensionsTests
{
	[TestClass]
	public class ActionLinkExtensions_ActionLink
	{
		[TestMethod]
		public void WithLinkTextActionNameAndAttributeExpressionReturnsCorrectly()
		{
			string linkText = "LinkText";
			string actionName = "ActionName";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.ActionLink( linkText, actionName, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}\">{4}</a>", attributeName, attributeValue, HtmlHelperGenerator.DefaultController, actionName, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLinkTextActionNameRouteValuesAndAttributeExpressionReturnsCorrectly()
		{
			string linkText = "LinkText";
			string actionName = "ActionName";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeValue = "RouteValue";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			var result = htmlHelper.ActionLink( linkText, actionName, routeValues, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}?RouteParameter={4}\">{5}</a>", attributeName, attributeValue, HtmlHelperGenerator.DefaultController, actionName, routeValue, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLinkTextActionNameRouteValueDictionaryAndAttributeExpressionReturnsCorrectly()
		{
			string linkText = "LinkText";
			string actionName = "ActionName";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			RouteValueDictionary routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.ActionLink( linkText, actionName, routeValues, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}?{4}={5}\">{6}</a>", attributeName, attributeValue, HtmlHelperGenerator.DefaultController, actionName, routeParameter, routeValue, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLinkTextActionNameControllerNameAndAttributeExpressionReturnsCorrectly()
		{
			string linkText = "LinkText";
			string actionName = "ActionName";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string controllerName = "ControllerName";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.ActionLink( linkText, actionName, controllerName, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}\">{4}</a>", attributeName, attributeValue, controllerName, actionName, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLinkTextActionNameControllerNameRouteValuesAndAttributeExpressionReturnsCorrectly()
		{
			string linkText = "LinkText";
			string actionName = "ActionName";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string controllerName = "ControllerName";
			string routeValue = "RouteValue";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			var result = htmlHelper.ActionLink( linkText, actionName, controllerName, routeValues, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}?RouteParameter={4}\">{5}</a>", attributeName, attributeValue, controllerName, actionName, routeValue, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLinkTextActionNameControllerNameRouteValueDictionaryAndAttributeExpressionReturnsCorrectly()
		{
			string linkText = "LinkText";
			string actionName = "ActionName";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string controllerName = "ControllerName";
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			RouteValueDictionary routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.ActionLink( linkText, actionName, controllerName, routeValues, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}?{4}={5}\">{6}</a>", attributeName, attributeValue, controllerName, actionName, routeParameter, routeValue, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLinkTextActionNameControllerNameProtocolHostNameFragmentAndAttributeExpressionReturnsCorrectly()
		{
			string linkText = "LinkText";
			string actionName = "ActionName";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string controllerName = "ControllerName";
			string protocol = "https";
			string hostName = "HostName";
			string fragment = "Fragment";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.ActionLink( linkText, actionName, controllerName, protocol, hostName, fragment, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"{2}://{3}/{4}/{5}#{6}\">{7}</a>", attributeName, attributeValue, protocol, hostName, controllerName, actionName, fragment, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLinkTextActionNameControllerNameProtocolHostNameFragmentRouteValuesAndAttributeExpressionReturnsCorrectly()
		{
			string linkText = "LinkText";
			string actionName = "ActionName";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string controllerName = "ControllerName";
			string protocol = "https";
			string hostName = "HostName";
			string fragment = "Fragment";
			string routeValue = "RouteValue";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			var result = htmlHelper.ActionLink( linkText, actionName, controllerName, protocol, hostName, fragment, routeValues, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"{2}://{3}/{4}/{5}?RouteParameter={6}#{7}\">{8}</a>", attributeName, attributeValue, protocol, hostName, controllerName, actionName, routeValue, fragment, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLinkTextActionNameControllerNameProtocolHostNameFragmentRouteValueDictionaryAndAttributeExpressionReturnsCorrectly()
		{
			string linkText = "LinkText";
			string actionName = "ActionName";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string controllerName = "ControllerName";
			string protocol = "https";
			string hostName = "HostName";
			string fragment = "Fragment";
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			RouteValueDictionary routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.ActionLink( linkText, actionName, controllerName, protocol, hostName, fragment, routeValues, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"{2}://{3}/{4}/{5}?{6}={7}#{8}\">{9}</a>", attributeName, attributeValue, protocol, hostName, controllerName, actionName, routeParameter, routeValue, fragment, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
