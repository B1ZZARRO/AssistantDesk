﻿#pragma checksum "..\..\..\AuthWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B40BBE4848A79C904908D8CCF1B79C97A9E0F6A8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Assistant;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Assistant {
    
    
    /// <summary>
    /// AuthWindow
    /// </summary>
    public partial class AuthWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\AuthWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_enter;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\AuthWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_login;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\AuthWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_password;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\AuthWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cb_remember;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\AuthWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_auth;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\AuthWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_reg;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\AuthWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_error;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.16.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Assistant;component/authwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AuthWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.16.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\AuthWindow.xaml"
            ((Assistant.AuthWindow)(target)).Closed += new System.EventHandler(this.AuthWindow_OnClosed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lbl_enter = ((System.Windows.Controls.Label)(target));
            
            #line 31 "..\..\..\AuthWindow.xaml"
            this.lbl_enter.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Lbl_enter_OnMouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tb_login = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tb_password = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.cb_remember = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.btn_auth = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\AuthWindow.xaml"
            this.btn_auth.Click += new System.Windows.RoutedEventHandler(this.Btn_auth_OnClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_reg = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\AuthWindow.xaml"
            this.btn_reg.Click += new System.Windows.RoutedEventHandler(this.Btn_reg_OnClick);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lbl_error = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
