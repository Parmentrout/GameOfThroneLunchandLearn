using GameOfThrones.LocalResource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameOfThrones.Models
{
    public class TranslationViewModel
    {
        [Display(Name="Hello", ResourceType = typeof(Resource))]
        public string Hello { get; set; }

        [Display(Name = "Beer", ResourceType = typeof(Resource))]
        public string Beer { get; set; }
    }
}