using System;
using System.Collections.Generic;

namespace StationeryProject.Models
{
    public partial class SprProduct
    {
        public SprProduct()
        {
            UserProductRequest = new HashSet<UserProductRequest>();
        }

        public long Id { get; set; }
        public string ProductName { get; set; }

        public ICollection<UserProductRequest> UserProductRequest { get; set; }
    }
}
