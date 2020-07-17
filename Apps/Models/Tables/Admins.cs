using System;
using System.ComponentModel.DataAnnotations;

namespace Apps.Models.Tables
{
    public class Admins
    {
        [Key]
        public int idAdmin { get; set; }
        public string nameAdmin { get; set; }
        public string emailAdmin { get; set; }
		public string passwordAdmin { get; set; }
		public string phoneAdmin { get; set; }
        public DateTime created { get; set; }
    }
	
}