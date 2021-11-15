using Application.Config.dto;
using AutoMapper;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Config.Automapper
{
    public class AccountProfiler : Profile
    {
        public AccountProfiler()
        {
            this.CreateMap<GetAccountDto, Account>();
        }
    }

}
