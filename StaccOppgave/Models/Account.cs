namespace StaccOppgave.Models
{
    public class Account
    {
        public int Accountid { get; set; }
        public int Userid { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public string Currency { get; set; }
        public Account(int accountid, int userid, string accountnumber, decimal balance, string currency)
        {
            Accountid = accountid;
            Userid = userid;
            AccountNumber = accountnumber;
            Balance = balance;
            Currency = currency;
        }
    }
}
