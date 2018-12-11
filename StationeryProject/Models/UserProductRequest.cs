using System;
using System.Collections.Generic;
using StationeryProject.Models;
using System.ComponentModel.DataAnnotations;

namespace StationeryProject.Models
{
    public partial class UserProductRequest
    {

        public long Id { get; set; }
        public long UserId { get; set; }
        public long ProductId { get; set; }

        //[Required]
        [Range(1, 1000, ErrorMessage ="Количество должно быть в интервале от 1 до 1000")]
        public int ProductAmount { get; set; }

        private string UserName { get; set; }
        private string ProductName { get; set; }

        public SprProduct Product { get; set; }
        public SprUser User { get; set; }



        public string getUserName()
        {
            /*
            var request = from u in _db.SprUser select u;
            request = request.Where(user => user.Id == upr.UserId);
            */
            return UserName;
        }

        public string getProductName()
        {
            return ProductName;
        }

        public void setUserName(string un)
        {
            UserName = un;
        }

        public void setProductName(string pn)
        {
            ProductName = pn;
        }
    }
}
