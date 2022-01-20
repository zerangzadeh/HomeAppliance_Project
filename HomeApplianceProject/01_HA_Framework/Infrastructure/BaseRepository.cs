using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace _01_HA_Framework.Infrastructure
{
    public class BaseRepository<TKey, TEntity> : IBaseRepository<TKey, TEntity> where TEntity : EntityBase<TKey>
    {
        private readonly DbContext _dBContext;

        public BaseRepository(DbContext dBContext)
        {
           _dBContext = dBContext;
        }

        public BaseRepository()
        {
        }

        public void Create(TEntity entity)
        {
           _dBContext.Add<TEntity>(entity);
            SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<TEntity, bool>> expression)
        {
            return _dBContext.Set<TEntity>().Any(expression);
        }

        public List<TEntity> GetAll()
        {
            return _dBContext.Set<TEntity>().ToList();
        }

        public TEntity GetBy(TKey ID)
        {
            return _dBContext.Find<TEntity>(ID);
        }

        public void SaveChanges()
        {
            _dBContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            SaveChanges();
        }

        
    }
}