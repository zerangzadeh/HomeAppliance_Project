using LinqToTwitter.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _01_HA_Framework.Infrastructure
{
    public interface IBaseRepository<TKey, TEntity> where TEntity : EntityBase<TKey>
    {
            void Create(TEntity entity);
            void Update(TEntity entity);
            void Delete(TEntity entity);
            TEntity GetBy(TKey ID);
        //TEntity GetDetails(TKey ID);
        List<TEntity> GetAll();
       
            bool Exists(Expression<Func<TEntity, bool>> expression);
            void SaveChanges();
        
    }
}
