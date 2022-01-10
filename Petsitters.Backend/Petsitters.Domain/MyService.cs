using System;

namespace Petsitters.Domain
{
    public class MyService
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public Guid UserId { get; set; }
        public User Worker { get; set; }
        public Guid BidId { get; set; }
        public Bid Bid { get; set; }
    }
}
