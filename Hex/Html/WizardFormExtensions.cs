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
	public static class WizardFormExtensions
	{
		public static MvcForm BeginWizardForm( this HtmlHelper htmlHelper )
		{
			MvcForm mvcForm = htmlHelper.BeginForm();

			WizardFormExtensions.WriteHiddenWizardTokenField( htmlHelper );

			return mvcForm;
		}

		public static MvcForm BeginWizardForm( this HtmlHelper htmlHelper, object htmlAttributes )
		{
			return htmlHelper.BeginWizardForm( HtmlHelper.AnonymousObjectToHtmlAttributes( htmlAttributes ) );
		}

		public static MvcForm BeginWizardForm( this HtmlHelper htmlHelper, IDictionary<string, object> htmlAttributes )
		{
			string rawUrl = htmlHelper.ViewContext.HttpContext.Request.RawUrl;
			MvcForm mvcForm = FormHelper.Execute( htmlHelper, rawUrl, FormMethod.Post, htmlAttributes );

			WizardFormExtensions.WriteHiddenWizardTokenField( htmlHelper );

			return mvcForm;
		}

		public static MvcForm BeginWizardForm( this HtmlHelper htmlHelper, Action<HtmlAttributeBuilder> attributeExpression )
		{
			return htmlHelper.BeginWizardForm( attributeExpression.GetAttributes() );
		}

		private static void WriteHiddenWizardTokenField( HtmlHelper htmlHelper )
		{
			WizardController wizardController = WizardController.FromHtmlHelper( htmlHelper );

			string wizardStateToken = wizardController.SaveWizardState( htmlHelper.ViewContext.RequestContext );

			TagBuilder wizardStateTagBuilder = new TagBuilder( HtmlElements.Input );
			wizardStateTagBuilder.MergeAttribute( HtmlAttributes.Type, HtmlHelper.GetInputTypeString( InputType.Hidden ) );
			wizardStateTagBuilder.MergeAttribute( HtmlAttributes.Name, Constants.WIZARD_STATE_TOKEN_HIDDEN_FIELD_NAME );
			wizardStateTagBuilder.MergeAttribute( HtmlAttributes.Value, wizardStateToken );

			htmlHelper.ViewContext.Writer.Write( wizardStateTagBuilder.ToString( TagRenderMode.SelfClosing ) );
		}
	}
}
