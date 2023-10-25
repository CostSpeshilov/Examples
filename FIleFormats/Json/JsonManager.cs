using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FIleFormats.Json
{
    internal class JsonManager
    {
        public void WriteBooks(string path, List<Book> books)
        {
            using FileStream stream = new FileStream(path, FileMode.Create);


            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };


            JsonSerializer.Serialize(stream, books, typeof(List<Book>), options);            
        }



        public List<Book> LoadBooks(string path)
        {
            using FileStream stream = new FileStream(path, FileMode.Open);

            var result = JsonSerializer.Deserialize<List<Book>>(stream);
            return result;
        }
    }
}
