using Hex.Wizard;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.Wizard
{
	/// <summary>
	/// Extensions to <see cref="System.Web.Mvc.ModelStateDictionary"/>.
	/// </summary>
	public static class ModelStateDictionaryExtensions
	{
		public static WizardStepValueCollection ToWizardStepValueCollection( this ModelStateDictionary modelStateDictionary, IValueProvider valueProvider )
		{
			if( modelStateDictionary == null )
			{
				throw new ArgumentNullException( "modelStateDictionary" );
			}

			if( valueProvider == null )
			{
				throw new ArgumentNullException( "valueProvider" );
			}

			WizardStepValueCollection wizardStepValues = new WizardStepValueCollection();

			foreach( KeyValuePair<string, ModelState> currentModelState in modelStateDictionary )
			{
				object rawValue = currentModelState.Value.Value.RawValue;
				if( rawValue is IEnumerable )
				{
					foreach( var currentRawValue in ( IEnumerable )rawValue )
					{
						wizardStepValues.Add( currentModelState.Key, currentRawValue.ToString() );
					}
				}
				else
				{
					wizardStepValues.Add( currentModelState.Key, rawValue.ToString() );
				}
			}

			var possibleIndexes = ( from string currentModelStateName in wizardStepValues
									let bracketIndex = currentModelStateName.LastIndexOf( '[' )
									where bracketIndex >= 0
									select string.Concat( currentModelStateName.Substring( 0, bracketIndex ), ".index" ) ).Distinct().ToList();

			foreach( string currentPossibleIndex in possibleIndexes )
			{
				ValueProviderResult currentValueProviderResult = valueProvider.GetValue( currentPossibleIndex );
				if( currentValueProviderResult != null )
				{
					object rawValue = currentValueProviderResult.RawValue;
					if( rawValue is IEnumerable )
					{
						foreach( var currentRawValue in ( IEnumerable )rawValue )
						{
							wizardStepValues.Add( currentPossibleIndex, currentRawValue.ToString() );
						}
					}
					else
					{
						wizardStepValues.Add( currentPossibleIndex, rawValue.ToString() );
					}
				}
			}

			return wizardStepValues;
		}

		public static void Update( this ModelStateDictionary modelStateDictionary, WizardStepValueCollection values )
		{
			if( modelStateDictionary == null )
			{
				throw new ArgumentNullException( "modelStateDictionary" );
			}

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
