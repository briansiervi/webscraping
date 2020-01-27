using System;
using System.ComponentModel.DataAnnotations;

namespace WebScraping.Models
{
    public class TaxaSelic
    {
        public int ID { get; set; }
        public int Numero { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        public String Vigencia { get; set; }
        public Double Valor { get; set; }
    }
}