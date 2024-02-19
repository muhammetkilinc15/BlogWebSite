using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;
        public BlogManager(IBlogDal dal)
        {
            _blogDal = dal;
        }


        public List<Blog> GetBlogListWriter(int id)
        {
            return _blogDal.GetListAll(x => x.WriterID == id);
        }

        public List<Blog> GetLast3Blog()
        {
            return _blogDal.GetListAll().Take(3).ToList();
        }
        public List<Blog> GetBlogListWithByWriterBM(int writerID)
        {
            return _blogDal.GetListWithCategoryByWriter(writerID);
        }

        public List<Blog> getBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory().ToList();
        }

        public List<Blog> GetBlogById(int id)
        {
            return _blogDal.GetListAll(x => x.BlogID == id);
        }
        public void TAdd(Blog entity)
        {
            _blogDal.Add(entity);
        }

        public void TUpdate(Blog entity)
        {
            _blogDal.Update(entity);
        }

        public void TDelete(Blog entity)
        {
            _blogDal.Delete(entity);
        }

        public List<Blog> GetList()
        {
            return _blogDal.GetListAll();
        }

        public Blog TGetById(int id)
        {
            return _blogDal.GetByID(id);
        }
    }
}
