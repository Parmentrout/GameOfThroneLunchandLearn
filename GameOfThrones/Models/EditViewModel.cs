using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameOfThrones.Models
{
    public class EditViewModel
    {
        [Display(Name = "Pet Name:  ")]
        [Required]
        public string PetName { get; set; }

        [Display(Name = "Pet Type:  ")]
        [Required]
        public string SelectedPetType { get; set; }

        public IEnumerable<SelectListItem> PetTypes => new List<SelectListItem>()
        {
            new SelectListItem() {Text = "Direwolf", Value = "Direwolf"},
            new SelectListItem() {Text = "Dragon", Value = "Dragon"},
            new SelectListItem() {Text = "Cat", Value = "Cat"}
        };

        [Display(Name = "Select Person:  ")]
        [Required]
        public int SelectedPerson { get; set; }

        public IEnumerable<SelectListItem> People { get; set; }
    }
}