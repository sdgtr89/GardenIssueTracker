using System.Collections.Generic;

namespace GardenIssueTracker.Application.GardenItems
{
    public class GardenItemsVm
    {
        public IEnumerable<GardenItemDto> GardenItems { get; set; }
    }
}
