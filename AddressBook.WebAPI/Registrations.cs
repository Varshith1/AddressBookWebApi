using AddressBookServices.Interfaces;
using AddressBookServices.Services;
using AddressBookWebAPI.Repository.EfRepo;
using AddressBookWebAPI.Repository.Interfaces;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace AddressBook.WebAPI
{
    public class Registrations : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<IAddressBookRepository, AddressBookEfRepository>(Lifestyle.Scoped);
            container.Register<IAddressBookWebApiServices, AddressBookWebApiServices>(Lifestyle.Scoped);
            container.Register<IAuthentificatinServices, AuthentificatinServices>(Lifestyle.Scoped);
            container.Register<IAuthenticationRepository, AuthenticationEfCore>(Lifestyle.Scoped);
        }

    }
}
