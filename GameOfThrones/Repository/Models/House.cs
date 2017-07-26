
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameOfThrones.Repository.Models
{
    public class House
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HouseId { get; set; }

        [StringLength(20)]
        public string HouseName { get; set; }

        [StringLength(30)]
        public string Location { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}