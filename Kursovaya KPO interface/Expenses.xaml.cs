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
    /// Логика взаимодействия для Expenses.xaml
    /// </summary>
    public partial class Expenses : Page
    {
        private Uri _mainMenuUri;
        public Expenses()
        {
            InitializeComponent();
            _mainMenuUri = MainMenu.MainMenuUri;
        }

        private void ExpensesButtonToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            if (_mainMenuUri == null)
                _mainMenuUri = new Uri("MainMenu.xaml", UriKind.Relative);
            NavigationService.Navigate(_mainMenuUri);
        }
    }
}
