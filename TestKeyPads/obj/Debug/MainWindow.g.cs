#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9F3639D2E51EBD65CEC9F176DE17BDEFC3C4D31CDDB1A585FA73E71C8EF7AF53"
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
using TestKeyPads;


namespace TestKeyPads {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox t1;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox t2;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox passwordBox;
        
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
            System.Uri resourceLocater = new System.Uri("/TestKeyPads;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            
            #line 8 "..\..\MainWindow.xaml"
            ((TestKeyPads.MainWindow)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            
            #line 9 "..\..\MainWindow.xaml"
            ((TestKeyPads.MainWindow)(target)).GotMouseCapture += new System.Windows.Input.MouseEventHandler(this.Window_GotMouseCapture);
            
            #line default
            #line hidden
            
            #line 11 "..\..\MainWindow.xaml"
            ((TestKeyPads.MainWindow)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.t1 = ((System.Windows.Controls.TextBox)(target));
            
            #line 16 "..\..\MainWindow.xaml"
            this.t1.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.t1_TextChanged);
            
            #line default
            #line hidden
            
            #line 17 "..\..\MainWindow.xaml"
            this.t1.SelectionChanged += new System.Windows.RoutedEventHandler(this.t1_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 18 "..\..\MainWindow.xaml"
            this.t1.LostFocus += new System.Windows.RoutedEventHandler(this.t1_LostFocus);
            
            #line default
            #line hidden
            
            #line 19 "..\..\MainWindow.xaml"
            this.t1.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.t1_PreviewKeyDown);
            
            #line default
            #line hidden
            
            #line 20 "..\..\MainWindow.xaml"
            this.t1.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.t1_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 21 "..\..\MainWindow.xaml"
            this.t1.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.t1_PreviewMouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.t2 = ((System.Windows.Controls.TextBox)(target));
            
            #line 25 "..\..\MainWindow.xaml"
            this.t2.SelectionChanged += new System.Windows.RoutedEventHandler(this.t2_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 26 "..\..\MainWindow.xaml"
            this.t2.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.t2_TextChanged);
            
            #line default
            #line hidden
            
            #line 27 "..\..\MainWindow.xaml"
            this.t2.LostFocus += new System.Windows.RoutedEventHandler(this.t2_LostFocus);
            
            #line default
            #line hidden
            
            #line 28 "..\..\MainWindow.xaml"
            this.t2.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.t2_PreviewKeyDown);
            
            #line default
            #line hidden
            
            #line 29 "..\..\MainWindow.xaml"
            this.t2.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.t2_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 30 "..\..\MainWindow.xaml"
            this.t2.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.t2_PreviewMouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.textBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.passwordBox = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 37 "..\..\MainWindow.xaml"
            this.passwordBox.PasswordChanged += new System.Windows.RoutedEventHandler(this.passwordBox_PasswordChanged);
            
            #line default
            #line hidden
            
            #line 38 "..\..\MainWindow.xaml"
            this.passwordBox.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.passwordBox_MouseDown_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

