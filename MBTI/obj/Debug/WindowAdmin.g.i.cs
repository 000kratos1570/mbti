﻿#pragma checksum "..\..\WindowAdmin.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2899F48F24C0172F182AACA6B893B79827356D5B0B2DEBA66FD05838E6C24ED5"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MBTI;
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


namespace MBTI {
    
    
    /// <summary>
    /// WindowAdmin
    /// </summary>
    public partial class WindowAdmin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\WindowAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTEx;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\WindowAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DGUsers;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\WindowAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTadd;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\WindowAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTReg;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\WindowAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTDel;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\WindowAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBLogin;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\WindowAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBPass;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\WindowAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBF;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\WindowAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBI;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\WindowAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBO;
        
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
            System.Uri resourceLocater = new System.Uri("/MBTI;component/windowadmin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WindowAdmin.xaml"
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
            this.BTEx = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\WindowAdmin.xaml"
            this.BTEx.Click += new System.Windows.RoutedEventHandler(this.BTEx_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DGUsers = ((System.Windows.Controls.DataGrid)(target));
            
            #line 12 "..\..\WindowAdmin.xaml"
            this.DGUsers.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DGUsers_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 12 "..\..\WindowAdmin.xaml"
            this.DGUsers.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.DGUsers_AutoGeneratingColumn);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BTadd = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\WindowAdmin.xaml"
            this.BTadd.Click += new System.Windows.RoutedEventHandler(this.BTadd_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BTReg = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\WindowAdmin.xaml"
            this.BTReg.Click += new System.Windows.RoutedEventHandler(this.BTReg_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BTDel = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\WindowAdmin.xaml"
            this.BTDel.Click += new System.Windows.RoutedEventHandler(this.BTDel_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TBLogin = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.TBPass = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.TBF = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.TBI = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.TBO = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

