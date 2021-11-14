using System;
using System.Collections.Generic;

namespace Petsitters.Domain
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BidId { get; set; }
        public List<Bid> Bids { get; set; }
    }
}
