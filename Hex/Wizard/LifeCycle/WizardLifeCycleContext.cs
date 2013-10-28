using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hex.Wizard.LifeCycle
{
	/// <summary>
	/// The context that is passed to all life cycle commands.
	/// </summary>
	public class WizardLifeCycleContext
	{
		/// <summary>
		/// Instantiates an instance of <see cref="WizardLifeCycleContext"/>.
		/// </summary>
		/// <param name="wizardController">The wizard controller.</param>
		public WizardLifeCycleContext( WizardController wizardController )
		{
			if( wizardController == null )
			{
				throw new ArgumentNullException( "wizardController" );
			}

			this.WizardController = wizardController;
		}

		/// <summary>
		/// Gets the wizard controller.
		/// </summary>
		public WizardController WizardController { get; private set; }

		/// <summary>
		/// Gets or sets the name of the action that should be executed in the wizard controller.
		/// </summary>
		public string ResultActionName { get; set; }

		/// <summary>
		/// Gets or sets the wizard state.
		/// </summary>
		public WizardState WizardState { get; set; }
	}
}
