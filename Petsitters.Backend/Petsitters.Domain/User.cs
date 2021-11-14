using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Petsitters.Domain
{
    public class User
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        [InverseProperty("Worker")]
        public List<Feedback> FeedbacksAboutMe { get; set; }
        [InverseProperty("Owner")]
        public List<Feedback> FeedbacksLeftByMe { get; set; }
    }
}
