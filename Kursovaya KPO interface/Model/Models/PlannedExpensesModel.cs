using Kursovaya_DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_KPO_interface.Model.Models
{
    public class PlannedExpensesModel 
    {
        public PlannedExpensesModel()
        {

        }
        public PlannedExpensesModel(PlannedExpenses plannedExpenses)
        {
            Id = plannedExpenses.Id;
            Sum = plannedExpenses.Sum;
            ExpenseTypesId = plannedExpenses.ExpenseTypesId;
            BudgetId = plannedExpenses.BudgetId;
        }
        public int Id { get; set; }
        public Nullable<decimal> Sum { get; set; }
        public int ExpenseTypesId { get; set; }
        public int BudgetId { get; set; }

        public string ExpenseType { get; set; }
    }
}
