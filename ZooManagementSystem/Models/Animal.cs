using System;
using System.Collections.Generic;

namespace ZooManagementSystem.Models
{
    public class Animal
    {
        public required string Name { get; set; }
        public required string Species { get; set; }
        public int Age { get; set; }
        public FeedingSchedule FeedingSchedule { get; set; } = new FeedingSchedule();
        public List<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
    }
}