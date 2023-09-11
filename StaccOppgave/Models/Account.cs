using System.Text.Json.Serialization;

namespace StaccOppgave.Models
{
    public class Account
    {
        [JsonPropertyName("accountId")]
        public int Accountid { get; set; }
        [JsonPropertyName("userId")]
        public int Userid { get; set; }
        [JsonPropertyName("accountNumber")]
        public string AccountNumber { get; set; }
        [JsonPropertyName("accountNumber")]
        public decimal Balance { get; set; }
        [JsonPropertyName("currency")]
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
