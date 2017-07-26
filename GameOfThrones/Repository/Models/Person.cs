using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameOfThrones.Repository.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        public bool IsAlive { get; set; }

        public int HouseId { get; set; }

        public virtual House House { get; set; }

        public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
    }
}