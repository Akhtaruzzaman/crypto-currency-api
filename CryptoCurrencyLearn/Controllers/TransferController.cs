using CryptoCurrencyLearn.Model;
using CryptoCurrencyLearn.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoCurrencyLearn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly IAccountService balanceService;

        public TransferController(IAccountService balanceService)
        {
            this.balanceService = balanceService;
        }
        [HttpPost(Name = "Transfer")]
        public async Task<IActionResult> Transfer(TransferDto transfer)
        {
            var res = await balanceService.Transper(transfer);
            balanceService.Account = transfer.Sender;
            return Ok($"Sender new balance is {await balanceService.GetBalance()}");
        }
    }
}
