using Eindproject2.Models.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Eindproject2.Models.Repositories
{
    public class GenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity : class
    {
        public Eindproject2APIContext _context { get; set; }

        private DbSet<TEntity> _dbSet;

        //ctor dependancy van de applicatie context:
        public GenericRepo(Eindproject2APIContext context)
        {
            this._context = context;
            this._dbSet = context.Set<TEntity>();  //type mee te geven in ctor (GenericRepository<App>)
                                                   //_context.Database.Log = new Logger().Log;
        }

        //interface implementatie:
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this._context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await this._context.Set<TEntity>().Where(expression).AsNoTracking().ToListAsync();
        }

        public async Task Create(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);

        }

        public async Task Update(TEntity entity)
        {
            await Task.Factory.StartNew(() =>
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.Set<TEntity>().Update(entity);

            });
        }

        public async Task Delete(TEntity entity)
        {
            await Task.Factory.StartNew(() =>
            {
                _context.Set<TEntity>().Remove(entity);

            });
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
