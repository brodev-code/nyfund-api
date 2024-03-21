using NyFund.Core.Framework.DataAccessLayer.EntityCore.Repository;
using NyFund.Data.Entity.Model;

namespace NyFund.Core.Repository.Interface
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByEmail(string email);

        Customer GetByPhone(string phoneNumber);

        Customer GetByUserName(string userName);

        string GetFullNameById(long id);

        Task<Customer> GetById(long id);
    }
}
