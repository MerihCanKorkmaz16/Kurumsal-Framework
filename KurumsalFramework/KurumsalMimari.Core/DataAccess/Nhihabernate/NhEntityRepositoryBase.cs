using KurumsalMimari.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace KurumsalMimari.Core.DataAccess.Nhihabernate
{
    public class NhEntityRepositoryBase<TEntity>:IEntityRepository<TEntity> where TEntity:class,IEntity,new()
    {
        private NhihabernateHelper _nhihabernateHelper;
        public NhEntityRepositoryBase(NhihabernateHelper nhihabernateHelper)
        {
            _nhihabernateHelper = nhihabernateHelper;
        }

        public TEntity Add(TEntity entity)
        {
            using (var session = _nhihabernateHelper.OpenSession())
            {
                session.Save(entity);
                return entity;
            }
        }

        public void Delete(TEntity entity)
        {
            using (var session = _nhihabernateHelper.OpenSession())
            {
                session.Delete(entity);
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var session = _nhihabernateHelper.OpenSession())
            {
                return session.Query<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var session = _nhihabernateHelper.OpenSession())
            {
                return filter == null
                    ? session.Query<TEntity>().ToList()
                    : session.Query<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var session = _nhihabernateHelper.OpenSession())
            {
                session.Update(entity);
                return entity;
            }
        }
    }
}
