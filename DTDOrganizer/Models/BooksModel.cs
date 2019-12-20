using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DTDOrganizer.Models
{
    public class BooksModel
    {
        [Key]
        public string isbn { get; set; }
        public string title { get; set; }
        public List<string> authors { get; set; }
        public int pages { get; set; }
        public string description { get; set; }
        public string publisher { get; set; }
        public string publishedDate { get; set; }
        public float rating { get; set; }
        public string imagePath { get; set; }
    }
}