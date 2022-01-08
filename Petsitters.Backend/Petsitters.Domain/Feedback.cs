using System;

namespace Petsitters.Domain
{
    public class Feedback
    {
        public int Id { get; set; }
        public int Mark { get; set; }
        public string Text { get; set; }
        public int OwnerUserId { get; set; }
        public User Owner { get; set; }
        public int WorkerUserId { get; set; }
        public User Worker { get; set; }
    }
}
