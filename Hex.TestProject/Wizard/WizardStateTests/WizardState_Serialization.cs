using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hex.Wizard;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Hex.TestProject.Wizard.WizardStateTests
{
	[TestClass]
	public class WizardState_Serialization
	{
		[TestMethod]
		public void SerializesAndDeserializesBinaryCorrectly()
		{
			string currentStepActionName = "CurrentStepActionName";
			WizardStepState[] steps = new WizardStepState[] { new WizardStepState( currentStepActionName, null ) };

			WizardState wizardState = new WizardState( currentStepActionName, steps );

			BinaryFormatter binaryFormatter = new BinaryFormatter();

			WizardState deserializedWizardState;
			using( MemoryStream memoryStream = new MemoryStream() )
			{
				binaryFormatter.Serialize( memoryStream, wizardState );

				memoryStream.Position = 0;

				deserializedWizardState = ( WizardState )binaryFormatter.Deserialize( memoryStream );
			}

			Assert.AreEqual( wizardState.CurrentStepActionName, deserializedWizardState.CurrentStepActionName );
			Assert.IsNotNull( deserializedWizardState.Steps );
		}
	}
}
