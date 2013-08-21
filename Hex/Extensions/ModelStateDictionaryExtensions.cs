using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.Extensions
{
	/// <summary>
	/// Extensions to <see cref="System.Web.Mvc.ModelStateDictionary"/>.
	/// </summary>
	public static class ModelStateDictionaryExtensions
	{
		/// <summary>
		/// Returns the value in model state for the specified <paramref name="key"/> converted the to <paramref name="destinationType"/>, or null if it is not found.
		/// </summary>
		/// <param name="modelStateDictionary">The instance of <see cref="System.Web.Mvc.ModelStateDictionary"/> that is being extended.</param>
		/// <param name="key">The key.</param>
		/// <param name="destinationType">The value type.</param>
		/// <param name="modelState">An instance <see cref="System.Web.Mvc.ModelState"/>, or null if it is not found.</param>
		/// <returns>The value in model state.</returns>
		public static object GetModelStateValue( this ModelStateDictionary modelStateDictionary, string key, Type destinationType, out ModelState modelState )
		{
			if( !modelStateDictionary.TryGetValue( key, out modelState ) || modelState.Value == null )
			{
				return null;
			}

			return modelState.Value.ConvertTo( destinationType, null );
		}
	}
}
