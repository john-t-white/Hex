﻿using System;
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
		public void Execute( WizardLifeCycleContext wizardLifeCycleContext, WizardController wizardController )
		{
			ModelStateDictionary modelStateDictionary = new ModelStateDictionary();
			foreach( WizardStep currentWizardStep in wizardController.WizardSteps.Where( x => x.Values != null ) )
			{
				IValueProvider valueProvider = new WizardStepValueCollectionValueProvider( currentWizardStep.Values, CultureInfo.CurrentUICulture );

				IModelBinder binder = System.Web.Mvc.ModelBinders.Binders.GetBinder( wizardController.WizardFormModelType );
				var bindingContext = new ModelBindingContext()
				{
					ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType( () => wizardController.WizardFormModel, wizardController.WizardFormModelType ),
					ModelState = modelStateDictionary,
					ModelName = null,
					ValueProvider = valueProvider
				};

				binder.BindModel( wizardController.ControllerContext, bindingContext );
			}
		}
	}
}
