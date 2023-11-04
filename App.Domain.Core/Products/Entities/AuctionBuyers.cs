using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.Entities
{
    public partial class AuctionBuyers
    {
        public int Id { get; set; }

        public int AuctionId { get; set; }

        public float SuggestedPrice { get; set; }

        public DateTime AttendanceDate { get; set; }

        public bool IsCanceled { get; set; }

        public virtual Auction Auction { get; set; } = null!;
    }
}
