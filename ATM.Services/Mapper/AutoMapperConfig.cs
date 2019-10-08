using ATM.Core.Domain;
using ATM.Services.Dto;
using ATM.Services.Dto.Card;
using ATM.Services.Dto.Transaction;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Services.Mapper
{
    public static class AutoMapperConfig
    {

        public static IMapper Initialize()
        {
            var config = new MapperConfiguration(c =>
           {
               c.CreateMap<BankAccount, BankAccountDto>();
               c.CreateMap<Card, CardDto>();
               c.CreateMap<ATM.Core.Domain.Transaction, TransactionDto>();
           });
            return config.CreateMapper();
        }

    }
}
