using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IlkeHukukBurosu.DAL.Entities
{
	public class About
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AboutID { get; set; }
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public string ImgUrl { get; set; }
    }
}
