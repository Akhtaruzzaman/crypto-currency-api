using CryptoCurrencyLearn.Model;
using CryptoCurrencyLearn.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace CryptoCurrencyLearn.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BalanceController : ControllerBase
    {
        private readonly IAccountService balanceService;

        public BalanceController(IAccountService balanceService)
        {
            this.balanceService = balanceService;
        }
        [HttpGet(Name = "GetBalance")]
        public async Task<string> Get()
        {
            return $"Balance is {await balanceService.GetBalance()}";
        }
        [HttpPost(Name = "GetBalanceByAddress")]
        public async Task<string> Post(string address)
        {
            balanceService.Account = new PersonalAccount { Address = address };
            return $"Balance is {await balanceService.GetBalance()}";
        }
    }
}