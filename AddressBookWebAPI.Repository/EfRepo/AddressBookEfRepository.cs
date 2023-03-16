using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Models.Models;
using AddressBookWebAPI.Repository.Interfaces;

namespace AddressBookWebAPI.Repository.EfRepo
{
    public class AddressBookEfRepository: IAddressBookRepository
    {
        ApplicationDbContext Context { get; set; }

        //IContext IRepo.Context 

        public AddressBookEfRepository(ApplicationDbContext context)
        {

            Context = context;

        }

        public void AddRecord(UserDetailsList data)
        {
            Context.UserDetailsList.Add(data);
            Context.SaveChanges();
        }
        public void UpdateRecord(UserDetailsList data)
        {
            Context.UserDetailsList.Update(data);
            Context.SaveChanges();
        }
        public void DeleteRecord(int id)
        {
            Context.UserDetailsList.Remove(Context.UserDetailsList.SingleOrDefault(x => x.Id == id));
            Context.SaveChanges();
        }
        public List<UserDetailsList> GetRecords()
        {
            return Context.UserDetailsList.ToList();
        }
        public UserDetailsList GetRecord(int id)
        {
            return Context.UserDetailsList.SingleOrDefault(x => x.Id == id);
        }
        public UserDetailsList GetNewlyAddedRecord()
        {
            return Context.UserDetailsList.OrderByDescending(x => x.Id).FirstOrDefault();
        }
    }
}
