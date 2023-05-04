using System.ComponentModel.DataAnnotations;

namespace DonetClient.Models
{
    public class Topic
    {
        [Key]
        public int id { get; set; }

   
        public string title { get; set; }

       
        public HashSet<string> Courses { get; set;} = new HashSet<string>();



    }
}
