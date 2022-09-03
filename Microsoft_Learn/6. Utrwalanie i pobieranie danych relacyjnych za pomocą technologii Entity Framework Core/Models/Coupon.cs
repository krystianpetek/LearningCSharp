using System;
using System.Collections.Generic;

namespace ContosoPizzaAPI_NET6_0.Models
{
    public partial class Coupon
    {
        public long Id { get; set; }
        public string Description { get; set; } = null!;
        public DateTime Expiration { get; set; }
    }
}