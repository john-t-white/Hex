using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Html;
using System.Web.Routing;

namespace Hex.TestProject.Html.FormExtensionsTests
{
	[TestClass]
	public class FormExtensions_BeginRouteForm
	{
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

			var result = htmlHelper.BeginRouteForm( routeValues, x => x.Attribute( attributeName, attributeValue ) );

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

			var result = htmlHelper.BeginRouteForm( routeValues, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<form {0}=\"{1}\" action=\"/{2}/{3}?{4}={5}\" method=\"post\">", attributeName, attributeValue, HtmlHelperGenerator.DefaultController, HtmlHelperGenerator.DefaultAction, routeParameter, routeValue );
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

			var result = htmlHelper.BeginRouteForm( routeName, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<form {0}=\"{1}\" action=\"/{2}\" method=\"post\">", attributeName, attributeValue, routeUrl );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteNameFormMethodAndAttributeExpressionReturnsCorrectly()
		{
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			FormMethod formMethod = FormMethod.Get;

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelperWithNamedRoute( routeName, routeUrl );

			var result = htmlHelper.BeginRouteForm( routeName, formMethod, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<form {0}=\"{1}\" action=\"/{2}\" method=\"get\">", attributeName, attributeValue, routeUrl );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteNameRouteValuesAndAttributeExpressionReturnsCorrectly()
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

			var result = htmlHelper.BeginRouteForm( routeName, routeValues, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<form {0}=\"{1}\" action=\"/{2}?RouteParameter={3}\" method=\"post\">", attributeName, attributeValue, routeUrl, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteNameRouteValueDictionaryAndAttributeExpressionReturnsCorrectly()
		{
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";

			RouteValueDictionary routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelperWithNamedRoute( routeName, routeUrl );

			var result = htmlHelper.BeginRouteForm( routeName, routeValues, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<form {0}=\"{1}\" action=\"/{2}?{3}={4}\" method=\"post\">", attributeName, attributeValue, routeUrl, routeParameter, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteNameRouteValuesFormMethodAndAttributeExpressionReturnsCorrectly()
		{
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeValue = "RouteValue";
			FormMethod formMethod = FormMethod.Get;

			object routeValues = new
			{
				RouteParameter = routeValue
			};

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelperWithNamedRoute( routeName, routeUrl );

			var result = htmlHelper.BeginRouteForm( routeName, routeValues, formMethod, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<form {0}=\"{1}\" action=\"/{2}?RouteParameter={3}\" method=\"get\">", attributeName, attributeValue, routeUrl, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}

		[TestMethod]
		public void WithRouteNameRouteValueDictionaryFormMethodAndAttributeExpressionReturnsCorrectly()
		{
			string routeName = "RouteName";
			string routeUrl = "RouteUrl";
			string attributeName = "AttributeName";
			string attributeValue = "AttributeValue";
			string routeParameter = "RouteParameter";
			string routeValue = "RouteValue";
			FormMethod formMethod = FormMethod.Get;

			RouteValueDictionary routeValues = new RouteValueDictionary();
			routeValues.Add( routeParameter, routeValue );

			HtmlHelper htmlHelper = HtmlHelperGenerator.CreateHtmlHelperWithNamedRoute( routeName, routeUrl );

			var result = htmlHelper.BeginRouteForm( routeName, routeValues, formMethod, x => x.Attribute( attributeName, attributeValue ) );

			string expectedResult = string.Format( "<form {0}=\"{1}\" action=\"/{2}?{3}={4}\" method=\"get\">", attributeName, attributeValue, routeUrl, routeParameter, routeValue );
			Assert.AreEqual( expectedResult, htmlHelper.ViewContext.Writer.ToString() );
		}
	}
}
