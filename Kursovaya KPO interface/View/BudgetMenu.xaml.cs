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
    /// Логика взаимодействия для BudgetMenu.xaml
    /// </summary>
    public partial class BudgetMenu : Page
    {
        private Uri _mainMenuUri;
        private Uri _plannedIncomesUri;
        private Uri _plannedExpensesUri;
        public static Uri BudgetMenuUri { get; set; }
        public BudgetMenu()
        {
            InitializeComponent();
            _mainMenuUri = MainMenu.MainMenuUri;
            BudgetMenuUri = new Uri("View/BudgetMenu.xaml", UriKind.Relative);
        }

        private void BudgetButtonExit_Click(object sender, RoutedEventArgs e)
        {
            if (_mainMenuUri == null)
                _mainMenuUri = new Uri("View/MainMenu.xaml", UriKind.Relative);
            NavigationService.Navigate(_mainMenuUri);
        }

        private void BudgetPlannedIncomes_Click(object sender, RoutedEventArgs e)
        {
            if (_plannedIncomesUri == null)
                _plannedIncomesUri = new Uri("View/PlannedIncomes.xaml", UriKind.Relative);
            NavigationService.Navigate(_plannedIncomesUri);
        }

        private void BudgetPlannedExpenses_Click(object sender, RoutedEventArgs e)
        {
            if (_plannedExpensesUri == null)
                _plannedExpensesUri = new Uri("View/PlannedExpenses.xaml", UriKind.Relative);
            NavigationService.Navigate(_plannedExpensesUri);
        }

        private void BudgetButtonNewBudget_Click(object sender, RoutedEventArgs e)
        {
            newBudgetSettings.Visibility = Visibility.Visible;
        }
    }
}
