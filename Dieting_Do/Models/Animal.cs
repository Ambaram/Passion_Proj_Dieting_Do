using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dieting_Do.Models
{
    public class Animal
    {
        [Key]
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
        public int AnimalWeight { get; set; }
        public int AnimalHeight { get; set; }


        // ForeignKey SpeciedId
        [ForeignKey("Species")]
        public int SpeciesId { get; set; }
        public virtual Species Species { get; set; }

    }
    public class AnimalDto
    {
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
        public int AnimalWeight { get; set; }
        public int AnimalHeight { get; set; }
        public string AnimalSpecies { get; set; }
    }
}