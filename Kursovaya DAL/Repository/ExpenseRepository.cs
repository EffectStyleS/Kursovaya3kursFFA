using Kursovaya_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_DAL.Repository
{
    public class ExpenseRepository : IRepository<Expense>
    {
        private FFAContext _db;

        public ExpenseRepository(FFAContext db)
        {
            this._db = db;
        }
        public void Create(Expense item)
        {
            _db.Expense.Add(item);
        }

        public void Delete(int id)
        {
            Expense expense = _db.Expense.Find(id);
            if (expense != null)
                _db.Expense.Remove(expense);
        }

        public List<Expense> GetAll()
        {
            return _db.Expense.ToList();
        }

        public Expense GetItem(int id)
        {
            return _db.Expense.Find(id);
        }

        public void Update(Expense item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
