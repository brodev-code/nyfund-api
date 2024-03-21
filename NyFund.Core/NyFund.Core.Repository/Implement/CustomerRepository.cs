using NyFund.Core.Repository.Interface;
using NyFund.Data.DataAccessLayer.Database;
using NyFund.Data.DataAccessLayer.EntityCore.Repository;
using NyFund.Data.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace NyFund.Core.Repository.Implement
{
    public class CustomerRepository : EntityRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContextBase dbContext) : base(dbContext)
        {

        }

        public Customer GetByEmail(string email)
        {
            var data = Get(x => x.Email == email);
            return data;
        }

        public Customer GetByPhone(string phoneNumber)
        {
            var data = Get(x => x.PhoneNumber == phoneNumber && x.IsActive && !x.IsDelete);
            return data;
        }

        public Customer GetByUserName(string userName)
        {
            var data = Get(x => x.UserName == userName);
            return data;
        }

        public string GetFullNameById(long id)
        {
            var data = GetQuery(x => x.Id == id).Select(x=> x.Name + " " + x.Surname).FirstOrDefault();
            return data;
        }

        public async Task<Customer> GetById(long id)
        {
            var data = await GetQuery(x => !x.IsDelete && x.IsActive && x.Id == id).FirstOrDefaultAsync();
            return data;
        }
    }
}