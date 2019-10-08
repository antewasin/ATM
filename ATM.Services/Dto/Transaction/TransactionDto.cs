using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Services.Dto.Transaction
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public Guid? BankAccountId { get; set; }
        public DateTime DateTransaction { get; set; }
        public double Amount { get; set; }
    }
}
