﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);

        T GetByID(int id);

        List<T> GetListAll();

        void Delete(T entity);
        
        // Şartlı Listeler de kullanılan yapı
        List<T> GetListAll(Expression<Func<T, bool>> filter);
    }
}
