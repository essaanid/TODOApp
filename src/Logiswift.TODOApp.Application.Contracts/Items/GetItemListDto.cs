using System;
using Volo.Abp.Application.Dtos;

namespace Logiswift.TODOApp.Items
{
    public class GetItemListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public Guid UserId { get; set; }
    }
}
