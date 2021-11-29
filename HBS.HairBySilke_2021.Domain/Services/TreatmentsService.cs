using System.Collections.Generic;
using HBS.Domain.IRepositories;
using HBS.HairBySilke_2021.Core.IServices;
using HBS.HairBySilke_2021.Core.Models;

namespace HBS.Domain.Services
{
    public class TreatmentsService : ITreatmentsService
    {
        private readonly ITreatmentsRepository _treatmentsRepository;

        public TreatmentsService(ITreatmentsRepository _treatmentsRepository)
        {
            this._treatmentsRepository = _treatmentsRepository;
        }
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

        public List<Treatment> GetAllTreatments()
        {
            return _treatmentsRepository.ReadAllTreatments();
        }
    }
}