using AddressBook.Models.Models;

namespace AddressBookWebAPI.Repository.Interfaces
{
    public interface IAuthenticationRepository
    {
        void AddNewUser(LoginDetails newuserdetails);
        LoginDetails GetUserLoginDetails(Login request);
    }
}