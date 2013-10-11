using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.Wizard.LifeCycle
{
	public class WizardLifeCycle
		: List<IWizardLifeCycleCommand>
	{
		public void Initialize( WizardController wizardController )
		{
			this.Add( new InitializeWizardActionsLifeCycleCommand() );
			this.Add( new CreateWizardFormModelLifeCycleCommand() );

			ValueProviderResult wizardStateTokenResult = wizardController.ValueProvider.GetValue( Constants.WIZARD_STATE_TOKEN_HIDDEN_FIELD_NAME );
			if( wizardStateTokenResult == null || string.IsNullOrWhiteSpace( wizardStateTokenResult.AttemptedValue ) )
			{
				this.Add( new InitializeWizardStepsLifeCycleCommand() );
			}
			else
			{
				this.Add( new LoadWizardStateLifeCycleCommand( wizardStateTokenResult.AttemptedValue ) );
				this.Add( new RestoreWizardStateLifeCycleCommand() );
				this.Add( new RestoreWizardFormLifeCycleCommand() );
				this.Add( new UpdateWizardFormLifeCycleCommand() );
				this.Add( new ProcessWizardButtonLifeCycleCommand() );
			}
		}
	}
}
