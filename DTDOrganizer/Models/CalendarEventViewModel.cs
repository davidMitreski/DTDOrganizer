using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DTDOrganizer.Models
{
    public class CalendarEventViewModel
    {
        public string title { get; set; }
        [DataType(DataType.Date)]
        public DateTime startDate { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public string startTime { get; set; }
        [DataType(DataType.Date)]
        public DateTime endDate { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public string endTime { get; set; }
        public eventColor color { get; set; }
        [MaxLength(150)]
        public string description { get; set; }
        public bool allDay { get; set; }
    }

    public enum eventColor { 
        Red, Blue, Aqua, BlueViolet, BurlyWood, DarkOrange, DodgerBlue, Gold, Green, LightGreen, Silver, Yellow
    }
}