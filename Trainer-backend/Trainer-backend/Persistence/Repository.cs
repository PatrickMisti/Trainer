using System.Data;
using Microsoft.EntityFrameworkCore;
using Serilog.Core;

namespace Trainer_backend.Persistence
{
    public interface IRepository<T>
    {
        // CRUD operations
        Task<bool> Create(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
        Task<int> DeleteById(int entityId);
        // queries
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
    }

    public class Repository<T> : IRepository<T> where T : class, new()
    {
        public Repository()
        {
            
        }

        public async Task<bool> Create(T entity)
        {
            try
            {
                using var db = new DatabaseContext();

                db.Set<T>().Add(entity);
                return await db.SaveChangesAsync() >= 0;
            } catch (Exception ex)
            {
                throw new DataException(ex.Message);
            }
        }

        public async Task<int> Delete(T entity)
        {
            try
            {
                await using var db = new DatabaseContext();
                db.Set<T>().Remove(entity);
                return await db.SaveChangesAsync();
            } catch (Exception ex)
            {
                throw new DataException(ex.Message);
            }
        }

        public async Task<int> DeleteById(int entityId)
        {
            try
            {
                await using var db = new DatabaseContext();
                var item = await db.Set<T>().FindAsync(entityId);
                db.Set<T>().Remove(item!);
                return await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new DataException(ex.Message);
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            await using var db = new DatabaseContext();
            return await db.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            await using var db = new DatabaseContext();
            return await db.Set<T>().FindAsync(id) ?? new T();
        }

        public async Task<int> Update(T entity)
        {
            try
            {
                await using var db = new DatabaseContext();
                db.Set<T>().Update(entity);
                return await db.SaveChangesAsync();
            } catch(Exception ex)
            {
                throw new DataException(ex.Message);
            }
        }
    }
}
