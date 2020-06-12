using KurumsalFramework.Northwind.DataAccess.Abstract;
using KurumsalFramework.Northwind.Entities.ComplexType;
using KurumsalFramework.Northwind.Entities.Concrete;
using KurumsalMimari.Core.DataAccess.Nhihabernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KurumsalFramework.Northwind.DataAccess.Concrete.Nhibernate
{
    public class NhProductDal:NhEntityRepositoryBase<Product>,IProductDal
    {
        public NhProductDal(NhihabernateHelper nHihabernateHelper) : base(nHihabernateHelper)
        {

        }

        public List<ProductDetail> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
