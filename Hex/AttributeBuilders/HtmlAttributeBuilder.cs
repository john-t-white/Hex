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
	public class HtmlAttributeBuilder
	{
		private const string DATA_ATTRIBUTE_PATTERN = "data-{0}";

		public HtmlAttributeBuilder()
		{
			this.Attributes = new AttributeCollection();
		}

		public AttributeCollection Attributes { get; private set; }

		public HtmlAttributeBuilder AccessKey( string accessKey )
		{
			this.Attributes[ HtmlAttributes.AccessKey ] = accessKey;

			return this;
		}

		public HtmlAttributeBuilder AddClass( params string[] classes )
		{
			AttributeValueCollection attributeValues = this.Attributes.GetAttributeValue<AttributeValueCollection>( HtmlAttributes.Class );
			if( attributeValues == null )
			{
				attributeValues = new AttributeValueCollection();
				this.Attributes[ HtmlAttributes.Class ] = attributeValues;
			}

			attributeValues.AddRange( classes );

			return this;
		}

		public HtmlAttributeBuilder AddMultiValueAttribute( string name, params object[] values )
		{
			if( !string.IsNullOrWhiteSpace( name ) )
			{
				AttributeValueCollection attributeValues = this.Attributes.GetAttributeValue<AttributeValueCollection>( name );
				if( attributeValues == null )
				{
					attributeValues = new AttributeValueCollection();
					this.Attributes[ name ] = attributeValues;
				}

				attributeValues.AddRange( values );
			}

			return this;
		}

		public HtmlAttributeBuilder Attribute( string name, object value )
		{
			if( !string.IsNullOrWhiteSpace( name ) )
			{
				this.Attributes[ name ] = value;
			}

			return this;
		}

		public HtmlAttributeBuilder ContentEditable()
		{
			return this.ContentEditable( ContentEditableType.True );
		}

		public HtmlAttributeBuilder ContentEditable( ContentEditableType contentEditableType )
		{
			this.Attributes[ HtmlAttributes.ContentEditable ] = contentEditableType.ToLowerString();

			return this;
		}

		public HtmlAttributeBuilder ContextMenu( string elementId )
		{
			this.Attributes[ HtmlAttributes.ContextMenu ] = elementId;

			return this;
		}

		public HtmlAttributeBuilder Data( string name, object value )
		{
			if( !string.IsNullOrWhiteSpace( name ) )
			{
				string attributeName = string.Format( DATA_ATTRIBUTE_PATTERN, name );
				this.Attributes[ attributeName ] = value;
			}

			return this;
		}

		public HtmlAttributeBuilder Dir( DirType dir )
		{
			this.Attributes[ HtmlAttributes.Dir ] = dir.ToLowerString();

			return this;
		}

		public HtmlAttributeBuilder Draggable()
		{
			return this.Draggable( DraggableType.True );
		}

		public HtmlAttributeBuilder Draggable( DraggableType draggableType )
		{
			this.Attributes[ HtmlAttributes.Draggable ] = draggableType.ToLowerString();

			return this;
		}

		public HtmlAttributeBuilder DropZone()
		{
			return this.DropZone( DropZoneType.Move );
		}


		public HtmlAttributeBuilder DropZone( DropZoneType dropZoneType )
		{
			this.Attributes[ HtmlAttributes.DropZone ] = dropZoneType.ToLowerString();

			return this;
		}

		public HtmlAttributeBuilder Events( Action<EventAttributeBuilder> eventAttributeExpression )
		{
			if( eventAttributeExpression != null )
			{
				eventAttributeExpression( new EventAttributeBuilder( this.Attributes ) );
			}

			return this;
		}

		public HtmlAttributeBuilder Hidden()
		{
			return this.Hidden( true );
		}

		public HtmlAttributeBuilder Hidden( bool hidden )
		{
			this.Attributes.AddOrRemoveMinimizedAttribute( HtmlAttributes.Hidden, hidden );

			return this;
		}

		public HtmlAttributeBuilder Id( string id )
		{
			this.Attributes[ HtmlAttributes.Id ] = id;

			return this;
		}

		public HtmlAttributeBuilder If( bool condition, Action<HtmlAttributeBuilder> trueAttributeExpression )
		{
			return this.If( condition, trueAttributeExpression, null );
		}

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

		public HtmlAttributeBuilder Lang( string languageCode )
		{
			this.Attributes[ HtmlAttributes.Lang ] = languageCode;

			return this;
		}

		public HtmlAttributeBuilder SpellCheck()
		{
			return this.SpellCheck( true );
		}

		public HtmlAttributeBuilder SpellCheck( bool spellCheck )
		{
			this.Attributes[ HtmlAttributes.SpellCheck ] = spellCheck.ToLowerString();

			return this;
		}

		public HtmlAttributeBuilder Styles( Action<StyleAttributeBuilder> styleAttributeExpression )
		{
			if( styleAttributeExpression != null )
			{
				AttributeNameValueCollection attributeNameValues = this.Attributes.GetAttributeValue<AttributeNameValueCollection>( HtmlAttributes.Style );
				if( attributeNameValues == null )
				{
					attributeNameValues = new AttributeNameValueCollection();
					this.Attributes[ HtmlAttributes.Style ] = attributeNameValues;
				}

				styleAttributeExpression( new StyleAttributeBuilder( attributeNameValues ) );
			}

			return this;
		}

		public HtmlAttributeBuilder TabIndex( int title )
		{
			this.Attributes[ HtmlAttributes.TabIndex ] = title;

			return this;
		}

		public HtmlAttributeBuilder Title( string value )
		{
			this.Attributes[ HtmlAttributes.Title ] = value;

			return this;
		}

		public HtmlAttributeBuilder Translate()
		{
			return this.Translate( TranslateType.Yes );
		}

		public HtmlAttributeBuilder Translate( TranslateType value )
		{
			this.Attributes[ HtmlAttributes.Translate ] = value.ToLowerString();

			return this;
		}
	}
}