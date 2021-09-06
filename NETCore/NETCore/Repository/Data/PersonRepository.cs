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
    public class PersonRepository : GeneralRepository<MyContext, Person, string>
    {
        private readonly MyContext myContext;
        private readonly DbSet<Person> dbSet;

        public PersonRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
            this.dbSet = myContext.Set<Person>();
        }
        //NIK, FirstName, LastName, Phone Number, Birthdate, Gender, Salary, Email, Password, Degree, GPA
        public IEnumerable<RegisterVM> GetRegisterVMs()
        {
            var RegisterVMs = (from p in myContext.Persons
                               join a in myContext.Accounts on p.NIK equals a.NIK
                               join pf in myContext.Profilings on a.NIK equals pf.NIK
                               join e in myContext.Educations on pf.EducationId equals e.Id
                               join u in myContext.Universities on e.UniversityId equals u.Id
                               select new RegisterVM
                               {
                                   NIK = p.NIK,
                                   NamaLengkap = p.FirstName + " " + p.LastName,
                                   //FirstName = p.FirstName,
                                   //LastName = p.LastName,
                                   PhoneNumber = p.Phone,
                                   BirthDate = p.BirthDate,
                                   Gender = (int)p.GenderName,
                                   Salary = p.Salary,
                                   Email = p.Email,
                                   Password = a.Password,
                                   Degree = e.Degree,
                                   GPA = e.GPA,
                                   UniversityId = u.Id
                               }).ToList();
            if (RegisterVMs.Count==0)
            {
                return null;
            }
            return RegisterVMs.ToList();
        }
        public RegisterVM GetRegister(string NIK)
        {
            if (dbSet.Find(NIK) == null)
            {
                return null;
            }
            else
            {
                return (from p in myContext.Persons
                        join a in myContext.Accounts on p.NIK equals a.NIK
                        join pf in myContext.Profilings on a.NIK equals pf.NIK
                        join e in myContext.Educations on pf.EducationId equals e.Id
                        join u in myContext.Universities on e.UniversityId equals u.Id
                        select new RegisterVM
                        {
                            NIK = p.NIK,
                            NamaLengkap = p.FirstName +" "+ p.LastName,
                            //FirstName = p.FirstName,
                            //LastName = p.LastName,
                            PhoneNumber = p.Phone,
                            BirthDate = p.BirthDate,
                            Gender = (int)p.GenderName,
                            Salary = p.Salary,
                            Email = p.Email,
                            Password = a.Password,
                            Degree = e.Degree,
                            GPA = e.GPA,
                            UniversityId = u.Id
                        }).Where(p => p.NIK == NIK).First();
            }
        }
        public int InsertReg(RegisterVM register)
        {
            myContext.Persons.Add(new Person()
            {
                NIK = register.NIK,
                FirstName  = register.FirstName,
                LastName = register.LastName,
                Phone = register.PhoneNumber,
                BirthDate = register.BirthDate,
                Salary = register.Salary,
                GenderName = (Person.Gender)register.Gender,
                Email = register.Email
            }) ;
            myContext.SaveChanges();

            myContext.Accounts.Add(new Account()
            {
                NIK = register.NIK,
                Password = BCrypt.Net.BCrypt.HashPassword(register.Password, BCrypt.Net.BCrypt.GenerateSalt(12))
            });
            myContext.SaveChanges();

            Education education = new Education(register.Degree, register.GPA, register.UniversityId);
            myContext.Educations.Add(education);
            myContext.SaveChanges();

            AccountRole accountRole = new AccountRole();
            accountRole.NIK = register.NIK;
            accountRole.RoleId = 1;
            myContext.AccountRoles.Add(accountRole);

            myContext.Profilings.Add(new Profiling()
            {
                NIK = register.NIK,
                EducationId = education.Id
            });

            return myContext.SaveChanges();
        }
        public string Validation(string nik, string email, string phone)
        {

            if (dbSet.Find(nik) != null)
            {
                return "NIK sudah ada";
            }

            if (dbSet.Where(per => per.Email == email).Count() > 0)
            {
                return "Email sudah ada";
            }

            if (dbSet.Where(per => per.Phone == phone).Count() > 0)
            {
                return "Nomor hp sudah ada";
            }

            return "1";

        }
        
    }
}
