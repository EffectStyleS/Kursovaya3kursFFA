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

namespace Kursovaya_KPO_interface.View
{
    /// <summary>
    /// Логика взаимодействия для StartMenu.xaml
    /// </summary>
    public partial class StartMenu : Page
    {
        public StartMenu()
        {
            InitializeComponent();
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
            tb.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            tb.GotFocus -= Log_GotFocus;
        }

        //очистить строку пароля при нажатии на неё
        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox pb = sender as PasswordBox;
            pb.Password = string.Empty;
            pb.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            pb.GotFocus -= PasswordBox_GotFocus;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ((PasswordBox)sender).Tag = ((PasswordBox)sender).Password;
        }
    }
}
