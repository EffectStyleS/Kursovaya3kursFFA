using Kursovaya_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_DAL.Repository
{
    public class PlannedExpensesRepository : IRepository<PlannedExpenses>
    {
        private FFAContext _db;

        public PlannedExpensesRepository(FFAContext db)
        {
            this._db = db;
        }
        public void Create(PlannedExpenses item)
        {
            _db.PlannedExpenses.Add(item);
        }

        public void Delete(int id)
        {
            PlannedExpenses plannedExpenses = _db.PlannedExpenses.Find(id);
            if (plannedExpenses != null)
                _db.PlannedExpenses.Remove(plannedExpenses);
        }

        public List<PlannedExpenses> GetAll()
        {
            return _db.PlannedExpenses.ToList();
        }

        public PlannedExpenses GetItem(int id)
        {
            return _db.PlannedExpenses.Find(id);
        }

        public void Update(PlannedExpenses item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
