using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Newtonsoft.Json;

namespace Hex.TestProject.Wizard.WizardStepValueCollectionTests
{
	[TestClass]
	public class WizardStepValueCollection_Serialization
	{
		[TestMethod]
		public void SerializesAndDeserializesBinaryCorrectly()
		{
			WizardStepValueCollection wizardStepStateValueCollection = this.GenerateWizardStepStateValueCollection();

			BinaryFormatter binaryFormatter = new BinaryFormatter();

			WizardStepValueCollection deserializedWizardStepStateValueCollection;
			using( MemoryStream memoryStream = new MemoryStream() )
			{
				binaryFormatter.Serialize( memoryStream, wizardStepStateValueCollection );

				memoryStream.Position = 0;

				deserializedWizardStepStateValueCollection = ( WizardStepValueCollection )binaryFormatter.Deserialize( memoryStream );
			}

			this.AssertSerialization( wizardStepStateValueCollection, deserializedWizardStepStateValueCollection );
		}

		[TestMethod]
		public void SerializesAndDeserializesJsonCorrectly()
		{
			WizardStepValueCollection wizardStepStateValueCollection = this.GenerateWizardStepStateValueCollection();

			string serializedWizardStepStateValueCollection = JsonConvert.SerializeObject( wizardStepStateValueCollection );

			WizardStepValueCollection deserializedWizardStepStateValueCollection = JsonConvert.DeserializeObject<WizardStepValueCollection>( serializedWizardStepStateValueCollection );

			this.AssertSerialization( wizardStepStateValueCollection, deserializedWizardStepStateValueCollection );
		}



		private WizardStepValueCollection GenerateWizardStepStateValueCollection()
		{
			string name1 = "Name1";
			string name2 = "Name2";

			WizardStepValueCollection wizardStepStateValueCollection = new WizardStepValueCollection();
			wizardStepStateValueCollection.Add( name1, "Name1Value1" );
			wizardStepStateValueCollection.Add( name1, "Name1Value2" );

			wizardStepStateValueCollection.Add( name2, "Name2Value1" );
			wizardStepStateValueCollection.Add( name2, "Name2Value2" );

			return wizardStepStateValueCollection;
		}

		private void AssertSerialization( WizardStepValueCollection originalWizardStepStateValueCollection, WizardStepValueCollection deserializedWizardStepStateValueCollection )
		{
			Assert.AreEqual( originalWizardStepStateValueCollection.Count, deserializedWizardStepStateValueCollection.Count );

			foreach( string currentOriginalName in originalWizardStepStateValueCollection )
			{
				string[] originalValues = originalWizardStepStateValueCollection.GetValues( currentOriginalName );
				string[] deserializedValues = deserializedWizardStepStateValueCollection.GetValues( currentOriginalName );

				Assert.AreEqual( originalValues.Length, deserializedValues.Length );
				for( int currentValueIndex = 0; currentValueIndex < originalValues.Length; currentValueIndex++ )
				{
					Assert.AreEqual( originalValues[ currentValueIndex ], deserializedValues[ currentValueIndex ] );
				}
			}
		}
	}
}
