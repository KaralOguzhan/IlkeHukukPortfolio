using IlkeHukukBurosu.DAL.Entities;
using IlkeHukukBurosu.DAL.Settings;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace IlkeHukukBurosu.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMongoCollection<Contact> _contactsCollection;
        public ContactController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _contactsCollection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);
        }
        public async Task<IActionResult> Index()
        {
            var values = await _contactsCollection.Find(x=>true).ToListAsync();
            return View(values);
        }
        public async Task<IActionResult> DeleteContact(string id)
        {
            await _contactsCollection.DeleteOneAsync(x=>x.ContactID==id);
            return RedirectToAction("Index");
        }
        
    }
}
