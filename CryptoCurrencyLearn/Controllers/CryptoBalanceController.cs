using CryptoCurrencyLearn.Service.IService;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace CryptoCurrencyLearn.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CryptoBalanceController : ControllerBase
    {
        private readonly IBalanceService balanceService;

        public CryptoBalanceController(IBalanceService balanceService)
        {
            this.balanceService = balanceService;
        }
        //[HttpGet(Name = "GetBalance")]
        //public async Task<string> Get()
        //{
        //    return $"Balance is {await balanceService.GetBalance()}";
        //}

        [HttpGet(Name = "Get")]
        public async Task<object> Get()
        {
            return await balanceService.Get();
        }

        [HttpPost(Name = "GetBalanceByAddress")]
        public async Task<string> Post(string address)
        {
            return $"Balance is {await balanceService.GetBalance(address)}";
        }
    }
}