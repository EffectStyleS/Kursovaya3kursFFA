using Kursovaya_DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Kursovaya_DAL.Repository
{
    public class UserRepository : IRepository<User>
    {
        private FFAContext _db;

        public UserRepository(FFAContext db)
        {
            this._db = db;
        }

        public void Create(User item)
        {
            _db.User.Add(item);
        }

        public void Delete(int id)
        {
            User user = _db.User.Find(id);
            if(user != null)
                _db.User.Remove(user);
        }

        public List<User> GetAll()
        {
            return _db.User.ToList();
        }

        public User GetItem(int id)
        {
            return _db.User.Find(id);
        }

        public void Update(User item)
        {
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
