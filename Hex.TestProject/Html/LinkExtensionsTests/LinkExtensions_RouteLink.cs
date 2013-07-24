using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;
using System.Web.Routing;

namespace Hex.TestProject.Html.LinkExtensionsTests
{
	[TestClass]
	public class LinkExtensions_RouteLink
	{
		[TestMethod]
		public void WithLinkTextRouteValuesAndAttributeExpressionReturnsCorrectly()
		{
			string linkText = "LinkText";
			string controllerName = "ControllerName";
			string actionName = "ActionName";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			object routeValues = new
			{
				controller = controllerName,
				action = actionName
			};

			var result = htmlHelper.RouteLink( linkText, routeValues, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}\">{4}</a>", attributeName, attributeValue, controllerName, actionName, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLinkTextRouteValueDictionaryAndAttributeExpressionReturnsCorrectly()
		{
			string linkText = "LinkText";
			string controllerName = "ControllerName";
			string actionName = "ActionName";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			RouteValueDictionary routeValues = new RouteValueDictionary();
			routeValues.Add( "controller", controllerName );
			routeValues.Add( "action", actionName );

			var result = htmlHelper.RouteLink( linkText, routeValues, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}\">{4}</a>", attributeName, attributeValue, controllerName, actionName, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLinkTextRouteNameAndAttributeExpressionReturnsCorrectly()
		{
			string linkText = "LinkText";
			string routeName = "RouteName";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			string routeUrl = "RouteUrl";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelperWithNamedRoute( routeName, routeUrl );

			var result = htmlHelper.RouteLink( linkText, routeName, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}\">{3}</a>", attributeName, attributeValue, routeUrl, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLinkTextRouteNameRouteValuesAndAttributeExpressionReturnsCorrectly()
		{
			string linkText = "LinkText";
			string routeName = "RouteName";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeValue = "RouteValue";

			string routeUrl = "RouteUrl";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelperWithNamedRoute( routeName, routeUrl );

			var result = htmlHelper.RouteLink( linkText, routeName, routeValues, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}?RouteParameter={3}\">{4}</a>", attributeName, attributeValue, routeUrl, routeValue, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLinkTextRouteNameRouteValueDictionaryAndAttributeExpressionReturnsCorrectly()
		{
			string linkText = "LinkText";
			string routeName = "RouteName";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			string routeUrl = "RouteUrl";

			var routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelperWithNamedRoute( routeName, routeUrl );

			var result = htmlHelper.RouteLink( linkText, routeName, routeValues, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}?{3}={4}\">{5}</a>", attributeName, attributeValue, routeUrl, routeParameter, routeValue, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLinkTextRouteNameProtocolHostNameFragmentAndAttributeExpressionReturnsCorrectly()
		{
			string linkText = "LinkText";
			string routeName = "RouteName";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string protocol = "https";
			string hostName = "HostName";
			string fragment = "Fragment";

			string routeUrl = "RouteUrl";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelperWithNamedRoute( routeName, routeUrl );

			var result = htmlHelper.RouteLink( linkText, routeName, protocol, hostName, fragment, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"{2}://{3}/{4}#{5}\">{6}</a>", attributeName, attributeValue, protocol, hostName, routeUrl, fragment, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLinkTextRouteNameProtocolHostNameFragmentRouteValuesAndAttributeExpressionReturnsCorrectly()
		{
			string linkText = "LinkText";
			string routeName = "RouteName";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string protocol = "https";
			string hostName = "HostName";
			string fragment = "Fragment";
			string routeValue = "RouteValue";

			string routeUrl = "RouteUrl";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelperWithNamedRoute( routeName, routeUrl );

			var result = htmlHelper.RouteLink( linkText, routeName, protocol, hostName, fragment, routeValues, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"{2}://{3}/{4}?RouteParameter={5}#{6}\">{7}</a>", attributeName, attributeValue, protocol, hostName, routeUrl, routeValue, fragment, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLinkTextRouteNameProtocolHostNameFragmentRouteValueDictionaryAndAttributeExpressionReturnsCorrectly()
		{
			string linkText = "LinkText";
			string routeName = "RouteName";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string protocol = "https";
			string hostName = "HostName";
			string fragment = "Fragment";
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			string routeUrl = "RouteUrl";

			var routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelperWithNamedRoute( routeName, routeUrl );

			var result = htmlHelper.RouteLink( linkText, routeName, protocol, hostName, fragment, routeValues, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"{2}://{3}/{4}?{5}={6}#{7}\">{8}</a>", attributeName, attributeValue, protocol, hostName, routeUrl, routeParameter, routeValue, fragment, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
