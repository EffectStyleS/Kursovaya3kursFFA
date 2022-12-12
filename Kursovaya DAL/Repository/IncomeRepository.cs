using Kursovaya_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_DAL.Repository
{
    public class IncomeRepository : IRepository<Income>
    {
        private FFAContext _db;

        public IncomeRepository(FFAContext db)
        {
            this._db = db;
        }
        public void Create(Income item)
        {
            _db.Income.Add(item);
        }

        public void Delete(int id)
        {
            Income income = _db.Income.Find(id);
            if(income != null)
                _db.Income.Remove(income);
        }

        public List<Income> GetAll()
        {
            return _db.Income.ToList();
        }

        public Income GetItem(int id)
        {
            return _db.Income.Find(id);
        }

        public void Update(Income item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
