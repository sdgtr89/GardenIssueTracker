using GardenIssueTracker.Application.Comments;
using GardenIssueTracker.Application.Common.Mapping;
using GardenIssueTracker.Application.PlantVarieties;
using GardenIssueTracker.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GardenIssueTracker.Application.GardenItems
{
    public class GardenItemDto : IMapFrom<GardenItem>
    {
        public int Id { get; set; }
        public int GardenId { get; set; }
        public DateTime DatePlanted { get; set; }
        public PlantVarietyDto PlantVariety { get; set; }
        public int PlantVarietyId { get; set; }
        public List<CommentDto> Comments { get; set; }

        public GardenItemDto()
        {
            Comments = new List<CommentDto>();
        }
    }
}
