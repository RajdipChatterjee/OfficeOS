using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OfficeOS.Api.Models;

public class TestDocument
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}