using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.DTO
{
    public class ICardDTO
    {
        [RegularExpression("^[0-9]{16}$")]
        public string CardNumber { get; set; } = string.Empty;
        [RegularExpression("^[0-9]{4}$")]
        public string Pin { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public int EmployeeId { get; set; }
        
    }
}
