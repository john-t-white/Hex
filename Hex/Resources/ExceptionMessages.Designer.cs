﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hex.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ExceptionMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ExceptionMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Hex.Resources.ExceptionMessages", typeof(ExceptionMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The url specified must be an absolute url..
        /// </summary>
        internal static string ABSOLUTE_URI_REQUIRED {
            get {
                return ResourceManager.GetString("ABSOLUTE_URI_REQUIRED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The currentStepActionName &apos;{0}&apos; does not exist in the list of steps..
        /// </summary>
        internal static string CURRENT_STEP_ACTION_NAME_DOES_NOT_EXIST_IN_STEPS {
            get {
                return ResourceManager.GetString("CURRENT_STEP_ACTION_NAME_DOES_NOT_EXIST_IN_STEPS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The current wizard step must exist in the collection..
        /// </summary>
        internal static string CURRENT_WIZARD_STEP_DOES_NOT_EXIST_IN_COLLECTION {
            get {
                return ResourceManager.GetString("CURRENT_WIZARD_STEP_DOES_NOT_EXIST_IN_COLLECTION", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Model state names should all start with the prefix &apos;{0}&apos;..
        /// </summary>
        internal static string MISSING_MODEL_STATE_NAME_PREFIX {
            get {
                return ResourceManager.GetString("MISSING_MODEL_STATE_NAME_PREFIX", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There is no next wizard step in the collection..
        /// </summary>
        internal static string NEXT_WIZARD_STEP_NOT_FOUND {
            get {
                return ResourceManager.GetString("NEXT_WIZARD_STEP_NOT_FOUND", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There are no wizard actions found for wizard controller &apos;{0}&apos;..
        /// </summary>
        internal static string NO_WIZARD_ACTIONS_FOUND {
            get {
                return ResourceManager.GetString("NO_WIZARD_ACTIONS_FOUND", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There is no previous wizard step in the collection..
        /// </summary>
        internal static string PREVIOUS_WIZARD_STEP_NOT_FOUND {
            get {
                return ResourceManager.GetString("PREVIOUS_WIZARD_STEP_NOT_FOUND", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value cannot be null or empty..
        /// </summary>
        internal static string VALUE_CANNOT_BE_NULL_OR_EMPTY {
            get {
                return ResourceManager.GetString("VALUE_CANNOT_BE_NULL_OR_EMPTY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Wizard controllers must not have an action defined in the route..
        /// </summary>
        internal static string WIZARD_CANNOT_CONTAIN_ACTION_IN_ROUTE {
            get {
                return ResourceManager.GetString("WIZARD_CANNOT_CONTAIN_ACTION_IN_ROUTE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The wizard step view model must implement &apos;{0}&apos;..
        /// </summary>
        internal static string WIZARD_STEP_VIEW_MODEL_DOES_NOT_IMPLEMENT_IWIZARDSTEPVIEWMODEL {
            get {
                return ResourceManager.GetString("WIZARD_STEP_VIEW_MODEL_DOES_NOT_IMPLEMENT_IWIZARDSTEPVIEWMODEL", resourceCulture);
            }
        }
    }
}
