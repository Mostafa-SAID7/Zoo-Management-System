using System.Collections.Generic;

namespace ZooManagementSystem.Models
{
    public class Enclosure
    {
        public string Name { get; set; } = string.Empty; // Initialize with a default value
        public int Capacity { get; set; }
        public List<Animal> Animals { get; set; } = new List<Animal>();
    }
}