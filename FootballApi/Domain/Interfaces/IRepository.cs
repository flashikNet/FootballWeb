using Domain.Entities;
using System;
using System.Collections.Generic;


namespace Domain.Interfaces
{
    public interface IRepository<T> 
        where T : EntityBase
    {
        IQueryable<T> GetAll(); // получение всех объектов
        Task<T> GetAsync(uint id); // получение одного объекта по id
        void Create(T item); // создание объекта
        Task UpdateAsync(T item); // обновление объекта
        void Delete(uint id); // удаление объекта по id
    }
}
