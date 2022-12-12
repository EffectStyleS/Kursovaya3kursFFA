using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_DAL.Interfaces
{
    public interface IDbRepos
    {
        IRepository<User> User { get; }
        IRepository<Budget> Budget { get; }
        IRepository<PlannedExpenses> PlannedExpenses { get; }
        IRepository<PlannedIncomes> PlannedIncomes { get; }
        IRepository<Expense> Expense { get; }
        IRepository<Income> Income { get; }
        IRepository<ExpenseTypes> ExpenseTypes { get; }
        IRepository<IncomeTypes> IncomeTypes { get; }
        IRepository<TimePeriod> TimePeriod { get; }

        int Save();
    }
}
