using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Services.Dto
{
    public class BankAccountDto
    {
        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? CardId { get; set; }
        public string NameAccount { get; set; }
        public double Balance { get;  set; }
    }
}
