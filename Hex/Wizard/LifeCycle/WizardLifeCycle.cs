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
		public WizardLifeCycle( WizardController wizardController )
		{
			if( wizardController == null )
			{
				throw new ArgumentNullException( "wizardController" );
			}

			this.WizardController = wizardController;
		}

		public WizardController WizardController { get; private set; }

		public virtual void Initialize()
		{
			this.Add( new InitializeWizardActionsLifeCycleCommand() );
			this.Add( new CreateWizardFormModelLifeCycleCommand() );

			ValueProviderResult wizardStateTokenResult = this.WizardController.ValueProvider.GetValue( Constants.WIZARD_STATE_TOKEN_HIDDEN_FIELD_NAME );
			if( wizardStateTokenResult == null || string.IsNullOrWhiteSpace( wizardStateTokenResult.AttemptedValue ) )
			{
				this.Add( new InitializeWizardStepsLifeCycleCommand() );
			}
			else
			{
				this.Add( new LoadWizardStateLifeCycleCommand( wizardStateTokenResult.AttemptedValue ) );
				this.Add( new RestoreWizardStateLifeCycleCommand() );
				this.Add( new RestoreWizardFormModelLifeCycleCommand() );
				this.Add( new UpdateWizardFormModelLifeCycleCommand() );
				this.Add( new ProcessWizardButtonLifeCycleCommand() );
			}

			this.Add( new CurrentStepLifeCycleCommand() );
		}
	}
}
