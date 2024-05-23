    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace ApiLibrary.Models
    {
        public class Card
        {
            public int Id { get; set; }
        public string CardNumber { get; set; } = string.Empty;
            public string Pin { get; set; } = string.Empty;
            public decimal Balance { get; set; }
            public int EmployeeId { get; set; }
            public Employee? Employee { get; set; }
        }
    }
