using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Models.Models
{
    [Table("UserDetailsList")]
    public class UserDetailsList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Landline { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
    }
}
