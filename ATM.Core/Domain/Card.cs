using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Core.Domain
{
    public class Card
    {
        public Guid Id { get; protected set; } 
        public string Type { get; protected set; }
        public string PIN { get; protected set; }

        public Card() { }

        public Card(Guid id, string type, string pin)
        {
            Id = id;
            Type = type;
            PIN = pin;
        }
        public Card(string type, string pin)
        {
           
            Type = type;
            PIN = pin;
        }
    }
}
