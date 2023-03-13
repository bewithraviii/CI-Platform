using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProjectsEntity.Models;

namespace MainProjectsEntity.ViewModel
{
    public class MissionCard
    {
        public long MissionId { get; set; }

        public string Title { get; set; } = null!;

        public string? ShortDescription { get; set; }

        public string? Description { get; set; }

        public string? CityName { get; set; }

        public string? Theme { get; set; }

        public string? OrganizationName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? Availability { get; set; }

        public string? GoalObjectiveText { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual ICollection<FavoriteMission> FavoriteMissions { get; } = new List<FavoriteMission>();
    }
}
