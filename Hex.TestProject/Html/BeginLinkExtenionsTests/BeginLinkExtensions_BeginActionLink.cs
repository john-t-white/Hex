using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;
using System.Web.Routing;
using System.Collections.Generic;

namespace Hex.TestProject.Html.BeginLinkExtenionsTests
{
	[TestClass]
	public class BeginLinkExtensions_BeginActionLink
	{
		[TestMethod]
		public void WithActionNameReturnsCorrectly()
		{
			string actionName = "ActionName";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginActionLink( actionName );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a href=\"/{0}/{1}\">", HtmlHelperGenerator.DefaultController, actionName );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameAndAttributeExpressionReturnsCorrectly()
		{
			string actionName = "ActionName";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginActionLink( actionName, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}\">", attributeName, attributeValue, HtmlHelperGenerator.DefaultController, actionName );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameAndRouteValuesObjectReturnsCorrectly()
		{
			string actionName = "ActionName";
			string routeValue = "RouteValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginActionLink( actionName, routeValues );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a href=\"/{0}/{1}?RouteParameter={2}\">", HtmlHelperGenerator.DefaultController, actionName, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameRouteValuesObjectAndHtmlAttributesObjectReturnsCorrectly()
		{
			string actionName = "ActionName";
			string attributeValue = "AttributeValue";
			string routeValue = "RouteValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginActionLink( actionName, routeValues, htmlAttributes );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a AttributeName=\"{0}\" href=\"/{1}/{2}?RouteParameter={3}\">", attributeValue, HtmlHelperGenerator.DefaultController, actionName, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameRouteValuesObjectAndAttributeExpressionReturnsCorrectly()
		{
			string actionName = "ActionName";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeValue = "RouteValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginActionLink( actionName, routeValues, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}?RouteParameter={4}\">", attributeName, attributeValue, HtmlHelperGenerator.DefaultController, actionName, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameAndRouteValuesDictionaryReturnsCorrectly()
		{
			string actionName = "ActionName";
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			var routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginActionLink( actionName, routeValues );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a href=\"/{0}/{1}?{2}={3}\">", HtmlHelperGenerator.DefaultController, actionName, routeParameter, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameRouteValuesDictionaryAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			string actionName = "ActionName";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			var routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			var htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginActionLink( actionName, routeValues, htmlAttributes );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}?{4}={5}\">", attributeName, attributeValue, HtmlHelperGenerator.DefaultController, actionName, routeParameter, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameRouteValuesDictionaryAndAttributeExpressionReturnsCorrectly()
		{
			string actionName = "ActionName";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			var routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginActionLink( actionName, routeValues, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}?{4}={5}\">", attributeName, attributeValue, HtmlHelperGenerator.DefaultController, actionName, routeParameter, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameAndControllerNameReturnsCorrectly()
		{
			string actionName = "ActionName";
			string controllerName = "ControllerName";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginActionLink( actionName, controllerName );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a href=\"/{0}/{1}\">", controllerName, actionName );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameControllerNameAndAttributeExpressionReturnsCorrectly()
		{
			string actionName = "ActionName";
			string controllerName = "ControllerName";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginActionLink( actionName, controllerName, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}\">", attributeName, attributeValue, controllerName, actionName );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameControllerNameRouteValuesObjectAndHtmlAttributesObjectReturnsCorrectly()
		{
			string actionName = "ActionName";
			string controllerName = "ControllerName";
			string attributeValue = "AttributeValue";
			string routeValue = "RouteValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginActionLink( actionName, controllerName, routeValues, htmlAttributes );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a AttributeName=\"{0}\" href=\"/{1}/{2}?RouteParameter={3}\">", attributeValue, controllerName, actionName, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameControllerNameRouteValuesObjectAndAttributeExpressionReturnsCorrectly()
		{
			string actionName = "ActionName";
			string controllerName = "ControllerName";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeValue = "RouteValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginActionLink( actionName, controllerName, routeValues, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}?RouteParameter={4}\">", attributeName, attributeValue, controllerName, actionName, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameControllerNameRouteValuesDictionaryAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			string actionName = "ActionName";
			string controllerName = "ControllerName";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			var routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			var htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginActionLink( actionName, controllerName, routeValues, htmlAttributes );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}?{4}={5}\">", attributeName, attributeValue, controllerName, actionName, routeParameter, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameControllerNameRouteValuesDictionaryAndAttributeExpressionReturnsCorrectly()
		{
			string actionName = "ActionName";
			string controllerName = "ControllerName";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			var routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginActionLink( actionName, controllerName, routeValues, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}?{4}={5}\">", attributeName, attributeValue, controllerName, actionName, routeParameter, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameControllerNameProtocolHostNameFragmentAndAttributeExpressionReturnsCorrectly()
		{
			string actionName = "ActionName";
			string controllerName = "ControllerName";
			string protocol = "http";
			string hostName = "HostName";
			string fragment = "Fragment";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginActionLink( actionName, controllerName, protocol, hostName, fragment, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"{2}://{3}/{4}/{5}#{6}\">", attributeName, attributeValue, protocol, hostName, controllerName, actionName, fragment );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameControllerNameProtocolHostNameFragmentRouteValuesObjectAndHtmlAttributesObjectReturnsCorrectly()
		{
			string actionName = "ActionName";
			string controllerName = "ControllerName";
			string protocol = "http";
			string hostName = "HostName";
			string fragment = "Fragment";
			string attributeValue = "AttributeValue";
			string routeValue = "RouteValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginActionLink( actionName, controllerName, protocol, hostName, fragment, routeValues, htmlAttributes );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a AttributeName=\"{0}\" href=\"{1}://{2}/{3}/{4}?RouteParameter={5}#{6}\">", attributeValue, protocol, hostName, controllerName, actionName, routeValue, fragment );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameControllerNameProtocolHostNameFragmentRouteValuesObjectAndAttributeExpressionReturnsCorrectly()
		{
			string actionName = "ActionName";
			string controllerName = "ControllerName";
			string protocol = "http";
			string hostName = "HostName";
			string fragment = "Fragment";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeValue = "RouteValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginActionLink( actionName, controllerName, protocol, hostName, fragment, routeValues, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"{2}://{3}/{4}/{5}?RouteParameter={6}#{7}\">", attributeName, attributeValue, protocol, hostName, controllerName, actionName, routeValue, fragment );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameControllerNameProtocolHostNameFragmentRouteValuesDictionaryAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			string actionName = "ActionName";
			string controllerName = "ControllerName";
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

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginActionLink( actionName, controllerName, protocol, hostName, fragment, routeValues, htmlAttributes );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"{2}://{3}/{4}/{5}?{6}={7}#{8}\">", attributeName, attributeValue, protocol, hostName, controllerName, actionName, routeParameter, routeValue, fragment );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameControllerNameProtocolHostNameFragmentRouteValuesDictionaryAndAttributeExpressionReturnsCorrectly()
		{
			string actionName = "ActionName";
			string controllerName = "ControllerName";
			string protocol = "http";
			string hostName = "HostName";
			string fragment = "Fragment";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			var routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginActionLink( actionName, controllerName, protocol, hostName, fragment, routeValues, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"{2}://{3}/{4}/{5}?{6}={7}#{8}\">", attributeName, attributeValue, protocol, hostName, controllerName, actionName, routeParameter, routeValue, fragment );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}
	}
}
