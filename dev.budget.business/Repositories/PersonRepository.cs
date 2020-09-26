using dev.budget.business.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace dev.budget.business.Repositories
{
    public class PersonRepository : BaseRepository<Person, int>
    {
        public PersonRepository(DbContext context) : base(context)
        {
        }
    }
}
