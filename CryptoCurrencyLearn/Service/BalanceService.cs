using CryptoCurrencyLearn.Service.IService;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;
using System.Numerics;

namespace CryptoCurrencyLearn.Service
{
    public class BalanceService : IBalanceService
    {
        public BalanceService()
        {
            
        }
        public async Task<decimal> GetBalance()
        {
            try
            {
                var web3 = new Web3("https://mainnet.infura.io/v3/c54d1d3684af4111bd248c93b19b9357");
                HexBigInteger balance = await web3.Eth.GetBalance.SendRequestAsync("0x18601AEA7f54d26D18B19C09F1cF94C186fCe8A1");
                return Web3.Convert.FromWei(balance.Value);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<decimal> GetBalance(string address)
        {
            try
            {
                var web3 = new Web3("https://mainnet.infura.io/v3/c54d1d3684af4111bd248c93b19b9357");
                HexBigInteger balance = await web3.Eth.GetBalance.SendRequestAsync(address);
                return Web3.Convert.FromWei(balance.Value);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<object> Get()
        {
            try
            {
                var web3 = new Web3("https://mainnet.infura.io/v3/c54d1d3684af4111bd248c93b19b9357");
                var account = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync("0x513c1ba0bebf66436b5fed86ab668452b7805593c05073eb2d51d3a52f480a76");
                return account;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
