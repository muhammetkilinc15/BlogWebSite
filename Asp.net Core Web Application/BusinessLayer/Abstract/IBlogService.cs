using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        List<Blog> GetBlogById(int id);
        List<Blog> getBlogListWithCategory();

        List<Blog> GetBlogListWriter(int id);


    }
}
