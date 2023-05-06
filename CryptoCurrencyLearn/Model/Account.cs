namespace CryptoCurrencyLearn.Model
{
    public class PersonalAccount
    {
        public string Address { get; set; } 
        public string PrivateKey { get; set; } 
    }
    public class BalanceTransper: PersonalAccount
    {
        public string ToAddress { get; set; } 
    }
}
