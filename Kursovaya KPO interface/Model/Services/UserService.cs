using Kursovaya_DAL;
using Kursovaya_DAL.Interfaces;
using Kursovaya_DAL.Repository;
using Kursovaya_KPO_interface.Model.Interfaces;
using Kursovaya_KPO_interface.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_KPO_interface.Model.Services
{
    public class UserService : IUserService
    {
        IDbRepos db;

        public UserService(IDbRepos db)
        {
            this.db = db;   
        }

        public UserModel GetUserByLogin(string login)
        {
            return db.User
                .GetAll()
                .Where(x => x.Login == login)
                .Select(x => new UserModel(x))
                .FirstOrDefault();
        }
    }
}
