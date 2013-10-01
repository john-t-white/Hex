using Hex.Resources;
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
		private const string MODEL_STATE_NAME_PREFIX = Constants.WIZARD_FORM_MODEL_NAME + ".";
		private const string MODEL_STATE_NAME_INDEX_SUFFIX = ".index";

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
				wizardStepValues.Add( ModelStateDictionaryExtensions.TrimWizardModelNamePrefix( currentModelState.Key ), currentModelState.Value.Value );
			}

			foreach( string currentPossibleIndex in ModelStateDictionaryExtensions.GetPossibleIndexes( modelStateDictionary ) )
			{
				ValueProviderResult currentValueProviderResult = valueProvider.GetValue( currentPossibleIndex );

				wizardStepValues.Add( ModelStateDictionaryExtensions.TrimWizardModelNamePrefix( currentPossibleIndex ), currentValueProviderResult );
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

					modelStateDictionary.SetModelValue( string.Format( "{0}{1}", MODEL_STATE_NAME_PREFIX, currentName ), valueProviderResult );
				}
			}
		}

		private static string[] GetPossibleIndexes( ModelStateDictionary modelStateDictionary )
		{
			return ( from string currentModelStateName in modelStateDictionary.Keys
					 let bracketIndex = currentModelStateName.LastIndexOf( '[' )
					 where bracketIndex >= 0
					 select string.Concat( currentModelStateName.Substring( 0, bracketIndex ), MODEL_STATE_NAME_INDEX_SUFFIX ) ).Distinct().ToArray();
		}

		private static string TrimWizardModelNamePrefix( string modelStateName )
		{
			if( !modelStateName.StartsWith( MODEL_STATE_NAME_PREFIX ) )
			{
				string exceptionMessage = string.Format( ExceptionMessages.MISSING_MODEL_STATE_NAME_PREFIX, MODEL_STATE_NAME_PREFIX );
				throw new InvalidOperationException( exceptionMessage );
			}

			return modelStateName.Substring( MODEL_STATE_NAME_PREFIX.Length );
		}
	}
}
