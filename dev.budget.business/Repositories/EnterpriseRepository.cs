using dev.budget.business.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace dev.budget.business.Repositories
{
    public class EnterpriseRepository : BaseRepository<Enterprise, int>
    {
        public EnterpriseRepository(DbContext context) : base(context)
        {
        }
    }
}
