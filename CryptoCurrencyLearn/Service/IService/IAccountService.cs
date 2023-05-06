using CryptoCurrencyLearn.Model;
using System.Numerics;

namespace CryptoCurrencyLearn.Service.IService
{
    public interface IAccountService
    {
        PersonalAccount Account { get; set; }
        public PersonalAccount ToAccount { get; set; }
        BalanceTransper BalanceTransper { get; set; }
        Task<decimal> GetBalance();
        Task<bool> Transper(TransferDto transfer);
    }
}
