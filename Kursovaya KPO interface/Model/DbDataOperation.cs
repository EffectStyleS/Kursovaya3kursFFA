using Kursovaya_DAL;
using Kursovaya_DAL.Interfaces;
using Kursovaya_KPO_interface.Model.Interfaces;
using Kursovaya_KPO_interface.Model.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_KPO_interface.Model
{
    public class DbDataOperation : IDbCrud
    {
        IDbRepos _db;
        public DbDataOperation(IDbRepos db)
        {
            _db = db;
        }

        #region Create

        public void CreateBudget(BudgetModel budget)
        {
            _db.Budget.Create(
                new Budget()
                {
                    Id = budget.Id,
                    StartDate = budget.StartDate,
                    TimePeriodId = budget.TimePeriodId,
                    UserId = budget.UserId,
                });
            Save();
        }

        public void CreateExpense(ExpenseModel expense)
        {
            _db.Expense.Create(
                new Expense()
                {
                    Id = expense.Id,
                    Name = expense.Name,
                    Value = expense.Value,
                    Date = expense.Date,
                    ExpenseTypesId = expense.ExpenseTypesId,
                    UserId = expense.UserId
                });
            Save();
        }

        public void CreateExpenseType(ExpenseTypesModel expenseType)
        {
            _db.ExpenseTypes.Create(
                new ExpenseTypes()
                {
                    Id = expenseType.Id,
                    Name = expenseType.Name
                });
            Save();
        }

        public void CreateIncome(IncomeModel income)
        {
            _db.Income.Create(
                new Income()
                {
                    Id = income.Id,
                    Name = income.Name,
                    Value = income.Value,
                    Date = income.Date,
                    IncomeTypesId = income.IncomeTypesId,
                    UserId = income.UserId
                });
            Save();
        }

        public void CreateIncomeType(IncomeTypesModel incomeType)
        {
            _db.IncomeTypes.Create(
                new IncomeTypes()
                {
                    Id = incomeType.Id,
                    Name = incomeType.Name
                });
            Save();
        }

        public void CreatePlannedExpense(PlannedExpensesModel plannedExpense)
        {
            _db.PlannedExpenses.Create(
                new PlannedExpenses()
                {
                    Id = plannedExpense.Id,
                    BudgetId = plannedExpense.BudgetId,
                    Sum = plannedExpense.Sum,
                    ExpenseTypesId = plannedExpense.ExpenseTypesId,
                });
            Save();
        }

        public void CreatePlannedIncome(PlannedIncomesModel plannedIncome)
        {
            _db.PlannedIncomes.Create(
                new PlannedIncomes()
                {
                    Id = plannedIncome.Id,
                    BudgetId = plannedIncome.BudgetId,
                    Sum = plannedIncome.Sum,
                    IncomeTypesId = plannedIncome.IncomeTypesId,
                });
            Save();
        }

        public void CreateTimePeriod(TimePeriodModel timePeriod)
        {
            _db.TimePeriod.Create(
                new TimePeriod()
                {
                    Id = timePeriod.Id,
                    Name = timePeriod.Name
                });
            Save();
        }

        public void CreateUser(UserModel user)
        {
            _db.User.Create(
                new User()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Login = user.Login,
                    Password = user.Password,
                    Role = user.Role
                });
            Save();
        }
        #endregion

        #region Delete
        public void DeleteBudget(int id)
        {
            if(_db.Budget.GetItem(id) != null)
            {
                _db.Budget.Delete(id);
                Save();
            }
        }

        public void DeleteExpense(int id)
        {
            if(_db.Expense.GetItem(id) != null)
            {
                _db.Expense.Delete(id);
                Save();
            }
        }

        public void DeleteExpenseType(int id)
        {
            if (_db.ExpenseTypes.GetItem(id) != null)
            {
                _db.ExpenseTypes.Delete(id);
                Save();
            }
        }

        public void DeleteIncome(int id)
        {
            if (_db.Income.GetItem(id) != null)
            {
                _db.Income.Delete(id);
                Save();
            }
        }

        public void DeleteIncomeType(int id)
        {
            if (_db.IncomeTypes.GetItem(id) != null)
            {
                _db.IncomeTypes.Delete(id);
                Save();
            }
        }

        public void DeletePlannedExpense(int id)
        {
            if (_db.PlannedExpenses.GetItem(id) != null)
            {
                _db.PlannedExpenses.Delete(id);
                Save();
            }
        }

        public void DeletePlannedIncome(int id)
        {
            if (_db.PlannedIncomes.GetItem(id) != null)
            {
                _db.PlannedIncomes.Delete(id);
                Save();
            }
        }

        public void DeleteTimePeriod(int id)
        {
            if (_db.TimePeriod.GetItem(id) != null)
            {
                _db.TimePeriod.Delete(id);
                Save();
            }
        }

        public void DeleteUser(int id)
        {
            if (_db.User.GetItem(id) != null)
            {
                _db.User.Delete(id);
                Save();
            }
        }
        #endregion

        #region GetAll
        public List<PlannedExpensesModel> GetAllBudgetsPlannedExpenses(int budgetId)
        {
            return _db.PlannedExpenses
                .GetAll()
                .Where(e => e.BudgetId == budgetId)
                .Select(e => new PlannedExpensesModel(e))
                .ToList();
        }

        public List<PlannedIncomesModel> GetAllBudgetsPlannedIncomes(int budgetId)
        {
            return _db.PlannedIncomes
                .GetAll()
                .Where(e => e.BudgetId == budgetId)
                .Select(e => new PlannedIncomesModel(e))
                .ToList();
        }

        public List<ExpenseModel> GetAllExpenses(int userId)
        {
            return _db.Expense
                .GetAll()
                .Where(e => e.UserId == userId)
                .Select(e => new ExpenseModel(e))
                .ToList();
        }

        public List<ExpenseTypesModel> GetAllExpenseTypes()
        {
            return _db.ExpenseTypes.GetAll().Select(e => new ExpenseTypesModel(e)).ToList();
        }

        public List<IncomeModel> GetAllIncomes(int userId)
        {
            return _db.Income
                .GetAll()
                .Where(e => e.UserId == userId)
                .Select(e => new IncomeModel(e))
                .ToList();

        }

        public List<IncomeTypesModel> GetAllIncomeTypes()
        {
            return _db.IncomeTypes.GetAll().Select(e => new IncomeTypesModel(e)).ToList();
        }

        public List<TimePeriodModel> GetAllTimePeriods()
        {
            return _db.TimePeriod.GetAll().Select(e => new TimePeriodModel(e)).ToList();
        }

        public List<BudgetModel> GetAllUserBudgets(int userId)
        {
            return _db.Budget
                .GetAll()
                .Where(e => e.UserId == userId)
                .Select(e => new BudgetModel(e))
                .ToList();
        }

        public List<BudgetModel> GetAllBudgets()
        {
            return _db.Budget.GetAll().Select(e => new BudgetModel(e)).ToList();
        }

        public List<UserModel> GetAllUsers()
        {
            return _db.User.GetAll().Select(e => new UserModel(e)).ToList();
        }
        #endregion

        #region GetById
        public PlannedExpensesModel GetBudgetsPlannedExpensesById(int id)
        {
            return new PlannedExpensesModel(_db.PlannedExpenses.GetItem(id));
        }

        public PlannedIncomesModel GetBudgetsPlannedIncomesById(int id)
        {
            return new PlannedIncomesModel(_db.PlannedIncomes.GetItem(id));
        }

        public ExpenseModel GetExpenseById(int id)
        {
            return new ExpenseModel(_db.Expense.GetItem(id));
        }

        public ExpenseTypesModel GetExpenseTypesById(int id)
        {
            return new ExpenseTypesModel(_db.ExpenseTypes.GetItem(id));
        }

        public IncomeModel GetIncomeById(int id)
        {
            return new IncomeModel(_db.Income.GetItem(id));
        }

        public IncomeTypesModel GetIncomeTypesById(int id)
        {
            return new IncomeTypesModel(_db.IncomeTypes.GetItem(id));
        }

        public TimePeriodModel GetTimePeriodsById(int id)
        {
            return new TimePeriodModel(_db.TimePeriod.GetItem(id));
        }

        public BudgetModel GetUserBudgetById(int id)
        {
            return new BudgetModel(_db.Budget.GetItem(id));
        }

        public UserModel GetUserById(int id)
        {
            return new UserModel(_db.User.GetItem(id));
        }
        #endregion

        #region Update

        public void UpdateBudget(BudgetModel budget)
        {
            Budget b = _db.Budget.GetItem(budget.Id);
            b.Id = budget.Id;
            b.StartDate = budget.StartDate;
            b.TimePeriodId = budget.TimePeriodId;
            b.UserId = budget.UserId;
            _db.Budget.Update(b);
            Save();
        }

        public void UpdateExpense(ExpenseModel expense)
        {
            Expense e = _db.Expense.GetItem(expense.Id);
            e.Id = expense.Id;
            e.Date = expense.Date;
            e.Name = expense.Name;
            e.Value = expense.Value;
            e.ExpenseTypesId = expense.ExpenseTypesId;
            e.UserId = expense.UserId;
            _db.Expense.Update(e);
            Save();
        }

        public void UpdateExpenseType(ExpenseTypesModel expenseType)
        {
            ExpenseTypes et = _db.ExpenseTypes.GetItem(expenseType.Id);
            et.Id = expenseType.Id;
            et.Name = expenseType.Name;
            _db.ExpenseTypes.Update(et);
            Save();
        }

        public void UpdateIncome(IncomeModel income)
        {
            Income i = _db.Income.GetItem(income.Id);
            i.Id = income.Id;
            i.Date = income.Date;
            i.Name = income.Name;
            i.Value = income.Value;
            i.IncomeTypesId = income.IncomeTypesId;
            i.UserId = income.UserId;
            _db.Income.Update(i);
            Save();
        }

        public void UpdateIncomeType(IncomeTypesModel incomeType)
        {
            IncomeTypes it = _db.IncomeTypes.GetItem(incomeType.Id);
            it.Id = incomeType.Id;
            it.Name = incomeType.Name;
            _db.IncomeTypes.Update(it);
            Save();
        }

        public void UpdatePlannedExpense(PlannedExpensesModel plannedExpense)
        {
            PlannedExpenses pe = _db.PlannedExpenses.GetItem(plannedExpense.Id);
            pe.Id = plannedExpense.Id;
            pe.Sum = plannedExpense.Sum;
            pe.BudgetId = plannedExpense.BudgetId;
            pe.ExpenseTypesId = plannedExpense.ExpenseTypesId;
            _db.PlannedExpenses.Update(pe);
            Save();
        }

        public void UpdatePlannedIncome(PlannedIncomesModel plannedIncome)
        {
            PlannedIncomes pi = _db.PlannedIncomes.GetItem(plannedIncome.Id);
            pi.Id = plannedIncome.Id;
            pi.Sum = plannedIncome.Sum;
            pi.BudgetId = plannedIncome.BudgetId;
            pi.IncomeTypesId = plannedIncome.IncomeTypesId;
            _db.PlannedIncomes.Update(pi);
            Save();
        }

        public void UpdateTimePeriod(TimePeriodModel timePeriod)
        {
            TimePeriod tp = _db.TimePeriod.GetItem(timePeriod.Id);
            tp.Id = timePeriod.Id;
            tp.Name = timePeriod.Name;
            _db.TimePeriod.Update(tp);
            Save();
        }

        public void UpdateUser(UserModel user)
        {
            User u = _db.User.GetItem(user.Id);
            u.Id = user.Id;
            u.Name = user.Name;
            u.Login = user.Login;
            u.Password = user.Password;
            u.Role = user.Role;
            _db.User.Update(u);
            Save();
        }

        #endregion

        public bool Save()
        {
            if (_db.Save() > 0) return true;
            return false;
        }
    }
}
