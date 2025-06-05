using System;
using System.Collections.Generic;

namespace ZooManagementSystem
{
    // Animal class definition
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Species: {Species}, Age: {Age}";
        }
    }

    // Zoo Management logic
    public class ZooManagement
    {
        private List<Animal> animals = new List<Animal>();
        private int nextId = 1;

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n--- Zoo Management System ---");
                Console.WriteLine("1. Add Animal");
                Console.WriteLine("2. View All Animals");
                Console.WriteLine("3. Remove Animal");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option (1-4): ");
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
                        Console.WriteLine("Exiting... Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
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

            Animal animal = new Animal
            {
                Id = nextId++,
                Name = name,
                Species = species,
                Age = age
            };

            animals.Add(animal);
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
                Console.WriteLine("Animal removed successfully!");
            }
            else
            {
                Console.WriteLine("Animal with that ID not found.");
            }
        }
    }

    // Main program entry
    class Program
    {
        static void Main(string[] args)
        {
            ZooManagement zoo = new ZooManagement();
            zoo.Run();
        }
    }
}
