using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.Wizard.LifeCycle
{
	/// <summary>
	/// The wizard life cycle command that updates the wizard form model and sets the values for the current step.
	/// </summary>
	public class UpdateWizardFormModelLifeCycleCommand
		: IWizardLifeCycleCommand
	{
		/// <summary>
		/// Executes the command.
		/// </summary>
		/// <param name="wizardLifeCycleContext">The wizard life cycle context.</param>
		public void Execute( WizardLifeCycleContext wizardLifeCycleContext )
		{
			WizardController wizardController = wizardLifeCycleContext.WizardController;

			IModelBinder binder = System.Web.Mvc.ModelBinders.Binders.GetBinder( wizardController.WizardFormModelType );
			var bindingContext = new ModelBindingContext()
			{
				ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType( () => wizardController.WizardFormModel, wizardController.WizardFormModelType ),
				ModelState = wizardController.ModelState,
				ModelName = Constants.WIZARD_FORM_MODEL_NAME,
				ValueProvider = wizardController.ValueProvider
			};

			binder.BindModel( wizardController.ControllerContext, bindingContext );

			wizardController.WizardSteps.CurrentStep.Values = wizardController.ModelState.ToWizardStepValueCollection( wizardController.ValueProvider );
		}
	}
}
