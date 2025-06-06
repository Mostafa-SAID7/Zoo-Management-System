using Xunit;
using ZooManagementSystem.Models;

namespace ZooManagementSystem.Tests
{
    public class AnimalTests
    {
        [Fact]
        public void Animal_ToString_ReturnsFormattedString()
        {
            var animal = new Animal
            {
                Id = 1,
                Name = "Leo",
                Species = "Lion",
                Age = 5,
                HealthStatus = "Healthy",
                FeedingSchedule = "8AM & 5PM"
            };

            string result = animal.ToString();
            Assert.Contains("Leo", result);
            Assert.Contains("Lion", result);
        }
    }
}
