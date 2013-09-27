using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Hex.TestProject.Wizard.WizardStepStateValueCollectionTests
{
	[TestClass]
	public class WizardStepStateValueCollection_Serialization
	{
		[TestMethod]
		public void SerializesAndDeserializesBinaryCorrectly()
		{
			string name1 = "Name1";
			string name1value1 = "Name1Value1";
			string name1value2 = "Name1Value2";

			string name2 = "Name2";
			string name2value1 = "Name2Value1";
			string name2value2 = "Name2Value2";

			WizardStepStateValueCollection wizardStepStateValueCollection = new WizardStepStateValueCollection();
			wizardStepStateValueCollection.Add( name1, name1value1 );
			wizardStepStateValueCollection.Add( name1, name1value2 );

			wizardStepStateValueCollection.Add( name2, name2value1 );
			wizardStepStateValueCollection.Add( name2, name2value2 );

			BinaryFormatter binaryFormatter = new BinaryFormatter();

			WizardStepStateValueCollection deserializedWizardStepStateValueCollection;
			using( MemoryStream memoryStream = new MemoryStream() )
			{
				binaryFormatter.Serialize( memoryStream, wizardStepStateValueCollection );

				memoryStream.Position = 0;

				deserializedWizardStepStateValueCollection = ( WizardStepStateValueCollection )binaryFormatter.Deserialize( memoryStream );
			}

			Assert.AreEqual( wizardStepStateValueCollection.Count, deserializedWizardStepStateValueCollection.Count );

			foreach( string currentName in wizardStepStateValueCollection )
			{
				string[] originalValues = wizardStepStateValueCollection.GetValues( currentName );
				string[] deserializedValues = deserializedWizardStepStateValueCollection.GetValues( currentName );

				Assert.AreEqual( originalValues.Length, deserializedValues.Length );
				for( int currentValueIndex = 0; currentValueIndex < originalValues.Length; currentValueIndex++ )
				{
					Assert.AreEqual( originalValues[ currentValueIndex ], deserializedValues[ currentValueIndex ] );
				}
			}
		}
	}
}
