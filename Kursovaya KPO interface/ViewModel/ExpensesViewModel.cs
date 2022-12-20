using Kursovaya_DAL;
using Kursovaya_KPO_interface.Infrastructure;
using Kursovaya_KPO_interface.Model.Interfaces;
using Kursovaya_KPO_interface.Model.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kursovaya_KPO_interface.ViewModel
{
    public class ExpensesViewModel : ViewModelBase
    {
        //static fields 
        public static Uri ExpensesUri { get; set; }

        //private fields
        short _mode;
        string _greeting;
        Uri _mainMenuUri;
        IDbCrud _dbOperations;
        ObservableCollection<ExpenseModel> _allExpenses;
        UserModel _user;
        List<ExpenseTypesModel> _expenseTypes;
        DateTime _startDate;
        ExpenseModel _selectedExpense;
        int _selectedExpenseTypesId;

        //ctors
        public ExpensesViewModel()
        {
            _user         = StartMenuViewModel.SelectedUser;
            Greeting      = _user.Name;
            _mainMenuUri  = MainMenuViewModel.MainMenuUri;
            ExpensesUri   = MainMenuViewModel.ExpensesUri;
            _dbOperations = App.MyMainWindow.CrudDb;
            _expenseTypes = _dbOperations.GetAllExpenseTypes();
            _startDate    = DateTime.Today;

            LoadUserExpenses();
        }

        //public properties
        public string Greeting
        {
            get
            {
                if (string.IsNullOrEmpty(_greeting))
                    _greeting = "Расходы пользователя";
                return _greeting;
            }
            set
            {
                _greeting = "Расходы пользователя " + value;
                OnPropertyChanged("Greeting");
            }
        }
        public ObservableCollection<ExpenseModel> AllExpenses
        {
            get
            {
                return _allExpenses;
            }
            set
            {
                _allExpenses = value;
                OnPropertyChanged("AllExpenses");
            }
        }
        public DateTime StartDate
        {
            get
            {
                if (_startDate == null)
                    _startDate = DateTime.Today;
                return _startDate;
            }
            set
            {
                _startDate = value;
                OnPropertyChanged("StartDate");
            }
        }
        public ExpenseModel SelectedExpense
        {
            get
            {
                if (_selectedExpense == null)
                {
                    _selectedExpense = new ExpenseModel
                    {
                        UserId = _user.Id,
                        Date = DateTime.Today,
                    };
                }
                return _selectedExpense;
            }
            set
            {
                _selectedExpense = value;
                OnPropertyChanged("SelectedExpense");
            }
        }
        public List<ExpenseTypesModel> ExpenseTypes
        {
            get
            {
                if (_expenseTypes == null)
                    _expenseTypes = _dbOperations.GetAllExpenseTypes();
                return _expenseTypes;
            }
            set
            {
                _expenseTypes = value;
                OnPropertyChanged("ExpenseTypes");
            }
        }
        public int SelectedExpenseTypesId
        {
            get
            {
                if (_selectedExpenseTypesId == null)
                    _selectedExpenseTypesId = 0;
                return _selectedExpenseTypesId;
            }
            set
            {
                _selectedExpenseTypesId = value;
                OnPropertyChanged("SelectedExpenseTypesId");
            }
        }

        //public methods
        private void LoadUserExpenses()
        {
            AllExpenses = new ObservableCollection<ExpenseModel>(_dbOperations.GetAllExpenses(_user.Id).OrderBy(x => x.Date));

            foreach (var expense in AllExpenses)
            {
                expense.ExpenseType = _dbOperations.GetExpenseTypesById(expense.ExpenseTypesId).Name;
            }
        }

        //commands regions

        #region ToMainMenu

        RelayCommand _toMainMenu;
        public ICommand ToMainMenu
        {
            get
            {
                if (_toMainMenu == null)
                    _toMainMenu = new RelayCommand(ExecuteToMainMenuCommand, CanExecuteToMainMenuCommand);
                return _toMainMenu;
            }
        }

        public void ExecuteToMainMenuCommand(object parameter)
        {
            Navigator.Page = parameter as Page;
            if (_mainMenuUri == null)
                _mainMenuUri = new Uri("View/MainMenu.xaml", UriKind.Relative);
            Navigator.Page.NavigationService.Navigate(_mainMenuUri);
        }

        public bool CanExecuteToMainMenuCommand(object parameter)
        {
            return true;
        }
        #endregion

        #region DeleteExpense

        RelayCommand _deleteExpense;
        public ICommand DeleteExpense
        {
            get
            {
                if (_deleteExpense == null)
                    _deleteExpense = new RelayCommand(ExecuteDeleteExpenseCommand, CanExecuteDeleteExpenseCommand);
                return _deleteExpense;
            }
        }

        public void ExecuteDeleteExpenseCommand(object parameter)
        {
            _dbOperations.DeleteExpense(SelectedExpense.Id);
            LoadUserExpenses();
        }

        public bool CanExecuteDeleteExpenseCommand(object parameter)
        {
            if (SelectedExpense == null)
                return false;
            return true;
        }
        #endregion

        #region CreateExpense

        RelayCommand _createExpense;
        public ICommand CreateExpense
        {
            get
            {
                if (_createExpense == null)
                    _createExpense = new RelayCommand(ExecuteCreateExpenseCommand, CanExecuteCreateExpenseCommand);
                return _createExpense;
            }
        }

        public void ExecuteCreateExpenseCommand(object parameter)
        {
            _selectedExpense = new ExpenseModel()
            {
                UserId = _user.Id,
                Date = DateTime.Today
            };

            _mode = 0;
        }

        public bool CanExecuteCreateExpenseCommand(object parameter)
        {
            return true;
        }
        #endregion

        #region UpdateExpense

        RelayCommand _updateExpense;
        public ICommand UpdateExpense
        {
            get
            {
                if (_updateExpense == null)
                    _updateExpense = new RelayCommand(ExecuteUpdateExpenseCommand, CanExecuteUpdateExpenseCommand);
                return _updateExpense;
            }
        }

        public void ExecuteUpdateExpenseCommand(object parameter)
        {
            StartDate = SelectedExpense.Date;
            SelectedExpenseTypesId = SelectedExpense.ExpenseTypesId - 1;
            _mode = 1;
        }

        public bool CanExecuteUpdateExpenseCommand(object parameter)
        {
            if (SelectedExpense != null)
                return true;
            return false;
        }
        #endregion

        #region Cancel

        RelayCommand _cancel;
        public ICommand Cancel
        {
            get
            {
                if (_cancel == null)
                    _cancel = new RelayCommand(ExecuteCancelCommand, CanExecuteCancelCommand);
                return _cancel;
            }
        }

        public void ExecuteCancelCommand(object parameter)
        {
            SelectedExpense = null;
        }

        public bool CanExecuteCancelCommand(object parameter)
        {
            return true;
        }
        #endregion

        #region AddExpenseDate

        RelayCommand _addExpenseDate;
        public ICommand AddExpenseDate
        {
            get
            {
                if (_addExpenseDate == null)
                    _addExpenseDate = new RelayCommand(ExecuteAddExpenseDateCommand, CanExecuteAddExpenseDateCommand);
                return _addExpenseDate;
            }
        }

        public void ExecuteAddExpenseDateCommand(object parameter)
        {
            _selectedExpense.Date = StartDate;
        }

        public bool CanExecuteAddExpenseDateCommand(object parameter)
        {
            if (StartDate >= DateTime.MinValue)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region AddExpenseTypesId

        RelayCommand _addExpenseTypesId;
        public ICommand AddExpenseTypesId
        {
            get
            {
                if (_addExpenseTypesId == null)
                    _addExpenseTypesId = new RelayCommand(ExecuteAddExpenseTypesIdCommand, CanExecuteAddExpenseTypesIdCommand);
                return _addExpenseTypesId;
            }
        }

        public void ExecuteAddExpenseTypesIdCommand(object parameter)
        {
            _selectedExpense.ExpenseTypesId = SelectedExpenseTypesId + 1; //из-за моей тупизны я задал в бд айдишник с единицы(для всех ъуъ сущностей)
        }

        public bool CanExecuteAddExpenseTypesIdCommand(object parameter)
        {
            if (SelectedExpenseTypesId > -1)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region AddExpenseName

        RelayCommand _addExpenseName;
        public ICommand AddExpenseName
        {
            get
            {
                if (_addExpenseName == null)
                    _addExpenseName = new RelayCommand(ExecuteAddExpenseNameCommand, CanExecuteAddExpenseNameCommand);
                return _addExpenseName;
            }
        }

        public void ExecuteAddExpenseNameCommand(object parameter)
        {
            _selectedExpense.Name = SelectedExpense.Name;
        }

        public bool CanExecuteAddExpenseNameCommand(object parameter)
        {
            if (!string.IsNullOrEmpty(SelectedExpense.Name))
            {
                return true;
            }
            return false;
        }
        #endregion

        #region AddExpenseValueAndSave

        RelayCommand _addExpenseValueAndSave;
        public ICommand AddExpenseValueAndSave
        {
            get
            {
                if (_addExpenseValueAndSave == null)
                    _addExpenseValueAndSave = new RelayCommand(ExecuteAddExpenseValueAndSaveCommand, CanExecuteAddExpenseValueAndSaveCommand);
                return _addExpenseValueAndSave;
            }
        }

        public void ExecuteAddExpenseValueAndSaveCommand(object parameter)
        {
            _selectedExpense.Value = SelectedExpense.Value;
            switch (_mode)
            {
                case 0:
                    _dbOperations.CreateExpense(_selectedExpense);
                    break;
                case 1:
                    _selectedExpense.ExpenseType = _dbOperations.GetExpenseTypesById(_selectedExpense.ExpenseTypesId).Name;
                    _dbOperations.UpdateExpense(_selectedExpense);
                    break;
            }
            LoadUserExpenses();
            _selectedExpense = null;
        }

        public bool CanExecuteAddExpenseValueAndSaveCommand(object parameter)
        {
            if (SelectedExpense.Value > 0)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
