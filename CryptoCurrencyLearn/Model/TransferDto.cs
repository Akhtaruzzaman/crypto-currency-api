
namespace CryptoCurrencyLearn.Model
{
    public class TransferDto
    {
        public PersonalAccount Sender { get; set; }
        public PersonalAccount Receiver { get; set; }
        public decimal Amount { get; set; }
    }
}
