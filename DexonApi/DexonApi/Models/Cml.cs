using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DexonApi.Models
{
    public class Cml
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        public int InfoId { get; set; }

        [ForeignKey("InfoId")]
        public Info Info { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string LineNumber { get; set; }

        [Column(TypeName = "int")]
        public int CmlNumber { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string CmlDescription { get; set; }

        [Column(TypeName = "float")]
        public float ActualOutsideDiameter { get; set; }

        [Column(TypeName = "float")]
        public float DesignThickness { get; set; }

        [Column(TypeName = "float")]
        public float StructuralThickness { get; set; }

        [Column(TypeName = "float")]
        public float RequiredThickness { get; set; }
    }
}
