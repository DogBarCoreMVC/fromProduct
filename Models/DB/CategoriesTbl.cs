using System;
using System.Collections.Generic;

#nullable disable

namespace fromProduct.Models.DB
{
    public partial class CategoriesTbl
    {
        public CategoriesTbl()
        {
            ProductsTbls = new HashSet<ProductsTbl>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<ProductsTbl> ProductsTbls { get; set; }
    }
}
