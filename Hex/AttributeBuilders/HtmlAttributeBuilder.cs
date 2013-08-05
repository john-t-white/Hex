using Hex;
using Hex.Extensions;
using Hex.Html;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace Hex.AttributeBuilders
{
	/// <summary>
	/// Provides a fluent way to specify HTML attributes and their values.
	/// </summary>
	public partial class HtmlAttributeBuilder
	{
		private const string DATA_ATTRIBUTE_PATTERN = "data-{0}";

		/// <summary>
		/// Instaniates a new instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.
		/// </summary>
		public HtmlAttributeBuilder()
		{
			this.Attributes = new AttributeCollection();
		}

		/// <summary>
		/// Contains the HTML attributes and their values.
		/// </summary>
		public AttributeCollection Attributes { get; private set; }

		/// <summary>
		/// Represents the HTML attribute "accesskey".
		/// </summary>
		/// <param name="accessKey">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder AccessKey( string accessKey )
		{
			this.Attributes[ HtmlAttributes.AccessKey ] = accessKey;

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "class". Multiple calls add additional values.
		/// </summary>
		/// <param name="classes">The list of values.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder AddClass( params string[] classes )
		{
			AttributeValueCollection attributeValues = null;
			if( !this.Attributes.TryGetValue<AttributeValueCollection>( HtmlAttributes.Class, out attributeValues ) )
			{
				attributeValues = new AttributeValueCollection();
				this.Attributes[ HtmlAttributes.Class ] = attributeValues;
			}

			attributeValues.AddRange( classes );
			return this;
		}

		/// <summary>
		/// Provides a way of adding a generic attribute that contains multiple values separated by a space. Multiple calls add additional values.
		/// </summary>
		/// <param name="name">The name of the attribute.</param>
		/// <param name="values">The list of values.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder AddMultiValueAttribute( string name, params object[] values )
		{
			if( !string.IsNullOrWhiteSpace( name ) )
			{
				AttributeValueCollection attributeValues = null;
				if( !this.Attributes.TryGetValue<AttributeValueCollection>( name, out attributeValues ) )
				{
					attributeValues = new AttributeValueCollection();
					this.Attributes[ name ] = attributeValues;
				}

				attributeValues.AddRange( values );
			}

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "alt".
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Alt( string value )
		{
			this.Attributes[ HtmlAttributes.Alt ] = value;

			return this;
		}

		/// <summary>
		/// Provides a way of adding a generic attribute and value.
		/// </summary>
		/// <param name="name">The name of the attribute.</param>
		/// <param name="value">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Attribute( string name, object value )
		{
			if( !string.IsNullOrWhiteSpace( name ) )
			{
				this.Attributes[ name ] = value;
			}

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "contenteditable" with the value of "true".
		/// </summary>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder ContentEditable()
		{
			return this.ContentEditable( ContentEditableType.True );
		}

		/// <summary>
		/// Represents the HTML attribute "contenteditable".
		/// </summary>
		/// <param name="contentEditableType">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder ContentEditable( ContentEditableType contentEditableType )
		{
			this.Attributes[ HtmlAttributes.ContentEditable ] = contentEditableType.ToLowerString();

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "contextmenu".
		/// </summary>
		/// <param name="elementId">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder ContextMenu( string elementId )
		{
			this.Attributes[ HtmlAttributes.ContextMenu ] = elementId;

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "data-*". The actual name of the attribute have "data-" automatically added to the beginning of the <paramref name="name"/>.
		/// </summary>
		/// <param name="name">The name of the attribute without "data-"</param>
		/// <param name="value">The value of the attribute.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Data( string name, object value )
		{
			if( !string.IsNullOrWhiteSpace( name ) )
			{
				string attributeName = string.Format( DATA_ATTRIBUTE_PATTERN, name );
				this.Attributes[ attributeName ] = value;
			}

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "dir".
		/// </summary>
		/// <param name="dir">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Dir( DirType dir )
		{
			return this.Dir( dir.ToLowerString() );
		}

		/// <summary>
		/// Represents the HTML attribute "dir".
		/// </summary>
		/// <param name="dir">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Dir( object dir )
		{
			this.Attributes[ HtmlAttributes.Dir ] = dir;

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "draggable" with the value of "true".
		/// </summary>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Draggable()
		{
			return this.Draggable( DraggableType.True );
		}

		/// <summary>
		/// Represents the HTML attribute "draggable".
		/// </summary>
		/// <param name="draggableType">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Draggable( DraggableType draggableType )
		{
			this.Attributes[ HtmlAttributes.Draggable ] = draggableType.ToLowerString();

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "dropzone" with the value of "move".
		/// </summary>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder DropZone()
		{
			return this.DropZone( DropZoneType.Move );
		}

		/// <summary>
		/// Represents the HTML attribute "dropzone".
		/// </summary>
		/// <param name="dropZoneType">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder DropZone( DropZoneType dropZoneType )
		{
			this.Attributes[ HtmlAttributes.DropZone ] = dropZoneType.ToLowerString();

			return this;
		}

		/// <summary>
		/// Provides a way to specify an expression for all HTML event attributes used by scripting.
		/// </summary>
		/// <param name="eventAttributeExpression">An expression that contains the HTML event attributes to set for the element.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Events( Action<EventAttributeBuilder> eventAttributeExpression )
		{
			if( eventAttributeExpression != null )
			{
				eventAttributeExpression( new EventAttributeBuilder( this.Attributes ) );
			}

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "hidden" with the value of "hidden".
		/// </summary>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Hidden()
		{
			return this.Hidden( true );
		}

		/// <summary>
		/// Represents the HTML attribute "hidden". True will add the attribute, false will remove the attribute if it has been specified.
		/// </summary>
		/// <param name="hidden">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Hidden( bool hidden )
		{
			this.Attributes.AddOrRemoveMinimizedAttribute( HtmlAttributes.Hidden, hidden );

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "id".
		/// </summary>
		/// <param name="id">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Id( string id )
		{
			this.Attributes[ HtmlAttributes.Id ] = id;

			return this;
		}

		/// <summary>
		/// Provides a way of adding attributes based on a condition.
		/// </summary>
		/// <param name="condition">The condition to be met.</param>
		/// <param name="trueAttributeExpression">An expression that contains the HTML attributes to set for the element if the condition is true.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder If( bool condition, Action<HtmlAttributeBuilder> trueAttributeExpression )
		{
			return this.If( condition, trueAttributeExpression, null );
		}

		/// <summary>
		/// Provides a way of adding attributes based on a condition.
		/// </summary>
		/// <param name="condition">The condition to be met.</param>
		/// <param name="trueAttributeExpression">An expression that contains the HTML attributes to set for the element if the condition is true.</param>
		/// <param name="falseAttributeExpression">An expression that contains the HTML attributes to set for the element if the condition is false.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder If( bool condition, Action<HtmlAttributeBuilder> trueAttributeExpression, Action<HtmlAttributeBuilder> falseAttributeExpression )
		{
			if( condition )
			{
				if( trueAttributeExpression != null )
				{
					trueAttributeExpression( this );
				}
			}
			else
			{
				if( falseAttributeExpression != null )
				{
					falseAttributeExpression( this );
				}
			}

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "lang".
		/// </summary>
		/// <param name="languageCode">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Lang( string languageCode )
		{
			this.Attributes[ HtmlAttributes.Lang ] = languageCode;

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "shape".
		/// </summary>
		/// <param name="shape">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Shape( ShapeType shape )
		{
			return this.Shape( shape.ToLowerString() );
		}

		/// <summary>
		/// Represents the HTML attribute "shape".
		/// </summary>
		/// <param name="shape">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Shape( object shape )
		{
			this.Attributes[ HtmlAttributes.Shape ] = shape;

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "spellcheck" with the value of "true".
		/// </summary>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder SpellCheck()
		{
			return this.SpellCheck( true );
		}

		/// <summary>
		/// Represents the HTML attribute "spellcheck".
		/// </summary>
		/// <param name="spellCheck">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder SpellCheck( bool spellCheck )
		{
			this.Attributes[ HtmlAttributes.SpellCheck ] = spellCheck.ToLowerString();

			return this;
		}

		/// <summary>
		/// Provides a way to specify an expression for all of the HTML style attributes values.
		/// </summary>
		/// <param name="styleAttributeExpression">An expression that contains the HTML style attribute values to set for the element.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Styles( Action<StyleAttributeBuilder> styleAttributeExpression )
		{
			if( styleAttributeExpression != null )
			{
				StyleCollection styles = null;
				if( !this.Attributes.TryGetValue<StyleCollection>( HtmlAttributes.Style, out styles ) )
				{
					styles = new StyleCollection();
					this.Attributes[ HtmlAttributes.Style ] = styles;
				}

				styleAttributeExpression( new StyleAttributeBuilder( styles ) );
			}

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "tabindex".
		/// </summary>
		/// <param name="title">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder TabIndex( int title )
		{
			this.Attributes[ HtmlAttributes.TabIndex ] = title;

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "title".
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Title( string value )
		{
			this.Attributes[ HtmlAttributes.Title ] = value;

			return this;
		}

		/// <summary>
		/// Represents the HTML attribute "translate" with the value of "yes".
		/// </summary>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Translate()
		{
			return this.Translate( TranslateType.Yes );
		}

		/// <summary>
		/// Represents the HTML attribute "translate".
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The same instance of <see cref="Hex.AttributeBuilders.HtmlAttributeBuilder"/>.</returns>
		public HtmlAttributeBuilder Translate( TranslateType value )
		{
			this.Attributes[ HtmlAttributes.Translate ] = value.ToLowerString();

			return this;
		}
	}
}