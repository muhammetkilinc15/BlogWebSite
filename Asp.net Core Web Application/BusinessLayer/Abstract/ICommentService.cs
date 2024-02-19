using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
        //void addComment(Comment Comment);

        //void removeComment(Comment Comment);

        //Comment getComment(int id);

        //List<Comment> getBlogs();

        //void updateComment(Blog Blog);

        List<Comment> getCommentListWithCategory(int id);

        List<Comment> GetCommentListWithBlog();

    }
}
