using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Models.Models;
using Microsoft.Win32;

namespace AutoMapper.Configuration.Mapper
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<UserRegister, LoginDetails>().ReverseMap();
            /*CreateMap<Register, LoginDetails>.ReverseMap();*/
            CreateMap<Contactdetails, UserDetailsList>().ReverseMap();
        }
    }
}
