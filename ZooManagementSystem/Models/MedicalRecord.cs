using System;

namespace ZooManagementSystem.Models
{
    public class MedicalRecord
    {
        public DateTime Date { get; set; }
        public required string Diagnosis { get; set; }
        public required string Treatment { get; set; }
    }
}