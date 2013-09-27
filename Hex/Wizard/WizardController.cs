using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hex.Wizard
{
	public abstract class WizardController
		: Controller
	{
		#region Controller Members

		protected override void Initialize( RequestContext requestContext )
		{
			base.Initialize( requestContext );

			this.WizardContext = new WizardContext( requestContext, this );
		}

		protected override IActionInvoker CreateActionInvoker()
		{
			return new WizardControllerActionInvoker();
		}

		public new IWizardActionInvoker ActionInvoker
		{
			get
			{
				return ( IWizardActionInvoker )base.ActionInvoker;
			}
			set
			{
				base.ActionInvoker = value;
			}
		}

		#endregion

		public IWizardContext WizardContext { get; set; }
	}
}
