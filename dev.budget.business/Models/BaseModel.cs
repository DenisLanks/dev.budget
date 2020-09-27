using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace dev.budget.business.Models
{
    public class BaseModel
    {
        protected DbContext context;

        protected BaseModel(DbContext dbContext)
        {
            context = dbContext;
        }
        protected void ValidateString(string value)
        {
            if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException();
            }
        }
    }
}
