// See https://aka.ms/new-console-template for more information
using FIleFormats.Csv;
using FIleFormats.Json;
using FIleFormats.Xml;

Console.WriteLine("csv");

var csvManager = new CsvManager();
var authors = csvManager.LoadAuthor("Csv/Authors.csv", ';');
foreach (var author in authors)
    Console.WriteLine($"{author.Id}. Полное имя = {author.Name} {author.Surname}");

Console.WriteLine();

var books = csvManager.LoadBooks("Csv/Books.csv", ',');
foreach (var book in books)
    Console.WriteLine($"{book.Id}. Название: {book.Name}. Автор: {book.Author.Name} {book.Author.Surname}.");

Console.WriteLine();

books = csvManager.LoadPublishingYears("Csv/PublishingYears.csv", '@');

WriteBooksOnConsole(books);


csvManager.WriteToCsv(new string[] { "books.csv", "authors.csv", "years.csv" }, ';', books);

Console.WriteLine();
Console.WriteLine("xml");
Console.WriteLine();

XmlManager xmlManager = new XmlManager();
//xmlManager.WriteBooks("books.xml", books);

var xmlBooks = xmlManager.LoadBooks("Xml/books.xml");
WriteBooksOnConsole(xmlBooks);



Console.WriteLine();
Console.WriteLine("json");
Console.WriteLine();

JsonManager jsonManager = new JsonManager();
jsonManager.WriteBooks("books.json", books);

var jsonBooks = jsonManager.LoadBooks("Json/books.json");
WriteBooksOnConsole(jsonBooks);

Console.ReadLine();

static void WriteBooksOnConsole(List<FIleFormats.Book> books)
{
    foreach (var book in books)
        Console.WriteLine($@"{book.Id}. Название: {book.Name}. 
        Автор: {book.Author.Name} {book.Author.Surname}.
        Опубликовано в {string.Join(", ", book.PublishingYears)}");
}