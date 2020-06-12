using KurumsalFramework.Northwind.Business.Abstract;
using KurumsalFramework.Northwind.Business.Concrete.Managers;
using KurumsalFramework.Northwind.DataAccess.Abstract;
using KurumsalFramework.Northwind.DataAccess.Concrete.EntityFramework;
using KurumsalMimari.Core.DataAccess;
using KurumsalMimari.Core.DataAccess.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KurumsalFramework.Northwind.Business.DependencyResolvers.Ninject
{
    public class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            //biri benden ıproductservice isterse productmanager ver
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();
            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            Bind<DbContext>().To<NorthwindContext>();
        }
    }
}
