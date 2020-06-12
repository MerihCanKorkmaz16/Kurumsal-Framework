using KurumsalFramework.Northwind.DataAccess.Abstract;
using KurumsalFramework.Northwind.Entities.Concrete;
using KurumsalMimari.Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KurumsalFramework.Northwind.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal: EfEntityRepositoryBase<Category,NorthwindContext>,ICategoryDal
    {
    }
}
