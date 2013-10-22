using Hex.AttributeBuilders;
using Hex.Extensions;
using Hex.Wizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Hex.Html
{
	/// <summary>
	/// Represents support for HTML forms used with the WizardController in an application with an expression for specifying HTML attributes.
	/// </summary>
	public static class WizardFormExtensions
	{
		/// <summary>
		/// Writes an opening &lt;form&gt; tag to the response used with the WizardController.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <returns>An opening &lt;form&gt; tag with the hidden wizard state field.</returns>
		public static MvcForm BeginWizardForm( this HtmlHelper htmlHelper )
		{
			MvcForm mvcForm = htmlHelper.BeginForm();

			WizardFormExtensions.WriteHiddenWizardTokenField( htmlHelper );

			return mvcForm;
		}

		/// <summary>
		/// Writes an opening &lt;form&gt; tag to the response used with the WizardController with the html attributes specified.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;form&gt; tag with the hidden wizard state field.</returns>
		public static MvcForm BeginWizardForm( this HtmlHelper htmlHelper, object htmlAttributes )
		{
			return htmlHelper.BeginWizardForm( HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		/// <summary>
		/// Writes an opening &lt;form&gt; tag to the response used with the WizardController with the html attributes specified.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="htmlAttributes">A dictionary that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;form&gt; tag with the hidden wizard state field.</returns>
		public static MvcForm BeginWizardForm( this HtmlHelper htmlHelper, IDictionary<string, object> htmlAttributes )
		{
			string rawUrl = htmlHelper.ViewContext.HttpContext.Request.RawUrl;
			MvcForm mvcForm = FormHelper.Execute( htmlHelper, rawUrl, FormMethod.Post, htmlAttributes );

			WizardFormExtensions.WriteHiddenWizardTokenField( htmlHelper );

			return mvcForm;
		}

		/// <summary>
		/// Writes an opening &lt;form&gt; tag to the response used with the WizardController with the html attributes specified.
		/// </summary>
		/// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
		/// <param name="attributeExpression">An expression that contains the HTML attributes to set for the element.</param>
		/// <returns>An opening &lt;form&gt; tag with the hidden wizard state field.</returns>
		public static MvcForm BeginWizardForm( this HtmlHelper htmlHelper, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginWizardForm( attributeExpression.GetAttributes() );
		}

		private static void WriteHiddenWizardTokenField( HtmlHelper htmlHelper )
		{
			WizardController wizardController = WizardController.FromHtmlHelper( htmlHelper );

			string wizardStateToken = wizardController.SaveWizardState( htmlHelper.ViewContext.Controller.ControllerContext );

			TagBuilder wizardStateTagBuilder = new TagBuilder( HtmlElements.Input );
			wizardStateTagBuilder.MergeAttribute( HtmlAttributes.Type, HtmlHelper.GetInputTypeString( InputType.Hidden ) );
			wizardStateTagBuilder.MergeAttribute( HtmlAttributes.Name, Constants.WIZARD_STATE_TOKEN_HIDDEN_FIELD_NAME );
			wizardStateTagBuilder.MergeAttribute( HtmlAttributes.Value, wizardStateToken );

			htmlHelper.ViewContext.Writer.Write( wizardStateTagBuilder.ToString( TagRenderMode.SelfClosing ) );
		}
	}
}
