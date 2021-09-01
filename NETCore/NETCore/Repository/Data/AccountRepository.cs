using Microsoft.EntityFrameworkCore;
using NETCore.Context;
using NETCore.Models;
using NETCore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.Repository.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, string>
    {
        private readonly MyContext myContext;
        private readonly DbSet<Person> dbSet;
        public AccountRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
            this.dbSet = myContext.Set<Person>();
        }
        public LoginVM Login(LoginVM login)
        {
            if (dbSet.Where(p => p.Email == login.Email).Count() <= 0)
            {
                return null;
            }

            return (from p in myContext.Persons
                    join a in myContext.Accounts
                    on p.NIK equals a.NIK
                    select new LoginVM
                    {
                        Email = p.Email,
                        Password = a.Password,
                    }
         ).Where(p => p.Email == login.Email).First();
        }
    }
}
