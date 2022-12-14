using Kursovaya_KPO_interface.Model.Interfaces;
using Kursovaya_KPO_interface.Model.Util;
using Kursovaya_KPO_interface.Util;
using Kursovaya_KPO_interface.View;
using Ninject;
using Ninject.Planning.Bindings.Resolvers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Kursovaya_KPO_interface
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainWindow MyMainWindow { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);

            string connection = "FFADb.Context";
            var kernel = new StandardKernel(new NinjectRegistrations(), new ServiceModule(connection));

            IDbCrud crudServ = kernel.Get<IDbCrud>();
            IBudgetService budgetServ = kernel.Get<IBudgetService>();
            IExpenseService expenseService = kernel.Get<IExpenseService>();
            IExpenseTypesService expenseTypesService = kernel.Get<IExpenseTypesService>();
            IIncomeService incomeService = kernel.Get<IIncomeService>();
            IIncomeTypesService incomeTypesService = kernel.Get<IIncomeTypesService>();
            IPlannedExpensesService plannedExpensesService = kernel.Get<IPlannedExpensesService>();
            IPlannedIncomesService plannedIncomesService = kernel.Get<IPlannedIncomesService>();
            IReportsService reportsService = kernel.Get<IReportsService>();
            ITimePeriodService timePeriodService = kernel.Get<ITimePeriodService>();
            IUserService userService = kernel.Get<IUserService>();
            
            MyMainWindow = new MainWindow(crudServ, userService, budgetServ, expenseService, expenseTypesService, incomeService, incomeTypesService,
                plannedExpensesService, plannedIncomesService, reportsService, timePeriodService);

            Current.MainWindow = MyMainWindow;

            Current.MainWindow = kernel.Get<MainWindow>();
            Current.MainWindow.Show();
        }

        


    }
}
