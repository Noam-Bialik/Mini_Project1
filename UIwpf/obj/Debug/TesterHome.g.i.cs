#pragma checksum "..\..\TesterHome.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C9B088172FF9DDE2745D5387054F0D4D5419ABA2"
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


namespace UIwpf
{


    /// <summary>
    /// TesterHome
    /// </summary>
    public partial class TesterHome : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector
    {


#line 15 "..\..\TesterHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateTester;

#line default
#line hidden


#line 16 "..\..\TesterHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Remove;

#line default
#line hidden


#line 17 "..\..\TesterHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UpdateTest;

#line default
#line hidden


#line 18 "..\..\TesterHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AllTests;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/UIwpf;component/testerhome.xaml", System.UriKind.Relative);

#line 1 "..\..\TesterHome.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.UpdateTester = ((System.Windows.Controls.Button)(target));

#line 15 "..\..\TesterHome.xaml"
                    this.UpdateTester.Click += new System.Windows.RoutedEventHandler(this.UpdateTester_Click);

#line default
#line hidden
                    return;
                case 2:
                    this.Remove = ((System.Windows.Controls.Button)(target));

#line 16 "..\..\TesterHome.xaml"
                    this.Remove.Click += new System.Windows.RoutedEventHandler(this.Remove_Click);

#line default
#line hidden
                    return;
                case 3:
                    this.UpdateTest = ((System.Windows.Controls.Button)(target));

#line 17 "..\..\TesterHome.xaml"
                    this.UpdateTest.Click += new System.Windows.RoutedEventHandler(this.UpdateTest_Click);

#line default
#line hidden
                    return;
                case 4:
                    this.AllTests = ((System.Windows.Controls.Button)(target));

#line 18 "..\..\TesterHome.xaml"
                    this.AllTests.Click += new System.Windows.RoutedEventHandler(this.AllTests_Click);

#line default
#line hidden
                    return;
                case 5:
                    this.data = ((System.Windows.Controls.Frame)(target));
                    return;
            }
            this._contentLoaded = true;
        }
    }
}

