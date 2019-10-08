using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Core.Domain
{
    public class Customer
    {
        public Guid Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public ICollection<BankAccount> BankAccounts { get; protected set; }

        public Customer()
        {
            BankAccounts = new List<BankAccount>();
        }

        public Customer(Guid id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
