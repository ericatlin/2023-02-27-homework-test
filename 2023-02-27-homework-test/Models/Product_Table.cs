namespace _2023_02_27_homework_test.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product_Table
    {
        [Key]
        [Column("product-id")]
        public int product_id { get; set; }

        [Column("product-name")]
        [Required]
        [StringLength(50)]
        public string product_name { get; set; }

        [Column("product-quantity")]
        public int product_quantity { get; set; }

        [Column("product-price")]
        public int product_price { get; set; }

        [Column("product-type")]
        [Required]
        [StringLength(50)]
        public string product_type { get; set; }
    }
}
