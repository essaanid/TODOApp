using System;
using System.ComponentModel.DataAnnotations;

namespace Logiswift.TODOApp.Items
{
    public class CreateItemDto
    {
        [Required]
        [StringLength(ItemConsts.MaxSubjectLength)]
        public string Subject { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public bool Status { get; set; }
    }
}