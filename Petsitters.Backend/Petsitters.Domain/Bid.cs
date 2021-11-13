using System;

namespace Petsitters.Domain
{
    public class Bid
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public int MyServiceId { get; set; }
        public int PetId { get; set; }
        public MyService MyService { get; set; }
        public Pet Pet { get; set; }

    }
}
