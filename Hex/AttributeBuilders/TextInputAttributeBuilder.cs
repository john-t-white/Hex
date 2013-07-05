using Hex.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hex.AttributeBuilders
{
	public abstract class TextInputAttributeBuilder<TSelf>
		: InputAttributeBuilder<TSelf>
		where TSelf : TextInputAttributeBuilder<TSelf>, new()
	{
		public TSelf Max( int max )
		{
			this.Attributes[ HtmlAttributes.Max ] = max;

			return ( TSelf )this;
		}

		public TSelf Max( DateTime max )
		{
			this.Attributes[ HtmlAttributes.Max ] = max;

			return ( TSelf )this;
		}

		public TSelf MaxLength( int maxLength )
		{
			this.Attributes[ HtmlAttributes.MaxLength ] = maxLength;

			return ( TSelf )this;
		}

		public TSelf Min( int min )
		{
			this.Attributes[ HtmlAttributes.Min ] = min;

			return ( TSelf )this;
		}

		public TSelf Min( DateTime min )
		{
			this.Attributes[ HtmlAttributes.Min ] = min;

			return ( TSelf )this;
		}

		public TSelf Pattern( Regex pattern )
		{
			if( pattern == null )
			{
				return ( TSelf )this;
			}

			return this.Pattern( pattern.ToString() );
		}

		public TSelf Pattern( string pattern )
		{
			this.Attributes[ HtmlAttributes.Pattern ] = pattern;

			return ( TSelf )this;
		}

		public TSelf PlaceHolder( string placeHolder )
		{
			this.Attributes[ HtmlAttributes.PlaceHolder ] = placeHolder;

			return ( TSelf )this;
		}

		public TSelf Size( int size )
		{
			this.Attributes[ HtmlAttributes.Size ] = size;

			return ( TSelf )this;
		}

		public TSelf Step( int step )
		{
			this.Attributes[ HtmlAttributes.Step ] = step;

			return ( TSelf )this;
		}
	}
}
