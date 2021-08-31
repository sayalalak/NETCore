using Microsoft.EntityFrameworkCore;
using NETCore.Context;
using NETCore.Models;
using NETCore.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.Repository
{
    public class OldRepository : OldIRepository
    {
        // panggil MyContext untuk gateway dan set obejct nya
        private readonly MyContext myContext;
        public OldRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public int Delete(string NIK)
        {
            var wantDelete = myContext.Persons.Find(NIK);
            if (wantDelete == null)
            {
                throw new ArgumentNullException();
            }
            myContext.Persons.Remove(wantDelete);
            return myContext.SaveChanges();
        }

        public IEnumerable<Person> Get()
        {
            return myContext.Persons.ToList();
        }

        public Person Get(string NIK)
        {
            //cari data berdasarkan primarykey
            return myContext.Persons.Find(NIK);
        }

        public int Insert(Person person)
        {
            myContext.Persons.Add(person);
            var insert = myContext.SaveChanges();
            return insert;
        }

        public int Update(Person person)
        { 
            myContext.Entry(person).State = EntityState.Modified;
            return myContext.SaveChanges();
        }
    }
}
