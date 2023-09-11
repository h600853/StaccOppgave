using System;
using System.Collections.Generic;
namespace ClassLibrary1
{
    public partial class Account
    {
        public int AccountId { get; set; }

        public int? UserId { get; set; }

        public string AccountNumber { get; set; } = null!;

        public decimal Balance { get; set; }

        public string Currency { get; set; } = null!;

        public virtual User? User { get; set; }
    }

}