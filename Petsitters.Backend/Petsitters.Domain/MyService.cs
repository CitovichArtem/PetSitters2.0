using System;
using System.Collections.Generic;

namespace Petsitters.Domain
{
    public class MyService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public int UserId { get; set; }
        public User Worker { get; set; }
        public List<Bid> Bids { get; set; }
    }
}
