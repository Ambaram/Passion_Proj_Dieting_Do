using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dieting_Do.Models
{
    public class Species
    {
        [Key]
        public int SpeciesId { get; set; }
        public string AnimalSpecies { get; set; }
        
    }

    public class SpeciesDto
    {
        public int SpeciesId { get; set; }
        public string AnimalSpecies { get; set; }
    }
}