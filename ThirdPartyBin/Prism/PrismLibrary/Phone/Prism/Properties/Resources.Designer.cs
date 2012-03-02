//===================================================================================
// Microsoft patterns & practices
// Composite Application Guidance for Windows Presentation Foundation and Silverlight
//===================================================================================
// Copyright (c) Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===================================================================================
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
//===================================================================================
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Practices.Prism.Properties {
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
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.Practices.Prism.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Cannot register a CompositeCommand in itself..
        /// </summary>
        internal static string CannotRegisterCompositeCommandInItself {
            get {
                return ResourceManager.GetString("CannotRegisterCompositeCommandInItself", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot register the same command twice in the same CompositeCommand..
        /// </summary>
        internal static string CannotRegisterSameCommandTwice {
            get {
                return ResourceManager.GetString("CannotRegisterSameCommandTwice", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Neither the executeMethod nor the canExecuteMethod delegates can be null..
        /// </summary>
        internal static string DelegateCommandDelegatesCannotBeNull {
            get {
                return ResourceManager.GetString("DelegateCommandDelegatesCannotBeNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to T for DelegateCommand&lt;T&gt; is not an object nor Nullable..
        /// </summary>
        internal static string DelegateCommandInvalidGenericPayloadType {
            get {
                return ResourceManager.GetString("DelegateCommandInvalidGenericPayloadType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Target of the IDelegateReference should be of type {0}..
        /// </summary>
        internal static string InvalidDelegateRerefenceTypeException {
            get {
                return ResourceManager.GetString("InvalidDelegateRerefenceTypeException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The member access expression does not access a property..
        /// </summary>
        internal static string PropertySupport_ExpressionNotProperty_Exception {
            get {
                return ResourceManager.GetString("PropertySupport_ExpressionNotProperty_Exception", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The expression is not a member access expression..
        /// </summary>
        internal static string PropertySupport_NotMemberAccessExpression_Exception {
            get {
                return ResourceManager.GetString("PropertySupport_NotMemberAccessExpression_Exception", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The referenced property is a static property..
        /// </summary>
        internal static string PropertySupport_StaticExpression_Exception {
            get {
                return ResourceManager.GetString("PropertySupport_StaticExpression_Exception", resourceCulture);
            }
        }
    }
}
