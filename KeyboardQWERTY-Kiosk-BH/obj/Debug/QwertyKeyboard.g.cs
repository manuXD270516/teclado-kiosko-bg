﻿#pragma checksum "..\..\QwertyKeyboard.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D98FFF99F1FBAC1060465CCC40A0684CA7B06C74E8180B4BEA606AF646BFF65A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using KeyPadQWERTY_Kiosk_BG.Converter;
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


namespace KeyPadQWERTY_Kiosk_BG {
    
    
    /// <summary>
    /// QwertyKeyboard
    /// </summary>
    public partial class QwertyKeyboard : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 9 "..\..\QwertyKeyboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal KeyPadQWERTY_Kiosk_BG.QwertyKeyboard Keyboard;
        
        #line default
        #line hidden
        
        
        #line 159 "..\..\QwertyKeyboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid AlfaKeyboard;
        
        #line default
        #line hidden
        
        
        #line 167 "..\..\QwertyKeyboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RowDefinition NumberKeys;
        
        #line default
        #line hidden
        
        
        #line 785 "..\..\QwertyKeyboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid NumKeyboard;
        
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
            System.Uri resourceLocater = new System.Uri("/KeyboardQWERTY-Kiosk-BH;component/qwertykeyboard.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\QwertyKeyboard.xaml"
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
            this.Keyboard = ((KeyPadQWERTY_Kiosk_BG.QwertyKeyboard)(target));
            
            #line 7 "..\..\QwertyKeyboard.xaml"
            this.Keyboard.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Keyboard_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 142 "..\..\QwertyKeyboard.xaml"
            ((System.Windows.Controls.Button)(target)).TouchLeave += new System.EventHandler<System.Windows.Input.TouchEventArgs>(this.closeKeyboard_Listener);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AlfaKeyboard = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.NumberKeys = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 6:
            this.NumKeyboard = ((System.Windows.Controls.Grid)(target));
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
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 2:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Primitives.ButtonBase.ClickEvent;
            
            #line 19 "..\..\QwertyKeyboard.xaml"
            eventSetter.Handler = new System.Windows.RoutedEventHandler(this.button_Click);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}

