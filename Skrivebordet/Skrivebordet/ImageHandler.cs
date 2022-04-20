using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Skrivebordet
{
    public class ImageHandler
    {
        private static int currentImgIndex = 0;
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

        public static string GetNextImagePath()
        {
            if (ImagePaths.Count > 0)
            {
                currentImgIndex = (currentImgIndex + 1) % ImagePaths.Count;
                return ImagePaths[currentImgIndex];
            }
            return string.Empty;
        }
    }
}
