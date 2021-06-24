using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dieting_Do.Models
{
    public class Feed_Schedule
    {
        [Key]
        public int SchedId { get; set; }
        public int No_Of_Meals { get; set; }
        public int Meal_Time_Diff { get; set; }
      
        
        [ForeignKey("Animal")]
        public int AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
    }
    public class Feed_ScheduleDto
    {
        public int SchedId { get; set; }
        public int No_Of_Meals { get; set; }
        public int Meal_Time_Diff { get; set; }
    }
}