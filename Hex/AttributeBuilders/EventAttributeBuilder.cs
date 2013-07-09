using Hex.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hex.AttributeBuilders
{
	/// <summary>
	/// Provides a fluent way to specify HTML event attributes and their values.
	/// </summary>
	public class EventAttributeBuilder
	{
		private AttributeCollection _attributes;

		/// <summary>
		/// Instaniates a new instance of <see cref="Hex.AttributeBuilders.EventAttributeBuilder"/>.
		/// </summary>
		/// <param name="attributes"></param>
		public EventAttributeBuilder( AttributeCollection attributes )
		{
			this._attributes = attributes;
		}

		/// <summary>
		/// Provides a way of adding an event.
		/// </summary>
		/// <param name="name">The name of the event attribute.</param>
		/// <param name="script">The script.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.EventAttributeBuilder"/>.</returns>
		public EventAttributeBuilder Event( string name, object script )
		{
			if( !string.IsNullOrWhiteSpace( name ) )
			{
				this._attributes[ name ] = script;
			}

			return this;
		}

		/// <summary>
		/// Represents the HTML event attribute "onblur".
		/// </summary>
		/// <param name="script">The script.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.EventAttributeBuilder"/>.</returns>
		public EventAttributeBuilder OnBlur( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnBlur ] = script;

			return this;
		}

		/// <summary>
		/// Represents the HTML event attribute "onchange".
		/// </summary>
		/// <param name="script">The script.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.EventAttributeBuilder"/>.</returns>
		public EventAttributeBuilder OnChange( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnChange ] = script;

			return this;
		}

		/// <summary>
		/// Represents the HTML event attribute "onclick".
		/// </summary>
		/// <param name="script">The script.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.EventAttributeBuilder"/>.</returns>
		public EventAttributeBuilder OnClick( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnClick ] = script;

			return this;
		}

		/// <summary>
		/// Represents the HTML event attribute "oncontextmenu".
		/// </summary>
		/// <param name="script">The script.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.EventAttributeBuilder"/>.</returns>
		public EventAttributeBuilder OnContextMenu( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnContextMenu ] = script;

			return this;
		}

		/// <summary>
		/// Represents the HTML event attribute "ondblclick".
		/// </summary>
		/// <param name="script">The script.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.EventAttributeBuilder"/>.</returns>
		public EventAttributeBuilder OnDblClick( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnDblClick ] = script;

			return this;
		}

		/// <summary>
		/// Represents the HTML event attribute "ondrag".
		/// </summary>
		/// <param name="script">The script.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.EventAttributeBuilder"/>.</returns>
		public EventAttributeBuilder OnDrag( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnDrag ] = script;

			return this;
		}

		/// <summary>
		/// Represents the HTML event attribute "ondragend".
		/// </summary>
		/// <param name="script">The script.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.EventAttributeBuilder"/>.</returns>
		public EventAttributeBuilder OnDragEnd( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnDragEnd ] = script;

			return this;
		}

		/// <summary>
		/// Represents the HTML event attribute "ondragenter".
		/// </summary>
		/// <param name="script">The script.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.EventAttributeBuilder"/>.</returns>
		public EventAttributeBuilder OnDragEnter( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnDragEnter ] = script;

			return this;
		}

		/// <summary>
		/// Represents the HTML event attribute "ondragleave".
		/// </summary>
		/// <param name="script">The script.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.EventAttributeBuilder"/>.</returns>
		public EventAttributeBuilder OnDragLeave( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnDragLeave ] = script;

			return this;
		}

		/// <summary>
		/// Represents the HTML event attribute "ondragover".
		/// </summary>
		/// <param name="script">The script.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.EventAttributeBuilder"/>.</returns>
		public EventAttributeBuilder OnDragOver( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnDragOver ] = script;

			return this;
		}

		/// <summary>
		/// Represents the HTML event attribute "ondragstart".
		/// </summary>
		/// <param name="script">The script.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.EventAttributeBuilder"/>.</returns>
		public EventAttributeBuilder OnDragStart( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnDragStart ] = script;

			return this;
		}

		/// <summary>
		/// Represents the HTML event attribute "ondrop".
		/// </summary>
		/// <param name="script">The script.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.EventAttributeBuilder"/>.</returns>
		public EventAttributeBuilder OnDrop( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnDrop ] = script;

			return this;
		}

		/// <summary>
		/// Represents the HTML event attribute "onfocus".
		/// </summary>
		/// <param name="script">The script.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.EventAttributeBuilder"/>.</returns>
		public EventAttributeBuilder OnFocus( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnFocus ] = script;

			return this;
		}

		/// <summary>
		/// Represents the HTML event attribute "onformchange".
		/// </summary>
		/// <param name="script">The script.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.EventAttributeBuilder"/>.</returns>
		public EventAttributeBuilder OnFormChange( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnFormChange ] = script;

			return this;
		}

		/// <summary>
		/// Represents the HTML event attribute "onforminput".
		/// </summary>
		/// <param name="script">The script.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.EventAttributeBuilder"/>.</returns>
		public EventAttributeBuilder OnFormInput( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnFormInput ] = script;

			return this;
		}

		/// <summary>
		/// Represents the HTML event attribute "oninput".
		/// </summary>
		/// <param name="script">The script.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.EventAttributeBuilder"/>.</returns>
		public EventAttributeBuilder OnInput( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnInput ] = script;

			return this;
		}

		/// <summary>
		/// Represents the HTML event attribute "oninvalid".
		/// </summary>
		/// <param name="script">The script.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.EventAttributeBuilder"/>.</returns>
		public EventAttributeBuilder OnInvalid( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnInvalid ] = script;

			return this;
		}

		/// <summary>
		/// Represents the HTML event attribute "onkeydown".
		/// </summary>
		/// <param name="script">The script.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.EventAttributeBuilder"/>.</returns>
		public EventAttributeBuilder OnKeyDown( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnKeyDown ] = script;

			return this;
		}

		/// <summary>
		/// Represents the HTML event attribute "onkeypress".
		/// </summary>
		/// <param name="script">The script.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.EventAttributeBuilder"/>.</returns>
		public EventAttributeBuilder OnKeyPress( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnKeyPress ] = script;

			return this;
		}

		/// <summary>
		/// Represents the HTML event attribute "onkeyup".
		/// </summary>
		/// <param name="script">The script.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.EventAttributeBuilder"/>.</returns>
		public EventAttributeBuilder OnKeyUp( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnKeyUp ] = script;

			return this;
		}

		/// <summary>
		/// Represents the HTML event attribute "onmousedown".
		/// </summary>
		/// <param name="script">The script.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.EventAttributeBuilder"/>.</returns>
		public EventAttributeBuilder OnMouseDown( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnMouseDown ] = script;

			return this;
		}

		/// <summary>
		/// Represents the HTML event attribute "onmousemove".
		/// </summary>
		/// <param name="script">The script.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.EventAttributeBuilder"/>.</returns>
		public EventAttributeBuilder OnMouseMove( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnMouseMove ] = script;

			return this;
		}

		/// <summary>
		/// Represents the HTML event attribute "onmouseout".
		/// </summary>
		/// <param name="script">The script.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.EventAttributeBuilder"/>.</returns>
		public EventAttributeBuilder OnMouseOut( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnMouseOut ] = script;

			return this;
		}

		/// <summary>
		/// Represents the HTML event attribute "onmouseover".
		/// </summary>
		/// <param name="script">The script.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.EventAttributeBuilder"/>.</returns>
		public EventAttributeBuilder OnMouseOver( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnMouseOver ] = script;

			return this;
		}

		/// <summary>
		/// Represents the HTML event attribute "onmouseup".
		/// </summary>
		/// <param name="script">The script.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.EventAttributeBuilder"/>.</returns>
		public EventAttributeBuilder OnMouseUp( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnMouseUp ] = script;

			return this;
		}

		/// <summary>
		/// Represents the HTML event attribute "onmousewheel".
		/// </summary>
		/// <param name="script">The script.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.EventAttributeBuilder"/>.</returns>
		public EventAttributeBuilder OnMouseWheel( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnMouseWheel ] = script;

			return this;
		}

		/// <summary>
		/// Represents the HTML event attribute "onscroll".
		/// </summary>
		/// <param name="script">The script.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.EventAttributeBuilder"/>.</returns>
		public EventAttributeBuilder OnScroll( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnScroll ] = script;

			return this;
		}

		/// <summary>
		/// Represents the HTML event attribute "onselect".
		/// </summary>
		/// <param name="script">The script.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.EventAttributeBuilder"/>.</returns>
		public EventAttributeBuilder OnSelect( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnSelect ] = script;

			return this;
		}

		/// <summary>
		/// Represents the HTML event attribute "onsubmit".
		/// </summary>
		/// <param name="script">The script.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.EventAttributeBuilder"/>.</returns>
		public EventAttributeBuilder OnSubmit( string script )
		{
			this._attributes[ HtmlAttributes.Events.OnSubmit ] = script;

			return this;
		}
	}
}
