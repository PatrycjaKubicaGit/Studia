using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using NBD_SystemZarządzaniaBiblioteką.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class BooksController : Controller
{
    private readonly IMongoCollection<Book> _booksCollection;

    public BooksController(IConfiguration configuration)
    {
        var connectionString = configuration["MongoDBSettings:ConnectionString"];
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase("SystemZarzadzaniaBiblioteka");
        _booksCollection = database.GetCollection<Book>("books");
    }

    public async Task<IActionResult> Index()
    {
        var books = new List<Book>();
        using (var cursor = await _booksCollection.FindAsync(new BsonDocument()))
        {
            while (await cursor.MoveNextAsync())
            {
                var batch = cursor.Current;
                foreach (var document in batch)
                {
                    books.Add(document);
                }
            }
        }

        return View(books);
    }

   
    public IActionResult AddBooks()
    {
        return View();
    }

    
    public async Task<IActionResult> EditBooks(string id)
    {
        var book = await _booksCollection.Find(b => b.Id == new ObjectId(id)).FirstOrDefaultAsync();
        return View(book);
    }

    
    public async Task<IActionResult> DeleteBooks(string id)
    {
        var book = await _booksCollection.Find(b => b.Id == new ObjectId(id)).FirstOrDefaultAsync();
        return View(book);
    }

    
    [HttpPost]
    public async Task<IActionResult> AddBooks(Book book)
    {
        if (ModelState.IsValid)
        {
            await _booksCollection.InsertOneAsync(book);
            return RedirectToAction(nameof(Index));
        }
        return View(book);
    }

    
    [HttpPost]
    public async Task<IActionResult> EditBooks(string id, Book book)
    {
        if (ModelState.IsValid)
        {
            var filter = Builders<Book>.Filter.Eq("_id", new ObjectId(id));
            var update = Builders<Book>.Update
                .Set(b => b.Title, book.Title)
                .Set(b => b.Author, book.Author)
                .Set(b => b.Copies, book.Copies)
                .Set(b => b.Reviews, book.Reviews)
                .Set(b => b.NumberOfCopies, book.NumberOfCopies);

            await _booksCollection.UpdateOneAsync(filter, update);
            return RedirectToAction(nameof(Index));
        }
        return View(book);
    }


    public async Task<IActionResult> Delete(string id)
    {
        var book = await _booksCollection.Find(b => b.Id == new ObjectId(id)).FirstOrDefaultAsync();
        if (book == null)
        {
            return NotFound();
        }
        return View(book);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        await _booksCollection.DeleteOneAsync(b => b.Id == new ObjectId(id));
        return RedirectToAction(nameof(Index));
    }
}
