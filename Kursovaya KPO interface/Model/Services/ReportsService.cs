using Kursovaya_DAL;
using Kursovaya_DAL.Interfaces;
using Kursovaya_KPO_interface.Model.Interfaces;
using Kursovaya_KPO_interface.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_KPO_interface.Model.Services
{
    public class ReportsService : IReportsService
    {
        IDbRepos _db;

        public ReportsService(IDbRepos db)
        {
            _db = db;
        }

        private DateTime GetEndDate(BudgetModel budget)
        {
            DateTime endDate = new DateTime();
            switch (budget.TimePeriodId)
            {
                case 1:
                    endDate = budget.StartDate.AddMonths(1);
                    break;
                case 2:
                    endDate = budget.StartDate.AddMonths(3);
                    break;
                case 3:
                    endDate = budget.StartDate.AddYears(1);
                    break;
            }

            return endDate;
        }

        public List<List<decimal?>> TakeDifferenceOfExpensesSum(UserModel user)
        {
            List<List<decimal?>> differences = new List<List<decimal?>>();

            List<ExpenseTypesModel> expenseTypes = _db.ExpenseTypes.GetAll().Select(e => new ExpenseTypesModel(e)).ToList();
            List<List<ExpenseModel>> expensesByType = new List<List<ExpenseModel>>();
            List<decimal?> AllSumOfExpensesValues = new List<decimal?>();

            for(int i = 0; i < expenseTypes.Count; i++)
            {
                var expenseByType = _db.Expense
                    .GetAll()
                    .Where(e => e.UserId == user.Id)
                    .Select(e => new ExpenseModel(e))
                    .ToList()
                    .Where(x => x.ExpenseTypesId == expenseTypes[i].Id)
                    .ToList();              

                expensesByType.Add(expenseByType);
            }

            List<BudgetModel> userBudgets = _db.Budget.GetAll().Where(e => e.UserId == user.Id).Select(e => new BudgetModel(e)).ToList();
            List<List<decimal?>> allBudgetsPlannedExpenses = new List<List<decimal?>>();

            foreach (var userBudget in userBudgets)
            {
                List<PlannedExpensesModel> plannedExpenses = _db.PlannedExpenses
                    .GetAll()
                    .Where(e => e.BudgetId == userBudget.Id)
                    .Select(e => new PlannedExpensesModel(e))
                    .ToList();

                List<decimal?> sumsOfPlannedExpenses = new List<decimal?>();
                decimal? sum = 0.0m;

                for (int i = 0; i < expenseTypes.Count; i++)
                {
                    sum = plannedExpenses.Where(x => x.ExpenseTypesId == expenseTypes[i].Id).FirstOrDefault().Sum;
                    sumsOfPlannedExpenses.Add(sum);
                }

                allBudgetsPlannedExpenses.Add(sumsOfPlannedExpenses);
            }

            for(int b = 0; b < userBudgets.Count; b++)
            {
                List<decimal?> budgetDifferences = new List<decimal?>();

                for(int i = 0; i < expenseTypes.Count; i++)
                {
                    var periodExpensesByType = expensesByType[i].
                        Select(x => new ExpenseModel()
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Date = x.Date,
                            Value = x.Value,
                            ExpenseTypesId = x.ExpenseTypesId,
                            UserId = x.UserId,
                        })
                        .Where(e => e.Date > userBudgets[b].StartDate && e.Date < GetEndDate(userBudgets[b]))
                        .ToList();

                    decimal? sumOfExpensesValues = 0.0m;
                    foreach (var expense in periodExpensesByType)
                    {
                        sumOfExpensesValues += expense.Value;
                    }

                    var difference = sumOfExpensesValues - allBudgetsPlannedExpenses[b][i];

                    budgetDifferences.Add(difference);

                }
                differences.Add(budgetDifferences);
            }
            
            return differences;
        }
    }
}
