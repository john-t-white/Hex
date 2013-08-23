using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.ModelBinders
{
	public class CheckBoxListModelBinder
		: IModelBinder
	{
		public object BindModel( ControllerContext controllerContext, ModelBindingContext bindingContext )
		{
			string checkBoxListKey = string.Format( "{0}.CheckBoxList", bindingContext.ModelName );
			ValueProviderResult isCheckBoxListResult = bindingContext.ValueProvider.GetValue( checkBoxListKey );
			if( isCheckBoxListResult != null )
			{
				var checkBoxListItems = bindingContext.ValueProvider.GetValue( bindingContext.ModelName );
				if( checkBoxListItems == null )
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
