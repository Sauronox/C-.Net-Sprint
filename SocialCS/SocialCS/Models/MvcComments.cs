using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialCS.Models
{
    public class MvcComments
    {
        [Key]
        public int CommentsID { get; set; }
        public String Title { get; set; }
        public String Author { get; set; }
        public DateTime Timestamp { get; set; }
        public String Text { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> ArtilcesID { get; set; }

        public virtual MvcUser MvcUser { get; set; }
        public virtual MvcArticles MvcArticles { get; set; }
    }
}
