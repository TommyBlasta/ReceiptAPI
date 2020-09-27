using System;
using System.Collections.Generic;

namespace ReceiptAPI.Models
{
    public partial class Seller
    {
        public Seller()
        {
            Receipt = new HashSet<Receipt>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Receipt> Receipt { get; set; }
    }
}
