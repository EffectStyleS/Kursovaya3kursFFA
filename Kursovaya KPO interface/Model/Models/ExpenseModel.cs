using Kursovaya_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_KPO_interface.Model.Models
{
    public class ExpenseModel
    {
        public ExpenseModel() { }

        public ExpenseModel(Expense expense)
        {
            Id = expense.Id;
            Name = expense.Name;
            Value = expense.Value;
            Date = expense.Date;
            ExpenseTypesId = expense.ExpenseTypesId;
            UserId = expense.UserId;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public System.DateTime Date { get; set; }
        public int ExpenseTypesId { get; set; }
        public int UserId { get; set; }
        public string ExpenseType { get; set; }
        public string OnlyDate
        {
            get
            {
                return Date.ToShortDateString();
            }
        }
    }
}
