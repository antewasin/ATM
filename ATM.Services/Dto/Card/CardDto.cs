using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Services.Dto.Card
{
    public class CardDto
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string PIN { get; set; }
    }
}
