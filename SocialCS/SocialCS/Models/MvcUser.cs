using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialCS.Models
{
    public class MvcUser
    {
        public MvcUser(){
            this.MvcComments = new HashSet<MvcComments>();
            this.MvcArticles = new HashSet<MvcArticles>();
        }
        [Key]
        public int UserID { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public int Age { get; set; }
        public DateTime Timestamp { get; set; }

        public ICollection<MvcComments> MvcComments { get; set; }
        public ICollection<MvcArticles> MvcArticles { get; set; }
    }
}
