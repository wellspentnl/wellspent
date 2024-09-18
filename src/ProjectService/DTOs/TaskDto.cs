using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectService.DTOs
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public TaskStatus Status { get; set; }        
        public int ProjectId { get; set; }
    }
}