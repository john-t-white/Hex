using Hex.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.ModelBinders
{
	/// <summary>
	/// Supports model binding a list of checkboxes.
	/// </summary>
	public class CheckBoxValuesModelBinder
		: IModelBinder
	{
		/// <summary>
		/// Binds the model by using the specified controller context and binding context.
		/// </summary>
		/// <param name="controllerContext">The context within which the controller operates. The context information includes the controller, HTTP content, request context, and route data.</param>
		/// <param name="bindingContext">The context within which the model is bound. The context includes information such as the model object, model name, model type, property filter, and value provider.</param>
		/// <returns>The bound object.</returns>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="bindingContext " />parameter is null.</exception>
		public object BindModel( ControllerContext controllerContext, ModelBindingContext bindingContext )
		{
			if( bindingContext == null )
			{
				throw new ArgumentNullException( "bindingContext" );
			}

			string checkBoxListKey = string.Format( "{0}.{1}", bindingContext.ModelName, CheckBoxListItemExtensions.CheckBoxListHiddenName );
			ValueProviderResult isCheckBoxListResult = bindingContext.ValueProvider.GetValue( checkBoxListKey );
			if( isCheckBoxListResult != null )
			{
				if( bindingContext.ValueProvider.GetValue( bindingContext.ModelName ) == null )
				{
					var emptyValueResult = new ValueProviderResult( new string[] { }, string.Empty, isCheckBoxListResult.Culture );
					bindingContext.ModelState.SetModelValue( bindingContext.ModelName, emptyValueResult );

					return null;
				}
			}

			return System.Web.Mvc.ModelBinders.Binders.DefaultBinder.BindModel( controllerContext, bindingContext );
		}
	}
}
