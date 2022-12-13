using Kursovaya_KPO_interface.Model.Interfaces;
using Kursovaya_KPO_interface.Model;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kursovaya_KPO_interface.Model.Services;

namespace Kursovaya_KPO_interface.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IBudgetService>().To<BudgetService>();
            Bind<IExpenseService>().To<ExpenseService>();
            Bind<IExpenseTypesService>().To<ExpenseTypesService>();
            Bind<IIncomeService>().To<IncomeService>();
            Bind<IIncomeTypesService>().To<IncomeTypesService>();
            Bind<IPlannedExpensesService>().To<PlannedExpensesService>();
            Bind<IPlannedIncomesService>().To<PlannedIncomesService>();
            Bind<IReportsService>().To<ReportsService>();
            Bind<ITimePeriodService>().To<TimePeriodService>();
            Bind<IUserService>().To<UserService>();
            Bind<IDbCrud>().To<DbDataOperation>();
        }
    }
}
