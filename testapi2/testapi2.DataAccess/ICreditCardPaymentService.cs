


using System.Collections.Generic;
using System.Threading.Tasks;
using testapi2.DTO;

namespace testapi2.Service
{
    public interface ICreditCardPaymentService
    {
        Task<int> CreateAsync(CreditCardPaymentModel payment);
        Task<CreditCardPaymentModel> GetByIdAsync(int id);
        Task<List<CreditCardPaymentModel>> GetAllAsync();
        Task<int> UpdateAsync(CreditCardPaymentModel payment);
        Task<int> DeleteAsync(int id);
    }
}
