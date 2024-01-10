namespace IlkeHukukBurosu.DAL.Settings
{
	public class DatabaseSettings : IDatabaseSettings
	{
		public string ConnectionString { get; set; }
		public string DatabaseName { get; set; }
		public string AboutCollectionName { get; set; }
		public string AddressCollectionName { get; set; }
		public string BlogCollectionName { get; set; }
		public string ContactCollectionName { get; set; }
		public string ServiceCollectionName { get; set; }
	}
}
