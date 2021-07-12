using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dieting_Do.Models.ViewModels
{
    public class AnimalRequirement
    {
        public AnimalDto SelectedAnimal { get; set; }
        public St_Dto SelectedStandard { get; set; }
        public SpeciesDto SelectedSpecies { get; set; }
    }
}