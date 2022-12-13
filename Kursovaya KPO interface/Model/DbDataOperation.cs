using Kursovaya_DAL;
using Kursovaya_DAL.Interfaces;
using Kursovaya_KPO_interface.Model.Interfaces;
using Kursovaya_KPO_interface.Model.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_KPO_interface.Model
{
    public class DbDataOperation : IDbCrud
    {
        IDbRepos db;

        public DbDataOperation(IDbRepos db)
        {
            this.db = db;
        }

        #region Create

        public void CreateBudget(BudgetModel budget)
        {
            db.Budget.Create(
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
            db.Expense.Create(
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
            db.ExpenseTypes.Create(
                new ExpenseTypes()
                {
                    Id = expenseType.Id,
                    Name = expenseType.Name
                });
            Save();
        }

        public void CreateIncome(IncomeModel income)
        {
            db.Income.Create(
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
            db.IncomeTypes.Create(
                new IncomeTypes()
                {
                    Id = incomeType.Id,
                    Name = incomeType.Name
                });
            Save();
        }

        public void CreatePlannedExpense(PlannedExpensesModel plannedExpense)
        {
            db.PlannedExpenses.Create(
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
            db.PlannedIncomes.Create(
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
            db.TimePeriod.Create(
                new TimePeriod()
                {
                    Id = timePeriod.Id,
                    Name = timePeriod.Name
                });
            Save();
        }

        public void CreateUser(UserModel user)
        {
            db.User.Create(
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
            if(db.Budget.GetItem(id) != null)
            {
                db.Budget.Delete(id);
                Save();
            }
        }

        public void DeleteExpense(int id)
        {
            if(db.Expense.GetItem(id) != null)
            {
                db.Expense.Delete(id);
                Save();
            }
        }

        public void DeleteExpenseType(int id)
        {
            if (db.ExpenseTypes.GetItem(id) != null)
            {
                db.ExpenseTypes.Delete(id);
                Save();
            }
        }

        public void DeleteIncome(int id)
        {
            if (db.Income.GetItem(id) != null)
            {
                db.Income.Delete(id);
                Save();
            }
        }

        public void DeleteIncomeType(int id)
        {
            if (db.IncomeTypes.GetItem(id) != null)
            {
                db.IncomeTypes.Delete(id);
                Save();
            }
        }

        public void DeletePlannedExpense(int id)
        {
            if (db.PlannedExpenses.GetItem(id) != null)
            {
                db.PlannedExpenses.Delete(id);
                Save();
            }
        }

        public void DeletePlannedIncome(int id)
        {
            if (db.PlannedIncomes.GetItem(id) != null)
            {
                db.PlannedIncomes.Delete(id);
                Save();
            }
        }

        public void DeleteTimePeriod(int id)
        {
            if (db.TimePeriod.GetItem(id) != null)
            {
                db.TimePeriod.Delete(id);
                Save();
            }
        }

        public void DeleteUser(int id)
        {
            if (db.User.GetItem(id) != null)
            {
                db.User.Delete(id);
                Save();
            }
        }
        #endregion

        #region GetAll
        public List<PlannedExpensesModel> GetAllBudgetsPlannedExpenses(int budgetId)
        {
            return db.PlannedExpenses
                .GetAll()
                .Where(e => e.BudgetId == budgetId)
                .Select(e => new PlannedExpensesModel(e))
                .ToList();
        }

        public List<PlannedIncomesModel> GetAllBudgetsPlannedIncomes(int budgetId)
        {
            return db.PlannedIncomes
                .GetAll()
                .Where(e => e.BudgetId == budgetId)
                .Select(e => new PlannedIncomesModel(e))
                .ToList();
        }

        public List<ExpenseModel> GetAllExpenses(int userId)
        {
            return db.Expense
                .GetAll()
                .Where(e => e.UserId == userId)
                .Select(e => new ExpenseModel(e))
                .ToList();
        }

        public List<ExpenseTypesModel> GetAllExpenseTypes()
        {
            return db.ExpenseTypes.GetAll().Select(e => new ExpenseTypesModel(e)).ToList();
        }

        public List<IncomeModel> GetAllIncomes(int userId)
        {
            return db.Income
                .GetAll()
                .Where(e => e.UserId == userId)
                .Select(e => new IncomeModel(e))
                .ToList();
        }

        public List<IncomeTypesModel> GetAllIncomeTypes()
        {
            return db.IncomeTypes.GetAll().Select(e => new IncomeTypesModel(e)).ToList();
        }

        public List<TimePeriodModel> GetAllTimePeriods()
        {
            return db.TimePeriod.GetAll().Select(e => new TimePeriodModel(e)).ToList();
        }

        public List<BudgetModel> GetAllUserBudgets(int userId)
        {
            return db.Budget
                .GetAll()
                .Where(e => e.UserId == userId)
                .Select(e => new BudgetModel(e))
                .ToList();
        }

        public List<UserModel> GetAllUsers()
        {
            return db.User.GetAll().Select(e => new UserModel(e)).ToList();
        }
        #endregion

        #region GetById
        public PlannedExpensesModel GetBudgetsPlannedExpensesById(int id)
        {
            return new PlannedExpensesModel(db.PlannedExpenses.GetItem(id));
        }

        public PlannedIncomesModel GetBudgetsPlannedIncomesById(int id)
        {
            return new PlannedIncomesModel(db.PlannedIncomes.GetItem(id));
        }

        public ExpenseModel GetExpenseById(int id)
        {
            return new ExpenseModel(db.Expense.GetItem(id));
        }

        public ExpenseTypesModel GetExpenseTypesById(int id)
        {
            return new ExpenseTypesModel(db.ExpenseTypes.GetItem(id));
        }

        public IncomeModel GetIncomeById(int id)
        {
            return new IncomeModel(db.Income.GetItem(id));
        }

        public IncomeTypesModel GetIncomeTypesById(int id)
        {
            return new IncomeTypesModel(db.IncomeTypes.GetItem(id));
        }

        public TimePeriodModel GetTimePeriodsById(int id)
        {
            return new TimePeriodModel(db.TimePeriod.GetItem(id));
        }

        public BudgetModel GetUserBudgetById(int id)
        {
            return new BudgetModel(db.Budget.GetItem(id));
        }

        public UserModel GetUserById(int id)
        {
            return new UserModel(db.User.GetItem(id));
        }
        #endregion

        #region Update

        public void UpdateBudget(BudgetModel budget)
        {
            Budget b = db.Budget.GetItem(budget.Id);
            b.Id = budget.Id;
            b.StartDate = budget.StartDate;
            b.TimePeriodId = budget.TimePeriodId;
            b.UserId = budget.UserId;
            db.Budget.Update(b);
            Save();
        }

        public void UpdateExpense(ExpenseModel expense)
        {
            Expense e = db.Expense.GetItem(expense.Id);
            e.Id = expense.Id;
            e.Name = expense.Name;
            e.Value = expense.Value;
            e.ExpenseTypesId = expense.ExpenseTypesId;
            e.UserId = expense.UserId;
            db.Expense.Update(e);
            Save();
        }

        public void UpdateExpenseType(ExpenseTypesModel expenseType)
        {
            ExpenseTypes et = db.ExpenseTypes.GetItem(expenseType.Id);
            et.Id = expenseType.Id;
            et.Name = expenseType.Name;
            db.ExpenseTypes.Update(et);
            Save();
        }

        public void UpdateIncome(IncomeModel income)
        {
            Income i = db.Income.GetItem(income.Id);
            i.Id = income.Id;
            i.Name = income.Name;
            i.Value = income.Value;
            income.IncomeTypesId = income.IncomeTypesId;
            income.UserId = income.UserId;
            db.Income.Update(i);
            Save();
        }

        public void UpdateIncomeType(IncomeTypesModel incomeType)
        {
            IncomeTypes it = db.IncomeTypes.GetItem(incomeType.Id);
            it.Id = incomeType.Id;
            it.Name = incomeType.Name;
            db.IncomeTypes.Update(it);
            Save();
        }

        public void UpdatePlannedExpense(PlannedExpensesModel plannedExpense)
        {
            PlannedExpenses pe = db.PlannedExpenses.GetItem(plannedExpense.Id);
            pe.Id = plannedExpense.Id;
            pe.Sum = plannedExpense.Sum;
            pe.BudgetId = plannedExpense.BudgetId;
            pe.ExpenseTypesId = plannedExpense.ExpenseTypesId;
            db.PlannedExpenses.Update(pe);
            Save();
        }

        public void UpdatePlannedIncome(PlannedIncomesModel plannedIncome)
        {
            PlannedIncomes pi = db.PlannedIncomes.GetItem(plannedIncome.Id);
            pi.Id = plannedIncome.Id;
            pi.Sum = plannedIncome.Sum;
            pi.BudgetId = plannedIncome.BudgetId;
            pi.IncomeTypesId = plannedIncome.IncomeTypesId;
            db.PlannedIncomes.Update(pi);
            Save();
        }

        public void UpdateTimePeriod(TimePeriodModel timePeriod)
        {
            TimePeriod tp = db.TimePeriod.GetItem(timePeriod.Id);
            tp.Id = timePeriod.Id;
            tp.Name = timePeriod.Name;
            db.TimePeriod.Update(tp);
            Save();
        }

        public void UpdateUser(UserModel user)
        {
            User u = db.User.GetItem(user.Id);
            u.Id = user.Id;
            u.Name = user.Name;
            u.Login = user.Login;
            u.Password = user.Password;
            u.Role = user.Role;
            db.User.Update(u);
            Save();
        }

        #endregion
        public bool Save()
        {
            if (db.Save() > 0) return true;
            return false;
        }
    }
}
