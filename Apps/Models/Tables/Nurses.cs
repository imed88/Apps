using System;
using System.ComponentModel.DataAnnotations;

namespace Apps.Models.Tables
{
	public class Nurses
    {
        [Key]
        public int idNurse { get; set; }
        public string nameNurse { get; set; }
        public string emailNurse { get; set; }
		public string passwordNurse { get; set; }
		public string phoneNurse { get; set; }
        public DateTime created { get; set; }
    }
}