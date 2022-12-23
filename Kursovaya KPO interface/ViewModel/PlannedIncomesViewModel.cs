using Kursovaya_DAL;
using Kursovaya_KPO_interface.Infrastructure;
using Kursovaya_KPO_interface.Model.Interfaces;
using Kursovaya_KPO_interface.Model.Models;
using Kursovaya_KPO_interface.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kursovaya_KPO_interface.ViewModel
{
    public class PlannedIncomesViewModel : ViewModelBase
    {
        //static properties
        public static PlannedIncomesViewModel Instance { get; } = new PlannedIncomesViewModel();

        //events
        public delegate void Save(List<PlannedIncomesModel> plannedIncomes);
        public event Save OnSave;

        //private fields
        private Uri _budgetMenuUri;
        private IDbCrud _dbOperations;
        private List<PlannedIncomesModel> _plannedIncomes;
        private List<IncomeTypesModel> _incomeTypes;

        //ctors
        public PlannedIncomesViewModel()
        {
            _dbOperations = App.MyMainWindow.CrudDb;
            _budgetMenuUri = BudgetMenuViewModel.BudgetMenuUri;
            _incomeTypes = _dbOperations.GetAllIncomeTypes();

        }

        //public properties
        public List<IncomeTypesModel> IncomeTypes
        {
            get
            {
                if (_incomeTypes == null)
                    _incomeTypes = _dbOperations.GetAllIncomeTypes();
                return _incomeTypes;
            }
        }
        public List<PlannedIncomesModel> PlannedIncomes
        {
            get
            {
                if (_plannedIncomes == null)
                {
                    _plannedIncomes = new List<PlannedIncomesModel>();
                    for (int i = 0; i < IncomeTypes.Count(); i++)
                    {
                        _plannedIncomes.Add(new PlannedIncomesModel()
                        {
                            IncomeTypesId = IncomeTypes[i].Id,
                            Sum = 0,
                            IncomeType = IncomeTypes[i].Name
                        });
                    }
                }
                return _plannedIncomes;
            }
            set
            {
                _plannedIncomes = value;
                OnPropertyChanged(nameof(PlannedIncomes));
            }
        }

        //event handlers
        public void TakePlannedIncomes(List<PlannedIncomesModel> plannedIncomes)
        {
            PlannedIncomes = plannedIncomes;
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
            BudgetMenuViewModel.Instance.OnCreatingFPI += TakePlannedIncomes;
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

        #region SavePlannedIncomes

        RelayCommand _savePlannedIncomes;
        public ICommand SavePlannedIncomes
        {
            get
            {
                if (_savePlannedIncomes == null)
                    _savePlannedIncomes = new RelayCommand(ExecuteSavePlannedIncomesCommand, CanExecuteSavePlannedIncomesCommand);
                return _savePlannedIncomes;
            }
        }

        public void ExecuteSavePlannedIncomesCommand(object parameter)
        {
            OnSave(PlannedIncomes);
        }

        public bool CanExecuteSavePlannedIncomesCommand(object parameter)
        {
            return true;
        }
        #endregion

    }
}
