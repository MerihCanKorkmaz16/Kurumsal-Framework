using KurumsalFramework.Northwind.Entities.ComplexType;
using KurumsalFramework.Northwind.Entities.Concrete;
using KurumsalMimari.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KurumsalFramework.Northwind.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDetail> GetProductDetails();
    }
}
