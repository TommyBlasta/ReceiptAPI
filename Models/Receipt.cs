using System;
using System.Collections.Generic;

namespace ReceiptAPI.Models
{
    public partial class Receipt
    {
        public Receipt()
        {
            ProductToReceipt = new HashSet<ProductToReceipt>();
        }

        public long Id { get; set; }
        public long Seller { get; set; }
        public string DateOfPurchase { get; set; }

        public virtual Seller SellerNavigation { get; set; }
        public virtual ICollection<ProductToReceipt> ProductToReceipt { get; set; }
    }
}
