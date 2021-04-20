using System;

namespace Fak3News.Core.Domain
{
    public class Article
    {
        public Guid Id { get; set; }
        public byte[] Content { get; set; }
    }
}
