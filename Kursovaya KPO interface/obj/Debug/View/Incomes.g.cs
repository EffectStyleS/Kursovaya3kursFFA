#pragma checksum "..\..\..\View\Incomes.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "81DADCFA8C5CC698A950A0E65A086A3BCA1677A26EF62A2E005C308F73D2C831"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Kursovaya_KPO_interface.ViewModel;
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


namespace Kursovaya_KPO_interface.View {
    
    
    /// <summary>
    /// Incomes
    /// </summary>
    public partial class Incomes : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\View\Incomes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Kursovaya_KPO_interface.View.Incomes incomes;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\View\Incomes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackPanelCrudMenu;
        
        #line default
        #line hidden
        
        
        #line 184 "..\..\..\View\Incomes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackPanelDate;
        
        #line default
        #line hidden
        
        
        #line 198 "..\..\..\View\Incomes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePicker;
        
        #line default
        #line hidden
        
        
        #line 242 "..\..\..\View\Incomes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackPanelType;
        
        #line default
        #line hidden
        
        
        #line 310 "..\..\..\View\Incomes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackPanelName;
        
        #line default
        #line hidden
        
        
        #line 384 "..\..\..\View\Incomes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackPanelValue;
        
        #line default
        #line hidden
        
        
        #line 410 "..\..\..\View\Incomes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox numberTextBox;
        
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
            System.Uri resourceLocater = new System.Uri("/Kursovaya KPO interface;component/view/incomes.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\Incomes.xaml"
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
            this.incomes = ((Kursovaya_KPO_interface.View.Incomes)(target));
            return;
            case 2:
            this.stackPanelCrudMenu = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            
            #line 138 "..\..\..\View\Incomes.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonAddIncome_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 156 "..\..\..\View\Incomes.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonAddIncome_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.stackPanelDate = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.datePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            
            #line 220 "..\..\..\View\Incomes.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonAddIncomeDate_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 236 "..\..\..\View\Incomes.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonCancel_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.stackPanelType = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 10:
            
            #line 286 "..\..\..\View\Incomes.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonAddIncomeType_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 304 "..\..\..\View\Incomes.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonCancel_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.stackPanelName = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 13:
            
            #line 361 "..\..\..\View\Incomes.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonAddIncomeName_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 377 "..\..\..\View\Incomes.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonCancel_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.stackPanelValue = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 16:
            this.numberTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 412 "..\..\..\View\Incomes.xaml"
            this.numberTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 433 "..\..\..\View\Incomes.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonCancel_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 451 "..\..\..\View\Incomes.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

