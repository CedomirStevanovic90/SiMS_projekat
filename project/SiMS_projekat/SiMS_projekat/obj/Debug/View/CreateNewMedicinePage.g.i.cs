﻿#pragma checksum "..\..\..\View\CreateNewMedicinePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "98C952B37795C63D91691113A009CE44AD2463E428DE1FE24D36A11488F5CE13"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SiMS_projekat.View;
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


namespace SiMS_projekat.View {
    
    
    /// <summary>
    /// CreateNewMedicinePage
    /// </summary>
    public partial class CreateNewMedicinePage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\View\CreateNewMedicinePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button createBtn;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\View\CreateNewMedicinePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nameTextBox;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\View\CreateNewMedicinePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox producerTextBox;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\View\CreateNewMedicinePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox quantityTextBox;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\View\CreateNewMedicinePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox acceptedCheckBox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\View\CreateNewMedicinePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox rejectedCheckBox;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\View\CreateNewMedicinePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addIngredientsBtn;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\View\CreateNewMedicinePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox priceTextBox;
        
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
            System.Uri resourceLocater = new System.Uri("/SiMS_projekat;component/view/createnewmedicinepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\CreateNewMedicinePage.xaml"
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
            this.createBtn = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\View\CreateNewMedicinePage.xaml"
            this.createBtn.Click += new System.Windows.RoutedEventHandler(this.createBtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.nameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.producerTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.quantityTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.acceptedCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.rejectedCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 7:
            this.addIngredientsBtn = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\View\CreateNewMedicinePage.xaml"
            this.addIngredientsBtn.Click += new System.Windows.RoutedEventHandler(this.addIngredientsBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.priceTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
