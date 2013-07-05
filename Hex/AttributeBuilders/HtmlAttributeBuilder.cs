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
	public abstract class HtmlAttributeBuilder<TSelf>
		where TSelf : HtmlAttributeBuilder<TSelf>
	{
		private const string DATA_ATTRIBUTE_PATTERN = "data-{0}";

		protected HtmlAttributeBuilder()
		{
			this.Attributes = new AttributeCollection();
		}

		public AttributeCollection Attributes { get; private set; }

		public TSelf AccessKey( string accessKey )
		{
			this.Attributes[ HtmlAttributes.AccessKey ] = accessKey;

			return ( TSelf )this;
		}

		public TSelf AddClass( params string[] classes )
		{
			AttributeValueCollection attributeValues = this.Attributes.GetAttributeValue<AttributeValueCollection>( HtmlAttributes.Class );
			if( attributeValues == null )
			{
				attributeValues = new AttributeValueCollection();
				this.Attributes[ HtmlAttributes.Class ] = attributeValues;
			}

			attributeValues.AddRange( classes );

			return ( TSelf )this;
		}

		public TSelf AddMultiValueAttribute( string name, params object[] values )
		{
			TSelf self = ( TSelf )this;

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

			return ( TSelf )this;
		}

		public TSelf AddStyle( string name, object value )
		{
			if( !string.IsNullOrWhiteSpace( name ) )
			{
				AttributeNameValueCollection attributeNameValues = this.Attributes.GetAttributeValue<AttributeNameValueCollection>( HtmlAttributes.Style );
				if( attributeNameValues == null )
				{
					attributeNameValues = new AttributeNameValueCollection();
					this.Attributes[ HtmlAttributes.Style ] = attributeNameValues;
				}

				attributeNameValues[ name ] = value;
			}

			return ( TSelf )this;
		}

		public TSelf AddStyle( object styles )
		{
			if( styles != null )
			{
				this.AddStyle( HtmlHelper.AnonymousObjectToHtmlAttributes( styles ) );
			}

			return ( TSelf )this;
		}

		public TSelf AddStyle( IDictionary<string, object> styles )
		{
			if( styles != null )
			{
				var validStyleValues = styles.Where( x => !string.IsNullOrWhiteSpace( x.Key ) );
				if( validStyleValues.Count() > 0 )
				{
					AttributeNameValueCollection attributeNameValues = this.Attributes.GetAttributeValue<AttributeNameValueCollection>( HtmlAttributes.Style );
					if( attributeNameValues == null )
					{
						attributeNameValues = new AttributeNameValueCollection();
						this.Attributes[ HtmlAttributes.Style ] = attributeNameValues;
					}

					foreach( var currentStyle in validStyleValues )
					{
						attributeNameValues[ currentStyle.Key ] = currentStyle.Value;
					}
				}
			}

			return ( TSelf )this; ;
		}

		public TSelf Attribute( string name, object value )
		{
			if( !string.IsNullOrWhiteSpace( name ) )
			{
				this.Attributes[ name ] = value;
			}

			return ( TSelf )this;
		}

		public TSelf ContentEditable()
		{
			return this.ContentEditable( ContentEditableType.True );
		}

		public TSelf ContentEditable( ContentEditableType contentEditableType )
		{
			this.Attributes[ HtmlAttributes.ContentEditable ] = contentEditableType.ToLowerString();

			return ( TSelf )this;
		}

		public TSelf ContextMenu( string elementId )
		{
			this.Attributes[ HtmlAttributes.ContextMenu ] = elementId;

			return ( TSelf )this;
		}

		public TSelf Data( string name, object value )
		{
			if( !string.IsNullOrWhiteSpace( name ) )
			{
				string attributeName = string.Format( DATA_ATTRIBUTE_PATTERN, name );
				this.Attributes[ attributeName ] = value;
			}

			return ( TSelf )this;
		}

		public TSelf Dir( DirType dir )
		{
			this.Attributes[ HtmlAttributes.Dir ] = dir.ToLowerString();

			return ( TSelf )this;
		}

		public TSelf Draggable()
		{
			return this.Draggable( DraggableType.True );
		}

		public TSelf Draggable( DraggableType draggableType )
		{
			this.Attributes[ HtmlAttributes.Draggable ] = draggableType.ToLowerString();

			return ( TSelf )this;
		}

		public TSelf DropZone()
		{
			return this.DropZone( DropZoneType.Move );
		}


		public TSelf DropZone( DropZoneType dropZoneType )
		{
			this.Attributes[ HtmlAttributes.DropZone ] = dropZoneType.ToLowerString();

			return ( TSelf )this;
		}

		//public TSelf Events(Action<EventAttributeBuilder> eventAttributeExpression)
		//{
		//	if (eventAttributeExpression != null)
		//	{
		//		eventAttributeExpression(new EventAttributeBuilder(this.Attributes));
		//	}
		//	TSelf tSelf = (TSelf)this;
		//	return tSelf;
		//}

		public TSelf Hidden()
		{
			return this.Hidden( true );
		}

		public TSelf Hidden( bool hidden )
		{
			this.Attributes.AddOrRemoveMinimizedAttribute( HtmlAttributes.Hidden, hidden );

			return ( TSelf )this;
		}

		public TSelf Id( string id )
		{
			this.Attributes[ HtmlAttributes.Id ] = id;

			return ( TSelf )this;
		}

		public TSelf If( bool condition, Action<TSelf> trueAttributeExpression )
		{
			return this.If( condition, trueAttributeExpression, null );
		}

		public TSelf If( bool condition, Action<TSelf> trueAttributeExpression, Action<TSelf> falseAttributeExpression )
		{
			TSelf self = ( TSelf )this;

			if( condition )
			{
				if( trueAttributeExpression != null )
				{
					trueAttributeExpression( self );
				}
			}
			else
			{
				if( falseAttributeExpression != null )
				{
					falseAttributeExpression( self );
				}
			}

			return self;
		}

		public TSelf Lang( string languageCode )
		{
			this.Attributes[ HtmlAttributes.Lang ] = languageCode;

			return ( TSelf )this;
		}

		public TSelf SpellCheck()
		{
			return this.SpellCheck( true );
		}

		public TSelf SpellCheck( bool spellCheck )
		{
			this.Attributes[ HtmlAttributes.SpellCheck ] = spellCheck.ToLowerString();

			return ( TSelf )this;
		}

		public TSelf TabIndex( int title )
		{
			this.Attributes[ HtmlAttributes.TabIndex ] = title;

			return ( TSelf )this;
		}

		public TSelf Title( string value )
		{
			this.Attributes[ HtmlAttributes.Title ] = value;

			return ( TSelf )this;
		}

		public TSelf Translate()
		{
			TSelf tSelf = this.Translate( TranslateType.Yes );
			return tSelf;
		}

		public TSelf Translate( TranslateType value )
		{
			this.Attributes[ HtmlAttributes.Translate ] = value.ToLowerString();
			TSelf tSelf = ( TSelf )this;
			return tSelf;
		}
	}
}