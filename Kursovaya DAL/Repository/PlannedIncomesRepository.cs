using Kursovaya_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_DAL.Repository
{
    public class PlannedIncomesRepository : IRepository<PlannedIncomes>
    {
        private FFAContext _db;

        public PlannedIncomesRepository(FFAContext db)
        {
            this._db = db;
        }
        public void Create(PlannedIncomes item)
        {
            _db.PlannedIncomes.Add(item);
        }

        public void Delete(int id)
        {
            PlannedIncomes plannedIncomes = _db.PlannedIncomes.Find(id);
            if(plannedIncomes != null)
                _db.PlannedIncomes.Remove(plannedIncomes);
        }

        public List<PlannedIncomes> GetAll()
        {
            return _db.PlannedIncomes.ToList();
        }

        public PlannedIncomes GetItem(int id)
        {
            return _db.PlannedIncomes.Find(id);
        }

        public void Update(PlannedIncomes item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
