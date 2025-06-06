using System;
using ZooManagementSystem.Models;

namespace ZooManagementSystem.Services
{
    public class MenuService
    {
        private readonly ZooManager zoo;

        public MenuService(ZooManager zoo)
        {
            this.zoo = zoo;
        }

        public void ShowMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Zoo Management System ===");
                Console.WriteLine("1. Add Enclosure");
                Console.WriteLine("2. Add Animal");
                Console.WriteLine("3. View Animals");
                Console.WriteLine("4. Transfer Animal");
                Console.WriteLine("5. Search Animals");
                Console.WriteLine("6. Manage Medical Records");
                Console.WriteLine("7. Manage Feeding Schedule");
                Console.WriteLine("8. Save & Exit");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddEnclosure(); break;
                    case "2": AddAnimal(); break;
                    case "3": ViewAnimals(); break;
                    case "4": TransferAnimal(); break;
                    case "5": SearchAnimals(); break;
                    case "6": ManageMedicalRecords(); break;
                    case "7": ManageFeedingSchedule(); break;
                    case "8":
                        DataService.SaveZooData(zoo.GetEnclosures());
                        return;
                    default: Console.WriteLine("Invalid!"); break;
                }

                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }

        private void AddEnclosure()
        {
            Console.Write("Enter enclosure name: ");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Invalid enclosure name. Please enter a non-empty name.");
                return;
            }

            Console.Write("Enter capacity: ");
            var capInput = Console.ReadLine();

            if (int.TryParse(capInput, out var cap))
            {
                zoo.AddEnclosure(name, cap);
            }
            else
            {
                Console.WriteLine("Invalid capacity. Please enter a valid number.");
            }
        }

        private void AddAnimal()
        {
            Console.Write("Enter enclosure name: ");
            var enc = Console.ReadLine();
            Console.Write("Animal name: ");
            var name = Console.ReadLine();
            Console.Write("Species: ");
            var species = Console.ReadLine();
            Console.Write("Age: ");
            var ageInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(species))
            {
                Console.WriteLine("Invalid input. Name and species cannot be empty.");
                return;
            }

            if (int.TryParse(ageInput, out var age))
            {
                var animal = new Animal
                {
                    Name = name,
                    Species = species,
                    Age = age,
                    FeedingSchedule = new FeedingSchedule(),
                    MedicalRecords = new List<MedicalRecord>()
                };
                zoo.AddAnimal(enc, animal);
            }
            else
            {
                Console.WriteLine("Invalid age. Please enter a valid number.");
            }
        }

        private void ViewAnimals()
        {
            Console.Write("Enclosure name: ");
            var enc = Console.ReadLine();
            zoo.ListAnimals(enc);
        }

        private void TransferAnimal()
        {
            Console.Write("Enter source enclosure name: ");
            var from = Console.ReadLine();
            Console.Write("Enter destination enclosure name: ");
            var to = Console.ReadLine();
            Console.Write("Enter animal name: ");
            var name = Console.ReadLine();
            zoo.TransferAnimal(from, to, name);
        }

        private void SearchAnimals()
        {
            Console.Write("Enter name or species to search: ");
            var keyword = Console.ReadLine();
            zoo.SearchAnimals(keyword);
        }

        private void ManageMedicalRecords()
        {
            Console.Write("Enter enclosure name: ");
            var enc = Console.ReadLine();
            Console.Write("Enter animal name: ");
            var animalName = Console.ReadLine();

            var animal = zoo.FindAnimal(enc, animalName);
            if (animal == null)
            {
                Console.WriteLine("Animal not found.");
                return;
            }

            Console.WriteLine("1. View Medical Records");
            Console.WriteLine("2. Add Medical Record");
            Console.Write("Choose an option: ");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                if (animal.MedicalRecords.Count == 0)
                {
                    Console.WriteLine("No medical records found.");
                    return;
                }
                Console.WriteLine($"Medical Records for {animal.Name}:");
                foreach (var record in animal.MedicalRecords)
                {
                    Console.WriteLine($"Date: {record.Date.ToShortDateString()}, Diagnosis: {record.Diagnosis}, Treatment: {record.Treatment}");
                }
            }
            else if (choice == "2")
            {
                Console.Write("Enter diagnosis: ");
                var diagnosis = Console.ReadLine();
                Console.Write("Enter treatment: ");
                var treatment = Console.ReadLine();

                var record = new MedicalRecord
                {
                    Date = DateTime.Now,
                    Diagnosis = diagnosis,
                    Treatment = treatment
                };
                animal.MedicalRecords.Add(record);
                Console.WriteLine("Medical record added.");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        private void ManageFeedingSchedule()
        {
            Console.Write("Enter enclosure name: ");
            var enc = Console.ReadLine();
            Console.Write("Enter animal name: ");
            var animalName = Console.ReadLine();

            var animal = zoo.FindAnimal(enc, animalName);
            if (animal == null)
            {
                Console.WriteLine("Animal not found.");
                return;
            }

            Console.WriteLine($"Current feeding schedule: Food = {animal.FeedingSchedule.Food ?? "(none)"}, Time = {animal.FeedingSchedule.Time}");
            Console.Write("Enter food type: ");
            var food = Console.ReadLine();
            Console.Write("Enter feeding time (HH:mm): ");
            var timeInput = Console.ReadLine();

            if (TimeSpan.TryParse(timeInput, out var time))
            {
                animal.FeedingSchedule.Food = food;
                animal.FeedingSchedule.Time = time;
                Console.WriteLine("Feeding schedule updated.");
            }
            else
            {
                Console.WriteLine("Invalid time format.");
            }
        }
    }
}
