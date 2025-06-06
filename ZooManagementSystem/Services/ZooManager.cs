using System;
using System.Collections.Generic;
using ZooManagementSystem.Models;

namespace ZooManagementSystem.Services
{
    public class ZooManager
    {
        private List<Enclosure> enclosures;

        public ZooManager()
        {
            enclosures = DataService.LoadZooData();
        }

        public void AddEnclosure(string name, int capacity)
        {
            enclosures.Add(new Enclosure { Name = name, Capacity = capacity });
        }

        public void AddAnimal(string enclosureName, Animal animal)
        {
            var enclosure = enclosures.Find(e => e.Name == enclosureName);
            if (enclosure != null && enclosure.Animals.Count < enclosure.Capacity)
            {
                enclosure.Animals.Add(animal);
                Console.WriteLine($"{animal.Name} added to {enclosureName}.");
            }
            else
            {
                Console.WriteLine("Enclosure not found or is full.");
            }
        }

        public void ListAnimals(string enclosureName)
        {
            var enclosure = enclosures.Find(e => e.Name == enclosureName);
            if (enclosure != null)
            {
                Console.WriteLine($"Animals in {enclosureName}:");
                foreach (var a in enclosure.Animals)
                {
                    Console.WriteLine($"- {a.Name}, {a.Species}, {a.Age} years old");
                }
            }
            else
            {
                Console.WriteLine("Enclosure not found.");
            }
        }

        public void TransferAnimal(string fromEnclosure, string toEnclosure, string animalName)
        {
            var source = enclosures.Find(e => e.Name == fromEnclosure);
            var destination = enclosures.Find(e => e.Name == toEnclosure);

            if (source == null || destination == null)
            {
                Console.WriteLine("One or both enclosures not found.");
                return;
            }

            var animal = source.Animals.Find(a => a.Name == animalName);
            if (animal == null)
            {
                Console.WriteLine("Animal not found in the source enclosure.");
                return;
            }

            if (destination.Animals.Count >= destination.Capacity)
            {
                Console.WriteLine("Destination enclosure is full.");
                return;
            }

            source.Animals.Remove(animal);
            destination.Animals.Add(animal);
            Console.WriteLine($"{animal.Name} transferred from {fromEnclosure} to {toEnclosure}.");
        }

        public void SearchAnimals(string keyword)
        {
            Console.WriteLine($"Search Results for '{keyword}':");
            bool found = false;
            foreach (var enclosure in enclosures)
            {
                foreach (var animal in enclosure.Animals)
                {
                    if (animal.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                        animal.Species.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"- {animal.Name} ({animal.Species}), Age: {animal.Age}, Enclosure: {enclosure.Name}");
                        found = true;
                    }
                }
            }
            if (!found)
            {
                Console.WriteLine("No animals found.");
            }
        }

        // New helper method to find animal by enclosure and name
        public Animal FindAnimal(string enclosureName, string animalName)
        {
            var enclosure = enclosures.Find(e => e.Name == enclosureName);
            return enclosure?.Animals.Find(a => a.Name.Equals(animalName, StringComparison.OrdinalIgnoreCase));
        }

        public List<Enclosure> GetEnclosures() => enclosures;
    }
}
