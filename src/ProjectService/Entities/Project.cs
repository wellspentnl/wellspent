using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectService.Entities
{
    public class Project
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Location { get; set; }
    
        public List<Task> Tasks { get; set; } = new List<Task>();
        // // Foreign key to the User who created the project
        // public int CreatedById { get; set; }

        // // Navigation property to the User who created the project
        // public User CreatedBy { get; set; }

        // // Navigation property to the list of tasks under this project
        // public ICollection<Task> Tasks { get; set; }

        // // Navigation property to the volunteers signed up for this project
        // public ICollection<Volunteer> Volunteers { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
    }
}
