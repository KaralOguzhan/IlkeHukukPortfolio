using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IlkeHukukBurosu.DAL.Entities
{
	public class Service
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ServiceID { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public string ImgUrl { get; set; }
    }
}
