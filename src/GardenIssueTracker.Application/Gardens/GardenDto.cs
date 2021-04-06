using GardenIssueTracker.Application.Common.Mapping;
using GardenIssueTracker.Application.GardenItems;
using GardenIssueTracker.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GardenIssueTracker.Application.Gardens
{
    public class GardenDto : IMapFrom<Garden>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public IEnumerable<GardenItemDto> GardenItems { get; set; }

        public GardenDto()
        {
            GardenItems = new List<GardenItemDto>();
        }
    }
}
