using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc.Ajax;
using System.Web.Mvc;
using Hex.Ajax;
using System.Web.Routing;

namespace Hex.TestProject.Ajax.RouteLinkExtensionsTests
{
	[TestClass]
	public class RouteLinkExtensions_RouteLink
	{
		[TestMethod]
		public void WithLinkTextRouteValuesObjectAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string linkText = "LinkText";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeValue = "RouteValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.RouteLink( linkText, routeValues, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}?RouteParameter={4}\" onclick=\"Sys.Mvc.AsyncHyperlink.handleClick(this, new Sys.UI.DomEvent(event), {{ insertionMode: Sys.Mvc.InsertionMode.replace }});\">{5}</a>", attributeName, attributeValue, AjaxHelperGenerator.DefaultController, AjaxHelperGenerator.DefaultAction, routeValue, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLinkTextRouteValuesDictionaryAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string linkText = "LinkText";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			var routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.RouteLink( linkText, routeValues, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}?{4}={5}\" onclick=\"Sys.Mvc.AsyncHyperlink.handleClick(this, new Sys.UI.DomEvent(event), {{ insertionMode: Sys.Mvc.InsertionMode.replace }});\">{6}</a>", attributeName, attributeValue, AjaxHelperGenerator.DefaultController, AjaxHelperGenerator.DefaultAction, routeParameter, routeValue, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLinkTextRouteNameAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string linkText = "LinkText";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelperWithNamedRoute( routeName, routeUrl );

			var result = ajaxHelper.RouteLink( linkText, routeName, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}\" onclick=\"Sys.Mvc.AsyncHyperlink.handleClick(this, new Sys.UI.DomEvent(event), {{ insertionMode: Sys.Mvc.InsertionMode.replace }});\">{3}</a>", attributeName, attributeValue, routeUrl, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLinkTextRouteNameRouteValuesObjectAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string linkText = "LinkText";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			string routeValue = "RouteValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelperWithNamedRoute( routeName, routeUrl );

			var result = ajaxHelper.RouteLink( linkText, routeName, routeValues, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}?RouteParameter={3}\" onclick=\"Sys.Mvc.AsyncHyperlink.handleClick(this, new Sys.UI.DomEvent(event), {{ insertionMode: Sys.Mvc.InsertionMode.replace }});\">{4}</a>", attributeName, attributeValue, routeUrl, routeValue, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLinkTextRouteNameRouteValuesDictionaryAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string linkText = "LinkText";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			var routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelperWithNamedRoute( routeName, routeUrl );

			var result = ajaxHelper.RouteLink( linkText, routeName, routeValues, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}?{3}={4}\" onclick=\"Sys.Mvc.AsyncHyperlink.handleClick(this, new Sys.UI.DomEvent(event), {{ insertionMode: Sys.Mvc.InsertionMode.replace }});\">{5}</a>", attributeName, attributeValue, routeUrl, routeParameter, routeValue, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}

		[TestMethod]
		public void WithLinkTextRouteNameProtocolHostNameFragmentRouteValuesDictionaryAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string linkText = "LinkText";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			string protocol = "http";
			string hostName = "HostName";
			string fragment = "Fragment";
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			var routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelperWithNamedRoute( routeName, routeUrl );

			var result = ajaxHelper.RouteLink( linkText, routeName, protocol, hostName, fragment, routeValues, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"{2}://{3}/{4}?{5}={6}#{7}\" onclick=\"Sys.Mvc.AsyncHyperlink.handleClick(this, new Sys.UI.DomEvent(event), {{ insertionMode: Sys.Mvc.InsertionMode.replace }});\">{8}</a>", attributeName, attributeValue, protocol, hostName, routeUrl, routeParameter, routeValue, fragment, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
