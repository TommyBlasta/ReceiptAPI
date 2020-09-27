using System;
using System.Collections.Generic;

namespace ReceiptAPI.Models
{
    public partial class ProductToReceipt
    {
        public long Product { get; set; }
        public long Receipt { get; set; }
        public long Id { get; set; }
        public double? AppliedSale { get; set; }

        public virtual Product ProductNavigation { get; set; }
        public virtual Receipt ReceiptNavigation { get; set; }
    }
}
