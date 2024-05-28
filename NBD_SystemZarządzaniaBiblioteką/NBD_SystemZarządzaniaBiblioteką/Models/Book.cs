using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace NBD_SystemZarządzaniaBiblioteką.Models
{
    public class Book
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("author")]
        public Author Author { get; set; }

        [BsonElement("copies")]
        public List<Copy>? Copies { get; set; }

        [BsonElement("reviews")]
        public List<Review>? Reviews { get; set; }

        [BsonElement("numbersOfCopies")]
        public int NumberOfCopies { get; set; }
    }

    public class Author
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("bio")]
        public string Bio { get; set; }

        [BsonElement("surname")]
        public string? Surname { get; set; }

        [BsonElement("subauthor")]
        public string? Subauthor { get; set; }

        [BsonElement("series")]
        public string? Series { get; set; }

        [BsonElement("publisher")]
        public string? Publisher { get; set; }

        [BsonElement("type")]
        public string? Type { get; set; }

        [BsonElement("pages")]
        public int? Pages { get; set; }
    }


    public class Copy
    {
        [BsonElement("edition")]
        public string Edition { get; set; }

        [BsonElement("year")]
        public int? Year { get; set; }

        [BsonElement("publisher")]
        public string Publisher { get; set; }

        [BsonElement("release-date")]
        public string? ReleaseDate { get; set; }

    }

    public class Review
    {
        [BsonElement("reviewer")]
        public string Reviewer { get; set; }

        [BsonElement("rating")]
        public int Rating { get; set; }

        [BsonElement("comment")]
        public string Comment { get; set; }
    }
}
