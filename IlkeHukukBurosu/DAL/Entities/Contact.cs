using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IlkeHukukBurosu.DAL.Entities
{
	public class Contact
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ContactID { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Text { get; set; }
    }
}
