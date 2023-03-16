using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Models.Models;
using AddressBookServices.Interfaces;

namespace AddressBookServices.Services
{
    public class AddressBookWebApiServices : IAddressBookWebApiServices
    {
        private AddressBookWebAPI.Repository.Interfaces.IAddressBookRepository _context;
        public AddressBookWebApiServices(AddressBookWebAPI.Repository.Interfaces.IAddressBookRepository context)
        {
            _context = context;
        }
        public void AddRecord(UserDetailsList data)
        {
            _context.AddRecord(data);
        }
        public void UpdateRecord(UserDetailsList data)
        {
            _context.UpdateRecord(data);
        }
        public void DeleteRecord(int id)
        {
            _context.DeleteRecord(id);
        }
        public List<UserDetailsList> GetRecords()
        {
            return (_context.GetRecords());
        }
        public UserDetailsList GetRecord(int id)
        {
            return (_context.GetRecord(id));
        }
        public UserDetailsList GetNewlyAddedRecord()
        {
            return (_context.GetNewlyAddedRecord());
        }

    }
}
