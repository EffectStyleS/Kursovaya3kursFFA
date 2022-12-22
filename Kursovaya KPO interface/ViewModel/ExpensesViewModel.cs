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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kursovaya_KPO_interface.ViewModel
{
    public class ExpensesViewModel : ViewModelBase
    {
        //static fields 
        public static Uri ExpensesUri { get; set; }

        //private fields
        private short _mode;
        private string _greeting;
        private Uri _mainMenuUri;
        private IDbCrud _dbOperations;
        private ObservableCollection<ExpenseModel> _allExpenses;
        private UserModel _user;
        private List<ExpenseTypesModel> _expenseTypes;
        private DateTime _startDate;
        private ExpenseModel _selectedExpense;
        private int _selectedExpenseTypesId;
        private string _warning;
        private List<BudgetModel> _userBudgets;
        private IReportsService _reportsService;
        private IBudgetService _budgetService;
        private List<List<decimal?>> _differences;
        private decimal? _difference;
        private BudgetModel _differenceBudget;
        private ExpenseTypesModel _differenceType;
        private List<UserModel> _users;
        private Visibility _adminMode;
        private UserModel _readableUser;
        private int _selectedUserId;

        //ctors
        public ExpensesViewModel()
        {
            _user           = StartMenuViewModel.SelectedUser;
            _mainMenuUri    = MainMenuViewModel.MainMenuUri;
            ExpensesUri     = MainMenuViewModel.ExpensesUri;
            _dbOperations   = App.MyMainWindow.CrudDb;
            ExpenseTypes    = _dbOperations.GetAllExpenseTypes();
            StartDate       = DateTime.Today;            
            _reportsService = App.MyMainWindow.ReportsService;
            _budgetService  = App.MyMainWindow.BudgetService;
            ReadableUser    = _user;

            SelectedUserId = Users.IndexOf(ReadableUser);

            SetGreeting();
            LoadUserExpenses();
            GetDifference();
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
                _greeting = value;
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
        public string Warning
        {
            get
            {
                if (_warning == null)
                    _warning = " ";
                return _warning;
            }
            set
            {
                _warning = value;
                OnPropertyChanged(nameof(Warning));
            }
        }               
        public List<List<decimal?>> Differences
        {
            get
            {
                if (_differences == null)
                    _differences = new List<List<decimal?>>();
                return _differences;
            }
            set
            {
                _differences= value;
                OnPropertyChanged(nameof(_differences));
            }
        }
        public decimal? Difference
        {
            get
            {
                return _difference;
            }
            set
            {
                _difference = value;
                OnPropertyChanged(nameof(Difference));
            }
        }
        public List<BudgetModel> UserBudgets
        {
            get
            {
                if (_userBudgets == null)
                    _userBudgets = _dbOperations.GetAllUserBudgets(_user.Id);
                return _userBudgets;
            }
            set
            {
                _userBudgets = value;
                OnPropertyChanged(nameof(UserBudgets));
            }
        }
        public BudgetModel DifferenceBudget
        {
            get
            {
                if (_differenceBudget == null)
                    _differenceBudget = new BudgetModel();
                return _differenceBudget;
            }
            set
            {
                _differenceBudget = value;
                OnPropertyChanged(nameof(DifferenceBudget));
            }
        }
        public ExpenseTypesModel DifferenceType
        {
            get
            {
                if (_differenceType == null)
                    _differenceType = new ExpenseTypesModel();
                return _differenceType;
            }
            set
            {
                _differenceType = value;
                OnPropertyChanged(nameof(DifferenceType));
            }
        }
        public List<UserModel> Users
        {
            get
            {
                if (_users == null)
                    _users = _dbOperations.GetAllUsers();
                return _users;
            }
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }
        public UserModel ReadableUser
        {
            get
            {
                if (_readableUser == null)
                    _readableUser = new UserModel();
                return _readableUser;
            }
            set
            {
                _readableUser = value;
                OnPropertyChanged(nameof(ReadableUser));
            }
        }
        public Visibility AdminMode
        {
            get
            {
                if (_user.Role == 0)
                    _adminMode = Visibility.Visible;
                else
                    _adminMode = Visibility.Collapsed;
                return _adminMode;
            }
            set
            {
                _adminMode = value;
                OnPropertyChanged(nameof(AdminMode));
            }
        }
        public int SelectedUserId
        {
            get
            {
                return _selectedUserId;
            }
            set
            {
                _selectedUserId = value;
                if (value > -1)
                {
                    ReadableUser = Users[SelectedUserId];
                    LoadUserExpenses();
                }
                OnPropertyChanged(nameof(SelectedUserId));
            }
        }
                     
        //private methods
        private void LoadUserExpenses()
        {
            if(_user.Role == 1)
                AllExpenses = new ObservableCollection<ExpenseModel>(_dbOperations.GetAllExpenses(_user.Id).OrderBy(x => x.Date));
            if(_user.Role == 0)
                AllExpenses = new ObservableCollection<ExpenseModel>(_dbOperations.GetAllExpenses(ReadableUser.Id).OrderBy(x => x.Date));

            foreach (var expense in AllExpenses)
            {
                expense.ExpenseType = _dbOperations.GetExpenseTypesById(expense.ExpenseTypesId).Name;
            }
        }
        private void SetGreeting()
        {
            if (_user.Role == 0)
                Greeting = "Расходы пользователей";
            else
                Greeting = "Расходы пользователя" + _user.Name;
        }
        private void GetDifference()
        {
            Differences = _reportsService.TakeDifferenceOfExpensesSum(_user);

            for(int i = 0; i < Differences.Count; i++)
            {
                _budgetService.CreateProperties(UserBudgets[i]);
                var budgetDifferences = Differences[i];

                for(int j = 0; j < budgetDifferences.Count; j++)
                {
                    if (budgetDifferences[j] > 0)
                    {
                        Difference = budgetDifferences[j];
                        DifferenceBudget = UserBudgets[i];
                        DifferenceType = ExpenseTypes[j];
                    }
                }
            }

            if (Difference != null)
            {
                Warning = $"Категория {DifferenceType.Name} превысила бюджет на {DifferenceBudget.Properties} на {Difference}руб.";
                Difference = null;
            }
            else
                Warning = "";
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
            GetDifference();
        }

        public bool CanExecuteDeleteExpenseCommand(object parameter)
        {
            if (SelectedExpense != null && ReadableUser.Id != _user.Id)
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
            if (ReadableUser.Id != _user.Id)
                return false;
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
            if (SelectedExpense != null && ReadableUser.Id != _user.Id)
                return false;
            return true;
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
            GetDifference();
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
