using System;

namespace Domain.Models
{
    public class Article
    {
        public Guid Id { get; set; }
        public byte[] Content { get; set; }
    }
}
