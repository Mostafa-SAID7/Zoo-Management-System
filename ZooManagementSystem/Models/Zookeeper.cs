namespace ZooManagementSystem.Models
{
    public class Zookeeper
    {
        public required string Name { get; set; } // Added 'required' modifier
        public string AssignedEnclosure { get; set; } = string.Empty; // Default value retained
    }
}