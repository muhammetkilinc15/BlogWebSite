using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private Context Context = new Context();

        // Set komutu ile 

        public GenericRepository()
        {
            // Context.Set<T>();
        }


        // Neden set kullandık. Set ile veri tabanında gelen T değeri
        // Hangi değere karsılık geliyorsa ona göre o table ekleme,silme yapcak
        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
        }

        public void Delete(T entity)
        {
            Context.Remove(entity);
            Context.SaveChanges();
        }

        public T GetByID(int id)
        {
            return Context.Set<T>().Find(id);
        }


        // Şartlı Listeleme ile filterdan gelen değere göre listeleme için kullanılacak
        public List<T> GetListAll(Expression<Func<T, bool>> filter)
        {
            return Context.Set<T>().Where(filter).ToList();
        }

        public List<T> GetListAll()
        {
            return Context.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
            Context.SaveChanges();
        }
    }
}
