using Kursovaya_DAL;
using Kursovaya_KPO_interface.Infrastructure;
using Kursovaya_KPO_interface.Model.Interfaces;
using Kursovaya_KPO_interface.Model.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kursovaya_KPO_interface.ViewModel
{
    public class BudgetMenuViewModel : ViewModelBase
    {
        //events
        private delegate void FillPlannedExpensesAndIncomes();
        private event FillPlannedExpensesAndIncomes OnSelectingBudget;

        public delegate void NewBudgetCreatingForPlannedExpenses(List<PlannedExpensesModel> plannedExpenses);
        public event NewBudgetCreatingForPlannedExpenses OnCreatingFPE;

        public delegate void NewBudgetCreatingForPlannedIncomes(List<PlannedIncomesModel> plannedIncomes);
        public event NewBudgetCreatingForPlannedIncomes OnCreatingFPI;

        //static properties
        public static BudgetMenuViewModel Instance{ get; } = new BudgetMenuViewModel();
        public static Uri BudgetMenuUri { get; set; }
        public static Uri PlannedExpensesUri { get; set; }
        public static Uri PlannedIncomesUri { get; set; }

        //private fields
        private short _mode;
        private Uri _mainMenuUri;
        private IDbCrud _dbOperations;
        private UserModel _user;
        private BudgetModel _newBudget;
        private List<TimePeriodModel> _timePeriods;
        private DateTime _startDate;
        private int _selectedTimePeriodId;
        private List<PlannedExpensesModel> _plannedExpenses;
        private List<PlannedIncomesModel> _plannedIncomes;
        private string _saveResult;
        private List<BudgetModel> _userBudgets;
        private IBudgetService _budgetService;
        private int _selectedBudgetId;
        private List<ExpenseTypesModel> _expenseTypes;
        private List<IncomeTypesModel> _incomeTypes;
        private decimal? _saldo;
        private IPlannedExpensesService _plannedExpensesService;
        private IPlannedIncomesService _plannedIncomesService;
        private string _filePath;
        private List<UserModel> _users;
        private Visibility _adminMode;
        private UserModel _readableUser;
        private int _selectedUserId;

        //ctors
        public BudgetMenuViewModel()
        {
            _user                   = StartMenuViewModel.SelectedUser;
            _dbOperations           = App.MyMainWindow.CrudDb;
            _budgetService          = App.MyMainWindow.BudgetService;
            _plannedExpensesService = App.MyMainWindow.PlannedExpensesService;
            _plannedIncomesService  = App.MyMainWindow.PlannedIncomesService;
            BudgetMenuUri           = MainMenuViewModel.BudgetMenuUri;
            _mainMenuUri            = MainMenuViewModel.MainMenuUri;
            _timePeriods            = _dbOperations.GetAllTimePeriods();
            _startDate              = DateTime.Today;

            PlannedExpensesViewModel.Instance.OnSave += TakePlannedExpenses;
            PlannedIncomesViewModel.Instance.OnSave  += TakePlannedIncomes;

            OnSelectingBudget += LoadUserBudgets;
        }

        //public properties
        public List<TimePeriodModel> TimePeriods
        {
            get
            {
                if (_timePeriods == null)
                    _timePeriods = _dbOperations.GetAllTimePeriods();
                return _timePeriods;
            }
            set
            {
                _timePeriods = value;
                OnPropertyChanged(nameof(TimePeriods));
            }
        }
        public int SelectedTimePeriodId
        {
            get
            {
                if (_selectedTimePeriodId == null)
                    _selectedTimePeriodId = 0;
                return _selectedTimePeriodId;
            }
            set
            {
                _selectedTimePeriodId = value;
                OnPropertyChanged(nameof(SelectedTimePeriodId));
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
        public BudgetModel NewBudget
        {
            get
            {
                if (_newBudget == null)
                    _newBudget = new BudgetModel()
                    {
                        UserId = _user.Id
                    };
                return _newBudget;
            }
            set
            {
                _newBudget = value;
                OnPropertyChanged(nameof(NewBudget));
            }
        }
        public List<PlannedExpensesModel> PlannedExpenses
        {
            get
            {                
                return _plannedExpenses;
            }
            set
            {
                _plannedExpenses = value;
                OnPropertyChanged(nameof(PlannedExpenses));
            }
        }
        public List<PlannedIncomesModel> PlannedIncomes
        {
            get
            {                
                return _plannedIncomes;
            }
            set
            {
                _plannedIncomes = value;
                OnPropertyChanged(nameof(PlannedIncomes));
            }
        }
        public string SaveResult
        {
            get
            {
                if (_saveResult == null)
                {
                    _saveResult = "";
                }
                return _saveResult;
            }
            set
            {
                _saveResult = value;
                OnPropertyChanged(nameof(SaveResult));
            }
        }
        public List<BudgetModel> UserBudgets
        {
            get
            {
                if (_userBudgets == null)
                {
                    _userBudgets = _dbOperations.GetAllUserBudgets(_user.Id);
                    foreach (var budget in _userBudgets)
                    {
                        _budgetService.CreateProperties(budget);
                    }
                }
                return _userBudgets;
            }
            set
            {
                _userBudgets = value;
                foreach (var budget in _userBudgets)
                {
                    _budgetService.CreateProperties(budget);
                }
                OnPropertyChanged(nameof(UserBudgets));
            }
        }
        public int SelectedBudgetId
        {
            get 
            {
                if (_selectedBudgetId == null)
                    _selectedBudgetId = 0;
                return _selectedBudgetId;
            }
            set
            {
                _selectedBudgetId = value;

                if(value > -1)
                    OnSelectingBudget();

                OnPropertyChanged(nameof(SelectedBudgetId));
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
        }
        public List<IncomeTypesModel> IncomeTypes
        {
            get
            {
                if (_incomeTypes == null)
                    _incomeTypes = _dbOperations.GetAllIncomeTypes();
                return _incomeTypes;
            }
        }
        public decimal? Saldo
        {
            get
            {
                if (_saldo == null)
                    _saldo = 0;
                return _saldo;
            }
            set
            {
                _saldo = value;
                OnPropertyChanged(nameof(Saldo));
            }
        }
        public string FilePath
        {
            get
            {
                if (_filePath == null)
                    _filePath = "Бюджет.pdf";
                return _filePath; 
            }
            set
            {
                _filePath = value;
                OnPropertyChanged(nameof(FilePath));
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
                    UserBudgets = _dbOperations.GetAllUserBudgets(ReadableUser.Id);
                    SelectedBudgetId = 0;
                }
                OnPropertyChanged(nameof(SelectedUserId));
            }
        }

        //private methods
        private void LoadUserBudgets()
        {
            if(UserBudgets.Count == 0)
            {
                PlannedExpenses = null;
                PlannedIncomes = null;
                Saldo = 0.0m;
            }

            else
            {
                PlannedExpenses = _dbOperations.GetAllBudgetsPlannedExpenses(UserBudgets[SelectedBudgetId].Id);

                for (int i = 0; i < PlannedExpenses.Count; i++)
                {
                    PlannedExpenses[i].ExpenseType = ExpenseTypes[i].Name;
                }

                PlannedIncomes = _dbOperations.GetAllBudgetsPlannedIncomes(UserBudgets[SelectedBudgetId].Id);
                for (int i = 0; i < PlannedIncomes.Count; i++)
                {
                    PlannedIncomes[i].IncomeType = IncomeTypes[i].Name;
                }

                Saldo = _plannedIncomesService.GetSumOfAllPlannedIncomes(PlannedIncomes)
                    - _plannedExpensesService.GetSumOfAllPlannedExpenses(PlannedExpenses);
            }
            
        }

        //public methods

            //events handlers
        public void TakePlannedExpenses(List<PlannedExpensesModel> plannedExpenses)
        {
            PlannedExpenses = plannedExpenses;
        }
        public void TakePlannedIncomes(List<PlannedIncomesModel> plannedIncomes)
        {
            PlannedIncomes = plannedIncomes;
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

        #region ToPlannedExpenses

        RelayCommand _toPlannedExpenses;
        public ICommand ToPlannedExpenses
        {
            get
            {
                if (_toPlannedExpenses == null)
                    _toPlannedExpenses = new RelayCommand(ExecuteToPlannedExpensesCommand, CanExecuteToPlannedExpensesCommand);
                return _toPlannedExpenses;
            }
        }

        public void ExecuteToPlannedExpensesCommand(object parameter)
        {
            Navigator.Page = parameter as Page;
            if (PlannedExpensesUri == null)
                PlannedExpensesUri = new Uri("View/PlannedExpenses.xaml", UriKind.Relative);
            Navigator.Page.NavigationService.Navigate(PlannedExpensesUri);
        }

        public bool CanExecuteToPlannedExpensesCommand(object parameter)
        {
            return true;
        }
        #endregion

        #region ToPlannedIncomes

        RelayCommand _toPlannedIncomes;
        public ICommand ToPlannedIncomes
        {
            get
            {
                if (_toPlannedIncomes == null)
                    _toPlannedIncomes = new RelayCommand(ExecuteToPlannedIncomesCommand, CanExecuteToPlannedIncomesCommand);
                return _toPlannedIncomes;
            }
        }

        public void ExecuteToPlannedIncomesCommand(object parameter)
        {
            Navigator.Page = parameter as Page;
            if (PlannedIncomesUri == null)
                PlannedIncomesUri = new Uri("View/PlannedIncomes.xaml", UriKind.Relative);
            Navigator.Page.NavigationService.Navigate(PlannedIncomesUri);
        }

        public bool CanExecuteToPlannedIncomesCommand(object parameter)
        {
            return true;
        }
        #endregion

        #region CreateBudget

        RelayCommand _createBudget;
        public ICommand CreateBudget
        {
            get
            {
                if (_createBudget == null)
                    _createBudget = new RelayCommand(ExecuteCreateBudgetCommand, CanExecuteCreateBudgetCommand);
                return _createBudget;
            }
        }

        public void ExecuteCreateBudgetCommand(object parameter)
        {
            _mode = 1;
            _user = StartMenuViewModel.SelectedUser;
            OnPropertyChanged(nameof(AdminMode));

            NewBudget = new BudgetModel()
            {
                UserId = _user.Id
            };

            PlannedExpenses = null;
            PlannedIncomes = null;

            SaveResult = "";
            NewBudget = null;
        }

        public bool CanExecuteCreateBudgetCommand(object parameter)
        {
            return true;
        }
        #endregion

        #region ReadBudgets

        RelayCommand _readBudgets;
        public ICommand ReadBudgets
        {
            get
            {
                if (_readBudgets == null)
                    _readBudgets = new RelayCommand(ExecuteReadBudgetsCommand, CanExecuteReadBudgetsCommand);
                return _readBudgets;
            }
        }

        public void ExecuteReadBudgetsCommand(object parameter)
        {
            _user = StartMenuViewModel.SelectedUser;
            OnPropertyChanged(nameof(AdminMode));

            PlannedExpenses = null;
            PlannedIncomes = null;

            ReadableUser = _user;
            SelectedUserId = Users.IndexOf(ReadableUser);

            if (_user.Role != 0)
            {
                UserBudgets = _dbOperations.GetAllUserBudgets(_user.Id);
                SelectedBudgetId = 0;
            }

            _mode = 2;           
        }

        public bool CanExecuteReadBudgetsCommand(object parameter)
        {
            return true;
        }
        #endregion

        #region SavePDF

        RelayCommand _savePDF;
        public ICommand SavePDF
        {
            get
            {
                if (_savePDF == null)
                    _savePDF = new RelayCommand(ExecuteSavePDFCommand, CanExecuteSavePDFCommand);
                return _savePDF;
            }
        }

        public void ExecuteSavePDFCommand(object parameter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                FilePath = saveFileDialog.FileName;
            }

            _budgetService.SavePDF(UserBudgets[SelectedBudgetId], FilePath);
        }

        public bool CanExecuteSavePDFCommand(object parameter)
        {
            return true;
        }
        #endregion

        #region SaveBudget

        RelayCommand _saveBudget;
        public ICommand SaveBudget
        {
            get
            {
                if (_saveBudget == null)
                    _saveBudget = new RelayCommand(ExecuteSaveBudgetCommand, CanExecuteSaveBudgetCommand);
                return _saveBudget;
            }
        }

        public void ExecuteSaveBudgetCommand(object parameter)
        {
            if(PlannedExpenses != null && PlannedIncomes != null)
            {
                NewBudget.StartDate = StartDate;                
                NewBudget.TimePeriodId = SelectedTimePeriodId + 1; //из-за комбобокса, там индексы с нуля
                
                _dbOperations.CreateBudget(NewBudget);
                var newBudgetId = _dbOperations.GetAllBudgets().Last().Id;

                foreach (PlannedExpensesModel plannedExpense in PlannedExpenses)
                {
                    plannedExpense.BudgetId = newBudgetId;
                    _dbOperations.CreatePlannedExpense(plannedExpense);
                }

                foreach (PlannedIncomesModel plannedIncome in PlannedIncomes)
                {
                    plannedIncome.BudgetId = newBudgetId;
                    _dbOperations.CreatePlannedIncome(plannedIncome);
                }

                SaveResult = "Бюджет сохранён";
                NewBudget = null;
                PlannedExpenses = null;
                PlannedIncomes = null;
                OnCreatingFPE(PlannedExpenses);
                OnCreatingFPI(PlannedIncomes);
            }
            else if(PlannedIncomes == null)
            {
                SaveResult = "Не заполнены запланированные доходы";
            }
            else
            {
                SaveResult = "Не заполнены запланированные расходы";
            }           
        }

        public bool CanExecuteSaveBudgetCommand(object parameter)
        {
            return true;
        }
        #endregion

        #region SaveFamilyBudget

        RelayCommand _saveFamilyBudget;
        public ICommand SaveFamilyBudget
        {
            get
            {
                if (_saveFamilyBudget == null)
                    _saveFamilyBudget = new RelayCommand(ExecuteSaveFamilyBudgetCommand, CanExecuteSaveFamilyBudgetCommand);
                return _saveFamilyBudget;
            }
        }

        public void ExecuteSaveFamilyBudgetCommand(object parameter)
        {
            if (PlannedExpenses != null && PlannedIncomes != null)
            {
                foreach (var user in Users)
                {
                    NewBudget.StartDate = StartDate;
                    NewBudget.TimePeriodId = SelectedTimePeriodId + 1; //из-за комбобокса, там индексы с нуля
                    NewBudget.UserId = user.Id;

                    _dbOperations.CreateBudget(NewBudget);
                    var newBudgetId = _dbOperations.GetAllBudgets().Last().Id;

                    foreach (PlannedExpensesModel plannedExpense in PlannedExpenses)
                    {
                        plannedExpense.BudgetId = newBudgetId;
                        _dbOperations.CreatePlannedExpense(plannedExpense);
                    }

                    foreach (PlannedIncomesModel plannedIncome in PlannedIncomes)
                    {
                        plannedIncome.BudgetId = newBudgetId;
                        _dbOperations.CreatePlannedIncome(plannedIncome);
                    }
                }

                SaveResult = "Бюджет сохранён";
                NewBudget = null;
                PlannedExpenses = null;
                PlannedIncomes = null;
                OnCreatingFPE(PlannedExpenses);
                OnCreatingFPI(PlannedIncomes);
            }
            else if (PlannedIncomes == null)
            {
                SaveResult = "Не заполнены запланированные доходы";
            }
            else
            {
                SaveResult = "Не заполнены запланированные расходы";
            }
        }

        public bool CanExecuteSaveFamilyBudgetCommand(object parameter)
        {
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
            NewBudget = null;
            PlannedExpenses = null;
            PlannedIncomes = null;
            OnCreatingFPE(PlannedExpenses);
            OnCreatingFPI(PlannedIncomes);
        }

        public bool CanExecuteCancelCommand(object parameter)
        {
            return true;
        }
        #endregion

    }
}
