using System;
using System.ComponentModel.DataAnnotations;

namespace Logiswift.TODOApp.Items
{
    public class UpdateItemDto
    {
        [Required]
        [StringLength(ItemConsts.MaxSubjectLength)]
        public string Subject { get; set; }

        [Required]
        [StringLength(ItemConsts.MaxSubjectLength)]
        public string UserId { get; set; }

        public bool Status { get; set; }

    }
}
