using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace dev.budget.business.Repositories
{
    public class BaseRepository<TEntity, TID> where TEntity:class
    {
        private DbSet<TEntity> dbSet;
        protected DbContext context;

        public DbSet<TEntity> DbSet { get => dbSet; }

        public BaseRepository(DbContext context)
        {
            dbSet = context.Set<TEntity>();
            
        }
        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
            this.context.SaveChanges();

        }

        public void Insert(TEntity[] entities)
        {
            dbSet.AddRange(entities);
            this.context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            dbSet.Update(entity);
            context.SaveChanges();
        }

        public void Update(TEntity[] entities)
        {
            dbSet.UpdateRange(entities);
            context.SaveChanges();
        }

        public TEntity Find(TID id)
        {
            return dbSet.Find(id);
        }

    }
}
