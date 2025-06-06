using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using ZooManagementSystem.Models;

namespace ZooManagementSystem.Services
{
    public static class DataService
    {
        private const string FilePath = "Data/zoo_data.json";

        public static List<Enclosure> LoadZooData()
        {
            if (!File.Exists(FilePath)) return new();
            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Enclosure>>(json) ?? new();
        }

        public static void SaveZooData(List<Enclosure> enclosures)
        {
            var json = JsonSerializer.Serialize(enclosures, new JsonSerializerOptions { WriteIndented = true });
            Directory.CreateDirectory("Data");
            File.WriteAllText(FilePath, json);
        }
    }
}