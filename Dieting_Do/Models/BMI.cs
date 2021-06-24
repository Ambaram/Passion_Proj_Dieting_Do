using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dieting_Do.Models
{
    public class BMI
    {
        [Key]
        public int BMIId { get; set; }
        public int AnimalBMI { get; set; }

        

        
        [ForeignKey("Animal")]
        public int AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
    }
    public  class BMIDto
    {
        public int BMIId { get; set; }
        public int AnimalBMI { get; set; }

    }
}