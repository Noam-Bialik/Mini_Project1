﻿#pragma checksum "..\..\TraineeHome.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "65826DEDBEB5A780F4DD99F3D6090FBBBA609ED1"
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
    /// TraineeHome
    /// </summary>
    public partial class TraineeHome : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\TraineeHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateTrainee;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\TraineeHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Remove;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\TraineeHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddTest;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\TraineeHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AllTests;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\TraineeHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AllTestersInRadius;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\TraineeHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid data;
        
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
            System.Uri resourceLocater = new System.Uri("/UIwpf;component/traineehome.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TraineeHome.xaml"
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
            this.UpdateTrainee = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\TraineeHome.xaml"
            this.UpdateTrainee.Click += new System.Windows.RoutedEventHandler(this.UpdateTrainee_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Remove = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\TraineeHome.xaml"
            this.Remove.Click += new System.Windows.RoutedEventHandler(this.Remove_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.AddTest = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\TraineeHome.xaml"
            this.AddTest.Click += new System.Windows.RoutedEventHandler(this.AddTest_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AllTests = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\TraineeHome.xaml"
            this.AllTests.Click += new System.Windows.RoutedEventHandler(this.AllTests_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AllTestersInRadius = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\TraineeHome.xaml"
            this.AllTestersInRadius.Click += new System.Windows.RoutedEventHandler(this.AllTestersInRadius_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.data = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

