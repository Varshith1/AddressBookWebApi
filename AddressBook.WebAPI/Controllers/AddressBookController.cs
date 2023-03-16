using AddressBook.Models.Models;
using AddressBookServices.Interfaces;
using AutoMapper;
using AutoMapper.Configuration.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace AddressBook.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressBookController : ControllerBase
    {
            private readonly IAddressBookWebApiServices _services;
            private readonly IMapper _mapper;
            public AddressBookController(IAddressBookWebApiServices services, IMapper mapper)
            {
                _services = services;
                _mapper = mapper;
            }
            [HttpGet]
            public IEnumerable<UserDetailsList> GetContacts()
            {
                return _services.GetRecords();
            }

            [HttpGet("{id}")]

            public ActionResult<UserDetailsList> GetContact(int id)
            {
                if (_services.GetRecord(id) == null)
                {
                    return BadRequest("No Contact Found!");
                }
                else
                {
                    return _services.GetRecord(id);
                }
            }
            [HttpPost]
            public void PostContact(UserDetailsList record, int value)
            {
            //var loginDetails = _mapper.Map<UserDetailsList>(record);
            _services.AddRecord(record);
            }


            [HttpPut("{id}")]
            [Authorize(Roles = "Admin,admin")]  
        public void PutContact(UserDetailsList record, int id)
            {
                record.Id = id;
                _services.UpdateRecord(record);
            }
            [HttpDelete("{id}")]
            [Authorize(Roles="Admin,admin")]
            public void DeleteContact(int id)
            {
                _services.DeleteRecord(id);
            }
            [HttpGet]
            [Route("Getnewlyaddedrecord")]
            public ActionResult<UserDetailsList> GetNEwlyAddedRecord()
            {
                return _services.GetNewlyAddedRecord();
            }
        }
}
