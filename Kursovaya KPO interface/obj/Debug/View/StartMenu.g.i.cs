// Updated by XamlIntelliSenseFileGenerator 15.12.2022 0:05:50
#pragma checksum "..\..\..\View\StartMenu.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "45A2799FC7A3007E2033C0FE1A17134C54B4689320C95999E5A5DF43F9E24155"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Kursovaya_KPO_interface.Infrastructure;
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


namespace Kursovaya_KPO_interface.View
{


    /// <summary>
    /// StartMenu
    /// </summary>
    public partial class StartMenu : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden


#line 38 "..\..\..\View\StartMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock mainProjectName;

#line default
#line hidden


#line 85 "..\..\..\View\StartMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxLogin;

#line default
#line hidden


#line 111 "..\..\..\View\StartMenu.xaml"
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
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Kursovaya KPO interface;component/view/startmenu.xaml", System.UriKind.Relative);

#line 1 "..\..\..\View\StartMenu.xaml"
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
                    this.startMenu = ((Kursovaya_KPO_interface.View.StartMenu)(target));
                    return;
                case 2:
                    this.mainProjectName = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 3:
                    this.textBoxLogin = ((System.Windows.Controls.TextBox)(target));

#line 93 "..\..\..\View\StartMenu.xaml"
                    this.textBoxLogin.GotFocus += new System.Windows.RoutedEventHandler(this.Log_GotFocus);

#line default
#line hidden
                    return;
                case 4:
                    this.passwordBox = ((System.Windows.Controls.PasswordBox)(target));

#line 120 "..\..\..\View\StartMenu.xaml"
                    this.passwordBox.GotFocus += new System.Windows.RoutedEventHandler(this.PasswordBox_GotFocus);

#line default
#line hidden

#line 121 "..\..\..\View\StartMenu.xaml"
                    this.passwordBox.PasswordChanged += new System.Windows.RoutedEventHandler(this.PasswordBox_PasswordChanged);

#line default
#line hidden
                    return;
                case 5:

#line 170 "..\..\..\View\StartMenu.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonExit_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.Page startMenu;
    }
}

