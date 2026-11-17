using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OfficeOS.Api.Models
{
    public class Organization
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

    }
}
