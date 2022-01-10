using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Petsitters.Domain
{
    public class Bid
    {
        [Key]
        [ForeignKey("MyService")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public Guid MyServiceId { get; set; }
        public Guid PetId { get; set; }
        public MyService MyService { get; set; }
        public Pet Pet { get; set; }

    }
}
