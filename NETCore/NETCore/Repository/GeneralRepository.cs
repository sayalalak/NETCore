﻿using Microsoft.EntityFrameworkCore;
using NETCore.Context;
using NETCore.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.Repository
{
    public class GeneralRepository<Context, Entity, Key> : IRepository<Entity, Key>
        where Entity : class
        where Context : MyContext
    {
        private readonly MyContext myContext;
        private readonly DbSet<Entity> dbSet;

        public GeneralRepository(MyContext myContext)
        {
            this.myContext = myContext;
            dbSet = myContext.Set<Entity>();
        }

        public int Delete(Key key)
        {
            var wantDelete = dbSet.Find(key);
            if (wantDelete == null)
            {
                throw new ArgumentNullException();
            }
            dbSet.Remove(wantDelete);
            return myContext.SaveChanges();
        }

        public IEnumerable<Entity> Get()
        {
            return dbSet.ToList();
        }

        public Entity Get(Key key)
        {
            return dbSet.Find(key);
        }

        public int Insert(Entity entity)
        {
            dbSet.Add(entity);
            var insert = myContext.SaveChanges();
            return insert;
        }

        public int Update(Entity entity)
        {
            myContext.Entry(entity).State = EntityState.Modified;
            return myContext.SaveChanges();
        }
    }
}
