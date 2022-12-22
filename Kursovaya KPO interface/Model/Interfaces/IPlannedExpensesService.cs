using Kursovaya_KPO_interface.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_KPO_interface.Model.Interfaces
{
    public interface IPlannedExpensesService
    {
        decimal? GetSumOfAllPlannedExpenses(List<PlannedExpensesModel> plannedExpenses);
    }
}
