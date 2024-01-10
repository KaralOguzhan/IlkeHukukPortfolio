using IlkeHukukBurosu.DAL.Entities;
using IlkeHukukBurosu.DAL.Settings;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace IlkeHukukBurosu.Controllers
{
    public class UIMessageController : Controller
    {
        private readonly IMongoCollection<Contact> _contactsCollection;
		public UIMessageController(IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_contactsCollection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(Contact contact)
        {
			await _contactsCollection.InsertOneAsync(contact);
            return RedirectToAction("Index");
        }
		public IActionResult actionResult()
		{
			return View();
		}
    }
}
