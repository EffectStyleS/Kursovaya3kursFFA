using Kursovaya_KPO_interface.Model.Interfaces;
using Kursovaya_KPO_interface.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_KPO_interface.Model.Services
{
    public class PlannedIncomesService : IPlannedIncomesService
    {
        public decimal? GetSumOfAllPlannedIncomes(List<PlannedIncomesModel> plannedIncomes)
        {
            decimal? sumOfAllPlannedIncomes = 0.0m;

            foreach (PlannedIncomesModel plannedIncomesModel in plannedIncomes)
            {
                sumOfAllPlannedIncomes += plannedIncomesModel.Sum;
            }

            return sumOfAllPlannedIncomes;
        }
    }
}
