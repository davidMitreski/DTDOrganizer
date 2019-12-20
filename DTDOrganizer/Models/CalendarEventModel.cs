using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DTDOrganizer.Models
{
    public class CalendarEventModel
    {
        [Key]
        public int id { get; set; }
        [MaxLength(50)]
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string color { get; set; }
        [MaxLength(150)]
        public string description { get; set; }
        public bool allDay { get; set; }
    }
}