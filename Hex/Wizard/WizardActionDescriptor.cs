using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.Wizard
{
	public class WizardActionDescriptor
		: ActionDescriptor
	{
		private bool _wizardStepAttributeInitialized = false;
		private WizardStepAttribute _wizardStepAttribute = null;

		public WizardActionDescriptor( ActionDescriptor actionDescriptor )
		{
			if( actionDescriptor == null )
			{
				throw new ArgumentNullException( "actionDescriptor" );
			}

			this.ActionDescriptor = actionDescriptor;
		}

		#region ActionDescriptor Members

		public override string ActionName
		{
			get
			{
				return this.ActionDescriptor.ActionName;
			}
		}

		public override ControllerDescriptor ControllerDescriptor
		{
			get
			{
				return this.ActionDescriptor.ControllerDescriptor;
			}
		}

		public override object Execute( ControllerContext controllerContext, IDictionary<string, object> parameters )
		{
			return this.ActionDescriptor.Execute( controllerContext, parameters );
		}

		public override ParameterDescriptor[] GetParameters()
		{
			return this.ActionDescriptor.GetParameters();
		}

		#endregion

		public ActionDescriptor ActionDescriptor { get; private set; }

		public string Name
		{
			get
			{
				WizardStepAttribute wizardStepAttribute = this.GetWizardStepAttribute();
				if( wizardStepAttribute != null )
				{
					return wizardStepAttribute.Name;
				}

				return null;
			}
		}

		public string Description
		{
			get
			{
				WizardStepAttribute wizardStepAttribute = this.GetWizardStepAttribute();
				if( wizardStepAttribute != null )
				{
					return wizardStepAttribute.Description;
				}

				return null;
			}
		}

		public int Order
		{
			get
			{
				WizardStepAttribute wizardStepAttribute = this.GetWizardStepAttribute();
				if( wizardStepAttribute != null )
				{
					return wizardStepAttribute.Order;
				}

				return 0;
			}
		}

		#region Internal Methods

		private WizardStepAttribute GetWizardStepAttribute()
		{
			if( !this._wizardStepAttributeInitialized )
			{
				this._wizardStepAttribute = this.ActionDescriptor.GetCustomAttributes( typeof( WizardStepAttribute ), false ).FirstOrDefault() as WizardStepAttribute;
				this._wizardStepAttributeInitialized = true;
			}

			return this._wizardStepAttribute;
		}

		#endregion
	}
}
