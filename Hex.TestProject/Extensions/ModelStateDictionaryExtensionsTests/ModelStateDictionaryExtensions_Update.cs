using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Globalization;
using Hex.Wizard;
using Hex.Extensions;

namespace Hex.TestProject.Extensions.ModelStateDictionaryExtensionsTests
{
	[TestClass]
	public class ModelStateDictionaryExtensions_Update
	{
		[TestMethod]
		public void UpdatesCorrectly()
		{
			string[] wizardStepValueNames = new string[]
			{
				"NameOne",
				"NameTwo"
			};

			WizardStepValueCollection wizardStepValues = new WizardStepValueCollection();
			foreach( string currentName in wizardStepValueNames )
			{
				for( int currentValueIndex = 0; currentValueIndex < 2; currentValueIndex++ )
				{
					string currentValue = string.Format( "{0}Value{1}", currentName, currentValueIndex );
					wizardStepValues.Add( currentName, currentValue );
				}
			}

			ModelStateDictionary modelStateDictionary = new ModelStateDictionary();
			modelStateDictionary.SetModelValue( "Key", new ValueProviderResult( "RawValue", "AttemptedValue", CultureInfo.CurrentUICulture ) );

			modelStateDictionary.Update( wizardStepValues );

			Assert.AreEqual( wizardStepValueNames.Length, modelStateDictionary.Count );
			foreach( string currentName in wizardStepValueNames )
			{
				Assert.IsTrue( modelStateDictionary.ContainsKey( currentName ) );
				ValueProviderResult currentValueProviderResult = modelStateDictionary[ currentName ].Value;

				Assert.IsNotNull( currentValueProviderResult );

				string[] expectedValues = wizardStepValues.GetValues( currentName );
				string expectedAttemptedValue = string.Join( ",", expectedValues );
				string[] currentRawValues = ( string[] )currentValueProviderResult.RawValue;

				Assert.AreEqual( expectedValues.Length, currentRawValues.Length );
				foreach( string currentExpectedValue in expectedValues )
				{
					Assert.IsTrue( currentRawValues.Contains( currentExpectedValue ) );
				}

				Assert.AreEqual( expectedAttemptedValue, currentValueProviderResult.AttemptedValue );
				Assert.AreEqual( CultureInfo.CurrentUICulture, currentValueProviderResult.Culture );
			}
		}

		[TestMethod]
		public void WithNullValuesUpdatesCorrectly()
		{
			WizardStepValueCollection wizardStepValues = null;

			ModelStateDictionary modelStateDictionary = new ModelStateDictionary();
			modelStateDictionary.SetModelValue( "Key", new ValueProviderResult( "RawValue", "AttemptedValue", CultureInfo.CurrentUICulture ) );

			modelStateDictionary.Update( wizardStepValues );

			Assert.AreEqual( 0, modelStateDictionary.Count );
		}
	}
}
