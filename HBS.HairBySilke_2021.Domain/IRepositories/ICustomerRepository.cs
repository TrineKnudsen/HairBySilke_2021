using System.Collections.Generic;
using HBS.HairBySilke_2021.Core.Models;

namespace HBS.Domain.IRepositories
{
    public interface ICustomerRepository
    {
        Customer CreateCustomer(Customer customer);

        List<Customer> ReadAllCustomers();

        Customer UpdateCustomer(Customer customerToUpdate);

        void DeleteCustomer(int id);
    }
}