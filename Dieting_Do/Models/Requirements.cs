using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dieting_Do.Models
{
    public class Requirements
    {
        [Key]
        public int ReqId { get; set; }
        public int Vitamin { get; set; }
        public int Fibre { get; set; }
        public int Protein { get; set; }
        public int Carbs { get; set; }

        
        [ForeignKey("Animal")]
        public int AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
    }
    public class RequirementsDto
    {
        public int ReqId { get; set; }
        public int Vitamin { get; set; }
        public int Fibre { get; set; }
        public int Protein { get; set; }
        public int Carbs { get; set; }
    }
}