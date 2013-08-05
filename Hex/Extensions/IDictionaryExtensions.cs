using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Hex.Extensions
{
	/// <summary>
	/// Extensions for <see cref="System.Collections.Generic.IDictionary{K,V}"/>
	/// </summary>
	public static class IDictionaryExtensions
	{
		/// <summary>
		/// Gets the value with the associated key casted to <typeparamref name="TValue"/>.
		/// </summary>
		/// <typeparam name="TValue">The type of value.</typeparam>
		/// <param name="dictionary">The IDictionar&lt;string, object&gt; this method extends.</param>
		/// <param name="key">The key whose value to get.</param>
		/// <param name="value">When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the type <typeparamref name="TValue"/>. This parameter is passed uninitialized.</param>
		/// <returns>true if the object that implements IDictionary&lt;TKey, TValue&gt; contains an element with the specified key; otherwise, false.</returns>
		public static bool TryGetValue<TValue>( this IDictionary<string, object> dictionary, string key, out TValue value )
		{
			object attributeValue;
			if( !dictionary.TryGetValue( key, out attributeValue ) )
			{
				value = default( TValue );
				return false;
			}

			value = ( TValue )attributeValue;
			return true;
		}

		/// <summary>
		/// Returns all of the items as a string of Html attributes.
		/// </summary>
		/// <param name="dictionary">The IDictionary&lt;string, object&gt; this method extends.</param>
		/// <returns>A string of Html attributes.</returns>
		public static string ToHtmlAttributeString<TKey, TValue>( this IDictionary<TKey, TValue> dictionary )
		{
			var attributeValues = ( from currentValue in dictionary
									select string.Format( "{0}=\"{1}\"", currentValue.Key, HttpUtility.HtmlAttributeEncode( Convert.ToString( currentValue.Value ) ) ) )
									.ToArray();

			return string.Join( " ", attributeValues );
		}
	}
}
