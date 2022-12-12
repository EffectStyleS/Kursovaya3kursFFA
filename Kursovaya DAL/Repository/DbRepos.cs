using Kursovaya_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_DAL.Repository
{
    public class DbRepos : IDbRepos
    {
        private FFAContext _db;
        private UserRepository _userRepository;
        private BudgetRepository _budgetRepository;
        private ExpenseRepository _expenseRepository;
        private ExpenseTypesRepository _expenseTypesRepository;
        private IncomeRepository _incomeRepository;
        private IncomeTypesRepository _incomeTypesRepository;
        private PlannedExpensesRepository _plannedExpensesRepository;
        private PlannedIncomesRepository _plannedIncomesRepository;
        private TimePeriodRepository _timePeriodRepository;

        public DbRepos()
        {
            _db = new FFAContext();
        }


        public IRepository<User> User
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_db);
                return _userRepository;
            }
        }


        public IRepository<Budget> Budget
        {
            get
            {
                if (_budgetRepository == null)
                    _budgetRepository = new BudgetRepository(_db);
                return _budgetRepository;
            }
        }


        public IRepository<PlannedExpenses> PlannedExpenses
        {
            get
            {
                if (_plannedExpensesRepository == null)
                    _plannedExpensesRepository = new PlannedExpensesRepository(_db);
                return _plannedExpensesRepository;
            }
        }

        public IRepository<PlannedIncomes> PlannedIncomes
        {
            get
            {
                if (_plannedIncomesRepository == null)
                    _plannedIncomesRepository = new PlannedIncomesRepository(_db);
                return _plannedIncomesRepository;
            }
        }

        public IRepository<Expense> Expense
        {
            get
            {
                if (_expenseRepository == null)
                    _expenseRepository = new ExpenseRepository(_db);
                return _expenseRepository;
            }
        }

        public IRepository<Income> Income
        {
            get
            {
                if (_incomeRepository == null)
                    _incomeRepository = new IncomeRepository(_db);
                return _incomeRepository;
            }
        }

        public IRepository<ExpenseTypes> ExpenseTypes
        {
            get
            {
                if (_expenseTypesRepository == null)
                    _expenseTypesRepository = new ExpenseTypesRepository(_db);
                return _expenseTypesRepository;
            }
        }

        public IRepository<IncomeTypes> IncomeTypes
        {
            get
            {
                if (_incomeTypesRepository == null)
                    _incomeTypesRepository = new IncomeTypesRepository(_db);
                return _incomeTypesRepository;
            }
        }

        public IRepository<TimePeriod> TimePeriod
        {
            get
            {
                if (_timePeriodRepository == null)
                    _timePeriodRepository = new TimePeriodRepository(_db);
                return _timePeriodRepository;
            }
        }

        public int Save()
        {
            return _db.SaveChanges();
        }
    }
}
