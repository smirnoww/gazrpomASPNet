using System;
using System.Collections.Generic;
using StationeryProject.Models;

namespace StationeryProject.Models
{
    public partial class UserProductRequest
    {
        private StationeryContext _db;

        public long Id { get; set; }
        public long UserId { get; set; }
        public long ProductId { get; set; }
        public int ProductAmount { get; set; }

        public SprProduct Product { get; set; }
        public SprUser User { get; set; }

        public UserProductRequest(StationeryContext db)
        {
            _db = db;
        }

        public string getUserName()
        {
            var request = from u in _db.SprUser select u;
            request = request.Where(user => user.Id == upr.UserId);

            return "User Mock";
        }

        public string getProductName()
        {
            return "Product Mock";
        }
    }
}
