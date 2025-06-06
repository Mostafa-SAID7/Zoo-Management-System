using System;

namespace ZooManagementSystem.Models
{
    public class FeedingSchedule
    {
        public string Food { get; set; } = string.Empty; // Default value added to avoid null
        public TimeSpan Time { get; set; }
    }
}
