using Kursovaya_KPO_interface.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_KPO_interface.Model.Interfaces
{
    public interface IBudgetService
    {
        void CreateProperties(BudgetModel budget);

        DateTime GetEndDate(BudgetModel budget);

        void SavePDF(BudgetModel budget, string filePath);
    }
}
