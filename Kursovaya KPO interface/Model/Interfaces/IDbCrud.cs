using Kursovaya_DAL;
using Kursovaya_KPO_interface.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_KPO_interface.Model.Interfaces
{
    public interface IDbCrud
    {
        List<UserModel> GetAllUsers();
        UserModel GetUserById(int id);
        void CreateUser(UserModel user);
        void UpdateUser(UserModel user);
        void DeleteUser(int id);

        List<BudgetModel> GetAllUserBudgets(int userId);
        List<BudgetModel> GetAllBudgets();
        BudgetModel GetUserBudgetById(int id);
        void CreateBudget(BudgetModel budget);
        void UpdateBudget(BudgetModel budget);
        void DeleteBudget(int id);

        List<ExpenseModel> GetAllExpenses(int userId);
        ExpenseModel GetExpenseById(int id);
        void CreateExpense(ExpenseModel expense);
        void UpdateExpense(ExpenseModel expense);
        void DeleteExpense(int id);

        List<ExpenseTypesModel> GetAllExpenseTypes();
        ExpenseTypesModel GetExpenseTypesById(int id);
        void CreateExpenseType(ExpenseTypesModel expenseType);
        void UpdateExpenseType(ExpenseTypesModel expenseType);
        void DeleteExpenseType(int id);

        List<IncomeModel> GetAllIncomes(int userId);
        IncomeModel GetIncomeById(int id);
        void CreateIncome(IncomeModel income);
        void UpdateIncome(IncomeModel income);
        void DeleteIncome(int id);

        List<IncomeTypesModel> GetAllIncomeTypes();
        IncomeTypesModel GetIncomeTypesById(int id);
        void CreateIncomeType(IncomeTypesModel incomeType);
        void UpdateIncomeType(IncomeTypesModel incomeType);
        void DeleteIncomeType(int id);

        List<PlannedExpensesModel> GetAllBudgetsPlannedExpenses(int budgetId);
        PlannedExpensesModel GetBudgetsPlannedExpensesById(int id);
        void CreatePlannedExpense(PlannedExpensesModel plannedExpense);
        void UpdatePlannedExpense(PlannedExpensesModel plannedExpense);
        void DeletePlannedExpense(int id);

        List<PlannedIncomesModel> GetAllBudgetsPlannedIncomes(int budgetId);
        PlannedIncomesModel GetBudgetsPlannedIncomesById(int id);
        void CreatePlannedIncome(PlannedIncomesModel plannedIncome);
        void UpdatePlannedIncome(PlannedIncomesModel plannedIncome);
        void DeletePlannedIncome(int id);

        List<TimePeriodModel> GetAllTimePeriods();      
        TimePeriodModel GetTimePeriodsById(int id);
        void CreateTimePeriod(TimePeriodModel timePeriod);
        void UpdateTimePeriod(TimePeriodModel timePeriod);
        void DeleteTimePeriod(int id);
    }
}
