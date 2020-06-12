using FluentValidation;
using KurumsalFramework.Northwind.Business.ValidationRules.FluentValidation;
using KurumsalFramework.Northwind.Entities.Concrete;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KurumsalFramework.Northwind.Business.DependencyResolvers.Ninject
{
    public class ValidationModule:NinjectModule
    {
        public override void Load()
        {
            //Ivalidator isterse productvalidatior ver demek
            Bind<IValidator<Product>>().To<ProductValidatior>().InSingletonScope();
        }
    }
}
