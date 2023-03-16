using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Models.Models;
using AddressBookWebAPI.Repository.Interfaces;

namespace AddressBookWebAPI.Repository.EfRepo
{
    public class AuthenticationEfCore: IAuthenticationRepository
    {
        ApplicationDbContext Context { get; set; }

        public AuthenticationEfCore(ApplicationDbContext context)
        {
            Context = context;
        }
        public void AddNewUser(LoginDetails newuserdetails)
        {
            Context.LoginCredentials.Add(newuserdetails);


        }

        public LoginDetails GetUserLoginDetails(Login request)
        {
            var user = Context.LoginCredentials.FirstOrDefault(x => x.UserName == request.Username && x.Password == request.Password);
            return user;
        }
    }
}
