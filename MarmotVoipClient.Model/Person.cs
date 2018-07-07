﻿using System.ComponentModel.DataAnnotations;

namespace MarmotVoipClient.Model
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }
    }
}
