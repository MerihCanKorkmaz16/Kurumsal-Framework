using KurumsalFramework.Northwind.Business.Abstract;
using KurumsalFramework.Northwind.Business.ValidationRules.FluentValidation;
using KurumsalFramework.Northwind.DataAccess.Abstract;
using KurumsalFramework.Northwind.Entities.Concrete;
using KurumsalMimari.Core.CrossCuttingConcerns.Validation.FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KurumsalMimari.Core.Aspects.Postsharp;
using KurumsalMimari.Core.DataAccess;
using System.Transactions;
using KurumsalMimari.Core.Aspects.Postsharp.TransactionAspect;
using KurumsalMimari.Core.Aspects.Postsharp.CacheAspect;
using KurumsalMimari.Core.Aspects.Postsharp.LogAspects;
using KurumsalMimari.Core.CrossCuttingConcerns.Caching.Microsoft;
using KurumsalMimari.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;

namespace KurumsalFramework.Northwind.Business.Concrete.Managers
{
    //transaction yönetimi bir metod da 3 işlem yapıyoruz diyelim(add,update,delete) ilk 2 işlem başarılı olursa son işlem başarısız olursa ne yaparız.
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [FluentValidationAspect(typeof(ProductValidatior))]//aspect orianted programming
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }

        [FluentValidationAspect(typeof(ProductValidatior))]//aspect
        public Product Update(Product product)
        {
            //2iş yapıyorum
            ValidatorTool.FluentValidate(new ProductValidatior(), product);
            return _productDal.Update(product);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        [TransactionScopeAspect]
        public void TransactionalOperation(Product product1, Product product2)
        {
            //kötü kod
            //using (TransactionScope scope = new TransactionScope())
            //{
            //    try
            //    {
            //       
            //        scope.Complete();
            //    }
            //    catch
            //    {
            //        //hata varsa
            //        scope.Dispose();

            //    }
            //}
            //kötü kod  bitiş
            _productDal.Add(product1);
            _productDal.Update(product2);

        }
    }
}
