using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Models.Models;
using Dapper.Contrib.Extensions;
using Dapper;
using Microsoft.Win32;
using AddressBookWebAPI.Repository.Interfaces;
using AutoMapper.Configuration.Mapper;

namespace AddressBookWebAPI.Repository.Dapper
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private DapperContext Context { get; set; }
        public AuthenticationRepository(DapperContext dapperContext)
        {
            Context = dapperContext;
        }
        public LoginDetails GetUserLoginDetails(Login request)
        {
            string query = $"select  * from LoginCredentials where UserName='{request.Username}' and Password='{request.Password}'";
            var user = Context.Connection.Query<LoginDetails>(query).SingleOrDefault();

            return user;
        }
        public void AddNewUser(LoginDetails newuserdetails)
        {
            
            Context.Connection.Insert(newuserdetails);
        }
    }
}
