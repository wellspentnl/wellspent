using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ProjectService.Entities
{
    [Table("Tasks")]
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public TaskStatus Status { get; set; }        
        public int ProjectId { get; set; }
        public Project Project { get; set; }


    }
}