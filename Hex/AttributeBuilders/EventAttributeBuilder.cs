using Hex.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex.AttributeBuilders
{
	public class EventAttributeBuilder
	{
		private AttributeCollection _attributes;

		public EventAttributeBuilder( AttributeCollection attributes )
		{
			this._attributes = attributes;
		}

		public EventAttributeBuilder Event( string name, object value )
		{
			if( !string.IsNullOrWhiteSpace( name ) )
			{
				this._attributes[ name ] = value;
			}

			return this;
		}

		public EventAttributeBuilder OnBlur( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnBlur ] = script;

			return this;
		}

		public EventAttributeBuilder OnChange( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnChange ] = script;

			return this;
		}

		public EventAttributeBuilder OnClick( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnClick ] = script;

			return this;
		}

		public EventAttributeBuilder OnContextMenu( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnContextMenu ] = script;

			return this;
		}

		public EventAttributeBuilder OnDblClick( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnDblClick ] = script;

			return this;
		}

		public EventAttributeBuilder OnDrag( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnDrag ] = script;

			return this;
		}

		public EventAttributeBuilder OnDragEnd( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnDragEnd ] = script;

			return this;
		}

		public EventAttributeBuilder OnDragEnter( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnDragEnter ] = script;

			return this;
		}

		public EventAttributeBuilder OnDragLeave( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnDragLeave ] = script;

			return this;
		}

		public EventAttributeBuilder OnDragOver( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnDragOver ] = script;

			return this;
		}

		public EventAttributeBuilder OnDragStart( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnDragStart ] = script;

			return this;
		}

		public EventAttributeBuilder OnDrop( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnDrop ] = script;

			return this;
		}

		public EventAttributeBuilder OnFocus( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnFocus ] = script;

			return this;
		}

		public EventAttributeBuilder OnFormChange( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnFormChange ] = script;

			return this;
		}

		public EventAttributeBuilder OnFormInput( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnFormInput ] = script;

			return this;
		}

		public EventAttributeBuilder OnInput( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnInput ] = script;

			return this;
		}

		public EventAttributeBuilder OnInvalid( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnInvalid ] = script;

			return this;
		}

		public EventAttributeBuilder OnKeyDown( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnKeyDown ] = script;

			return this;
		}

		public EventAttributeBuilder OnKeyPress( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnKeyPress ] = script;

			return this;
		}

		public EventAttributeBuilder OnKeyUp( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnKeyUp ] = script;

			return this;
		}

		public EventAttributeBuilder OnMouseDown( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnMouseDown ] = script;

			return this;
		}

		public EventAttributeBuilder OnMouseMove( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnMouseMove ] = script;

			return this;
		}

		public EventAttributeBuilder OnMouseOut( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnMouseOut ] = script;

			return this;
		}

		public EventAttributeBuilder OnMouseOver( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnMouseOver ] = script;

			return this;
		}

		public EventAttributeBuilder OnMouseUp( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnMouseUp ] = script;

			return this;
		}

		public EventAttributeBuilder OnMouseWheel( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnMouseWheel ] = script;

			return this;
		}

		public EventAttributeBuilder OnScroll( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnScroll ] = script;

			return this;
		}

		public EventAttributeBuilder OnSelect( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnSelect ] = script;

			return this;
		}

		public EventAttributeBuilder OnSubmit( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnSubmit ] = script;

			return this;
		}
	}
}
