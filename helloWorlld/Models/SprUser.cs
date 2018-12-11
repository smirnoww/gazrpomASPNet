using System;
using System.Collections.Generic;

namespace helloWorlld.Models
{
    public partial class SprUser
    {
        public SprUser()
        {
            UserProductRequest = new HashSet<UserProductRequest>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<UserProductRequest> UserProductRequest { get; set; }
    }
}
