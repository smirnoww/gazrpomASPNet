using System;
using System.Collections.Generic;

namespace StationeryProject.Models
{
    public partial class UserProductRequest
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long ProductId { get; set; }
        public int ProductAmount { get; set; }

        public SprProduct Product { get; set; }
        public SprUser User { get; set; }
    }
}
