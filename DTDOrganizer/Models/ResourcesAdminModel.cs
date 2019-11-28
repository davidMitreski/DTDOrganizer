using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DTDOrganizer.Models
{
    public class ResourcesAdminModel
    {
        [Key]
        public int Id { get; set; }
        public ResourceType Type { get; set; }
        public String Name { get; set; }
        [StringLength(150, ErrorMessage = "Description cannot be longer than 40 characters.")]
        public String Description { get; set; }
        public string Image { get; set; }
    }
}