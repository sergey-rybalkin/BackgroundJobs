﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BackgroundJobs {
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
    internal class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BackgroundJobs.Strings", typeof(Strings).Assembly);
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
        ///   Looks up a localized string similar to Background Jobs error.
        /// </summary>
        internal static string ErrorHeader {
            get {
                return ResourceManager.GetString("ErrorHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No files selected on the active panel.
        /// </summary>
        internal static string ErrorNoFilesSelected {
            get {
                return ResourceManager.GetString("ErrorNoFilesSelected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Active panel is not available.
        /// </summary>
        internal static string ErrorNoPanel {
            get {
                return ResourceManager.GetString("ErrorNoPanel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Copy.
        /// </summary>
        internal static string MenuCopy {
            get {
                return ResourceManager.GetString("MenuCopy", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Delete.
        /// </summary>
        internal static string MenuDelete {
            get {
                return ResourceManager.GetString("MenuDelete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Execute scheduled jobs.
        /// </summary>
        internal static string MenuExecute {
            get {
                return ResourceManager.GetString("MenuExecute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Move.
        /// </summary>
        internal static string MenuMove {
            get {
                return ResourceManager.GetString("MenuMove", resourceCulture);
            }
        }
    }
}
