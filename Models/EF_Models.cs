using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DigitalRegistry.Models
{
    //public class EF_Models
    //{
    public class Social_Media
    {
        [Key]
        public int id { get; set; }
        public string organization { get; set; }
        public string account { get; set; }
        public string service_key { get; set; }
        public string short_description { get; set; }
        public string long_description { get; set; }
        public string service_display_name { get; set; }
        public string service_url { get; set; }
        public string language { get; set; }
        public List<Agencies> agencies { get; set; }
        public List<Tags> tags { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }

    public class All_Social_Media
    {

        //public Metadata metadata { get; set; }
        public int count_ { get; set; }
        [Key]
        
        public int page { get; set; }
        public int page_size { get; set; }
        public int pages { get; set; }
        public List<Social_Media> results { get; set; }
    }

    /*public class Metadata
    {
        public int count_ { get; set; }
        [Key]
        public int page { get; set; }
        public int page_size { get; set; }
        public int pages { get; set; }
    }*/

    public class Agencies
    {
        [Key]
        public int agencies_id { get; set; }
        public string name { get; set; }
        public string info_url { get; set; }
    }
    public class Tags
    {
        [Key]
        public int tags_id { get; set; }
        public string tag_text { get; set; }
    }
    //}
}
