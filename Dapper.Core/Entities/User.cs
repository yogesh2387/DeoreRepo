using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string Address { get; set; }

        public string MobileNo { get; set; }

        public DateTime DateOfRegistration { get; set; }
    }
}
