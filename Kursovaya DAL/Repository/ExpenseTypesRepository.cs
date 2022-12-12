using Kursovaya_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kursovaya_DAL.Repository
{
    public class ExpenseTypesRepository : IRepository<ExpenseTypes>
    {
        private FFAContext _db;

        public ExpenseTypesRepository(FFAContext db)
        {
            this._db = db;
        }

        public void Create(ExpenseTypes item)
        {
            _db.ExpenseTypes.Add(item);
        }

        public void Delete(int id)
        {
            ExpenseTypes expenseTypes = _db.ExpenseTypes.Find(id);
            if (expenseTypes != null)
                _db.ExpenseTypes.Remove(expenseTypes);
        }

        public List<ExpenseTypes> GetAll()
        {
            return _db.ExpenseTypes.ToList();
        }

        public ExpenseTypes GetItem(int id)
        {
            return _db.ExpenseTypes.Find(id);
        }

        public void Update(ExpenseTypes item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
