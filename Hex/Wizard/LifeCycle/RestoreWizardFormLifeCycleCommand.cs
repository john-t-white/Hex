using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.Wizard.LifeCycle
{
	public class RestoreWizardFormLifeCycleCommand
		: IWizardLifeCycleCommand
	{
		public void Execute( WizardLifeCycleContext wizardLifeCycleContext )
		{
			WizardController wizardController = wizardLifeCycleContext.WizardController;

			ModelStateDictionary modelStateDictionary = new ModelStateDictionary();
			IModelBinder binder = System.Web.Mvc.ModelBinders.Binders.GetBinder( wizardController.WizardFormModelType );
			ModelMetadata wizardFormModelMetadata = ModelMetadataProviders.Current.GetMetadataForType( () => wizardController.WizardFormModel, wizardController.WizardFormModelType );

			foreach( WizardStep currentWizardStep in wizardController.WizardSteps.Where( x => x.Values != null ) )
			{
				IValueProvider valueProvider = new WizardStepValueCollectionValueProvider( currentWizardStep.Values, CultureInfo.CurrentUICulture );

				var bindingContext = new ModelBindingContext()
				{
					ModelMetadata = wizardFormModelMetadata,
					ModelState = modelStateDictionary,
					ModelName = null,
					ValueProvider = valueProvider
				};

				binder.BindModel( wizardController.ControllerContext, bindingContext );
			}
		}
	}
}
