using IlkeHukukBurosu.DAL.Entities;
using IlkeHukukBurosu.DAL.Settings;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace IlkeHukukBurosu.Controllers
{
	public class UIServiceController : Controller
	{
		private readonly IMongoCollection<Service> _serviceCollection;
		public UIServiceController(IDatabaseSettings _databaseSettings)
		{
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.DatabaseName);
			_serviceCollection = database.GetCollection<Service>(_databaseSettings.ServiceCollectionName);
		}
		public async Task<IActionResult> Index()
		{
			var values = await _serviceCollection.Find(x=>true).ToListAsync();
			return View(values);
		}
	}
}
