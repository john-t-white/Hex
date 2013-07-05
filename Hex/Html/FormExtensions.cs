using Hex.AttributeBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Hex.Extensions;

namespace Hex.Html
{
	public static class FormExtensions
	{
		public static MvcForm BeginForm( this HtmlHelper htmlHelper, object routeValues, Action<FormAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginForm( null, null, new RouteValueDictionary( routeValues ), FormMethod.Post, attributeExpression.GetAttributes() );
		}

		public static MvcForm BeginForm( this HtmlHelper htmlHelper, RouteValueDictionary routeValues, Action<FormAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginForm( null, null, routeValues, FormMethod.Post, attributeExpression.GetAttributes() );
		}

		public static MvcForm BeginForm( this HtmlHelper htmlHelper, string actionName, string controllerName, Action<FormAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginForm( actionName, controllerName, new RouteValueDictionary(), FormMethod.Post, attributeExpression.GetAttributes() );
		}

		public static MvcForm BeginForm( this HtmlHelper htmlHelper, string actionName, string controllerName, FormMethod method, Action<FormAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginForm( actionName, controllerName, new RouteValueDictionary(), method, attributeExpression.GetAttributes() );
		}

		public static MvcForm BeginForm( this HtmlHelper htmlHelper, string actionName, string controllerName, object routeValues, Action<FormAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginForm( actionName, controllerName, new RouteValueDictionary( routeValues ), FormMethod.Post, attributeExpression.GetAttributes() );
		}

		public static MvcForm BeginForm( this HtmlHelper htmlHelper, string actionName, string controllerName, RouteValueDictionary routeValues, Action<FormAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginForm( actionName, controllerName, routeValues, FormMethod.Post, attributeExpression.GetAttributes() );
		}

		public static MvcForm BeginForm( this HtmlHelper htmlHelper, string actionName, string controllerName, object routeValues, FormMethod method, Action<FormAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginForm( actionName, controllerName, new RouteValueDictionary( routeValues ), method, attributeExpression.GetAttributes() );
		}

		public static MvcForm BeginForm( this HtmlHelper htmlHelper, string actionName, string controllerName, RouteValueDictionary routeValues, FormMethod method, Action<FormAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginForm( actionName, controllerName, routeValues, method, attributeExpression.GetAttributes() );
		}

		public static MvcForm BeginRouteForm( this HtmlHelper htmlHelper, object routeValues, Action<FormAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginRouteForm( null, new RouteValueDictionary( routeValues ), FormMethod.Post, attributeExpression.GetAttributes() );
		}

		public static MvcForm BeginRouteForm( this HtmlHelper htmlHelper, RouteValueDictionary routeValues, Action<FormAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginRouteForm( null, routeValues, FormMethod.Post, attributeExpression.GetAttributes() );
		}

		public static MvcForm BeginRouteForm( this HtmlHelper htmlHelper, string routeName, Action<FormAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginRouteForm( routeName, new RouteValueDictionary(), FormMethod.Post, attributeExpression.GetAttributes() );
		}

		public static MvcForm BeginRouteForm( this HtmlHelper htmlHelper, string routeName, FormMethod method, Action<FormAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginRouteForm( routeName, new RouteValueDictionary(), method, attributeExpression.GetAttributes() );
		}

		public static MvcForm BeginRouteForm( this HtmlHelper htmlHelper, string routeName, object routeValues, Action<FormAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginRouteForm( routeName, new RouteValueDictionary( routeValues ), FormMethod.Post, attributeExpression.GetAttributes() );
		}

		public static MvcForm BeginRouteForm( this HtmlHelper htmlHelper, string routeName, RouteValueDictionary routeValues, Action<FormAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginRouteForm( routeName, routeValues, FormMethod.Post, attributeExpression.GetAttributes() );
		}

		public static MvcForm BeginRouteForm( this HtmlHelper htmlHelper, string routeName, object routeValues, FormMethod method, Action<FormAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginRouteForm( routeName, new RouteValueDictionary( routeValues ), method, attributeExpression.GetAttributes() );
		}

		public static MvcForm BeginRouteForm( this HtmlHelper htmlHelper, string routeName, RouteValueDictionary routeValues, FormMethod method, Action<FormAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginRouteForm( routeName, routeValues, method, attributeExpression.GetAttributes() );
		}
	}
}
