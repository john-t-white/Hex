using Hex.AttributeBuilders;
using Hex.Extensions;
using Hex.Html;
using Hex.Wizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.Html
{
	public static class BeginWizardButtonExtensions
	{
		private const string PREVIOUS_SUBMIT_BUTTON_VALUE = "Previous";
		private const string NEXT_SUBMIT_BUTTON_VALUE = "Next";

		public static MvcButton BeginPreviousWizardStepSubmitButton( this HtmlHelper htmlHelper )
		{
			return htmlHelper.BeginPreviousWizardStepSubmitButton( ( IDictionary<string, object> )null );
		}

		public static MvcButton BeginPreviousWizardStepSubmitButton( this HtmlHelper htmlHelper, object htmlAttributes )
		{
			return htmlHelper.BeginPreviousWizardStepSubmitButton( HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		public static MvcButton BeginPreviousWizardStepSubmitButton( this HtmlHelper htmlHelper, IDictionary<string, object> htmlAttributes )
		{
			htmlAttributes = htmlAttributes ?? new Dictionary<string, object>();

			WizardController wizardController = WizardController.FromHtmlHelper( htmlHelper );
			if( !wizardController.WizardSteps.HasPreviousStep() )
			{
				htmlAttributes[ HtmlAttributes.Disabled ] = HtmlAttributes.Disabled;
			}

			return htmlHelper.BeginSubmitButton( Constants.WIZARD_PREVIOUS_BUTTON_NAME, PREVIOUS_SUBMIT_BUTTON_VALUE, htmlAttributes );
		}

		public static MvcButton BeginPreviousWizardStepSubmitButton( this HtmlHelper htmlHelper, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginPreviousWizardStepSubmitButton( attributeExpression.GetAttributes() );
		}



		public static MvcButton BeginNextWizardStepSubmitButton( this HtmlHelper htmlHelper )
		{
			return htmlHelper.BeginNextWizardStepSubmitButton( ( IDictionary<string, object> )null );
		}

		public static MvcButton BeginNextWizardStepSubmitButton( this HtmlHelper htmlHelper, object htmlAttributes )
		{
			return htmlHelper.BeginNextWizardStepSubmitButton( HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		public static MvcButton BeginNextWizardStepSubmitButton( this HtmlHelper htmlHelper, IDictionary<string, object> htmlAttributes )
		{
			htmlAttributes = htmlAttributes ?? new Dictionary<string, object>();

			WizardController wizardController = WizardController.FromHtmlHelper( htmlHelper );
			if( !wizardController.WizardSteps.HasNextStep() )
			{
				htmlAttributes[ HtmlAttributes.Disabled ] = HtmlAttributes.Disabled;
			}

			return htmlHelper.BeginSubmitButton( Constants.WIZARD_NEXT_BUTTON_NAME, NEXT_SUBMIT_BUTTON_VALUE, htmlAttributes );
		}

		public static MvcButton BeginNextWizardStepSubmitButton( this HtmlHelper htmlHelper, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginNextWizardStepSubmitButton( attributeExpression.GetAttributes() );
		}
	}
}
