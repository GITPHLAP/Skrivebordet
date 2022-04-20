using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Skrivebordet
{
    public class ImageHandler
    {
        private const string JsonPath = "imagepaths.json";
        public static ObservableCollection<string> ImagePaths { get; set; } = new();

        public static void Save()
        {
            string json = JsonSerializer.Serialize(ImagePaths.ToList());
            File.WriteAllText(JsonPath, json);
        }

        public static void Load()
        {
            if (File.Exists(JsonPath))
            {
                string json = File.ReadAllText("imagepaths.json");
                var imagePaths =  JsonSerializer.Deserialize<List<string>>(json) 
                    ?? new List<string>();
                ImagePaths = new ObservableCollection<string>(imagePaths);
            }
        }
    }
}
