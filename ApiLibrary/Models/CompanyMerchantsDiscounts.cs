using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiLibrary.Models
{
    public class CompanyMerchantsDiscounts
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
        public int MerchantId { get; set; }
        public Merchant? Merchant { get; set; }
        public decimal Discount { get; set; }
    }
}
