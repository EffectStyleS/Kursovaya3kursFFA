using Kursovaya_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_KPO_interface.Model.Models
{
    public class PlannedIncomesModel
    {
        public PlannedIncomesModel()
        {

        }

        public PlannedIncomesModel(PlannedIncomes plannedIncomes)
        {
            Id = plannedIncomes.Id;
            Sum = plannedIncomes.Sum;
            IncomeTypesId = plannedIncomes.IncomeTypesId;
            BudgetId = plannedIncomes.BudgetId;
        }


        public int Id { get; set; }
        public Nullable<decimal> Sum { get; set; }
        public int IncomeTypesId { get; set; }
        public int BudgetId { get; set; }
        public string IncomeType { get; set; }
    }
}
