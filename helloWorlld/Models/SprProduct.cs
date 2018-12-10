using System;
using System.Collections.Generic;

namespace helloWorlld.Models
{
    public partial class SprProduct
    {
        public SprProduct()
        {
            UserProductRequest = new HashSet<UserProductRequest>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }

        public ICollection<UserProductRequest> UserProductRequest { get; set; }
    }
}
