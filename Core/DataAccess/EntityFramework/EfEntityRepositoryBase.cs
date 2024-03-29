﻿using Core.DataAccess.Abstract;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext> : IEntityRepository<TEntity> //IEntityrepositoryden imzalı metodları alır.
        where TContext: DbContext, new()
        where TEntity:class, IEntity, new()
    
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext()) //using metodu gereksiz nesnenin bellekten daha hızlı atılmasını sağlar performansı artırır.
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext()) //using metodu gereksiz nesnenin bellekten daha hızlı atılmasını sağlar performansı artırır.
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {

                return context.Set<TEntity>().SingleOrDefault(filter);
                
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();                               //select * from product
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext()) //using metodu gereksiz nesnenin bellekten daha hızlı atılmasını sağlar performansı artırır.
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }







    }
}
