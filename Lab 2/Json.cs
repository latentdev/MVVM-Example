using Lab_2.Models;
using Lab_2.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Json
    {
        public static void SerializeToFile(string path, IEnumerable<FontViewModel> fonts)
        {
            if (Directory.Exists(path))
            {
                path += "settings.json";
                File.WriteAllText(path, JsonConvert.SerializeObject(fonts, Formatting.Indented));
            }
            else
                throw new ArgumentException("Invalid path");
        }

        public static IEnumerable<SavedFont> DeserializeFontsFromFile(string path)
        {
            if (File.Exists(path))
            {
                return JsonConvert.DeserializeObject<IEnumerable<SavedFont>>(File.ReadAllText(path));
            }
            else
                return new List<SavedFont>();
        }
    }
}
