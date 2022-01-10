using System;

namespace Petsitters.Domain
{
    public class Feedback
    {
        public Guid Id { get; set; }
        public int Mark { get; set; }
        public string Text { get; set; }
        public Guid OwnerUserId { get; set; }
        public User Owner { get; set; }
        public Guid WorkerUserId { get; set; }
        public User Worker { get; set; }
    }
}
