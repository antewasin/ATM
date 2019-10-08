using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Services.Commands.Transaction
{
    public class DoTransaction : ICommand
    {
        public Guid? BankAccountId { get; set; }
        public double Amount { get; set; }

    }
}
