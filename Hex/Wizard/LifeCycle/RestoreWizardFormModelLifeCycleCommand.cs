using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hex.Wizard.LifeCycle
{
	/// <summary>
	/// The wizard life cycle command that restores the wizard form model.
	/// </summary>
	public class RestoreWizardFormModelLifeCycleCommand
		: IWizardLifeCycleCommand
	{
		/// <summary>
		/// Executes the command.
		/// </summary>
		/// <param name="wizardLifeCycleContext">The wizard life cycle context.</param>
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
