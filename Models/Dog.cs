using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ATHEMIwebsite.Models
{
    public class Dog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? DogId { get; set; }

        [BsonElement("Name")]
        [Required]
        public string Name { get; set; } = string.Empty;


        public string Description { get; set; } = string.Empty;
    }
}
