using Kursovaya_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_DAL.Repository
{
    public class BudgetRepository : IRepository<Budget>
    {
        private FFAContext _db;

        public BudgetRepository(FFAContext db)
        {
            this._db = db;
        }
        public void Create(Budget item)
        {
            _db.Budget.Add(item);
        }

        public void Delete(int id)
        {
            Budget budget = _db.Budget.Find(id);
            if (budget != null)
                _db.Budget.Remove(budget);
        }

        public List<Budget> GetAll()
        {
            return _db.Budget.ToList();
        }

        public Budget GetItem(int id)
        {
            return _db.Budget.Find(id);
        }

        public void Update(Budget item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
