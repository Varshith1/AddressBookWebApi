using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Dapper;
using AddressBook.Models.Models;
using AddressBookWebAPI.Repository.Interfaces;

namespace AddressBookWebAPI.Repository.Dapper
{
    public class AddressBookDapperRepository : IAddressBookRepository
    {
        private DapperContext Context { get; set; }
        public AddressBookDapperRepository(DapperContext dapperContext)
        {
            Context = dapperContext;
        }
        public List<UserDetailsList> GetRecords()
        {
            /*return Context.Connection.GetAll<UserDetailsList>().ToList()*/
            ;
            string query = "select * from UserDetailsList  ";
            return Context.Connection.Query<UserDetailsList>(query).ToList();
        }
        public UserDetailsList GetRecord(int Id)
        {
            /*string query = $"select * from UserDetailsList where Id=@Id";
            return Context.Connection.Query<UserDetailsList>(query);*/
            return Context.Connection.Get<UserDetailsList>(Id);
        }
        public void DeleteRecord(int Id)
        {
            Context.Connection.Delete(Context.Connection.Get<UserDetailsList>(Id));
        }
        public void AddRecord(UserDetailsList contact)
        {
            Context.Connection.Insert(contact);
        }
        public void UpdateRecord(UserDetailsList contact)
        {
            Context.Connection.Update(contact);
        }
        public UserDetailsList GetNewlyAddedRecord()
        {
            string query = $"select  * from UserDetailsList Order by Id desc";
            return Context.Connection.Query<UserDetailsList>(query).FirstOrDefault();
        }
    }
}
