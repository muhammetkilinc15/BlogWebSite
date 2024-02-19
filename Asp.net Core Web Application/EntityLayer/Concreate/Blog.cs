using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string BlogThumbnailImage { get; set; }
        public string BlogImage { get; set; }
        public string BlogCreateDate { get; set; }
        public bool BlogStatus { get; set; }

        // İlişkili tablolar :D :D: :D
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public int WriterID { get; set; }
        public virtual Writer Writer { get; set; }

    }
}
