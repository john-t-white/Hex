using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Newtonsoft.Json;

namespace Hex.TestProject.Wizard.WizardStepStateTests
{
	[TestClass]
	public class WizardStepState_Serialization
	{
		[TestMethod]
		public void SerializesAndDeserializesBinaryCorrectly()
		{
			WizardStepState wizardStepState = this.GenerateWizardStepState();

			BinaryFormatter binaryFormatter = new BinaryFormatter();

			WizardStepState deserializedWizardStepState;
			using( MemoryStream memoryStream = new MemoryStream() )
			{
				binaryFormatter.Serialize( memoryStream, wizardStepState );

				memoryStream.Position = 0;

				deserializedWizardStepState = ( WizardStepState )binaryFormatter.Deserialize( memoryStream );
			}

			this.AssertSerialization( wizardStepState, deserializedWizardStepState );
		}

		[TestMethod]
		public void SerializesAndDeserializesJsonCorrectly()
		{
			WizardStepState wizardStepState = this.GenerateWizardStepState();

			string serializedWizardStepState = JsonConvert.SerializeObject( wizardStepState );

			WizardStepState deserializedWizardStepState = JsonConvert.DeserializeObject<WizardStepState>( serializedWizardStepState );

			this.AssertSerialization( wizardStepState, deserializedWizardStepState );
		}



		private WizardStepState GenerateWizardStepState()
		{
			string actionName = "ActionName";
			WizardStepStateValueCollection values = new WizardStepStateValueCollection();

			return new WizardStepState( actionName, values );
		}

		private void AssertSerialization( WizardStepState originalWizardStepState, WizardStepState deserializedWizardStepState )
		{
			Assert.AreEqual( originalWizardStepState.ActionName, deserializedWizardStepState.ActionName );
			Assert.IsNotNull( deserializedWizardStepState.Values );
		}
	}
}
