using dev.budget.business.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace dev.budget.business.Repositories
{
    public class UserRepository : BaseRepository<User, int>
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public User GetByUsernamePassword(string username, string password)
        {
            return DbSet.Where(u => u.Username.Equals(username) && u.Password.Equals(password))
                .FirstOrDefault();
        }
    }
}
