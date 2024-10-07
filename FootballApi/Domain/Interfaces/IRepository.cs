using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRepository<T> 
        where T : EntityBase
    {
        /// <summary>
        /// Получение всех объектов
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Получение одного объекта по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Объект или null</returns>
        Task<T?> GetAsync(Guid id);

        /// <summary>
        /// Создание объекта
        /// </summary>
        /// <param name="item">Объект, который требуется добавить</param>
        /// <returns></returns>
        Task CreateAsync(T item);

        /// <summary>
        /// Обновление объекта происходит по id => id менять нельзя
        /// </summary>
        /// <param name="item">Обновленный объект</param>
        /// <returns></returns>
        Task UpdateAsync(T item);

        /// <summary>
        /// Удаление объекта по id
        /// </summary>
        /// <param name="id"></param>
        void Delete(Guid id); 
    }
}
