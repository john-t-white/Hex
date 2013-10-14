using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.Wizard.LifeCycle
{
	public class UpdateWizardFormModelLifeCycleCommand
		: IWizardLifeCycleCommand
	{
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
