using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace ZooManagementSystem
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public string HealthStatus { get; set; }
        public string FeedingSchedule { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Species: {Species}, Age: {Age}, Health: {HealthStatus}, Feeding: {FeedingSchedule}";
        }
    }

    public class ZooManagement
    {
        private List<Animal> animals = new List<Animal>();
        private int nextId = 1;
        private const string FilePath = "animals.json";

        public void Run()
        {
            if (!Login())
                return;

            LoadFromFile();

            while (true)
            {
                Console.WriteLine("\n--- Zoo Management System ---");
                Console.WriteLine("1. Add Animal");
                Console.WriteLine("2. View All Animals");
                Console.WriteLine("3. Remove Animal");
                Console.WriteLine("4. Search Animals");
                Console.WriteLine("5. Sort Animals");
                Console.WriteLine("6. Save and Exit");
                Console.WriteLine("7. Edit Animal Info");
                Console.WriteLine("8. View Animals by Health Status");
                Console.Write("Select an option (1-8): ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddAnimal();
                        break;
                    case "2":
                        ViewAnimals();
                        break;
                    case "3":
                        RemoveAnimal();
                        break;
                    case "4":
                        SearchAnimals();
                        break;
                    case "5":
                        SortAnimals();
                        break;
                    case "6":
                        SaveToFile();
                        Console.WriteLine("Exiting... Goodbye!");
                        return;
                    case "7":
                        EditAnimal();
                        break;
                    case "8":
                        FilterByHealth();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        private bool Login()
        {
            const string USERNAME = "admin";
            const string ENCODED_PASSWORD = "em9vMTIz"; // "zoo123" base64

            Console.Write("Username: ");
            string user = Console.ReadLine();

            Console.Write("Password: ");
            string pass = Console.ReadLine();
            string encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(pass));

            if (user == USERNAME && encoded == ENCODED_PASSWORD)
            {
                Console.WriteLine("Login successful!");
                return true;
            }

            Console.WriteLine("Invalid credentials. Access denied.");
            return false;
        }

        private void AddAnimal()
        {
            Console.Write("Enter Animal Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Animal Species: ");
            string species = Console.ReadLine();

            Console.Write("Enter Animal Age: ");
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine("Invalid age. Please enter a number.");
                return;
            }

            Console.Write("Enter Animal Health Status (e.g., Healthy, Sick): ");
            string health = Console.ReadLine();

            Console.Write("Enter Feeding Schedule (e.g., 8AM & 6PM): ");
            string feeding = Console.ReadLine();

            Animal animal = new Animal
            {
                Id = nextId++,
                Name = name,
                Species = species,
                Age = age,
                HealthStatus = health,
                FeedingSchedule = feeding
            };

            animals.Add(animal);
            SaveToFile();
            Console.WriteLine("Animal added successfully!");
        }

        private void ViewAnimals()
        {
            Console.WriteLine("\n--- List of Animals ---");

            if (animals.Count == 0)
            {
                Console.WriteLine("No animals in the zoo.");
                return;
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private void RemoveAnimal()
        {
            Console.Write("Enter Animal ID to remove: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            Animal animal = animals.Find(a => a.Id == id);
            if (animal != null)
            {
                animals.Remove(animal);
                SaveToFile();
                Console.WriteLine("Animal removed successfully!");
            }
            else
            {
                Console.WriteLine("Animal with that ID not found.");
            }
        }

        private void SearchAnimals()
        {
            Console.Write("Enter name or species to search: ");
            string query = Console.ReadLine().ToLower();

            var results = animals.FindAll(a =>
                a.Name.ToLower().Contains(query) || a.Species.ToLower().Contains(query));

            if (results.Count == 0)
            {
                Console.WriteLine("No animals found matching the query.");
                return;
            }

            Console.WriteLine("\n--- Search Results ---");
            foreach (var animal in results)
            {
                Console.WriteLine(animal);
            }
        }

        private void SortAnimals()
        {
            Console.WriteLine("Sort by: 1. Age  2. Name");
            string option = Console.ReadLine();

            if (option == "1")
                animals.Sort((a, b) => a.Age.CompareTo(b.Age));
            else if (option == "2")
                animals.Sort((a, b) => a.Name.CompareTo(b.Name));
            else
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            Console.WriteLine("Animals sorted successfully.");
            ViewAnimals();
        }

        private void EditAnimal()
        {
            Console.Write("Enter Animal ID to edit: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            Animal animal = animals.Find(a => a.Id == id);
            if (animal == null)
            {
                Console.WriteLine("Animal not found.");
                return;
            }

            Console.WriteLine($"Editing Animal: {animal}");

            Console.Write("Enter new Health Status (leave blank to keep current): ");
            string newHealth = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newHealth))
                animal.HealthStatus = newHealth;

            Console.Write("Enter new Feeding Schedule (leave blank to keep current): ");
            string newFeeding = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newFeeding))
                animal.FeedingSchedule = newFeeding;

            SaveToFile();
            Console.WriteLine("Animal updated successfully.");
        }

        private void FilterByHealth()
        {
            Console.Write("Enter health status to filter by (e.g., Sick): ");
            string status = Console.ReadLine().ToLower();

            var filtered = animals.FindAll(a => a.HealthStatus?.ToLower() == status);

            if (filtered.Count == 0)
            {
                Console.WriteLine("No animals with that health status.");
                return;
            }

            Console.WriteLine($"\n--- Animals with Health Status: {status} ---");
            foreach (var animal in filtered)
            {
                Console.WriteLine(animal);
            }
        }

        private void SaveToFile()
        {
            var json = JsonSerializer.Serialize(animals);
            File.WriteAllText(FilePath, json);
        }

        private void LoadFromFile()
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                animals = JsonSerializer.Deserialize<List<Animal>>(json) ?? new List<Animal>();
                nextId = animals.Count > 0 ? animals[^1].Id + 1 : 1;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ZooManagement zoo = new ZooManagement();
            zoo.Run();
        }
    }
}
