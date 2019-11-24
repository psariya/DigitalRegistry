using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DigitalRegistry.Models
{
    public class Social_Media
    {
        [Key]
        public int Id { get; set; }
        public string Organization { get; set; }
        public string Account { get; set; }
        public string Service_key { get; set; }
        public string Short_description { get; set; }
        public string Long_description { get; set; }
        public string Service_display_name { get; set; }
        public string Service_url { get; set; }
        public string Language { get; set; }
        public List<Agencies> agencies { get; set; }
        public List<Tags> tags { get; set; }
        public string Created_at { get; set; }
        public string Updated_at { get; set; }
    }

    public class All_Social_Media
    {
        public int count_ { get; set; }
        [Key]        
        public int page { get; set; }
        public int page_size { get; set; }
        public int pages { get; set; }
        public List<Social_Media> Results { get; set; }
    }
    public class Agencies
    {
        [Key]
        public int a_id { get; set; }
        public string Name { get; set; }
        public string Info_url { get; set; }
    }
    public class Tags
    {
        [Key]
        public int t_id { get; set; }
        public string Tag_text { get; set; }
    }
 }
