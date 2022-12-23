using Kursovaya_KPO_interface.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kursovaya_KPO_interface.ViewModel
{
    public class MainMenuViewModel : ViewModelBase
    {
        //static properties
        public static Uri MainMenuUri { get; set; }
        public static Uri IncomesUri { get; set; }
        public static Uri ExpensesUri { get; set; }
        public static Uri BudgetMenuUri { get; set; }

        //private fields
        private string _greeting;
        private Uri _startMenuUri;
             
        //ctors
        public MainMenuViewModel()
        {
            Greeting      = StartMenuViewModel.SelectedUser.Name;
            _startMenuUri = StartMenuViewModel.StartMenuUri;
            MainMenuUri   = StartMenuViewModel.MainMenuUri;
        }

        //public properties
        public string Greeting
        {
            get
            {
                if (string.IsNullOrEmpty(_greeting))
                    _greeting = "Добро пожаловать, пользователь";
                return _greeting;
            }
            set
            {
                _greeting = "Добро пожаловать, " + value;
                OnPropertyChanged("Greeting");
            }
        }

        //commands regions
        #region ToBudgetMenu

        RelayCommand _toBudgetMenu;
        public ICommand ToBudgetMenu
        {
            get
            {
                if (_toBudgetMenu == null)
                    _toBudgetMenu = new RelayCommand(ExecuteToBudgetMenuCommand, CanExecuteToBudgetMenuCommand);
                return _toBudgetMenu;
            }
        }

        public void ExecuteToBudgetMenuCommand(object parameter)
        {
            Navigator.Page = parameter as Page;
            if (BudgetMenuUri == null)
                BudgetMenuUri = new Uri("View/BudgetMenu.xaml", UriKind.Relative);
            Navigator.Page.NavigationService.Navigate(BudgetMenuUri);
        }

        public bool CanExecuteToBudgetMenuCommand(object parameter)
        {
            return true;
        }
        #endregion

        #region ToStartMenu

        RelayCommand _toStartMenu;
        public ICommand ToStartMenu
        {
            get
            {
                if (_toStartMenu == null)
                    _toStartMenu = new RelayCommand(ExecuteToStartMenuCommand, CanExecuteToStartMenuCommand);
                return _toStartMenu;
            }
        }

        public void ExecuteToStartMenuCommand(object parameter)
        {
            Navigator.Page = parameter as Page;
            if (_startMenuUri == null)
                _startMenuUri = new Uri("View/StartMenu.xaml", UriKind.Relative);
            Navigator.Page.NavigationService.Navigate(_startMenuUri);
        }

        public bool CanExecuteToStartMenuCommand(object parameter)
        {
            return true;
        }
        #endregion

        #region ToExpenses

        RelayCommand _toExpenses;
        public ICommand ToExpenses
        {
            get
            {
                if (_toExpenses == null)
                    _toExpenses = new RelayCommand(ExecuteToExpensesCommand, CanExecuteToExpensesCommand);
                return _toExpenses;
            }
        }

        public void ExecuteToExpensesCommand(object parameter)
        {
            Navigator.Page = parameter as Page;
            if (ExpensesUri == null)
                ExpensesUri = new Uri("View/Expenses.xaml", UriKind.Relative);
            Navigator.Page.NavigationService.Navigate(ExpensesUri);
        }

        public bool CanExecuteToExpensesCommand(object parameter)
        {
            return true;
        }
        #endregion

        #region ToIncomes

        RelayCommand _toIncomes;
        public ICommand ToIncomes
        {
            get
            {
                if (_toIncomes == null)
                    _toIncomes = new RelayCommand(ExecuteToIncomesCommand, CanExecuteToIncomesCommand);
                return _toIncomes;
            }
        }

        public void ExecuteToIncomesCommand(object parameter)
        {
            Navigator.Page = parameter as Page;
            if (IncomesUri == null)
                IncomesUri = new Uri("View/Incomes.xaml", UriKind.Relative);
            Navigator.Page.NavigationService.Navigate(IncomesUri);
        }

        public bool CanExecuteToIncomesCommand(object parameter)
        {
            return true;
        }
        #endregion


    }
}
