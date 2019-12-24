using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DTDOrganizer.Models
{
    public class ResourcesRequestModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public ResourceType type { get; set; }

        [DisplayName("Name of resource")]
        public string ResourceName { get; set; }

        [DisplayName("Quantity")]
        [Range(1, 100, ErrorMessage = "Only quantities between 1 and 100 are allowed")]
        public int Qty { get; set; }
        [StringLength(300, ErrorMessage = "Description cannot be longer than 300 characters.")]
        public string Comment { get; set; }

        public bool Urgent { get; set; }
        public bool done { get; set; }
        public string orderDate { get; set; }
        public ResourcesRequestModel(ResourcesRequestViewModel viewModel) {
            type = viewModel.type;
            ResourceName = viewModel.ResourceName;
            Qty = viewModel.Qty;
            Comment = viewModel.Comment;
            Urgent = viewModel.Urgent;
            done = false;
            orderDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
        }
    }
}
