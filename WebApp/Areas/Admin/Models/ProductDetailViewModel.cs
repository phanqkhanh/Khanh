using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Areas.Admin.Models
{
    public class ProductDetailViewModel
    {
        public ProductDetailViewModel(int id, string img, int productId)
        {
            Id = id;
            Img = img;
            ProductId = productId;
        }
        public int Id { get; set; }
        public string Img { get; set; }
        public int ProductId { get; set; }
    }
}