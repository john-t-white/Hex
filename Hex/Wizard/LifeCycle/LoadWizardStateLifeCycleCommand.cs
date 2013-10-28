using Hex.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard.LifeCycle
{
	/// <summary>
	/// The wizard life cycle command that loads the wizard state.
	/// </summary>
	public class LoadWizardStateLifeCycleCommand
		: IWizardLifeCycleCommand
	{
		private const string HANDLE_WIZARD_STATE_NOT_FOUND_ACTION_NAME = "HandleWizardStateNotFound";

		/// <summary>
		/// Instantiates an instance of <see cref="LoadWizardStateLifeCycleCommand"/>.
		/// </summary>
		/// <param name="wizardStateToken">The wizard state token.</param>
		public LoadWizardStateLifeCycleCommand( string wizardStateToken )
		{
			if( string.IsNullOrWhiteSpace( wizardStateToken ) )
			{
				throw new ArgumentException( ExceptionMessages.VALUE_CANNOT_BE_NULL_OR_EMPTY, "wizardStateToken" );
			}

			this.WizardStateToken = wizardStateToken;
		}

		/// <summary>
		/// Returns the wizard state token.
		/// </summary>
		public string WizardStateToken { get; private set; }

		/// <summary>
		/// Executes the command.
		/// </summary>
		/// <param name="wizardLifeCycleContext">The wizard life cycle context.</param>
		public void Execute( WizardLifeCycleContext wizardLifeCycleContext )
		{
			WizardController wizardController = wizardLifeCycleContext.WizardController;

			WizardState wizardState = wizardController.WizardStateProvider.Load( wizardController.ControllerContext, this.WizardStateToken );
			if( wizardState == null )
			{
				wizardLifeCycleContext.ResultActionName = HANDLE_WIZARD_STATE_NOT_FOUND_ACTION_NAME;
			}
			else
			{
				wizardLifeCycleContext.WizardState = wizardState;
			}
		}
	}
}
