using AddressBook.Models.Models;

namespace AddressBookServices.Interfaces
{
    public interface IAuthentificatinServices
    {
        void AddUser(LoginDetails user);
        LoginDetails GetUserLoginDetails(Login request);
    }
}