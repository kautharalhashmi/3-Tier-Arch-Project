using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Entities
{
    // This file defines the Product entity which represents a product in the database.
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public double Price { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
