﻿#pragma checksum "..\..\..\View\ViewAllMedicinesPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B25E28791C71238C2C636FBF7D11B9514BFC132592BD4FB37DB4F52FDFA0D7D7"
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
    /// ViewAllMedicinesPage
    /// </summary>
    public partial class ViewAllMedicinesPage : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        /// <summary>
        /// myMedicinesDataGrid Name Field
        /// </summary>
        
        #line 13 "..\..\..\View\ViewAllMedicinesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.DataGrid myMedicinesDataGrid;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\View\ViewAllMedicinesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button createBtn;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\View\ViewAllMedicinesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backBtn;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\View\ViewAllMedicinesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBoxSorting;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\View\ViewAllMedicinesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchTextBox;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\View\ViewAllMedicinesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox searchComboBox;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\View\ViewAllMedicinesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button searchBtn;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\View\ViewAllMedicinesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button acceptedAndRejectedBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/SiMS_projekat;component/view/viewallmedicinespage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\ViewAllMedicinesPage.xaml"
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
            this.myMedicinesDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.createBtn = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\..\View\ViewAllMedicinesPage.xaml"
            this.createBtn.Click += new System.Windows.RoutedEventHandler(this.createBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.backBtn = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\..\View\ViewAllMedicinesPage.xaml"
            this.backBtn.Click += new System.Windows.RoutedEventHandler(this.backBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.comboBoxSorting = ((System.Windows.Controls.ComboBox)(target));
            
            #line 77 "..\..\..\View\ViewAllMedicinesPage.xaml"
            this.comboBoxSorting.DropDownClosed += new System.EventHandler(this.comboBoxSorting_DropDownClosed);
            
            #line default
            #line hidden
            return;
            case 9:
            this.searchTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.searchComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.searchBtn = ((System.Windows.Controls.Button)(target));
            
            #line 101 "..\..\..\View\ViewAllMedicinesPage.xaml"
            this.searchBtn.Click += new System.Windows.RoutedEventHandler(this.searchBtn_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.acceptedAndRejectedBtn = ((System.Windows.Controls.Button)(target));
            
            #line 104 "..\..\..\View\ViewAllMedicinesPage.xaml"
            this.acceptedAndRejectedBtn.Click += new System.Windows.RoutedEventHandler(this.acceptedAndRejectedBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 2:
            
            #line 38 "..\..\..\View\ViewAllMedicinesPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.updateBtn_Click);
            
            #line default
            #line hidden
            break;
            case 3:
            
            #line 39 "..\..\..\View\ViewAllMedicinesPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.deleteBtn_Click);
            
            #line default
            #line hidden
            break;
            case 4:
            
            #line 53 "..\..\..\View\ViewAllMedicinesPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ingredientsBtn_Click);
            
            #line default
            #line hidden
            break;
            case 5:
            
            #line 67 "..\..\..\View\ViewAllMedicinesPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.purchaseBtn_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
