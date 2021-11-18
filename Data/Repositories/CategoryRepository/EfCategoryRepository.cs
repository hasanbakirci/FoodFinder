using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Data.Repositories.CategoryRepository
{
    public class EfCategoryRepository : ICategoryRepository
    {
        private readonly FoodApplicationDbContext _context;

        public EfCategoryRepository(FoodApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(Category entity)
        {
            entity.CreatedAt = DateTime.Now;
            _context.categories.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> Delete(Guid id)
        {
            var category = await _context.categories.SingleOrDefaultAsync(c => c.Id == id);
            _context.categories.Remove(category);
            var result = await _context.SaveChangesAsync();
            return result == 1 ? true : false;
        }

        public async Task<IEnumerable<Category>> Get()
        {
            return await _context.categories.ToListAsync();
        }

        public async Task<Category> GetById(Guid id)
        {
            return await _context.categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> IsExist(Guid id)
        {
            return await _context.categories.AnyAsync(f => f.Id == id);
        }

        public async Task<bool> Update(Category entity)
        {
            var category = await _context.categories.FirstOrDefaultAsync(c => c.Id == entity.Id);
            category.Name = entity.Name != default ? entity.Name : category.Name;
            category.UpdatedAt = DateTime.Now;
            var result = await _context.SaveChangesAsync();
            return result == 1 ? true : false;
        }
    }
}