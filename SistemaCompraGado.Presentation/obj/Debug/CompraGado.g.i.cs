﻿#pragma checksum "..\..\CompraGado.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "597AE8224D6439A625B212065A47D5AC1DCE8A2B"
//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

using SistemaCompraGado.Presentation;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace SistemaCompraGado.Presentation {
    
    
    /// <summary>
    /// CompraGado
    /// </summary>
    public partial class CompraGado : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\CompraGado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtID;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\CompraGado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDtEntrega;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\CompraGado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboPecuarista;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\CompraGado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdicionar;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\CompraGado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExcluir;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\CompraGado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAlterar;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\CompraGado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid grdItens;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\CompraGado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblModificar;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\CompraGado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cboAnimal;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\CompraGado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblAnimal;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\CompraGado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblQuantidade;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\CompraGado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtQuantidade;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\CompraGado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSalvar;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\CompraGado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancelar;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\CompraGado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTotal;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\CompraGado.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGravarCompra;
        
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
            System.Uri resourceLocater = new System.Uri("/SistemaCompraGado.Presentation;component/compragado.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CompraGado.xaml"
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
            this.txtID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtDtEntrega = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.cboPecuarista = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.btnAdicionar = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\CompraGado.xaml"
            this.btnAdicionar.Click += new System.Windows.RoutedEventHandler(this.BtnAdicionar_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnExcluir = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\CompraGado.xaml"
            this.btnExcluir.Click += new System.Windows.RoutedEventHandler(this.BtnExcluir_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnAlterar = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\CompraGado.xaml"
            this.btnAlterar.Click += new System.Windows.RoutedEventHandler(this.BtnAlterar_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.grdItens = ((System.Windows.Controls.DataGrid)(target));
            
            #line 21 "..\..\CompraGado.xaml"
            this.grdItens.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGrid_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lblModificar = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.cboAnimal = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.lblAnimal = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.lblQuantidade = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.txtQuantidade = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.btnSalvar = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\CompraGado.xaml"
            this.btnSalvar.Click += new System.Windows.RoutedEventHandler(this.BtnSalvar_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.btnCancelar = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\CompraGado.xaml"
            this.btnCancelar.Click += new System.Windows.RoutedEventHandler(this.BtnCancelar_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.lblTotal = ((System.Windows.Controls.Label)(target));
            return;
            case 16:
            this.btnGravarCompra = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\CompraGado.xaml"
            this.btnGravarCompra.Click += new System.Windows.RoutedEventHandler(this.btnGravarCompra_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

