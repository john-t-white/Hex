using Hex.AttributeBuilders;
using Hex.Extensions;
using Hex.Wizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.Html
{
	public static class WizardButtonExtensions
	{
		public static MvcHtmlString PreviousWizardStepSubmitInputButton( this HtmlHelper htmlHelper )
		{
			return htmlHelper.PreviousWizardStepSubmitInputButton( null, ( IDictionary<string, object> )null );
		}

		public static MvcHtmlString PreviousWizardStepSubmitInputButton( this HtmlHelper htmlHelper, object htmlAttributes )
		{
			return htmlHelper.PreviousWizardStepSubmitInputButton( null, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		public static MvcHtmlString PreviousWizardStepSubmitInputButton( this HtmlHelper htmlHelper, IDictionary<string, object> htmlAttributes )
		{
			return htmlHelper.PreviousWizardStepSubmitInputButton( null, htmlAttributes );
		}

		public static MvcHtmlString PreviousWizardStepSubmitInputButton( this HtmlHelper htmlHelper, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.PreviousWizardStepSubmitInputButton( null, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString PreviousWizardStepSubmitInputButton( this HtmlHelper htmlHelper, string value )
		{
			return htmlHelper.PreviousWizardStepSubmitInputButton( value, ( IDictionary<string, object> )null );
		}

		public static MvcHtmlString PreviousWizardStepSubmitInputButton( this HtmlHelper htmlHelper, string value, object htmlAttributes )
		{
			return htmlHelper.PreviousWizardStepSubmitInputButton( value, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		public static MvcHtmlString PreviousWizardStepSubmitInputButton( this HtmlHelper htmlHelper, string value, IDictionary<string, object> htmlAttributes )
		{
			value = value ?? "Previous";
			htmlAttributes = htmlAttributes ?? new Dictionary<string, object>();

			WizardController wizardController = WizardController.FromHtmlHelper( htmlHelper );
			if( !wizardController.WizardSteps.HasPreviousStep() )
			{
				htmlAttributes[ HtmlAttributes.Disabled ] = HtmlAttributes.Disabled;
			}

			return htmlHelper.SubmitInputButton( Constants.WIZARD_PREVIOUS_BUTTON_NAME, value, htmlAttributes );
		}

		public static MvcHtmlString PreviousWizardStepSubmitInputButton( this HtmlHelper htmlHelper, string value, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.PreviousWizardStepSubmitInputButton( value, attributeExpression.GetAttributes() );
		}




		public static MvcHtmlString NextWizardStepSubmitInputButton( this HtmlHelper htmlHelper )
		{
			return htmlHelper.NextWizardStepSubmitInputButton( null, ( IDictionary<string, object> )null );
		}

		public static MvcHtmlString NextWizardStepSubmitInputButton( this HtmlHelper htmlHelper, object htmlAttributes )
		{
			return htmlHelper.NextWizardStepSubmitInputButton( null, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		public static MvcHtmlString NextWizardStepSubmitInputButton( this HtmlHelper htmlHelper, IDictionary<string, object> htmlAttributes )
		{
			return htmlHelper.NextWizardStepSubmitInputButton( null, htmlAttributes );
		}

		public static MvcHtmlString NextWizardStepSubmitInputButton( this HtmlHelper htmlHelper, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.NextWizardStepSubmitInputButton( null, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString NextWizardStepSubmitInputButton( this HtmlHelper htmlHelper, string value )
		{
			return htmlHelper.NextWizardStepSubmitInputButton( value, ( IDictionary<string, object> )null );
		}

		public static MvcHtmlString NextWizardStepSubmitInputButton( this HtmlHelper htmlHelper, string value, object htmlAttributes )
		{
			return htmlHelper.NextWizardStepSubmitInputButton( value, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		public static MvcHtmlString NextWizardStepSubmitInputButton( this HtmlHelper htmlHelper, string value, IDictionary<string, object> htmlAttributes )
		{
			value = value ?? "Next";
			htmlAttributes = htmlAttributes ?? new Dictionary<string, object>();

			WizardController wizardControllerContext = WizardController.FromHtmlHelper( htmlHelper );
			if( !wizardControllerContext.WizardSteps.HasNextStep() )
			{
				htmlAttributes[ HtmlAttributes.Disabled ] = HtmlAttributes.Disabled;
			}

			return htmlHelper.SubmitInputButton( Constants.WIZARD_NEXT_BUTTON_NAME, value, htmlAttributes );
		}

		public static MvcHtmlString NextWizardStepSubmitInputButton( this HtmlHelper htmlHelper, string value, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.NextWizardStepSubmitInputButton( value, attributeExpression.GetAttributes() );
		}
	}
}
