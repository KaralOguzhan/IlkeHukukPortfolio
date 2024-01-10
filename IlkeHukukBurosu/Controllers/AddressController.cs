using IlkeHukukBurosu.DAL.Entities;
using IlkeHukukBurosu.DAL.Settings;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace IlkeHukukBurosu.Controllers
{
    public class AddressController : Controller
    {
        private readonly IMongoCollection<Address> _addressCollection;
        public AddressController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _addressCollection = database.GetCollection<Address>(_databaseSettings.AddressCollectionName);
        }
        public async Task<IActionResult> Index()
        {
            var values = await _addressCollection.Find(x=>true).ToListAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateAddress()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAddress(Address address)
        {
            await _addressCollection.InsertOneAsync(address);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteAddress(string id)
        {
            await _addressCollection.DeleteOneAsync(x => x.AddressID == id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAddress(string id)
        {
            var values = await _addressCollection.Find(x => x.AddressID == id).FirstOrDefaultAsync();
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAddress(Address address)
        {
            await _addressCollection.FindOneAndReplaceAsync(x => x.AddressID == address.AddressID, address);
            return RedirectToAction("Index");
        }


    }
}
