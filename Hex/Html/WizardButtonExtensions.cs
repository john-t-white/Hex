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
		private const string PREVIOUS_SUBMIT_BUTTON_VALUE = "Previous";
		private const string NEXT_SUBMIT_BUTTON_VALUE = "Next";

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
			value = value ?? PREVIOUS_SUBMIT_BUTTON_VALUE;
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



		public static MvcHtmlString PreviousWizardStepSubmitButton( this HtmlHelper htmlHelper )
		{
			return htmlHelper.PreviousWizardStepSubmitButton( null, ( IDictionary<string, object> )null );
		}

		public static MvcHtmlString PreviousWizardStepSubmitButton( this HtmlHelper htmlHelper, object htmlAttributes )
		{
			return htmlHelper.PreviousWizardStepSubmitButton( null, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		public static MvcHtmlString PreviousWizardStepSubmitButton( this HtmlHelper htmlHelper, IDictionary<string, object> htmlAttributes )
		{
			return htmlHelper.PreviousWizardStepSubmitButton( null, htmlAttributes );
		}

		public static MvcHtmlString PreviousWizardStepSubmitButton( this HtmlHelper htmlHelper, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.PreviousWizardStepSubmitButton( null, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString PreviousWizardStepSubmitButton( this HtmlHelper htmlHelper, string buttonText )
		{
			return htmlHelper.PreviousWizardStepSubmitButton( buttonText, ( IDictionary<string, object> )null );
		}

		public static MvcHtmlString PreviousWizardStepSubmitButton( this HtmlHelper htmlHelper, string buttonText, object htmlAttributes )
		{
			return htmlHelper.PreviousWizardStepSubmitButton( buttonText, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		public static MvcHtmlString PreviousWizardStepSubmitButton( this HtmlHelper htmlHelper, string buttonText, IDictionary<string, object> htmlAttributes )
		{
			buttonText = buttonText ?? PREVIOUS_SUBMIT_BUTTON_VALUE;
			htmlAttributes = htmlAttributes ?? new Dictionary<string, object>();

			WizardController wizardController = WizardController.FromHtmlHelper( htmlHelper );
			if( !wizardController.WizardSteps.HasPreviousStep() )
			{
				htmlAttributes[ HtmlAttributes.Disabled ] = HtmlAttributes.Disabled;
			}

			return htmlHelper.SubmitButton( Constants.WIZARD_PREVIOUS_BUTTON_NAME, buttonText, PREVIOUS_SUBMIT_BUTTON_VALUE, htmlAttributes );
		}

		public static MvcHtmlString PreviousWizardStepSubmitButton( this HtmlHelper htmlHelper, string buttonText, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.PreviousWizardStepSubmitButton( buttonText, attributeExpression.GetAttributes() );
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
			value = value ?? NEXT_SUBMIT_BUTTON_VALUE;
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



		public static MvcHtmlString NextWizardStepSubmitButton( this HtmlHelper htmlHelper )
		{
			return htmlHelper.NextWizardStepSubmitButton( null, ( IDictionary<string, object> )null );
		}

		public static MvcHtmlString NextWizardStepSubmitButton( this HtmlHelper htmlHelper, object htmlAttributes )
		{
			return htmlHelper.NextWizardStepSubmitButton( null, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		public static MvcHtmlString NextWizardStepSubmitButton( this HtmlHelper htmlHelper, IDictionary<string, object> htmlAttributes )
		{
			return htmlHelper.NextWizardStepSubmitButton( null, htmlAttributes );
		}

		public static MvcHtmlString NextWizardStepSubmitButton( this HtmlHelper htmlHelper, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.NextWizardStepSubmitButton( null, attributeExpression.GetAttributes() );
		}

		public static MvcHtmlString NextWizardStepSubmitButton( this HtmlHelper htmlHelper, string buttonText )
		{
			return htmlHelper.NextWizardStepSubmitButton( buttonText, ( IDictionary<string, object> )null );
		}

		public static MvcHtmlString NextWizardStepSubmitButton( this HtmlHelper htmlHelper, string buttonText, object htmlAttributes )
		{
			return htmlHelper.NextWizardStepSubmitButton( buttonText, HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		public static MvcHtmlString NextWizardStepSubmitButton( this HtmlHelper htmlHelper, string buttonText, IDictionary<string, object> htmlAttributes )
		{
			buttonText = buttonText ?? NEXT_SUBMIT_BUTTON_VALUE;
			htmlAttributes = htmlAttributes ?? new Dictionary<string, object>();

			WizardController wizardControllerContext = WizardController.FromHtmlHelper( htmlHelper );
			if( !wizardControllerContext.WizardSteps.HasNextStep() )
			{
				htmlAttributes[ HtmlAttributes.Disabled ] = HtmlAttributes.Disabled;
			}

			return htmlHelper.SubmitButton( Constants.WIZARD_NEXT_BUTTON_NAME, buttonText, NEXT_SUBMIT_BUTTON_VALUE, htmlAttributes );
		}

		public static MvcHtmlString NextWizardStepSubmitButton( this HtmlHelper htmlHelper, string buttonText, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.NextWizardStepSubmitButton( buttonText, attributeExpression.GetAttributes() );
		}
	}
}
