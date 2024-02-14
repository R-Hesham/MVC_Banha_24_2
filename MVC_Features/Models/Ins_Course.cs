using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Features.Models
{
    [PrimaryKey("InsId", "CrsId")]
    public class Ins_Course
    {
        [ForeignKey("instructor")]
        public int InsId { get; set; }
        [ForeignKey("course")]
        public int CrsId { get; set; }
        public int Evaluation { get; set; }

        // Navigation Properties
        public Course course { get; set; }
        public Instructor instructor { get; set; }
    }
}
