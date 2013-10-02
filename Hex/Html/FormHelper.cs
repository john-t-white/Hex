using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Hex.Html
{
	internal static class FormHelper
	{
		private static readonly MethodInfo _formHelperMethod;

		static FormHelper()
		{
			BindingFlags bindingFlags = BindingFlags.Static | BindingFlags.NonPublic;

			Type formExtensionsType = typeof( System.Web.Mvc.Html.FormExtensions );
			FormHelper._formHelperMethod = formExtensionsType.GetMethod( "FormHelper", bindingFlags );
		}

		internal static MvcForm Execute( HtmlHelper htmlHelper, string formAction, FormMethod method, IDictionary<string, object> htmlAttributes )
		{
			object[] parameters = new object[]
			{
				htmlHelper,
				formAction,
				method,
				htmlAttributes
			};

			return ( MvcForm )FormHelper._formHelperMethod.Invoke( null, parameters );
		}
	}
}
