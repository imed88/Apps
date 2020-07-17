using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apps.Models.Tables
{
    public class Patients
    {
        [Key]
        public int idPatients { get; set; }
        public string namePatients { get; set; }
        public string phonePatients { get; set; }
        public int gender { get; set; }
        public string health_condition { get; set; }
        public int doctor_id { get; set; }
        public int nurse_id { get; set; }
        public DateTime created { get; set; }
    }
}
