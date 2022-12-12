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
    /// Логика взаимодействия для PlannedExpenses.xaml
    /// </summary>
    public partial class PlannedExpenses : Page
    {
        private Uri _budgetMenuUri;
        public PlannedExpenses()
        {
            InitializeComponent();
            _budgetMenuUri = BudgetMenu.BudgetMenuUri;
        }

        private void PlannedExpensesButtonExit_Click(object sender, RoutedEventArgs e)
        {
            if (_budgetMenuUri == null)
                _budgetMenuUri = new Uri("BudgetMenu.xaml", UriKind.Relative);
            NavigationService.Navigate(_budgetMenuUri);
        }
    }
}
