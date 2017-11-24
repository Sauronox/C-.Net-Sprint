using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialCS.Models
{
    public class MvcArticles
    {
        public MvcArticles(){
            this.MvcComments = new HashSet<MvcComments>();
        }
        [Key]
        public int ArticlesID { get; set; }
        public String Title { get; set; }
        public String Author { get; set; }
        public DateTime Timestamp { get; set; }
        public String Text { get; set; }
        public Nullable<int> UserID { get; set; }

        public virtual MvcUser MvcUser { get; set; }
        public ICollection<MvcComments> MvcComments { get; set; }

    }
}
