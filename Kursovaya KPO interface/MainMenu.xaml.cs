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
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        private Uri _startMenuUri;
        private Uri _incomesUri;
        private Uri _expensesUri;
        private Uri _budgetMenuUri;

        public static Uri MainMenuUri { get; set; }
        public MainMenu()
        {
            InitializeComponent();
            _startMenuUri = StartMenu.StartMenuUri;
            MainMenuUri = new Uri("MainMenu.xaml", UriKind.Relative);
        }

        private void ButtonExitToStartMenu_Click(object sender, RoutedEventArgs e)
        {
            if (_startMenuUri == null)
                _startMenuUri = new Uri("StartMenu.xaml", UriKind.Relative);
            NavigationService.Navigate(_startMenuUri);
        }

        private void ButtonIncomes_Click(object sender, RoutedEventArgs e)
        {
            if (_incomesUri == null)
                _incomesUri = new Uri("Incomes.xaml", UriKind.Relative);
            NavigationService.Navigate(_incomesUri);
        }

        private void ButtonExpenses_Click(object sender, RoutedEventArgs e)
        {
            if (_expensesUri == null)
                _expensesUri = new Uri("Expenses.xaml", UriKind.Relative);
            NavigationService.Navigate(_expensesUri);
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void ButtonBudgets_Click(object sender, RoutedEventArgs e)
        {
            if (_budgetMenuUri == null)
                _budgetMenuUri = new Uri("BudgetMenu.xaml", UriKind.Relative);
            NavigationService.Navigate(_budgetMenuUri);
        }
    }

}
