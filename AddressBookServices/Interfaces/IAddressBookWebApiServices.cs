using AddressBook.Models.Models;

namespace AddressBookServices.Interfaces
{
    public interface IAddressBookWebApiServices
    {
        void AddRecord(UserDetailsList data);
        void DeleteRecord(int id);
        UserDetailsList GetNewlyAddedRecord();
        UserDetailsList GetRecord(int id);
        List<UserDetailsList> GetRecords();
        void UpdateRecord(UserDetailsList data);
    }
}