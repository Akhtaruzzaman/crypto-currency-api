using CryptoCurrencyLearn.Model;
using CryptoCurrencyLearn.Service.IService;
using Nethereum.Hex.HexTypes;
using Nethereum.Web3;
using System.Numerics;
using Nethereum.Web3.Accounts;
using Nethereum.Web3.Accounts.Managed;
using Nethereum.Hex.HexTypes;

namespace CryptoCurrencyLearn.Service
{
    public class AccountService : IAccountService
    {
        public PersonalAccount Account { get; set; }
        public PersonalAccount ToAccount { get; set; }
        public BalanceTransper BalanceTransper { get; set; }

        public AccountService()
        {
            if (this.Account == null)
            {
                this.Account = new PersonalAccount
                {
                    Address = "0xf43F618C1178e8d9132F6c09CAE67Db769823B9b",
                    PrivateKey = "0xd15ede4e960847369fb8978487239a3177090b635d56da1331b65d85484a02f1"
                };
                this.ToAccount = new PersonalAccount
                {
                    Address = "0x44c182e58CC049266d684fA022Ee99B82FCE14D8",
                    PrivateKey = "0x68d3842f4aa124ee655503c991dce2d608f28958c385aa25fcc5b06ee06fc415"
                };
            }
        }
        public async Task<decimal> GetBalance()
        {
            try
            {
                var web3 = new Web3($"{SystemData.RpcClient}");
                HexBigInteger balance = await web3.Eth.GetBalance.SendRequestAsync(this.Account.Address);
                return Web3.Convert.FromWei(balance.Value);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Transper(TransferDto transfer)
        {
            try
            {
                if (transfer.Sender == null)
                    transfer.Sender = this.Account;
                if (transfer.Receiver == null)
                    transfer.Receiver = this.ToAccount;

                var account = new Account(transfer.Sender.PrivateKey);
                var web3 = new Web3(account, SystemData.RpcClient);

                var transaction2 = await web3.Eth.GetEtherTransferService()
                .TransferEtherAndWaitForReceiptAsync(transfer.Receiver.Address, transfer.Amount, 2);

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
