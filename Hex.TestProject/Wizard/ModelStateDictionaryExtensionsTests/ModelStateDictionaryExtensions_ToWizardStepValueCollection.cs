using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Globalization;
using Hex.Wizard;
using System.Collections.Specialized;

namespace Hex.TestProject.Wizard.ModelStateDictionaryExtensionsTests
{
	[TestClass]
	public class ModelStateDictionaryExtensions_ToWizardStepValueCollection
	{
		private const string WIZARD_FORM_MODEL_NAME_PREFIX = "WizardFormModel.";

		[TestMethod]
		public void ReturnsCorrectly()
		{
			ModelStateDictionary modelStateDictionary = this.GenerateModelStateDictionary();

			IValueProvider valueProvider = new NameValueCollectionValueProvider( new NameValueCollection(), CultureInfo.CurrentUICulture );

			WizardStepValueCollection wizardStepValues = modelStateDictionary.ToWizardStepValueCollection( valueProvider );

			Assert.AreEqual( modelStateDictionary.Count, wizardStepValues.Count );
			foreach( string currentModelStateName in modelStateDictionary.Keys )
			{
				string expectedWizardStepValueName = currentModelStateName.Substring( WIZARD_FORM_MODEL_NAME_PREFIX.Length );
				Assert.IsTrue( wizardStepValues.AllKeys.Contains( expectedWizardStepValueName ) );

				ValueProviderResult currentValueProviderResult = modelStateDictionary[ currentModelStateName ].Value;
				string[] currentRawValues = ( string[] )currentValueProviderResult.RawValue;
				string[] currentWizardStepValues = wizardStepValues.GetValues( expectedWizardStepValueName );

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
			string nameWithIndex = "NameWithIndex";
			string indexValue = "IndexValue";

			ModelStateDictionary modelStateDictionary = this.GenerateModelStateDictionaryWithIndex( nameWithIndex, indexValue );

			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection.Add( string.Format( "{0}{1}.Index", WIZARD_FORM_MODEL_NAME_PREFIX, nameWithIndex ), indexValue );

			IValueProvider valueProvider = this.GenerateNameValueCollectionProvider( nameValueCollection );

			WizardStepValueCollection wizardStepValues = modelStateDictionary.ToWizardStepValueCollection( valueProvider );

			Assert.AreEqual( modelStateDictionary.Count + nameValueCollection.Count, wizardStepValues.Count );
			foreach( string currentModelStateName in modelStateDictionary.Keys )
			{
				string expectedWizardStepValueName = currentModelStateName.Substring( WIZARD_FORM_MODEL_NAME_PREFIX.Length );
				Assert.IsTrue( wizardStepValues.AllKeys.Contains( expectedWizardStepValueName ) );

				ValueProviderResult currentValueProviderResult = modelStateDictionary[ currentModelStateName ].Value;
				string[] currentRawValues = ( string[] )currentValueProviderResult.RawValue;
				string[] currentWizardStepValues = wizardStepValues.GetValues( expectedWizardStepValueName );

				Assert.AreEqual( currentRawValues.Length, currentWizardStepValues.Length );
				foreach( string currentRawValue in currentRawValues )
				{
					Assert.IsTrue( currentWizardStepValues.Contains( currentRawValue ) );
				}
			}

			foreach( string currentKey in nameValueCollection.AllKeys )
			{
				string expectedWizardStepValueIndexName = currentKey.Substring( WIZARD_FORM_MODEL_NAME_PREFIX.Length );
				Assert.IsTrue( wizardStepValues.AllKeys.Contains( expectedWizardStepValueIndexName, StringComparer.InvariantCultureIgnoreCase ) );

				string[] currentIndexValues = nameValueCollection.GetValues( currentKey );
				string[] currentWizardStepValues = wizardStepValues.GetValues( expectedWizardStepValueIndexName );

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

				string currentModelStateName = string.Format( "{0}{1}", WIZARD_FORM_MODEL_NAME_PREFIX, currentName );
				modelStateDictionary.SetModelValue( currentModelStateName, new ValueProviderResult( currentValues, string.Join( ",", currentValues ), CultureInfo.CurrentUICulture ) );
			}

			return modelStateDictionary;
		}

		private ModelStateDictionary GenerateModelStateDictionaryWithIndex( string modelStateWithIndexName, string indexValue )
		{
			ModelStateDictionary modelStateDictionary = this.GenerateModelStateDictionary();

			string modelStateName = string.Format( "{0}{1}[{2}]", WIZARD_FORM_MODEL_NAME_PREFIX, modelStateWithIndexName, indexValue );
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
