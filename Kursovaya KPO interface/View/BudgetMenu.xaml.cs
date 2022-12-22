using Kursovaya_KPO_interface.ViewModel;
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
        private static short _mode = 0;
        public BudgetMenu()
        {
            InitializeComponent();
            DataContext = BudgetMenuViewModel.Instance;
            SetVisibilityMode();
        }      

        private void ButtonNewBudget_Click(object sender, RoutedEventArgs e)
        {
            _mode = 1;
            SetVisibilityMode();
        }
        private void ButtonReadBudgets_Click(object sender, RoutedEventArgs e)
        {
            _mode = 2;
            SetVisibilityMode();
        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            _mode = 0;
            SetVisibilityMode();
        }

        private void SetVisibilityMode()
        {
            switch (_mode)
            {
                case 0:
                    stackPanelMode.Visibility = Visibility.Visible;
                    stackPanelNewBudgetSettings.Visibility = Visibility.Collapsed;
                    stackPanelReadBudgets.Visibility = Visibility.Collapsed;
                    buttonToMainMenu.Visibility = Visibility.Visible;
                    break;

                case 1:
                    stackPanelMode.Visibility = Visibility.Collapsed;
                    stackPanelNewBudgetSettings.Visibility = Visibility.Visible;
                    stackPanelReadBudgets.Visibility = Visibility.Collapsed;
                    buttonToMainMenu.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    stackPanelMode.Visibility = Visibility.Collapsed;
                    stackPanelNewBudgetSettings.Visibility = Visibility.Collapsed;
                    stackPanelReadBudgets.Visibility = Visibility.Visible;
                    buttonToMainMenu.Visibility = Visibility.Collapsed;
                    break;
            }
        }

    }
}
