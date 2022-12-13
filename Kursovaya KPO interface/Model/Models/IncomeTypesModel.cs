using Kursovaya_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_KPO_interface.Model.Models
{
    public class IncomeTypesModel
    {
        public IncomeTypesModel()
        {
                
        }

        public IncomeTypesModel(IncomeTypes incomeTypes)
        {
            Id = incomeTypes.Id;
            Name = incomeTypes.Name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
