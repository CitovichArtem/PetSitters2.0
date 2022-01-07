using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Petsitters.Domain
{
    public class Bid
    {
        [Key]
        [ForeignKey("MyService")]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public int MyServiceId { get; set; }
        public int PetId { get; set; }
        public MyService MyService { get; set; }
        public Pet Pet { get; set; }

    }
}
