using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;
using System.Web.Routing;
using System.Collections.Generic;

namespace Hex.TestProject.Html.BeginLinkExtenionsTests
{
	[TestClass]
	public class BeingLinkExtensions_BeginRouteLink
	{
		[TestMethod]
		public void WithRouteValuesObjectReturnsCorrectly()
		{
			string routeValue = "RouteValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginRouteLink( routeValues );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a href=\"/{0}/{1}?RouteParameter={2}\">", HtmlHelperGenerator.DefaultController, HtmlHelperGenerator.DefaultAction, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteValuesObjectAndHtmlAttributesObjectReturnsCorrectly()
		{
			string routeValue = "RouteValue";
			string attributeValue = "AttributeValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginRouteLink( routeValues, htmlAttributes );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a AttributeName=\"{0}\" href=\"/{1}/{2}?RouteParameter={3}\">", attributeValue, HtmlHelperGenerator.DefaultController, HtmlHelperGenerator.DefaultAction, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteValuesObjectAndAttributeExpressionReturnsCorrectly()
		{
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeValue = "RouteValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginRouteLink( routeValues, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}?RouteParameter={4}\">", attributeName, attributeValue, HtmlHelperGenerator.DefaultController, HtmlHelperGenerator.DefaultAction, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteValuesDictionaryReturnsCorrectly()
		{
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			var routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginRouteLink( routeValues );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a href=\"/{0}/{1}?{2}={3}\">", HtmlHelperGenerator.DefaultController, HtmlHelperGenerator.DefaultAction, routeParameter, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteValuesDictionaryAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			var routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			var htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginRouteLink( routeValues, htmlAttributes );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}?{4}={5}\">", attributeName, attributeValue, HtmlHelperGenerator.DefaultController, HtmlHelperGenerator.DefaultAction, routeParameter, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteValuesDictionaryAndAttributeExpressionReturnsCorrectly()
		{
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			var routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginRouteLink( routeValues, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}?{4}={5}\">", attributeName, attributeValue, HtmlHelperGenerator.DefaultController, HtmlHelperGenerator.DefaultAction, routeParameter, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteNameReturnsCorrectly()
		{
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelperWithNamedRoute( routeName, routeUrl );

			var result = htmlHelper.BeginRouteLink( routeName );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a href=\"/{0}\">", routeUrl );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteNameAndAttributeExpressionReturnsCorrectly()
		{
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";

			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelperWithNamedRoute( routeName, routeUrl );

			var result = htmlHelper.BeginRouteLink( routeName, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}\">", attributeName, attributeValue, routeUrl );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteNameAndRouteValuesObjectReturnsCorrectly()
		{
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			string routeValue = "RouteValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelperWithNamedRoute( routeName, routeUrl );

			var result = htmlHelper.BeginRouteLink( routeName, routeValues );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a href=\"/{0}?RouteParameter={1}\">", routeUrl, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteNameRouteValuesObjectAndHtmlAttributesObjectReturnsCorrectly()
		{
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			string routeValue = "RouteValue";
			string attributeValue = "AttributeValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelperWithNamedRoute( routeName, routeUrl );

			var result = htmlHelper.BeginRouteLink( routeName, routeValues, htmlAttributes );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a AttributeName=\"{0}\" href=\"/{1}?RouteParameter={2}\">", attributeValue, routeUrl, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteNameRouteValuesObjectAndAttributeExpressionReturnsCorrectly()
		{
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeValue = "RouteValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelperWithNamedRoute( routeName, routeUrl );

			var result = htmlHelper.BeginRouteLink( routeName, routeValues, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}?RouteParameter={3}\">", attributeName, attributeValue, routeUrl, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteNameAndRouteValuesDictionaryReturnsCorrectly()
		{
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			var routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelperWithNamedRoute( routeName, routeUrl );

			var result = htmlHelper.BeginRouteLink( routeName, routeValues );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a href=\"/{0}?{1}={2}\">", routeUrl, routeParameter, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteNameRouteValuesDictionaryAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			var routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			var htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelperWithNamedRoute( routeName, routeUrl );

			var result = htmlHelper.BeginRouteLink( routeName, routeValues, htmlAttributes );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}?{3}={4}\">", attributeName, attributeValue, routeUrl, routeParameter, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteNameRouteValuesDictionaryAndAttributeExpressionReturnsCorrectly()
		{
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			var routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelperWithNamedRoute( routeName, routeUrl );

			var result = htmlHelper.BeginRouteLink( routeName, routeValues, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}?{3}={4}\">", attributeName, attributeValue, routeUrl, routeParameter, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteNameProtocolHostNameFragmentAndAttributeExpressionReturnsCorrectly()
		{
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			string protocol = "http";
			string hostName = "HostName";
			string fragment = "Fragment";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelperWithNamedRoute( routeName, routeUrl );

			var result = htmlHelper.BeginRouteLink( routeName, protocol, hostName, fragment, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"{2}://{3}/{4}#{5}\">", attributeName, attributeValue, protocol, hostName, routeUrl, fragment );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteNameProtocolHostNameFragmentRouteValuesObjectAndHtmlAttributesObjectReturnsCorrectly()
		{
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			string protocol = "http";
			string hostName = "HostName";
			string fragment = "Fragment";
			string routeValue = "RouteValue";
			string attributeValue = "AttributeValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelperWithNamedRoute( routeName, routeUrl );

			var result = htmlHelper.BeginRouteLink( routeName, protocol, hostName, fragment, routeValues, htmlAttributes );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a AttributeName=\"{0}\" href=\"{1}://{2}/{3}?RouteParameter={4}#{5}\">", attributeValue, protocol, hostName, routeUrl, routeValue, fragment );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteNameProtocolHostNameFragmentRouteValuesObjectAndAttributeExpressionReturnsCorrectly()
		{
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			string protocol = "http";
			string hostName = "HostName";
			string fragment = "Fragment";
			string routeValue = "RouteValue";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelperWithNamedRoute( routeName, routeUrl );

			var result = htmlHelper.BeginRouteLink( routeName, protocol, hostName, fragment, routeValues, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"{2}://{3}/{4}?RouteParameter={5}#{6}\">", attributeName, attributeValue, protocol, hostName, routeUrl, routeValue, fragment );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteNameProtocolHostNameFragmentRouteValuesDictionaryAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			string protocol = "http";
			string hostName = "HostName";
			string fragment = "Fragment";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			var routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			var htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelperWithNamedRoute( routeName, routeUrl );

			var result = htmlHelper.BeginRouteLink( routeName, protocol, hostName, fragment, routeValues, htmlAttributes );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"{2}://{3}/{4}?{5}={6}#{7}\">", attributeName, attributeValue, protocol, hostName, routeUrl, routeParameter, routeValue, fragment );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteNameProtocolHostNameFragmentRouteValuesDictionaryAndAttributeExpressionReturnsCorrectly()
		{
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			string protocol = "http";
			string hostName = "HostName";
			string fragment = "Fragment";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			var routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelperWithNamedRoute( routeName, routeUrl );

			var result = htmlHelper.BeginRouteLink( routeName, protocol, hostName, fragment, routeValues, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"{2}://{3}/{4}?{5}={6}#{7}\">", attributeName, attributeValue, protocol, hostName, routeUrl, routeParameter, routeValue, fragment );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}
	}
}
