using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySkincare.Models
{
    public class RegisterRequest
    {
        public string FName { get; set; }

        public string LName { get; set; }

        public string PhoneNum { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZIP { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
