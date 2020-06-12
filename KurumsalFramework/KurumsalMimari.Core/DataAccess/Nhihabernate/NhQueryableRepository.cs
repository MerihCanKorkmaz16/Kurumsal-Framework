using KurumsalMimari.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KurumsalMimari.Core.DataAccess.Nhihabernate
{
    public class NhQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private NhihabernateHelper _nhihabernateHelper;
        private IQueryable<T> _entities;
        public NhQueryableRepository(NhihabernateHelper nhihabernateHelper)
        {
            _nhihabernateHelper = nhihabernateHelper;
        }
        public IQueryable<T> Table { get { return this.Entities; } }
        public virtual IQueryable<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _nhihabernateHelper.OpenSession().Query<T>();
                }
                return _entities;
            }
        }

        IQueryable<T> IQueryableRepository<T>.Table { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
