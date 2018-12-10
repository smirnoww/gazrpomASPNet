using System;
using System.Collections.Generic;

namespace StationeryProject.Models
{
    public partial class SprUser
    {
        public SprUser()
        {
            UserProductRequest = new HashSet<UserProductRequest>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<UserProductRequest> UserProductRequest { get; set; }
    }
}
