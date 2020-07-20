using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apps.Models.Tables
{
    public class Specialites
    {
        [Key]
        public int idSpecialite { get; set; }
        public string nameSpecialite { get; set; }
    }
}
