using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using KurumsalMimari.Core.DataAccess.Nhihabernate;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KurumsalFramework.Northwind.DataAccess.Concrete.Nhibernate.Helpers
{
    public class SqlServerHelper : NhihabernateHelper
    {
        protected override ISessionFactory InitializeFactory()
        {
            return Fluently.Configure().Database(MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("NorthwindContext")))
                .Mappings(t => t.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }
       
    }
}
