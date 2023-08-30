using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using testapi2.DataAccess;
using testapi2.DTO;

namespace testapi2.Service
{
    public class CreditCardPaymentService : ICreditCardPaymentService
    {
        private readonly string connectionString;
        private readonly CreditCardPaymentRepository paymentRepository;

        public CreditCardPaymentService(string connectionString)
        {
            this.connectionString = connectionString;
            this.paymentRepository = new CreditCardPaymentRepository(connectionString);
        }

        public async Task<int> CreateAsync(CreditCardPaymentModel payment)
        {
            return await paymentRepository.CreateAsync(payment);
        }

        public async Task<CreditCardPaymentModel> GetByIdAsync(int id)
        {
            return await paymentRepository.GetByIdAsync(id);
        }

        public async Task<List<CreditCardPaymentModel>> GetAllAsync()
        {
            return await paymentRepository.GetAllAsync();
        }

        public async Task<int> UpdateAsync(CreditCardPaymentModel payment)
        {
            return await paymentRepository.UpdateAsync(payment);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await paymentRepository.DeleteAsync(id);
        }
    }

    public class RegeneratedCreditCardPaymentService : ICreditCardPaymentService
    {
        private readonly string connectionString;
        private readonly CreditCardPaymentRepository paymentRepository;

        public RegeneratedCreditCardPaymentService(string connectionString)
        {
            this.connectionString = connectionString;
            this.paymentRepository = new CreditCardPaymentRepository(connectionString);
        }

        public async Task<int> CreateAsync(CreditCardPaymentModel payment)
        {
            return await paymentRepository.CreateAsync(payment);
        }

        public async Task<CreditCardPaymentModel> GetByIdAsync(int id)
        {
            return await paymentRepository.GetByIdAsync(id);
        }

        public async Task<List<CreditCardPaymentModel>> GetAllAsync()
        {
            return await paymentRepository.GetAllAsync();
        }

        public async Task<int> UpdateAsync(CreditCardPaymentModel payment)
        {
            return await paymentRepository.UpdateAsync(payment);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await paymentRepository.DeleteAsync(id);
        }
    }
}