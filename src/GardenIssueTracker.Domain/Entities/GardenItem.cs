using System;
using System.Collections.Generic;

namespace GardenIssueTracker.Domain.Entities
{
    public class GardenItem
    {
        public int Id { get; set; }
        public Garden Garden { get; set; }
        public int GardenId { get; set; }
        public DateTime DatePlanted { get; set; }
        public PlantVariety PlantVariety { get; set; }
        public int PlantVarietyId { get; set; }
        public IEnumerable<Comment> Comments { get; set; }

        public GardenItem()
        {

            Comments = new HashSet<Comment>();
        }
    }
}