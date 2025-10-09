using Grocery.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Grocery.Core.Models
{
    public class ProductCategory : Category
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        public ProductCategory(int id, int productid, int categoryId) : this(id, default!, productid, categoryId) { }

        public ProductCategory(int id, string name, int productId, int categoryId) : base(id, name)
        {
            ProductId = productId;
            CategoryId = categoryId;
        }
    }
}





