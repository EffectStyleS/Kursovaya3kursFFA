using Kursovaya_DAL.Interfaces;
using Kursovaya_DAL.Repository;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_KPO_interface.Model.Util
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public override void Load()
        {
            Bind<IDbRepos>().To<DbRepos>().InSingletonScope().WithConstructorArgument(connectionString);
            
        }

    }
}
