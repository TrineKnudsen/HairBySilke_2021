using System.Collections.Generic;
using HBS.HairBySilke_2021.Core.Models;

namespace HBS.HairBySilke_2021.Core.IServices
{
    public interface ITreatmentsService
    {
        Customer CreateCustomer(Customer customer);

        List<Customer> ReadAllCustomers();

        Customer UpdateCustomer(Customer customerToUpdate);

        void DeleteCustomer(int id);
        List<Treatment> GetAllTreatments();
    }
}