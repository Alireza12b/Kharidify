using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Products.DTOs
{
    public class AuctionBuyersInputDto
    {
        public int Id { get; set; }

        public int AuctionId { get; set; }

        public float SuggestedPrice { get; set; }

        public DateTime AttendanceDate { get; set; }

        public bool IsCanceled { get; set; }
    }

    public class AuctionBuyersOutputDto
    {
        public int Id { get; set; }

        public int AuctionId { get; set; }

        public float SuggestedPrice { get; set; }

        public DateTime AttendanceDate { get; set; }

        public bool IsCanceled { get; set; }
    }
}
