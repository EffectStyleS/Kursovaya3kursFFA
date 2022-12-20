using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Incomes.xaml
    /// </summary>
    public partial class Incomes : Page
    {
        public Incomes()
        {
            InitializeComponent(); 
        }

        private void Name_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.Text = string.Empty;
            tb.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            tb.GotFocus -= Name_GotFocus;
        }

        private void NumberTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.Text = string.Empty;
            tb.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            tb.GotFocus -= Name_GotFocus;
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ButtonAddIncome_Click(object sender, RoutedEventArgs e)
        {
            stackPanelCrudMenu.Visibility = Visibility.Collapsed;
            stackPanelDate.Visibility = Visibility.Visible;
        }

        private void ButtonAddIncomeDate_Click(object sender, RoutedEventArgs e)
        {
            stackPanelDate.Visibility = Visibility.Collapsed;
            stackPanelType.Visibility = Visibility.Visible;
        }

        private void ButtonAddIncomeType_Click(object sender, RoutedEventArgs e)
        {
            stackPanelType.Visibility = Visibility.Collapsed;
            stackPanelName.Visibility = Visibility.Visible;
        }

        private void ButtonAddIncomeName_Click(object sender, RoutedEventArgs e)
        {
            stackPanelName.Visibility = Visibility.Collapsed;
            stackPanelValue.Visibility = Visibility.Visible;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            stackPanelCrudMenu.Visibility = Visibility.Visible;
            stackPanelDate.Visibility = Visibility.Collapsed;
            stackPanelType.Visibility = Visibility.Collapsed;
            stackPanelName.Visibility = Visibility.Collapsed;
            stackPanelValue.Visibility = Visibility.Collapsed;
        }
    }
}
