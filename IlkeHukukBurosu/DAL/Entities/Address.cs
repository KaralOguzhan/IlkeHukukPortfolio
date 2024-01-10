using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IlkeHukukBurosu.DAL.Entities
{
	public class Address
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AddressID { get; set; }
        public string Phone { get; set; }
        public string AddressDef { get; set; }
        public string Email { get; set; }
        public string Linkedin { get; set; }
        public string OfficeName { get; set; }
    }
}
