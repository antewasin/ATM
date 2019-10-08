using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Core.Domain
{
    public class Transaction
    {
        private Guid guid;

        public Guid Id { get; protected set; }
        public Guid? BankAccountId { get; protected set; }
        public DateTime DateTransaction { get; protected set; }
        public double Amount { get; protected set; }
        public virtual BankAccount BankAccount { get; protected set; }

        public Transaction() { }

        public Transaction(Guid id, Guid bankAccountId, double amount)
        {
            Id = id;
            BankAccountId = bankAccountId;
            DateTransaction = DateTime.UtcNow;
            Amount = amount;
        }

        public Transaction(Guid guid, Guid? bankAccountId, double amount)
        {
            this.guid = guid;
            BankAccountId = bankAccountId;
            Amount = amount;
        }
    }
}
