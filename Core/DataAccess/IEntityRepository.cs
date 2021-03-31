using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.DataAccess.Abstract
{

    public interface IEntityRepository<T> where T:class,IEntity, new() //generic constraint //class = referans tip olabilir anlamına gelir. //IEntity = 
                                                                 //IEntity veya IEntity implemente eden bir nesne olabilir
                                                                //new yazarak da IEntity nin kendisi hariç sadece implemente edildiği nesneleri yazabiliyor oluyoruz.
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter=null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        //List<T> GeyByCategory(int categoryId);



        //buradaki t yerine, bu interface in implemente edildiği tüm interfacelerde farklı entitylerin ismi yazılır(product,category vb.)
        //metodlar da ona göre dizayn edilir ek olarak yazmaya gerek yok.

    }
}
