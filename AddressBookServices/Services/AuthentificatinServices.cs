using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using AddressBook.Models.Models;
using AddressBookServices.Interfaces;
using AddressBookWebAPI.Repository.Dapper;
using AddressBookWebAPI.Repository.Interfaces;

namespace AddressBookServices.Services
{
    public class AuthentificatinServices : IAuthentificatinServices
    {
        private readonly IAuthenticationRepository context;
        public AuthentificatinServices(IAuthenticationRepository _context)
        {
            this.context = _context;

        }
        public LoginDetails GetUserLoginDetails(Login request)
        {
            return context.GetUserLoginDetails(request);
        }
        public void AddUser(LoginDetails user)
        {
            context.AddNewUser(user);
        }
    }
}
