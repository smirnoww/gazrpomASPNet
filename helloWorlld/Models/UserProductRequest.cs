using System;
using System.Collections.Generic;

namespace helloWorlld.Models
{
    public partial class UserProductRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int ProductAmount { get; set; }

        public SprProduct Product { get; set; }
        public SprUser User { get; set; }
    }
}
