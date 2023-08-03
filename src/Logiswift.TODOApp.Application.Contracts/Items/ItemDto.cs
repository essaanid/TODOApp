using System;
using Volo.Abp.Application.Dtos;

namespace Logiswift.TODOApp.Items
{
    public class ItemDto : EntityDto<Guid>
    {
        public string Subject { get; set; }
        public bool IsDone { get; set; }
        public string AssigneeName { get; set; }
        public Guid AssigneeId { get; set; }

    }
}