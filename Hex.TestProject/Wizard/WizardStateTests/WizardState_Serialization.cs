using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Newtonsoft.Json;

namespace Hex.TestProject.Wizard.WizardStateTests
{
	[TestClass]
	public class WizardState_Serialization
	{
		[TestMethod]
		public void SerializesAndDeserializesBinaryCorrectly()
		{
			WizardState wizardState = this.GenerateWizardState();

			BinaryFormatter binaryFormatter = new BinaryFormatter();

			WizardState deserializedWizardState;
			using( MemoryStream memoryStream = new MemoryStream() )
			{
				binaryFormatter.Serialize( memoryStream, wizardState );

				memoryStream.Position = 0;

				deserializedWizardState = ( WizardState )binaryFormatter.Deserialize( memoryStream );
			}

			this.AssertSerialization( wizardState, deserializedWizardState );
		}

		[TestMethod]
		public void SerializesAndDeserializesJsonCorrectly()
		{
			WizardState wizardState = this.GenerateWizardState();

			string serializedWizardState = JsonConvert.SerializeObject( wizardState );

			WizardState deserializedWizardState = JsonConvert.DeserializeObject<WizardState>( serializedWizardState );

			this.AssertSerialization( wizardState, deserializedWizardState );
		}



		private WizardState GenerateWizardState()
		{
			string currentStepActionName = "CurrentStepActionName";
			WizardStepState[] steps = new WizardStepState[] { new WizardStepState( currentStepActionName, null ) };

			return new WizardState( currentStepActionName, steps );
		}

		private void AssertSerialization( WizardState originalWizardState, WizardState deserializedWizardState )
		{
			Assert.AreEqual( originalWizardState.CurrentStepActionName, deserializedWizardState.CurrentStepActionName );
			Assert.IsNotNull( deserializedWizardState.Steps );
		}
	}
}
