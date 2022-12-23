using Kursovaya_KPO_interface.Infrastructure;
using Kursovaya_KPO_interface.Model.Interfaces;
using Kursovaya_KPO_interface.Model.Models;
using Kursovaya_KPO_interface.View;
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
    public class IncomesViewModel : ViewModelBase
    {
        //static properties 
        public static Uri IncomesUri { get; set; }

        //private fields
        private short _mode;
        private string _greeting;       
        private Uri _mainMenuUri;
        private IDbCrud _dbOperations;
        private ObservableCollection<IncomeModel> _allIncomes;
        private UserModel _user;
        private List<IncomeTypesModel> _incomeTypes;
        private DateTime _startDate;
        private IncomeModel _selectedIncome;
        private int _selectedIncomeTypesId;
        private List<UserModel> _users;
        private Visibility _adminMode;
        private UserModel _readableUser;
        private int _selectedUserId;

        //ctors
        public IncomesViewModel()
        {
            _user         = StartMenuViewModel.SelectedUser;            
            _mainMenuUri  = MainMenuViewModel.MainMenuUri;
            IncomesUri    = MainMenuViewModel.IncomesUri;
            _dbOperations = App.MyMainWindow.CrudDb;
            IncomeTypes  = _dbOperations.GetAllIncomeTypes();
            StartDate    = DateTime.Today;
            ReadableUser = _user;

            SelectedUserId = Users.IndexOf(ReadableUser);

            SetGreeting();
            LoadUserIncomes();
        }

        //public properties
        public string Greeting
        {
            get
            {
                if (string.IsNullOrEmpty(_greeting))
                    _greeting = "Доходы пользователя";
                return _greeting;
            }
            set
            {
                _greeting = value;
                OnPropertyChanged("Greeting");
            }
        }
        public ObservableCollection<IncomeModel> AllIncomes
        {
            get
            {
                return _allIncomes;
            }
            set
            {
                _allIncomes = value;
                OnPropertyChanged("AllIncomes");
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
        public IncomeModel SelectedIncome
        {
            get
            {
                if (_selectedIncome == null)
                {
                    _selectedIncome = new IncomeModel
                    {
                        UserId = _user.Id,
                        Date = DateTime.Today,
                    };
                }
                return _selectedIncome;
            }
            set
            {
                _selectedIncome = value;
                OnPropertyChanged("SelectedIncome");
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
            set
            {
                _incomeTypes = value;
                OnPropertyChanged("IncomeTypes");
            }
        }
        public int SelectedIncomeTypesId
        {
            get
            {
                if (_selectedIncomeTypesId == null)
                    _selectedIncomeTypesId = 0;
                return _selectedIncomeTypesId;
            }
            set
            {
                _selectedIncomeTypesId = value;
                OnPropertyChanged("SelectedIncomeTypesId");
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
                    LoadUserIncomes();
                }                   
                OnPropertyChanged(nameof(SelectedUserId));
            }
        }

        //private methods
        private void LoadUserIncomes()
        {
            if (_user.Role == 1)
                AllIncomes = new ObservableCollection<IncomeModel>(_dbOperations.GetAllIncomes(_user.Id).OrderBy(x => x.Date));
            if (_user.Role == 0)
                AllIncomes = new ObservableCollection<IncomeModel>(_dbOperations.GetAllIncomes(ReadableUser.Id).OrderBy(x => x.Date));
            
            foreach (var income in AllIncomes)
            {
                income.IncomeType = _dbOperations.GetIncomeTypesById(income.IncomeTypesId).Name;
            }
        }
        private void SetGreeting()
        {
            if (_user.Role == 0)
                Greeting = "Доходы пользователей";
            else
                Greeting = "Доходы пользователя" + _user.Name;
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

        #region DeleteIncome

        RelayCommand _deleteIncome;
        public ICommand DeleteIncome
        {
            get
            {
                if (_deleteIncome == null)
                    _deleteIncome = new RelayCommand(ExecuteDeleteIncomeCommand, CanExecuteDeleteIncomeCommand);
                return _deleteIncome;
            }
        }

        public void ExecuteDeleteIncomeCommand(object parameter)
        {
            _dbOperations.DeleteIncome(SelectedIncome.Id);
            LoadUserIncomes();
        }

        public bool CanExecuteDeleteIncomeCommand(object parameter)
        {
            if (_user.Role == 0 && ReadableUser.Id != _user.Id)
                return false;
            if (SelectedIncome == null || SelectedIncome.Id == 0)
                return false;
            return true;
        }
        #endregion
        
        #region CreateIncome

        RelayCommand _createIncome;
        public ICommand CreateIncome
        {
            get
            {
                if (_createIncome == null)
                    _createIncome = new RelayCommand(ExecuteCreateIncomeCommand, CanExecuteCreateIncomeCommand);
                return _createIncome;
            }
        }

        public void ExecuteCreateIncomeCommand(object parameter)
        {
            _selectedIncome = new IncomeModel()
            {
                UserId = _user.Id,
                Date = DateTime.Today
            };

            _mode = 0;
        }

        public bool CanExecuteCreateIncomeCommand(object parameter)
        {
            if (ReadableUser.Id != _user.Id)
                return false;
            return true;
        }
        #endregion

        #region UpdateIncome

        RelayCommand _updateIncome;
        public ICommand UpdateIncome
        {
            get
            {
                if (_updateIncome == null)
                    _updateIncome = new RelayCommand(ExecuteUpdateIncomeCommand, CanExecuteUpdateIncomeCommand);
                return _updateIncome;
            }
        }

        public void ExecuteUpdateIncomeCommand(object parameter)
        {
            StartDate = SelectedIncome.Date;
            SelectedIncomeTypesId = SelectedIncome.IncomeTypesId - 1;
            _mode = 1;
        }

        public bool CanExecuteUpdateIncomeCommand(object parameter)
        {
            if (_user.Role == 0 && ReadableUser.Id != _user.Id)
                return false;
            if (SelectedIncome == null || SelectedIncome.Id == 0)
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
            SelectedIncome = null;
        }

        public bool CanExecuteCancelCommand(object parameter)
        {
            return true;
        }
        #endregion

        #region AddIncomeDate
       
        RelayCommand _addIncomeDate;
        public ICommand AddIncomeDate
        {
            get
            {
                if (_addIncomeDate == null)
                    _addIncomeDate = new RelayCommand(ExecuteAddIncomeDateCommand, CanExecuteAddIncomeDateCommand);
                return _addIncomeDate;
            }
        }

        public void ExecuteAddIncomeDateCommand(object parameter)
        {
            _selectedIncome.Date = StartDate;
        }

        public bool CanExecuteAddIncomeDateCommand(object parameter)
        {
            if (StartDate >= DateTime.MinValue)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region AddIncomeTypesId
             
        RelayCommand _addIncomeTypesId;
        public ICommand AddIncomeTypesId
        {
            get
            {
                if (_addIncomeTypesId == null)
                    _addIncomeTypesId = new RelayCommand(ExecuteAddIncomeTypesIdCommand, CanExecuteAddIncomeTypesIdCommand);
                return _addIncomeTypesId;
            }
        }

        public void ExecuteAddIncomeTypesIdCommand(object parameter)
        {            
            _selectedIncome.IncomeTypesId = SelectedIncomeTypesId + 1;  //из-за комбобокса, там индексы с нуля
        }

        public bool CanExecuteAddIncomeTypesIdCommand(object parameter)
        {
            if (SelectedIncomeTypesId > -1)
            {               
                return true;
            }
            return false;
        }
        #endregion

        #region AddIncomeName

        RelayCommand _addIncomeName;
        public ICommand AddIncomeName
        {
            get
            {
                if (_addIncomeName == null)
                    _addIncomeName = new RelayCommand(ExecuteAddIncomeNameCommand, CanExecuteAddIncomeNameCommand);
                return _addIncomeName;
            }
        }

        public void ExecuteAddIncomeNameCommand(object parameter)
        {
            _selectedIncome.Name = SelectedIncome.Name;
        }

        public bool CanExecuteAddIncomeNameCommand(object parameter)
        {
            if (!string.IsNullOrEmpty(SelectedIncome.Name))
            {
                return true;
            }
            return false;
        }
        #endregion

        #region AddIncomeValueAndSave

        RelayCommand _addIncomeValueAndSave;
        public ICommand AddIncomeValueAndSave
        {
            get
            {
                if (_addIncomeValueAndSave == null)
                    _addIncomeValueAndSave = new RelayCommand(ExecuteAddIncomeValueAndSaveCommand, CanExecuteAddIncomeValueAndSaveCommand);
                return _addIncomeValueAndSave;
            }
        }

        public void ExecuteAddIncomeValueAndSaveCommand(object parameter)
        {
            _selectedIncome.Value = SelectedIncome.Value;
            switch (_mode)
            {
                case 0:
                    _dbOperations.CreateIncome(_selectedIncome);
                    break;
                case 1:
                    _selectedIncome.IncomeType = _dbOperations.GetIncomeTypesById(_selectedIncome.IncomeTypesId).Name;
                    _dbOperations.UpdateIncome(_selectedIncome);
                    break;
            }
            LoadUserIncomes();
            _selectedIncome = null;           
        }

        public bool CanExecuteAddIncomeValueAndSaveCommand(object parameter)
        {
            if (SelectedIncome.Value > 0)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
