using Kursovaya_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_KPO_interface.Model.Models
{
    public class BudgetModel
    {
        public BudgetModel() { }

        public BudgetModel(Budget budget)
        {
            Id = budget.Id;
            StartDate = budget.StartDate;
            TimePeriodId = budget.TimePeriodId;
            UserId = budget.UserId;
        }

        public int Id { get; set; }
        public System.DateTime StartDate { get; set; }
        public int TimePeriodId { get; set; }
        public int UserId { get; set; }

        public string Properties { get; set; }

    }
}
