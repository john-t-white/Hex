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
	/// <summary>
	/// Represents support for wizard next/previous buttons in an application with HTML attributes.
	/// </summary>
	public static class BeginWizardButtonExtensions
	{
		private const string PREVIOUS_SUBMIT_BUTTON_VALUE = "Previous";
		private const string NEXT_SUBMIT_BUTTON_VALUE = "Next";

		/// <summary>
		/// Writes an opening &lt;button&gt; tag to move to the previous step to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <returns>An opening &lt;button&gt; tag with type="button" for moving to the previous step.</returns>
		public static MvcButton BeginPreviousWizardStepSubmitButton( this HtmlHelper htmlHelper )
		{
			return htmlHelper.BeginPreviousWizardStepSubmitButton( ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Writes an opening &lt;button&gt; tag to move to the previous step to the response with the specified html attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;button&gt; tag with type="button" for moving to the previous step.</returns>
		public static MvcButton BeginPreviousWizardStepSubmitButton( this HtmlHelper htmlHelper, object htmlAttributes )
		{
			return htmlHelper.BeginPreviousWizardStepSubmitButton( HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		/// <summary>
		/// Writes an opening &lt;button&gt; tag to move to the previous step to the response with the specified html attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;button&gt; tag with type="button" for moving to the previous step.</returns>
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

		/// <summary>
		/// Writes an opening &lt;button&gt; tag to move to the previous step to the response with the specified html attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;button&gt; tag with type="button" for moving to the previous step.</returns>
		public static MvcButton BeginPreviousWizardStepSubmitButton( this HtmlHelper htmlHelper, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginPreviousWizardStepSubmitButton( attributeExpression.GetAttributes() );
		}

		/// <summary>
		/// Writes an opening &lt;button&gt; tag to move to the next step to the response.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <returns>An opening &lt;button&gt; tag with type="button" for moving to the next step.</returns>
		public static MvcButton BeginNextWizardStepSubmitButton( this HtmlHelper htmlHelper )
		{
			return htmlHelper.BeginNextWizardStepSubmitButton( ( IDictionary<string, object> )null );
		}

		/// <summary>
		/// Writes an opening &lt;button&gt; tag to move to the next step to the response with the specified html attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;button&gt; tag with type="button" for moving to the next step.</returns>
		public static MvcButton BeginNextWizardStepSubmitButton( this HtmlHelper htmlHelper, object htmlAttributes )
		{
			return htmlHelper.BeginNextWizardStepSubmitButton( HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		/// <summary>
		/// Writes an opening &lt;button&gt; tag to move to the next step to the response with the specified html attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;button&gt; tag with type="button" for moving to the next step.</returns>
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

		/// <summary>
		/// Writes an opening &lt;button&gt; tag to move to the next step to the response with the specified html attributes.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;button&gt; tag with type="button" for moving to the next step.</returns>
		public static MvcButton BeginNextWizardStepSubmitButton( this HtmlHelper htmlHelper, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginNextWizardStepSubmitButton( attributeExpression.GetAttributes() );
		}
	}
}
