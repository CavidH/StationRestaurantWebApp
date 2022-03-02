using System;

namespace Core.Entities
{
    public class About
    {
        public int  Id { get; set; }
        public string Title { get; set; }
        public string Head { get; set; }
        public string Content { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
