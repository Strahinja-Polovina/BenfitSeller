using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BaseLibrary.DTO
{
    public class IPayDTO
    {
        public decimal Amount { get; set; }
        [RegularExpression("^[0-9]{16}$")]
        public string CardNumber { get; set; } = string.Empty;
        [RegularExpression("^[0-9]{4}$")]
        public string Pin { get; set; } = string.Empty;
        public int MerchantId { get; set; }
    }
}
