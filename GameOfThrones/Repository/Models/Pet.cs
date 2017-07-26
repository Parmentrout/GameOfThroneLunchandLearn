using GameOfThrones.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameOfThrones.Repository.Models
{
    public class Pet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PetId { get; set; }

        public PetType PetType { get; set; }

        public string Name { get; set; }

        public int PersonId { get; set; }

        public Person Person { get; set; }
    }
}