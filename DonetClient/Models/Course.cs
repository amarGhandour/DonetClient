using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DonetClient.Models
{
    public class Course
    {
        
        public int id { get; set; }

        public string courseName { get; set; }

        public int duration { get; set; }

        public string description { get; set; }

        public int topicId {get; set; }

        public string? topicName { get; set; }
    }
}
