
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using testapi2.DTO;
using testapi2.Service;

namespace testapi2.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditCardPaymentController : ControllerBase
    {
        private readonly ICreditCardPaymentService paymentService;

        public CreditCardPaymentController(ICreditCardPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreditCardPaymentModel payment)
        {
            var id = await paymentService.CreateAsync(payment);
            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var payment = await paymentService.GetByIdAsync(id);
            if (payment == null)
                return NotFound();

            return Ok(payment);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var payments = await paymentService.GetAllAsync();
            return Ok(payments);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CreditCardPaymentModel payment)
        {
            var result = await paymentService.UpdateAsync(payment);
            if (result == 0)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await paymentService.DeleteAsync(id);
            if (result == 0)
                return NotFound();

            return Ok(result);
        }
    }
}
