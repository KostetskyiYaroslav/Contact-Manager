﻿#pragma checksum "..\..\..\UIL\AddContactInOtherGroupUIL.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "99717D9E218D1BE170BF1BCE86B166BB"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Windows.Converters;
using FirstFloor.ModernUI.Windows.Navigation;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Xceed.Wpf.Toolkit;


namespace ContactManagerArchitecture1.UIL {
    
    
    /// <summary>
    /// AddContactInOtherGroupUIL
    /// </summary>
    public partial class AddContactInOtherGroupUIL : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\UIL\AddContactInOtherGroupUIL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ContactPhoneList_CB;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\UIL\AddContactInOtherGroupUIL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox GroupNameList_CB;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\UIL\AddContactInOtherGroupUIL.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddContact_B;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ContactManagerArchitecture1;component/uil/addcontactinothergroupuil.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UIL\AddContactInOtherGroupUIL.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ContactPhoneList_CB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 13 "..\..\..\UIL\AddContactInOtherGroupUIL.xaml"
            this.ContactPhoneList_CB.Loaded += new System.Windows.RoutedEventHandler(this.ContactPhoneList_CB_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.GroupNameList_CB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 14 "..\..\..\UIL\AddContactInOtherGroupUIL.xaml"
            this.GroupNameList_CB.Loaded += new System.Windows.RoutedEventHandler(this.GroupNameList_CB_Loaded);
            
            #line default
            #line hidden
            return;
            case 3:
            this.AddContact_B = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\UIL\AddContactInOtherGroupUIL.xaml"
            this.AddContact_B.Click += new System.Windows.RoutedEventHandler(this.AddContact_B_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

