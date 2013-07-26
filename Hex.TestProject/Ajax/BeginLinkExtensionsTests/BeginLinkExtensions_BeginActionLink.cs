using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Hex.Ajax;
using System.Web.Routing;
using System.Collections.Generic;

namespace Hex.TestProject.Ajax.BeginLinkExtensionsTests
{
	[TestClass]
	public class BeginLinkExtensions_BeginActionLink
	{
		private const string ONCLICK_SCRIPT = "onclick=\"Sys.Mvc.AsyncHyperlink.handleClick(this, new Sys.UI.DomEvent(event), { insertionMode: Sys.Mvc.InsertionMode.replace });\"";

		[TestMethod]
		public void WithActionNameAndAjaxOptionsReturnsCorrectly()
		{
			string actionName = "ActionName";
			AjaxOptions ajaxOptions = new AjaxOptions();

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.BeginActionLink( actionName, ajaxOptions );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a href=\"/{0}/{1}\" {2}>", AjaxHelperGenerator.DefaultController, actionName, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameAjaxOptionsAndAtributeExpressionReturnsCorrectly()
		{
			string actionName = "ActionName";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.BeginActionLink( actionName, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}\" {4}>", attributeName, attributeValue, AjaxHelperGenerator.DefaultController, actionName, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameRouteValuesObjectAndAjaxOptionsReturnsCorrectly()
		{
			string actionName = "ActionName";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string routeValue = "RouteValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.BeginActionLink( actionName, routeValues, ajaxOptions );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a href=\"/{0}/{1}?RouteParameter={2}\" {3}>", AjaxHelperGenerator.DefaultController, actionName, routeValue, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameRouteValuesObjectAjaxOptionsAndHtmlAttributesObjectReturnsCorrectly()
		{
			string actionName = "ActionName";
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

			var result = ajaxHelper.BeginActionLink( actionName, routeValues, ajaxOptions, htmlAttributes );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a AttributeName=\"{0}\" href=\"/{1}/{2}?RouteParameter={3}\" {4}>", attributeValue, AjaxHelperGenerator.DefaultController, actionName, routeValue, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameRouteValuesObjectAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string actionName = "ActionName";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string routeValue = "RouteValue";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.BeginActionLink( actionName, routeValues, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}?RouteParameter={4}\" {5}>", attributeName, attributeValue, AjaxHelperGenerator.DefaultController, actionName, routeValue, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameRouteValuesDictionaryAndAjaxOptionsReturnsCorrectly()
		{
			string actionName = "ActionName";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			RouteValueDictionary routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.BeginActionLink( actionName, routeValues, ajaxOptions );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a href=\"/{0}/{1}?{2}={3}\" {4}>", AjaxHelperGenerator.DefaultController, actionName, routeParameter, routeValue, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameRouteValuesDictionaryAjaxOptionsAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			string actionName = "ActionName";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			RouteValueDictionary routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.BeginActionLink( actionName, routeValues, ajaxOptions, htmlAttributes );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}?{4}={5}\" {6}>", attributeName, attributeValue, AjaxHelperGenerator.DefaultController, actionName, routeParameter, routeValue, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameRouteValuesDictionaryAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string actionName = "ActionName";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			RouteValueDictionary routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.BeginActionLink( actionName, routeValues, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}?{4}={5}\" {6}>", attributeName, attributeValue, AjaxHelperGenerator.DefaultController, actionName, routeParameter, routeValue, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameControllerNameAndAjaxOptionsReturnsCorrectly()
		{
			string actionName = "ActionName";
			string controllerName = "ControllerName";
			AjaxOptions ajaxOptions = new AjaxOptions();

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.BeginActionLink( actionName, controllerName, ajaxOptions );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a href=\"/{0}/{1}\" {2}>", controllerName, actionName, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameControllerNameAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string actionName = "ActionName";
			string controllerName = "ControllerName";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.BeginActionLink( actionName, controllerName, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}\" {4}>", attributeName, attributeValue, controllerName, actionName, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameControllerNameRouteValuesObjectAndAjaxOptionsReturnsCorrectly()
		{
			string actionName = "ActionName";
			string controllerName = "ControllerName";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string routeValue = "RouteValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.BeginActionLink( actionName, controllerName, routeValues, ajaxOptions );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a href=\"/{0}/{1}?RouteParameter={2}\" {3}>", controllerName, actionName, routeValue, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameControllerNameRouteValuesObjectAjaxOptionsAndHtmlAttributesObjectReturnsCorrectly()
		{
			string actionName = "ActionName";
			string controllerName = "ControllerName";
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

			var result = ajaxHelper.BeginActionLink( actionName, controllerName, routeValues, ajaxOptions, htmlAttributes );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a AttributeName=\"{0}\" href=\"/{1}/{2}?RouteParameter={3}\" {4}>", attributeValue, controllerName, actionName, routeValue, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameControllerNameRouteValuesObjectAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string actionName = "ActionName";
			string controllerName = "ControllerName";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string routeValue = "RouteValue";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.BeginActionLink( actionName, controllerName, routeValues, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}?RouteParameter={4}\" {5}>", attributeName, attributeValue, controllerName, actionName, routeValue, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameControllerNameRouteValuesDictionaryAndAjaxOptionsReturnsCorrectly()
		{
			string actionName = "ActionName";
			string controllerName = "ControllerName";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			RouteValueDictionary routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.BeginActionLink( actionName, controllerName, routeValues, ajaxOptions );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a href=\"/{0}/{1}?{2}={3}\" {4}>", controllerName, actionName, routeParameter, routeValue, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameControllerNameRouteValuesDictionaryAjaxOptionsAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			string actionName = "ActionName";
			string controllerName = "ControllerName";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			RouteValueDictionary routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.BeginActionLink( actionName, controllerName, routeValues, ajaxOptions, htmlAttributes );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}?{4}={5}\" {6}>", attributeName, attributeValue, controllerName, actionName, routeParameter, routeValue, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameControllerNameRouteValuesDictionaryAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string actionName = "ActionName";
			string controllerName = "ControllerName";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			RouteValueDictionary routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.BeginActionLink( actionName, controllerName, routeValues, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"/{2}/{3}?{4}={5}\" {6}>", attributeName, attributeValue, controllerName, actionName, routeParameter, routeValue, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameControllerNameProtocolHostNameFragmentRouteValuesObjectAjaxOptionsAndHtmlAttributesObjectReturnsCorrectly()
		{
			string actionName = "ActionName";
			string controllerName = "ControllerName";
			string protocol = "http";
			string hostName = "HostName";
			string fragment = "Fragment";
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

			var result = ajaxHelper.BeginActionLink( actionName, controllerName, protocol, hostName, fragment, routeValues, ajaxOptions, htmlAttributes );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a AttributeName=\"{0}\" href=\"{1}://{2}/{3}/{4}?RouteParameter={5}#{6}\" {7}>", attributeValue, protocol, hostName, controllerName, actionName, routeValue, fragment, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameControllerNameProtocolHostNameFragmentRouteValuesObjectAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string actionName = "ActionName";
			string controllerName = "ControllerName";
			string protocol = "http";
			string hostName = "HostName";
			string fragment = "Fragment";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string routeValue = "RouteValue";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.BeginActionLink( actionName, controllerName, protocol, hostName, fragment, routeValues, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"{2}://{3}/{4}/{5}?RouteParameter={6}#{7}\" {8}>", attributeName, attributeValue, protocol, hostName, controllerName, actionName, routeValue, fragment, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameControllerNameProtocolHostNameFragmentRouteValuesDictionaryAjaxOptionsAndHtmlAttributesDictionaryReturnsCorrectly()
		{
			string actionName = "ActionName";
			string controllerName = "ControllerName";
			string protocol = "http";
			string hostName = "HostName";
			string fragment = "Fragment";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			RouteValueDictionary routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
			htmlAttributes.Add( attributeName, attributeValue );

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.BeginActionLink( actionName, controllerName, protocol, hostName, fragment, routeValues, ajaxOptions, htmlAttributes );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"{2}://{3}/{4}/{5}?{6}={7}#{8}\" {9}>", attributeName, attributeValue, protocol, hostName, controllerName, actionName, routeParameter, routeValue, fragment, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameControllerNameProtocolHostNameFragmentRouteValuesDictionaryAjaxOptionsAndAttributeExpressionReturnsCorrectly()
		{
			string actionName = "ActionName";
			string controllerName = "ControllerName";
			string protocol = "http";
			string hostName = "HostName";
			string fragment = "Fragment";
			AjaxOptions ajaxOptions = new AjaxOptions();
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			RouteValueDictionary routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			AjaxHelper ajaxHelper = AjaxHelperGenerator.CreateAjaxHelper();

			var result = ajaxHelper.BeginActionLink( actionName, controllerName, protocol, hostName, fragment, routeValues, ajaxOptions, x => x.Attribute( attributeName, attributeValue ) );

			Assert.IsNotNull( result );

			string expectedResult = string.Format( "<a {0}=\"{1}\" href=\"{2}://{3}/{4}/{5}?{6}={7}#{8}\" {9}>", attributeName, attributeValue, protocol, hostName, controllerName, actionName, routeParameter, routeValue, fragment, ONCLICK_SCRIPT );
			Assert.AreEqual( expectedResult, ajaxHelper.ViewContext.Writer.ToString() );
		}
	}
}
