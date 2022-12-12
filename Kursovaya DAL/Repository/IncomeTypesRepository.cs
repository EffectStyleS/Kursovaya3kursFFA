using Kursovaya_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_DAL.Repository
{
    public class IncomeTypesRepository : IRepository<IncomeTypes>
    {
        private FFAContext _db;

        public IncomeTypesRepository(FFAContext db)
        {
            this._db = db;
        }

        public void Create(IncomeTypes item)
        {
            _db.IncomeTypes.Add(item);
        }

        public void Delete(int id)
        {
            IncomeTypes incomeTypes = _db.IncomeTypes.Find(id);
            if(incomeTypes != null)
                _db.IncomeTypes.Remove(incomeTypes);
        }

        public List<IncomeTypes> GetAll()
        {
            return _db.IncomeTypes.ToList();
        }

        public IncomeTypes GetItem(int id)
        {
            return _db.IncomeTypes.Find(id);
        }

        public void Update(IncomeTypes item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
