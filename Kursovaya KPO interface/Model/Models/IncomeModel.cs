using Kursovaya_DAL;
using System;

namespace Kursovaya_KPO_interface.Model.Models
{
    public class IncomeModel
    {
        public IncomeModel()
        {
        }

        public IncomeModel(Income income)
        {
            Id            = income.Id;
            Name          = income.Name;
            Value         = income.Value;
            Date          = income.Date;
            UserId        = income.UserId;
            IncomeTypesId = income.IncomeTypesId;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }        
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int IncomeTypesId { get; set; }
        public string IncomeType { get; set; }
        public string OnlyDate 
        {
            get
            {
                return Date.ToShortDateString();
            }
        }

    }
}
