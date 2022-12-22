using Kursovaya_KPO_interface.Model.Interfaces;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Frame _frame;
        public IDbCrud CrudDb { get; set; }
        public IUserService UserService { get; set; }
        public IBudgetService BudgetService { get; set; }
        public IExpenseService ExpenseService { get; set; }
        public IExpenseTypesService ExpenseTypesService { get; set; }
        public IIncomeService IncomeService { get; set; }
        public IIncomeTypesService IncomeTypesService { get; set; }
        public IPlannedExpensesService PlannedExpensesService { get; set; }
        public IPlannedIncomesService PlannedIncomesService { get; set; }
        public IReportsService ReportsService { get; set; }
        public ITimePeriodService TimePeriodService { get; set; }
        public Frame Frame { get => _frame; set => _frame = value; }

        public MainWindow(IDbCrud crudDb, IUserService userService, IBudgetService budgetService, IExpenseService expenseService,
            IExpenseTypesService expenseTypesService, IIncomeService incomeService, IIncomeTypesService incomeTypesService,
            IPlannedExpensesService plannedExpensesService, IPlannedIncomesService plannedIncomesService,
            IReportsService reportsService, ITimePeriodService timePeriodService)
        {
            InitializeComponent();
            //AllowsTransparency = true;
            //WindowStyle = WindowStyle.SingleBorderWindow;
            Frame = new Frame();
            Frame.Source = new Uri("View/StartMenu.xaml", UriKind.Relative);
            Frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            CrudDb = crudDb;
            UserService = userService;
            BudgetService = budgetService;
            ExpenseTypesService = expenseTypesService;
            IncomeService = incomeService;
            ReportsService = reportsService;
            TimePeriodService = timePeriodService;
            ExpenseService = expenseService;
            ExpenseTypesService = expenseTypesService;
            PlannedExpensesService = plannedExpensesService;
            IncomeTypesService = incomeTypesService;
            PlannedIncomesService = plannedIncomesService;
        }


    }
}
