using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc.Ajax;
using System.Web.Mvc;
using Hex.Ajax;
using System.Web.Routing;
using System.Collections.Generic;

namespace Hex.TestProject.Ajax.BeginLinkExtensionsTests
{
	[TestClass]
	public class BeginLinkExtensions_BeginRouteLink
	{
		private const string ONCLICK_SCRIPT = "onclick=\"Sys.Mvc.AsyncHyperlink.handleClick(this, new Sys.UI.DomEvent(event), { insertionMode: Sys.Mvc.InsertionMode.replace });\"";

		[TestMethod]
		public void WithRouteValuesObjectAndAjaxOptionsReturnsCorrectly()
		{
			AjaxOptions ajaxOptions = new AjaxOptions();
			string routeValue = "RouteValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.BeginRouteLink( routeValues, ajaxOptions );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a href=\"/{0}/{1}?RouteParameter={2}\" {3}>", AjaxHelperGenerator.DefaultController, AjaxHelperGenerator.DefaultAction, routeValue, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteValuesObjectAjaxOptionsAndHtmlAttributesObjectReturnsCorrectly()
		{
			AjaxOptions ajaxOptions = new AjaxOptions();
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

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.BeginRouteLink( routeValues, ajaxOptions, htmlAttributes );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a AttributeName=\"{0}\" href=\"/{1}/{2}?RouteParameter={3}\" {4}>", attributeValue, AjaxHelperGenerator.DefaultController, AjaxHelperGenerator.DefaultAction, routeValue, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteValuesObjectAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			AjaxOptions ajaxOptions = new AjaxOptions();
			string routeValue = "RouteValue";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.BeginRouteLink( routeValues, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}?RouteParameter={4}\" {5}>", attributeName, attributeValue, AjaxHelperGenerator.DefaultController, AjaxHelperGenerator.DefaultAction, routeValue, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteValuesDictionaryAndAjaxOptionsReturnsCorrectly()
		{
			AjaxOptions ajaxOptions = new AjaxOptions();
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			RouteValueDictionary routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.BeginRouteLink( routeValues, ajaxOptions );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a href=\"/{0}/{1}?{2}={3}\" {4}>", AjaxHelperGenerator.DefaultController, AjaxHelperGenerator.DefaultAction, routeParameter, routeValue, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteValuesDictionaryAjaxOptionsAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			AjaxOptions ajaxOptions = new AjaxOptions();
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			RouteValueDictionary routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			var htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.BeginRouteLink( routeValues, ajaxOptions, htmlAttributes );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}?{4}={5}\" {6}>", attributeName, attributeValue, AjaxHelperGenerator.DefaultController, AjaxHelperGenerator.DefaultAction, routeParameter, routeValue, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteValuesDictionaryAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			AjaxOptions ajaxOptions = new AjaxOptions();
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			RouteValueDictionary routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.BeginRouteLink( routeValues, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}?{4}={5}\" {6}>", attributeName, attributeValue, AjaxHelperGenerator.DefaultController, AjaxHelperGenerator.DefaultAction, routeParameter, routeValue, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteNameAndAjaxOptionsReturnsCorrectly()
		{
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			AjaxOptions ajaxOptions = new AjaxOptions();

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelperWithNamedRoute( routeName, routeUrl );

			var result = ajaxHelper.BeginRouteLink( routeName, ajaxOptions );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a href=\"/{0}\" {1}>", routeUrl, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteNameAjaxOptionsAndHtmlAttributesObjectReturnsCorrectly()
		{
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string attributeValue = "AttributeValue";

			object htmlAttributes = new
			{
				AttributeName = attributeValue
			};

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelperWithNamedRoute( routeName, routeUrl );

			var result = ajaxHelper.BeginRouteLink( routeName, ajaxOptions, htmlAttributes );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a AttributeName=\"{0}\" href=\"/{1}\" {2}>", attributeValue, routeUrl, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteNameAjaxOptionsAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			var htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelperWithNamedRoute( routeName, routeUrl );

			var result = ajaxHelper.BeginRouteLink( routeName, ajaxOptions, htmlAttributes );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}\" {3}>", attributeName, attributeValue, routeUrl, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteNameAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelperWithNamedRoute( routeName, routeUrl );

			var result = ajaxHelper.BeginRouteLink( routeName, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}\" {3}>", attributeName, attributeValue, routeUrl, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteNameRouteValuesObjectAndAjaxOptionsReturnsCorrectly()
		{
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string routeValue = "RouteValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelperWithNamedRoute( routeName, routeUrl );

			var result = ajaxHelper.BeginRouteLink( routeName, routeValues, ajaxOptions );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a href=\"/{0}?RouteParameter={1}\" {2}>", routeUrl, routeValue, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteNameRouteValuesObjectAjaxOptionsAndHtmlAttributesObjectReturnsCorrectly()
		{
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			AjaxOptions ajaxOptions = new AjaxOptions();
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

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelperWithNamedRoute( routeName, routeUrl );

			var result = ajaxHelper.BeginRouteLink( routeName, routeValues, ajaxOptions, htmlAttributes );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a AttributeName=\"{0}\" href=\"/{1}?RouteParameter={2}\" {3}>", attributeValue, routeUrl, routeValue, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteNameRouteValuesObjectAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string routeValue = "RouteValue";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelperWithNamedRoute( routeName, routeUrl );

			var result = ajaxHelper.BeginRouteLink( routeName, routeValues, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}?RouteParameter={3}\" {4}>", attributeName, attributeValue, routeUrl, routeValue, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteNameRouteValuesDictionaryAndAjaxOptionsReturnsCorrectly()
		{
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			RouteValueDictionary routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelperWithNamedRoute( routeName, routeUrl );

			var result = ajaxHelper.BeginRouteLink( routeName, routeValues, ajaxOptions );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a href=\"/{0}?{1}={2}\" {3}>", routeUrl, routeParameter, routeValue, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteNameRoutValuesDictionaryAjaxOptionsAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			RouteValueDictionary routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			var htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelperWithNamedRoute( routeName, routeUrl );

			var result = ajaxHelper.BeginRouteLink( routeName, routeValues, ajaxOptions, htmlAttributes );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}?{3}={4}\" {5}>", attributeName, attributeValue, routeUrl, routeParameter, routeValue, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteNameRouteValuesDictionaryAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			RouteValueDictionary routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelperWithNamedRoute( routeName, routeUrl );

			var result = ajaxHelper.BeginRouteLink( routeName, routeValues, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}?{3}={4}\" {5}>", attributeName, attributeValue, routeUrl, routeParameter, routeValue, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}





		[TestMethod]
		public void WithRouteNameProtocolHostNameFragmentRoutValuesDictionaryAjaxOptionsAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			string protocol = "http";
			string hostName = "hostName";
			string fragment = "Fragment";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			RouteValueDictionary routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			var htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelperWithNamedRoute( routeName, routeUrl );

			var result = ajaxHelper.BeginRouteLink( routeName, protocol, hostName, fragment, routeValues, ajaxOptions, htmlAttributes );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"{2}://{3}/{4}?{5}={6}#{7}\" {8}>", attributeName, attributeValue, protocol, hostName, routeUrl, routeParameter, routeValue, fragment, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteNameProtocolHostNameFragmentRouteValuesDictionaryAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			string protocol = "http";
			string hostName = "hostName";
			string fragment = "Fragment";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			RouteValueDictionary routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelperWithNamedRoute( routeName, routeUrl );

			var result = ajaxHelper.BeginRouteLink( routeName, protocol, hostName, fragment, routeValues, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"{2}://{3}/{4}?{5}={6}#{7}\" {8}>", attributeName, attributeValue, protocol, hostName, routeUrl, routeParameter, routeValue, fragment, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}
	}
}
