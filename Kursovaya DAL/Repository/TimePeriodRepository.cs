using Kursovaya_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_DAL.Repository
{
    public class TimePeriodRepository : IRepository<TimePeriod>
    {
        private FFAContext _db;

        public TimePeriodRepository(FFAContext db)
        {
            this._db = db;
        }
        public void Create(TimePeriod item)
        {
            _db.TimePeriod.Add(item);
        }

        public void Delete(int id)
        {
            TimePeriod timePeriod = _db.TimePeriod.Find(id);
            if(timePeriod != null)
                _db.TimePeriod.Remove(timePeriod);
        }

        public List<TimePeriod> GetAll()
        {
            return _db.TimePeriod.ToList();
        }

        public TimePeriod GetItem(int id)
        {
            return _db.TimePeriod.Find(id);
        }

        public void Update(TimePeriod item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
