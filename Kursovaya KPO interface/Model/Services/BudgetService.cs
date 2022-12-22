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
    public class BudgetService : IBudgetService
    {
        IDbRepos _db;

        public BudgetService(IDbRepos db)
        {
            _db = db;
        }

        public void CreateProperties(BudgetModel budget)
        {
            var timePeriod = _db.TimePeriod.GetItem(budget.TimePeriodId).Name;
            var startDate = budget.StartDate.ToShortDateString();

            budget.Properties = $"{timePeriod} с {startDate}";
        }

        public DateTime GetEndDate(BudgetModel budget)
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
    }
}
