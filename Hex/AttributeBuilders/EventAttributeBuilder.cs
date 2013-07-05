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
			this._attributes[ HtmlAttributes.OnBlur ] = script;

			return this;
		}

		public EventAttributeBuilder OnChange( string script )
		{
			this._attributes[ HtmlAttributes.OnChange ] = script;

			return this;
		}

		public EventAttributeBuilder OnClick( string script )
		{
			this._attributes[ HtmlAttributes.OnClick ] = script;

			return this;
		}

		public EventAttributeBuilder OnContextMenu( string script )
		{
			this._attributes[ HtmlAttributes.OnContextMenu ] = script;

			return this;
		}

		public EventAttributeBuilder OnDblClick( string script )
		{
			this._attributes[ HtmlAttributes.OnDblClick ] = script;

			return this;
		}

		public EventAttributeBuilder OnDrag( string script )
		{
			this._attributes[ HtmlAttributes.OnDrag ] = script;

			return this;
		}

		public EventAttributeBuilder OnDragEnd( string script )
		{
			this._attributes[ HtmlAttributes.OnDragEnd ] = script;

			return this;
		}

		public EventAttributeBuilder OnDragEnter( string script )
		{
			this._attributes[ HtmlAttributes.OnDragEnter ] = script;

			return this;
		}

		public EventAttributeBuilder OnDragLeave( string script )
		{
			this._attributes[ HtmlAttributes.OnDragLeave ] = script;

			return this;
		}

		public EventAttributeBuilder OnDragOver( string script )
		{
			this._attributes[ HtmlAttributes.OnDragOver ] = script;

			return this;
		}

		public EventAttributeBuilder OnDragStart( string script )
		{
			this._attributes[ HtmlAttributes.OnDragStart ] = script;

			return this;
		}

		public EventAttributeBuilder OnDrop( string script )
		{
			this._attributes[ HtmlAttributes.OnDrop ] = script;

			return this;
		}

		public EventAttributeBuilder OnFocus( string script )
		{
			this._attributes[ HtmlAttributes.OnFocus ] = script;

			return this;
		}

		public EventAttributeBuilder OnFormChange( string script )
		{
			this._attributes[ HtmlAttributes.OnFormChange ] = script;

			return this;
		}

		public EventAttributeBuilder OnFormInput( string script )
		{
			this._attributes[ HtmlAttributes.OnFormInput ] = script;

			return this;
		}

		public EventAttributeBuilder OnInput( string script )
		{
			this._attributes[ HtmlAttributes.OnInput ] = script;

			return this;
		}

		public EventAttributeBuilder OnInvalid( string script )
		{
			this._attributes[ HtmlAttributes.OnInvalid ] = script;

			return this;
		}

		public EventAttributeBuilder OnKeyDown( string script )
		{
			this._attributes[ HtmlAttributes.OnKeyDown ] = script;

			return this;
		}

		public EventAttributeBuilder OnKeyPress( string script )
		{
			this._attributes[ HtmlAttributes.OnKeyPress ] = script;

			return this;
		}

		public EventAttributeBuilder OnKeyUp( string script )
		{
			this._attributes[ HtmlAttributes.OnKeyUp ] = script;

			return this;
		}

		public EventAttributeBuilder OnMouseDown( string script )
		{
			this._attributes[ HtmlAttributes.OnMouseDown ] = script;

			return this;
		}

		public EventAttributeBuilder OnMouseMove( string script )
		{
			this._attributes[ HtmlAttributes.OnMouseMove ] = script;

			return this;
		}

		public EventAttributeBuilder OnMouseOut( string script )
		{
			this._attributes[ HtmlAttributes.OnMouseOut ] = script;

			return this;
		}

		public EventAttributeBuilder OnMouseOver( string script )
		{
			this._attributes[ HtmlAttributes.OnMouseOver ] = script;

			return this;
		}

		public EventAttributeBuilder OnMouseUp( string script )
		{
			this._attributes[ HtmlAttributes.OnMouseUp ] = script;

			return this;
		}

		public EventAttributeBuilder OnMouseWheel( string script )
		{
			this._attributes[ HtmlAttributes.OnMouseWheel ] = script;

			return this;
		}

		public EventAttributeBuilder OnScroll( string script )
		{
			this._attributes[ HtmlAttributes.OnScroll ] = script;

			return this;
		}

		public EventAttributeBuilder OnSelect( string script )
		{
			this._attributes[ HtmlAttributes.OnSelect ] = script;

			return this;
		}

		public EventAttributeBuilder OnSubmit( string script )
		{
			this._attributes[ HtmlAttributes.OnSubmit ] = script;

			return this;
		}
	}
}
