using KurumsalMimari.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KurumsalMimari.Core.DataAccess
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //Solid in d si bir katmanı başka bir katmanda new leyemezsin
        //biz listlerle çalıştığımız zaman context açıp kapatılır.Context kapanmadan çalışması ıcın IQueryrepo eklenir
        List<T> GetList(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter = null);
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
