using IlkeHukukBurosu.DAL.Entities;
using IlkeHukukBurosu.DAL.Settings;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace IlkeHukukBurosu.Controllers
{
    public class BlogController : Controller
    {
        private readonly IMongoCollection<Blog> _blogCollection;
        public BlogController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _blogCollection = database.GetCollection<Blog>(_databaseSettings.BlogCollectionName);
        }
        public async Task<IActionResult> Index()
        {
            var values = await _blogCollection.Find(x=>true).ToListAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateBlog()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(Blog blog)
        {
            await _blogCollection.InsertOneAsync(blog);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteBlog(string id)
        {
            await _blogCollection.DeleteOneAsync(x=>x.BlogID==id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateBlog(string id)
        {
            var values = await _blogCollection.Find(x => x.BlogID == id).FirstOrDefaultAsync();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBlog(Blog blog)
        {
            await _blogCollection.FindOneAndReplaceAsync(x => x.BlogID == blog.BlogID,blog);
            return RedirectToAction("Index");
        }
    }
}
