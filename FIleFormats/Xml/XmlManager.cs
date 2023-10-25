using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FIleFormats.Xml
{
    internal class XmlManager
    {
        public void WriteBooks(string path, List<Book> books)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
            using (StreamWriter stream = new StreamWriter(path))
            {
                serializer.Serialize(stream, books);
            }
        }



        public List<Book> LoadBooks(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
            using FileStream stream = new FileStream(path, FileMode.Open);

            var result = (List<Book>) serializer.Deserialize(stream);
            return result;
        }
    }
}
