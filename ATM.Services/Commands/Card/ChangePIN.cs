using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Services.Commands.Card
{
    public class ChangePIN : ICommand
    {
        public Guid Id { get; set; }
        public Guid BankAccountId { get; set; }
        public string Type { get; protected set; }
        public string PIN { get; set; }

    }
}
