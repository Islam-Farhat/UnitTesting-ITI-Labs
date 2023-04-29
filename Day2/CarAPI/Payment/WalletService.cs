using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarAPI.Payment
{
    public class WalletService : IPaymentService
    {
        public string Pay(double amount)
        {
            // Logic
            return $"Amount: {amount} is paid through Phone Wallet";
        }
    }
}