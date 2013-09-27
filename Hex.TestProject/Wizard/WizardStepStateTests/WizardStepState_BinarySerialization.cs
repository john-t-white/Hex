using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Hex.TestProject.Wizard.WizardStepStateTests
{
	[TestClass]
	public class WizardStepState_BinarySerialization
	{
		[TestMethod]
		public void SerializesAndDeserializesCorrectly()
		{
			string actionName = "ActionName";
			WizardStepStateValueCollection values = new WizardStepStateValueCollection();

			WizardStepState wizardStepState = new WizardStepState( actionName, values );

			BinaryFormatter binaryFormatter = new BinaryFormatter();

			WizardStepState deserializedWizardStepState;
			using( MemoryStream memoryStream = new MemoryStream() )
			{
				binaryFormatter.Serialize( memoryStream, wizardStepState );

				memoryStream.Position = 0;

				deserializedWizardStepState = ( WizardStepState )binaryFormatter.Deserialize( memoryStream );
			}

			Assert.AreEqual( wizardStepState.ActionName, deserializedWizardStepState.ActionName );
			Assert.IsNotNull( deserializedWizardStepState.Values );
		}
	}
}
