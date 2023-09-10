using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DexonApi.Models
{
    public class TestPoint
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "int")]
        public int CmlId { get; set; }
        [ForeignKey("CmlId")]
        public Cml Cml { get; set; }
        [Column(TypeName = "int")]
        public int CmlNumber { get; set; }
        [Column(TypeName = "int")]
        public int TpNumber { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string TpDescription { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string Note { get; set; }
    }
}
