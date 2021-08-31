﻿using NETCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.Repository.Interface
{
    interface OldIRepository
    {
        IEnumerable<Person> Get();
        Person Get(string NIK);
        int Insert(Person person);
        int Update(Person person);
        int Delete(string NIK);

    }
}
