using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.Wizard
{
	public class WizardActionDescriptor
		: ActionDescriptor
	{
		private bool _displayAttributeInitialized = false;
		private DisplayAttribute _displayAttribute = null;

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
				DisplayAttribute displayAttribute = this.GetDisplayAttribute();
				if( displayAttribute != null )
				{
					return displayAttribute.GetName();
				}

				return null;
			}
		}

		public string Description
		{
			get
			{
				DisplayAttribute displayAttribute = this.GetDisplayAttribute();
				if( displayAttribute != null )
				{
					return displayAttribute.GetDescription();
				}

				return null;
			}
		}

		public int Order
		{
			get
			{
				DisplayAttribute displayAttribute = this.GetDisplayAttribute();
				if( displayAttribute != null )
				{
					return displayAttribute.GetOrder() ?? 0;
				}

				return 0;
			}
		}

		#region Internal Methods

		private DisplayAttribute GetDisplayAttribute()
		{
			if( !this._displayAttributeInitialized )
			{
				this._displayAttribute = this.ActionDescriptor.GetCustomAttributes( typeof( DisplayAttribute ), false ).FirstOrDefault() as DisplayAttribute;
				this._displayAttributeInitialized = true;
			}

			return this._displayAttribute;
		}

		#endregion
	}
}
