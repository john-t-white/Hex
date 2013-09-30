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
			WizardController wizardController = WizardController.FromHtmlHelper( htmlHelper );

			MvcForm mvcForm = htmlHelper.BeginForm();

			string wizardStateToken = wizardController.SaveWizardState( htmlHelper.ViewContext.RequestContext );

			TagBuilder wizardStateTagBuilder = new TagBuilder( HtmlElements.Input );
			wizardStateTagBuilder.MergeAttribute( HtmlAttributes.Type, HtmlHelper.GetInputTypeString( InputType.Hidden ) );
			wizardStateTagBuilder.MergeAttribute( HtmlAttributes.Name, Constants.WIZARD_STATE_TOKEN_HIDDEN_FIELD_NAME );
			wizardStateTagBuilder.MergeAttribute( HtmlAttributes.Value, wizardStateToken );

			htmlHelper.ViewContext.Writer.Write( wizardStateTagBuilder.ToString( TagRenderMode.SelfClosing ) );

			return mvcForm;
		}
	}
}
