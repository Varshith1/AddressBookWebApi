using AddressBook.Models.Models;

namespace AddressBookWebAPI.Repository.Interfaces
{
    public interface IAddressBookRepository
    {
        void AddRecord(UserDetailsList contact);
        void DeleteRecord(int Id);
        UserDetailsList GetNewlyAddedRecord();
        UserDetailsList GetRecord(int Id);
        List<UserDetailsList> GetRecords();
        void UpdateRecord(UserDetailsList contact);
    }
}