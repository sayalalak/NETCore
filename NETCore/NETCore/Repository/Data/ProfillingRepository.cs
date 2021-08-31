using NETCore.Context;
using NETCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.Repository.Data
{
    public class ProfillingRepository : GeneralRepository<MyContext, Profiling, string>
    {
        public ProfillingRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
