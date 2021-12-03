using System.Collections.Generic;
using HBS.Domain.IRepositories;
using HBS.HairBySilke_2021.Core.Models;

namespace HBS.HairBySilke_2021.DataAccess.Repositories
{
    public class UserRepository : ICustomerRepository
    {
        public Customer CreateCustomer(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public List<Customer> ReadAllCustomers()
        {
            throw new System.NotImplementedException();
        }

        public Customer UpdateCustomer(Customer customerToUpdate)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCustomer(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}