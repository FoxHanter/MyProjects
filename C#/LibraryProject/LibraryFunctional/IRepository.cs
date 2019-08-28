using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryFunctional
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAllItems(); // получение всех объектов
        T GetItem(int id); // получение одного объекта по id
        void Create(T item); // создание объекта
        void Update(T item,int delta); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save();  // сохранение изменений
    }
}
