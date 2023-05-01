using System.Numerics;

namespace CryptoCurrencyLearn.Service.IService
{
    public interface IBalanceService
    {
        Task<object> Get();
        Task<decimal> GetBalance();
        Task<decimal> GetBalance(string address);
    }
}
