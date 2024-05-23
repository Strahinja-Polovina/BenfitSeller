using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.Responses
{
    public class PaymentResponse
    {
        public decimal Amount { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public string MerchantName { get; set; } = string.Empty;
    }
}
