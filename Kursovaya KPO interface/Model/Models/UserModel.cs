using Kursovaya_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_KPO_interface.Model.Models
{
    public class UserModel
    {
        public UserModel()
        {

        }

        public UserModel(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Login = user.Login;
            Password = user.Password;
            Role = user.Role;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
    }
}
