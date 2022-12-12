using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kursovaya_KPO_interface
{
    /// <summary>
    /// Логика взаимодействия для StartMenu.xaml
    /// </summary>
    public partial class StartMenu : Page
    {
        private Uri _mainMenuUri;
        public static Uri StartMenuUri { get; set; }
        public StartMenu()
        {
            InitializeComponent();
            StartMenuUri = new Uri("StartMenu.xaml", UriKind.Relative);
        }

        private void ButtonStartEnter_Click(object sender, RoutedEventArgs e)
        {
            if (_mainMenuUri == null)
                _mainMenuUri = new Uri("MainMenu.xaml", UriKind.Relative);
            NavigationService.Navigate(_mainMenuUri);          
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        //очистить строку логина при нажатии на неё
        private void Log_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.Text = string.Empty;
            tb.GotFocus -= Log_GotFocus;
        }

        //очистить строку пароля при нажатии на неё
        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox pb = sender as PasswordBox;
            pb.Password = string.Empty;
            pb.GotFocus -= PasswordBox_GotFocus;
        }
    }
}
