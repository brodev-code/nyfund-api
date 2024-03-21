using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace NyFund.Data.DataAccessLayer.Database
{
    public class DbContextBase : DbContext
    {
        public DbContextBase([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected DbContextBase()
        {
        }
    }
}
