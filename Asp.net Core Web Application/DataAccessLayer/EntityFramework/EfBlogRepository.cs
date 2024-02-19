using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.Repositories;
using EntityLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
	{
		public List<Blog> GetListWithCategory()
		{
			using (var c = new Context())
			{
				// İnclude metotudunu bloglara ait categoryi çekmek için 
				return c.Blogs.Include(x => x.Category).ToList();
			}
		}

		public List<Blog> GetListWithCategoryByWriter(int writerID)
		{
			using (var c = new Context())
			{
				// İnclude metotudunu bloglara ait categoryi çekmek için 
				return c.Blogs.Include(x => x.Category).Where(x=>x.WriterID==writerID).ToList();
			}
		}
	}
}
