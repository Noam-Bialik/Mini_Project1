﻿#pragma checksum "..\..\DirectorUserControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3E35C639831EC22B27496B4C740B60853BBADF10"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using UIwpf;


namespace UIwpf {
    
    
    /// <summary>
    /// DirectorUserControl
    /// </summary>
    public partial class DirectorUserControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\DirectorUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button testrs;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\DirectorUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button trainees;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\DirectorUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button tests;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\DirectorUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame MainColumn;
        
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
            System.Uri resourceLocater = new System.Uri("/UIwpf;component/directorusercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DirectorUserControl.xaml"
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
            this.testrs = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\DirectorUserControl.xaml"
            this.testrs.Click += new System.Windows.RoutedEventHandler(this.Testrs_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.trainees = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\DirectorUserControl.xaml"
            this.trainees.Click += new System.Windows.RoutedEventHandler(this.Trainees_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tests = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\DirectorUserControl.xaml"
            this.tests.Click += new System.Windows.RoutedEventHandler(this.Tests_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.MainColumn = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

