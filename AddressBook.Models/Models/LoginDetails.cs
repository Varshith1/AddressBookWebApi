using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Models.Models
{
    [Table("LoginCredentials")]
    public class LoginDetails
    {

            public int Id { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Role { get; set; }
        
    }
}
