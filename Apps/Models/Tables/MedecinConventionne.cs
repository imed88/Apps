using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apps.Models.Tables
{
    public class MedecinConventionne
    {

        [Key]
        public int IdMedConv { get; set; }
        public string NomMedConv { get; set; }
        public string PrenomMedConv { get; set; }
        public string Email { get; set; }
        public string Jours_Usine { get; set; }
        public string PlageHoraire { get; set; }
        public string Honoraire_seance { get; set; }
        public string MobielMedConv { get; set; }

        public int idSpecialite { get; set; }
       

        public virtual Specialites specialites { get; set; }
    }
}
