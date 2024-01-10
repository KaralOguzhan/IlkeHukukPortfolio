using IlkeHukukBurosu.DAL.Entities;
using IlkeHukukBurosu.DAL.Settings;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace IlkeHukukBurosu.Controllers
{
	public class UIAboutUsController : Controller
	{
		private readonly IMongoCollection<About> _aboutCollection;
		public UIAboutUsController(IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_aboutCollection = database.GetCollection<About>(_databaseSettings.AboutCollectionName);
		}
		
		public async Task<IActionResult> Index()
		{
			var values = await _aboutCollection.Find(x => true).ToListAsync();
			return View(values);
		}
		
	}
}
