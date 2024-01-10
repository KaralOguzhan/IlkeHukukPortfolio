using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IlkeHukukBurosu.DAL.Entities
{
	public class Blog
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string BlogID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImgUrl { get; set; }
    }
}
