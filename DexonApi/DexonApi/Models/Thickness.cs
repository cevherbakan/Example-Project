using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DexonApi.Models
{
    public class Thickness
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "int")]
        public int TpId { get; set; }
        [ForeignKey("TpId")]
        public TestPoint TestPoint { get; set; }
        [Column(TypeName = "int")]
        public int TpNumber { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime InspectionDate { get; set; }
        [Column(TypeName = "float")]
        public float ActualThickness { get; set; }
    }
}
