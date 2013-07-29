using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc.Ajax;
using System.Web.Mvc;
using System.Web.Routing;
using Hex.Ajax;

namespace Hex.TestProject.Ajax.LinkExtensionsTests
{
	[TestClass]
	public class LinkExtensions_RouteLink
	{
		private const string ONCLICK_SCRIPT = "onclick=\"Sys.Mvc.AsyncHyperlink.handleClick(this, new Sys.UI.DomEvent(event), { insertionMode: Sys.Mvc.InsertionMode.replace });\"";

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

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}?RouteParameter={4}\" {5}>{6}</a>", attributeName, attributeValue, AjaxHelperGenerator.DefaultController, AjaxHelperGenerator.DefaultAction, routeValue, ONCLICK_SCRIPT, linkText );
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

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}?{4}={5}\" {6}>{7}</a>", attributeName, attributeValue, AjaxHelperGenerator.DefaultController, AjaxHelperGenerator.DefaultAction, routeParameter, routeValue, ONCLICK_SCRIPT, linkText );
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

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}\" {3}>{4}</a>", attributeName, attributeValue, routeUrl, ONCLICK_SCRIPT, linkText );
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

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}?RouteParameter={3}\" {4}>{5}</a>", attributeName, attributeValue, routeUrl, routeValue, ONCLICK_SCRIPT, linkText );
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

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}?{3}={4}\" {5}>{6}</a>", attributeName, attributeValue, routeUrl, routeParameter, routeValue, ONCLICK_SCRIPT, linkText );
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

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"{2}://{3}/{4}?{5}={6}#{7}\" {8}>{9}</a>", attributeName, attributeValue, protocol, hostName, routeUrl, routeParameter, routeValue, fragment, ONCLICK_SCRIPT, linkText );
			Assert.AreEqual( expectedResult, result.ToHtmlString() );
		}
	}
}
