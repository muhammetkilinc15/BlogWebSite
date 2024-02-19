using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
	public class Comment
	{
		[Key]
		public int CommentID { get; set; }
		public string CommentUserName { get; set; }
		public string CommentTitle { get; set; }
		public string CommentContent { get; set; }
		public DateTime CommentDate { get; set; }
		public int BlogScore { get; set; }
		public bool CommentStatus { get; set; }

		// İlişki tablo
		public int BlogID { get; set; }
		public virtual Blog Blog { get; set; }


	}
}
