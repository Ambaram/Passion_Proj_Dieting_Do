using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Dieting_Do.Models
{
    public class Standard_Data
    {
        [Key]
        public int DataId { get; set; }
        public int St_AnimalBMI { get; set; }
        public string Species { get; set; }
        public int St_Protein { get; set; }
        public int St_Carbs { get; set; }
        public int St_Fibre { get; set; }
        public int St_Vitamin { get; set; }
        public int St_Fat { get; set; }
        public int St_No_Of_Meals { get; set; }
        public int St_Meal_Time_Diff { get; set; }
    }
    public class Standard_DataDto
    {
        public int DataId { get; set; }
        public int St_AnimalBMI { get; set; }
        public string Species { get; set; }
        public int St_Protein { get; set; }
        public int St_Carbs { get; set; }
        public int St_Fibre { get; set; }
        public int St_Vitamin { get; set; }
        public int St_Fat { get; set; }
        public int St_No_Of_Meals { get; set; }
        public int St_Meal_Time_Diff { get; set; }
    }
}