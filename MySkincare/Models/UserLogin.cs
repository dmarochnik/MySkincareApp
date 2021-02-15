using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MySkincare.Models
{
    public class User
    {
        [Key]
        public int UID { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public string PhoneNum { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZIP { get; set; }
    }

    public class Login
    {
        public int UID { get; set; }

        [Key]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
