namespace DatabaseProvider
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductDetail")]
    public partial class ProductDetail
    {
        public int Id { get; set; }

        public string Img { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
