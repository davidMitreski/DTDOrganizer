using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DTDOrganizer.Models
{
    public class ResourcesRequestViewModel
    {
        public ResourceType type { get; set; }

        [DisplayName("Name of resource")]
        public string ResourceName { get; set; }

        [DisplayName("Quantity")]
        [Range(1, 100, ErrorMessage = "Only quantities between 1 and 100 are allowed")]
        public int Qty { get; set; }
        [StringLength(300, ErrorMessage = "Description cannot be longer than 300 characters.")]
        public string Comment { get; set; }

        public bool Urgent { get; set; }
    }

    public enum ResourceType
    {
        Office, WorkMaterials,Utilities
    }
}