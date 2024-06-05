using Application.Interfaces.GenericRepositories;
using Domain.Comman;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Peristance.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Peristance.Extenstion.Repositories
{
    public class GenricRepository<T> : IGenericRepositary<T> where T : BaseAuditableEntity
    {
        private readonly ApplicationdbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        public GenricRepository(ApplicationdbContext context,IHttpContextAccessor accessor)
        {
            _context = context;
            _contextAccessor = accessor;
        }
        public IQueryable<T> Entities =>_context.Set<T>();

        public async Task<T> AddAsync(T entity)
        {
           var userid=Convert.ToInt32(_contextAccessor.HttpContext.User.FindFirstValue("id"));
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = userid;
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public Task DeleteAsync(T entity)
        {
           if(entity is BaseAuditableEntity auditableEntity)
            {
                auditableEntity.IsDeleted = true;
                auditableEntity.UpdatedDate = DateTime.Now;
                auditableEntity.UpdatedBy = Convert.ToInt32(_contextAccessor.HttpContext.User.FindFirstValue("id"));
                _context.Entry(entity).State = EntityState.Modified;
            }
           return Task.CompletedTask;
        }

        public async Task<List<T>> GetAll()
        {
            var data = await _context
                 .Set<T>()
                 .Where(e => !e.IsDeleted)
                 .ToListAsync();
                 return data;
        }

        public async Task<T> GetByID(int id)
        {
          var data=await _context
                .Set<T>()
                .Where (e => !e.IsDeleted && e.Id==id)
                .FirstOrDefaultAsync();
            return data;
        }

        public  Task UpdateAsync(T entity, int id)
        {
            var userid = Convert.ToInt32(_contextAccessor.HttpContext.User.FindFirstValue("id"));
            T exist=_context.Set<T>().Find(id);
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedBy = userid;
            _context.Entry(exist).CurrentValues.SetValues(exist);
            return Task.CompletedTask;
        }
    }
}
