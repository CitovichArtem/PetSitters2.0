using System;
using System.Collections.Generic;

namespace Petsitters.Domain
{
    public class Pet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid BidId { get; set; }
        public List<Bid> Bids { get; set; }
    }
}
