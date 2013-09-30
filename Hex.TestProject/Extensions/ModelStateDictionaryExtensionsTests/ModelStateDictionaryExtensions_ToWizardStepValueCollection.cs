using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Hex.Extensions;
using System.Globalization;
using Hex.Wizard;
using System.Collections.Specialized;

namespace Hex.TestProject.Extensions.ModelStateDictionaryExtensionsTests
{
	[TestClass]
	public class ModelStateDictionaryExtensions_ToWizardStepValueCollection
	{
		[TestMethod]
		public void ReturnsCorrectly()
		{
			ModelStateDictionary modelStateDictionary = this.GenerateModelStateDictionary();

			IValueProvider valueProvider = new NameValueCollectionValueProvider( new NameValueCollection(), CultureInfo.CurrentUICulture );

			WizardStepValueCollection wizardStepValues = modelStateDictionary.ToWizardStepValueCollection( valueProvider );

			Assert.AreEqual( modelStateDictionary.Count, wizardStepValues.Count );
			foreach( string currentModelStateName in modelStateDictionary.Keys )
			{
				Assert.IsTrue( wizardStepValues.AllKeys.Contains( currentModelStateName ) );

				ValueProviderResult currentValueProviderResult = modelStateDictionary[ currentModelStateName ].Value;
				string[] currentRawValues = ( string[] )currentValueProviderResult.RawValue;
				string[] currentWizardStepValues = wizardStepValues.GetValues( currentModelStateName );

				Assert.AreEqual( currentRawValues.Length, currentWizardStepValues.Length );
				foreach( string currentRawValue in currentRawValues )
				{
					Assert.IsTrue( currentWizardStepValues.Contains( currentRawValue ) );
				}
			}
		}

		[TestMethod]
		public void EmptyModelStateDictionaryReturnsCorrectly()
		{
			ModelStateDictionary modelStateDictionary = new ModelStateDictionary();

			IValueProvider valueProvider = this.GenerateNameValueCollectionProvider( new NameValueCollection() );

			WizardStepValueCollection wizardStepValues = modelStateDictionary.ToWizardStepValueCollection( valueProvider );

			Assert.AreEqual( 0, wizardStepValues.Count );
		}

		[TestMethod]
		public void WithIndexesReturnsCorrectly()
		{
			ModelStateDictionary modelStateDictionary = this.GenerateModelStateDictionaryWithIndex( "NameWithIndex", "IndexValue" );

			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection.Add( string.Format( "{0}.Index", "NameWithIndex" ), "IndexValue" );

			IValueProvider valueProvider = this.GenerateNameValueCollectionProvider( nameValueCollection );

			WizardStepValueCollection wizardStepValues = modelStateDictionary.ToWizardStepValueCollection( valueProvider );

			Assert.AreEqual( modelStateDictionary.Count + nameValueCollection.Count, wizardStepValues.Count );
			foreach( string currentModelStateName in modelStateDictionary.Keys )
			{
				Assert.IsTrue( wizardStepValues.AllKeys.Contains( currentModelStateName ) );

				ValueProviderResult currentValueProviderResult = modelStateDictionary[ currentModelStateName ].Value;
				string[] currentRawValues = ( string[] )currentValueProviderResult.RawValue;
				string[] currentWizardStepValues = wizardStepValues.GetValues( currentModelStateName );

				Assert.AreEqual( currentRawValues.Length, currentWizardStepValues.Length );
				foreach( string currentRawValue in currentRawValues )
				{
					Assert.IsTrue( currentWizardStepValues.Contains( currentRawValue ) );
				}
			}

			foreach( string currentKey in nameValueCollection.AllKeys )
			{
				Assert.IsTrue( wizardStepValues.AllKeys.Contains( currentKey, StringComparer.InvariantCultureIgnoreCase ) );

				string[] currentIndexValues = nameValueCollection.GetValues( currentKey );
				string[] currentWizardStepValues = wizardStepValues.GetValues( currentKey );

				Assert.AreEqual( currentIndexValues.Length, currentWizardStepValues.Length );
				foreach( string currentIndexValue in currentIndexValues )
				{
					Assert.IsTrue( currentWizardStepValues.Contains( currentIndexValue ) );
				}
			}
		}






		private ModelStateDictionary GenerateModelStateDictionary()
		{
			ModelStateDictionary modelStateDictionary = new ModelStateDictionary();

			string[] modelStateDictionaryNames = new string[]
			{
				"NameOne",
				"NameTwo"
			};

			int numberOfValues = 2;
			
			foreach( string currentName in modelStateDictionaryNames )
			{
				string[] currentValues = new string[ numberOfValues ];
				for( int currentValueIndex = 0; currentValueIndex < numberOfValues; currentValueIndex++ )
				{
					currentValues[ currentValueIndex ] = string.Format( "{0}Value{1}", currentName, currentValueIndex );
				}

				modelStateDictionary.SetModelValue( currentName, new ValueProviderResult( currentValues, string.Join( ",", currentValues ), CultureInfo.CurrentUICulture ) );
			}

			return modelStateDictionary;
		}

		private ModelStateDictionary GenerateModelStateDictionaryWithIndex( string modelStateWithIndexName, string indexValue )
		{
			ModelStateDictionary modelStateDictionary = this.GenerateModelStateDictionary();

			string modelStateName = string.Format( "{0}[{1}]", modelStateWithIndexName, indexValue );
			string modelStateValue = string.Format( "{0}Value", modelStateWithIndexName );

			modelStateDictionary.SetModelValue( modelStateName, new ValueProviderResult( new string[] { modelStateValue }, modelStateValue, CultureInfo.CurrentUICulture ) );

			return modelStateDictionary;
		}

		private NameValueCollectionValueProvider GenerateNameValueCollectionProvider( NameValueCollection nameValueCollection )
		{
			return new NameValueCollectionValueProvider( nameValueCollection, CultureInfo.CurrentUICulture );
		}
	}
}
