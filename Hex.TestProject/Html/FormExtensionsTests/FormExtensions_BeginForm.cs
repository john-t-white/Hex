using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;
using System.Web.Routing;

namespace Hex.TestProject.Html.FormExtensionsTests
{
	[TestClass]
	public class FormExtensions_BeginForm
	{
		[TestMethod]
		public void WithAttributeExpressionReturnsCorrectly()
		{
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginForm( x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<form {0}=\"{1}\" action=\"http://localhost\" method=\"post\">", attributeName, attributeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteValuesAndAttributeExpressionReturnsCorrectly()
		{
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeValue = "RouteValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginForm( routeValues, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<form {0}=\"{1}\" action=\"/{2}/{3}?RouteParameter={4}\" method=\"post\">", attributeName, attributeValue, HtmlHelperGenerator.DefaultController, HtmlHelperGenerator.DefaultAction, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteValueDictionaryAndAttributeExpressionReturnsCorrectly()
		{
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			RouteValueDictionary routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginForm( routeValues, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<form {0}=\"{1}\" action=\"/{2}/{3}?{4}={5}\" method=\"post\">", attributeName, attributeValue, HtmlHelperGenerator.DefaultController, HtmlHelperGenerator.DefaultAction, routeParameter, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameControllerNameAndAttributeExpressionReturnsCorrectly()
		{
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string controllerName = "ControllerName";
			string actionName = "ActionName";

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginForm( actionName, controllerName, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<form {0}=\"{1}\" action=\"/{2}/{3}\" method=\"post\">", attributeName, attributeValue, controllerName, actionName );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameControllerNameRouteValuesAndAttributeExpressionReturnsCorrectly()
		{
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string controllerName = "ControllerName";
			string actionName = "ActionName";
			string routeValue = "RouteValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginForm( actionName, controllerName, routeValues, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<form {0}=\"{1}\" action=\"/{2}/{3}?RouteParameter={4}\" method=\"post\">", attributeName, attributeValue, controllerName, actionName, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameControllerNameRouteValueDictionaryAndAttributeExpressionReturnsCorrectly()
		{
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string controllerName = "ControllerName";
			string actionName = "ActionName";
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			RouteValueDictionary routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginForm( actionName, controllerName, routeValues, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<form {0}=\"{1}\" action=\"/{2}/{3}?{4}={5}\" method=\"post\">", attributeName, attributeValue, controllerName, actionName, routeParameter, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameControllerNameFormMethodAndAttributeExpressionReturnsCorrectly()
		{
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string controllerName = "ControllerName";
			string actionName = "ActionName";
			FormMethod formMethod = FormMethod.Get;

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginForm( actionName, controllerName, formMethod, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<form {0}=\"{1}\" action=\"/{2}/{3}\" method=\"get\">", attributeName, attributeValue, controllerName, actionName );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameControllerNameRouteValuesFormMethodAndAttributeExpressionReturnsCorrectly()
		{
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string controllerName = "ControllerName";
			string actionName = "ActionName";
			FormMethod formMethod = FormMethod.Get;
			string routeValue = "RouteValue";

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginForm( actionName, controllerName, routeValues, formMethod, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<form {0}=\"{1}\" action=\"/{2}/{3}?RouteParameter={4}\" method=\"get\">", attributeName, attributeValue, controllerName, actionName, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithActionNameControllerNameRouteValueDictionaryFormMethodAndAttributeExpressionReturnsCorrectly()
		{
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string controllerName = "ControllerName";
			string actionName = "ActionName";
			FormMethod formMethod = FormMethod.Get;
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			RouteValueDictionary routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelper();

			var result = htmlHelper.BeginForm( actionName, controllerName, routeValues, formMethod, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<form {0}=\"{1}\" action=\"/{2}/{3}?{4}={5}\" method=\"get\">", attributeName, attributeValue, controllerName, actionName, routeParameter, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}
	}
}
