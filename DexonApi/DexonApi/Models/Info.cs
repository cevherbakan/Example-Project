using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DexonApi.Models
{
 
    public class Info
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string LineNumber { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string Location { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string From { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string To { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string DrawingNumber { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string Service { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string Material { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime InserviceDate { get; set; }
        [Column(TypeName = "float")]
        public float PipeSize { get; set; }
        [Column(TypeName = "float")]
        public float OriginalThickness { get; set; }
        [Column(TypeName = "float")]
        public float Stress { get; set; }
        [Column(TypeName = "float")]
        public float JointEfficiency { get; set; }
        [Column(TypeName = "float")]
        public float Ca { get; set; }
        [Column(TypeName = "float")]
        public float DesignLife { get; set; }
        [Column(TypeName = "float")]
        public float DesignPressure { get; set; }
        [Column(TypeName = "float")]
        public float OperatingPressure { get; set; }
        [Column(TypeName = "float")]
        public float DesignTemperature { get; set; }
        [Column(TypeName = "float")]
        public float OperatingTemperature { get; set; }
    }
}
