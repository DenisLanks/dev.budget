using dev.budget.business;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace dev.budget.test.Models
{
    public class BaseModelTest
    {
        protected DbContext context;
        protected BaseModelTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseInMemoryDatabase("teste");
            context = new DevBudgetContext(optionsBuilder.Options);
        }
    }
}
