using dev.budget.business.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev.budget.business.Repositories
{
    class BudgetRepository : BaseRepository<Budget, int>
    {
        public BudgetRepository(DbContext context) : base(context)
        {
        }

        public List<Budget> GetBudgetsByPerson(int personId)
        {
            return DbSet.Where(b => b.PersonId == personId)
                .ToList();
        }
    }
}
