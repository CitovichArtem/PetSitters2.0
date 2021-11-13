using System;

namespace Petsitters.Domain
{
    public class MyService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public int OwnerUserId { get; set; }
        public User Owner { get; set; }
        public int WorkerUserId { get; set; }
        public User Worker { get; set; }
    }
}
