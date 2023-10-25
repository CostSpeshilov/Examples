using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIleFormats.Csv
{
    internal class CsvManager
    {
        List<Author> _authors = new(100);
        List<Book> _books = new(100);
        public List<Author> LoadAuthor(string path, char separator)
        {
            _authors = new(100);
            using (var file = new StreamReader(path))
            {
                string? line;
                file.ReadLine();
                while ((line = file.ReadLine()) != null)
                {
                    var parts = line.Split(separator);
                    int id = int.Parse(parts[0]);
                    string surname = parts[1];
                    string name = parts[2];
                    _authors.Add(new Author() { Id = id, Surname = surname, Name = name });
                }
            }
            return _authors;
        }

        public List<Book> LoadBooks(string path, char separator)
        {
            _books = new(100);
            using (var file = new StreamReader(path))
            {
                string? line;
                file.ReadLine();
                while ((line = file.ReadLine()) != null)
                {
                    var parts = line.Split(separator);
                    int id = int.Parse(parts[0]);
                    string name = parts[1];
                    int authorId = int.Parse(parts[2]);
                    Author author = _authors.Single(x => x.Id == authorId);
                    _books.Add(new Book() { Id = id, Name = name, Author = author });
                }
            }
            return _books;
        }

        public List<Book> LoadPublishingYears(string path, char separator)
        {
            using (var file = new StreamReader(path))
            {
                string? line;
                file.ReadLine();
                while ((line = file.ReadLine()) != null)
                {
                    var parts = line.Split(separator);
                    int bookId = int.Parse(parts[0]);
                    int year = int.Parse(parts[1]);
                    Book book = _books.Single(x => x.Id == bookId);
                    book.PublishingYears.Add(year);
                }
            }
            return _books;
        }


        public void WriteToCsv(string[] pathes, char separator, List<Book> books)
        {
            string pathToBooks = pathes[0];
            string pathToAuthors = pathes[1];
            string pathToYears = pathes[2];
            using (var file = new StreamWriter(pathToBooks))
            {
                List<string> headers = new List<string>() { nameof(Book.Id), nameof(Book.Name), nameof(Book.Author) };

                file.WriteLine(string.Join(separator, headers));

                foreach (var book in books)
                {
                    string csvLine = string.Join(separator, 
                        new object[] { book.Id, book.Name, book.Author.Id });
                    file.WriteLine(csvLine);
                }
            }

            using (var file = new StreamWriter(pathToAuthors))
            {
                List<string> headers = new List<string>() { nameof(Author.Id), nameof(Author.Name), nameof(Author.Surname) };
                file.WriteLine(string.Join(separator, headers));
                foreach (var author in _authors)
                {
                    string csvLine = string.Join(separator, new object[] { author.Id, author.Name, author.Surname });
                    file.WriteLine(csvLine);
                }
            }

            using (var file = new StreamWriter(pathToYears))
            {
                List<string> headers = new List<string>() { nameof(Book.Id), "Year" };
                file.WriteLine(string.Join(separator, headers));
                foreach (var book in books)
                {
                    foreach (var year in book.PublishingYears)
                    {
                        string csvLine = string.Join(separator, new object[] { book.Id, year });
                        file.WriteLine(csvLine);
                    }
                }
            }
        }
    }
}
