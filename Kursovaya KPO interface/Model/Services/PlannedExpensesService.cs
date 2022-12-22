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
    public class PlannedExpensesService : IPlannedExpensesService
    {
        IDbRepos _db;

        public PlannedExpensesService(IDbRepos db)
        {
            _db = db;
        }   

        public decimal? GetSumOfAllPlannedExpenses(List<PlannedExpensesModel> plannedExpenses)
        {
            decimal? sumOfAllPlannedExpenses = 0.0m;

            foreach(PlannedExpensesModel plannedExpensesModel in plannedExpenses)
            {
                sumOfAllPlannedExpenses += plannedExpensesModel.Sum;
            }

            return sumOfAllPlannedExpenses;
        }
    }
}
