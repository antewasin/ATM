using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Core.Domain
{
    public class BankAccount
    {
        public Guid Id { get; protected set; }
        public Guid? CustomerId { get; protected set; }
        public Guid? CardId { get; protected set; }
        public string NameAccount { get; protected set; }
        public double Balance { get; protected set; }
        public virtual ICollection<Transaction> Transactions { get; protected set; }
        public virtual Card Card { get; protected set; }
        public virtual Customer Customer { get; protected set; }

        public BankAccount()
        {
            Transactions = new HashSet<Transaction>();
            
        }

        public BankAccount(Guid  id, Guid customerId, string nameAccount, double balance)
        {
            Id = id;
            CustomerId = customerId;
            NameAccount = nameAccount;
            Balance = balance;
        }
        public BankAccount(Guid id, Guid customerId, Guid cardId, string nameAccount, double balance)
        {
            Id = id;
            CustomerId = customerId;
            CardId = cardId;
            NameAccount = nameAccount;
            Balance = balance;
        }

        public void changeBalance(double money)
        {
            Balance -= money;
        }
    }
}
