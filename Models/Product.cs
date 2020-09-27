using System;
using System.Collections.Generic;

namespace ReceiptAPI.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductToReceipt = new HashSet<ProductToReceipt>();
        }

        public long Id { get; set; }
        public long? Seller { get; set; }
        public string Name { get; set; }
        public byte[] BasePrice { get; set; }

        public virtual ICollection<ProductToReceipt> ProductToReceipt { get; set; }
    }
}
