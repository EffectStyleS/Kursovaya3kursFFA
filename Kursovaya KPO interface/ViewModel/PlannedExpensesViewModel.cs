using Kursovaya_KPO_interface.Infrastructure;
using Kursovaya_KPO_interface.Model.Interfaces;
using Kursovaya_KPO_interface.Model.Models;
using Ninject.Planning;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kursovaya_KPO_interface.ViewModel
{
    public class PlannedExpensesViewModel : ViewModelBase
    {
        //static properties
        public static PlannedExpensesViewModel Instance { get; } = new PlannedExpensesViewModel();

        //events
        public delegate void Save(List<PlannedExpensesModel> plannedExpenses);
        public event Save OnSave;
        
        //private fields
        private Uri _budgetMenuUri;
        private IDbCrud _dbOperations;
        private List<PlannedExpensesModel> _plannedExpenses;
        private List<ExpenseTypesModel> _expenseTypes;
        private IPlannedExpensesService _plannedExpensesService;

        //ctors
        public PlannedExpensesViewModel()
        {
            _dbOperations           = App.MyMainWindow.CrudDb;
            _budgetMenuUri          = BudgetMenuViewModel.BudgetMenuUri;
            _expenseTypes           = _dbOperations.GetAllExpenseTypes();
            _plannedExpensesService = App.MyMainWindow.PlannedExpensesService;


        }

        //public properties
        public List<ExpenseTypesModel> ExpenseTypes
        {
            get
            {
                if (_expenseTypes == null)
                    _expenseTypes = _dbOperations.GetAllExpenseTypes();
                return _expenseTypes;
            }
        }
        public List<PlannedExpensesModel> PlannedExpenses
        {
            get
            {
                if (_plannedExpenses == null)
                {
                    _plannedExpenses = new List<PlannedExpensesModel>();
                    for (int i = 0; i < ExpenseTypes.Count(); i++)
                    {
                        _plannedExpenses.Add(new PlannedExpensesModel()
                        {
                            ExpenseTypesId = ExpenseTypes[i].Id,
                            Sum = 0,
                            ExpenseType = ExpenseTypes[i].Name
                        });
                    }
                }
                return _plannedExpenses;
            }
            set
            {
                _plannedExpenses = value;                
                OnPropertyChanged(nameof(PlannedExpenses));
            }
        }

        //event handlers
        public void TakePlannedExpenses(List<PlannedExpensesModel> plannedExpenses)
        {
            PlannedExpenses = plannedExpenses;
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
            BudgetMenuViewModel.Instance.OnCreatingFPE += TakePlannedExpenses;
            Navigator.Page = parameter as Page;
            if (_budgetMenuUri == null)
                _budgetMenuUri = new Uri("View/BudgetMenu.xaml", UriKind.Relative);
            Navigator.Page.NavigationService.Navigate(_budgetMenuUri);
        }

        public bool CanExecuteToBudgetMenuCommand(object parameter)
        {
            return true;
        }
        #endregion

        #region SavePlannedExpenses

        RelayCommand _savePlannedExpenses;
        public ICommand SavePlannedExpenses
        {
            get
            {
                if (_savePlannedExpenses == null)
                    _savePlannedExpenses = new RelayCommand(ExecuteSavePlannedExpensesCommand, CanExecuteSavePlannedExpensesCommand);
                return _savePlannedExpenses;
            }
        }

        public void ExecuteSavePlannedExpensesCommand(object parameter)
        {
            OnSave?.Invoke(PlannedExpenses);
        }

        public bool CanExecuteSavePlannedExpensesCommand(object parameter)
        {
            return true;
        }
        #endregion


    }
}
