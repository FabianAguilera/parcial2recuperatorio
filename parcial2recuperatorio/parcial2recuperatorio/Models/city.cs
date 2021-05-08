using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace parcial2recuperatorio.Models
{
    public class city
    {
        [Key]
        public string Name { get; set; }
        public string Capital { get; set; }
        public string Population { get; set; }
        public List<string> Timezones { get; set; }
        public List<decimal> Currencies { get; set; }
       
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}",ApplyFormatInEditMode=true)]
        public DateTime  Birthay { get; set; }


    }
}