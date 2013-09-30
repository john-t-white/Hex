using Hex.Wizard;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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



		//public static WizardStepValueCollection ToWizardStepValueCollection( this ModelStateDictionary modelStateDictionary, IValueProvider valueProvider )
		//{
		//	WizardStepValueCollection wizardStepValues = new WizardStepValueCollection();

		//	foreach( KeyValuePair<string, ModelState> currentModelState in modelStateDictionary )
		//	{
		//		object rawValue = currentModelState.Value.Value.RawValue;
		//		if( rawValue is IEnumerable )
		//		{
		//			foreach( var currentRawValue in ( IEnumerable )rawValue )
		//			{
		//				wizardStepValues.Add( currentModelState.Key, currentRawValue.ToString() );
		//			}
		//		}
		//		else
		//		{
		//			wizardStepValues.Add( currentModelState.Key, rawValue.ToString() );
		//		}
		//	}

		//	var possibleIndexes = ( from string currentModelStateName in wizardStepValues
		//							let bracketIndex = currentModelStateName.LastIndexOf( '[' )
		//							where bracketIndex >= 0
		//							select string.Concat( currentModelStateName.Substring( 0, bracketIndex ), ".index" ) ).Distinct().ToList();

		//	foreach( string currentPossibleIndex in possibleIndexes )
		//	{
		//		ValueProviderResult currentValueProviderResult = valueProvider.GetValue( currentPossibleIndex );
		//		if( currentValueProviderResult != null )
		//		{
		//			object rawValue = currentValueProviderResult.RawValue;
		//			if( rawValue is IEnumerable )
		//			{
		//				foreach( var currentRawValue in ( IEnumerable )rawValue )
		//				{
		//					wizardStepValues.Add( currentPossibleIndex, currentRawValue.ToString() );
		//				}
		//			}
		//			else
		//			{
		//				wizardStepValues.Add( currentPossibleIndex, rawValue.ToString() );
		//			}
		//		}
		//	}

		//	return wizardStepValues;
		//}

		public static void Update( this ModelStateDictionary modelStateDictionary, WizardStepValueCollection values )
		{
			modelStateDictionary.Clear();

			if( values != null )
			{
				foreach( string currentName in values )
				{
					string[] rawValues = values.GetValues( currentName );
					string attemptedValue = string.Join( ",", rawValues );
					ValueProviderResult valueProviderResult = new ValueProviderResult( rawValues, attemptedValue, CultureInfo.CurrentUICulture );

					modelStateDictionary.SetModelValue( currentName, valueProviderResult );
				}
			}
		}
	}
}
