using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Data.Repository
{
    public class EfFoodRepository : IFoodRepository
    {
        private readonly FoodApplicationDbContext _context;

        public EfFoodRepository(FoodApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(Food entity)
        {
            entity.CreatedAt = DateTime.Now;
            _context.foods.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> Delete(Guid id)
        {
            var food = await _context.foods.SingleOrDefaultAsync(f => f.Id == id);
            _context.foods.Remove(food);
            var result = await _context.SaveChangesAsync();
            return result == 1 ? true : false;
        }

        public async Task<bool> IsExist(Guid id)
        {
            return await _context.foods.AnyAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Food>> Get()
        {
            return await _context.foods.Include(c => c.Category).Include(c => c.Comments).ToListAsync();
        }

        public async Task<IEnumerable<Food>> GetByCategoryName(string categoryName)
        {
            return await _context.foods.Include(c => c.Category).Include(c => c.Comments).Where(f => f.Category.Name.ToLower().Contains(categoryName.ToLower())).ToListAsync();
        }

        public async Task<Food> GetById(Guid id)
        {
            return await _context.foods.Include(c => c.Category).Include(c => c.Comments.Where(x => x.Status == true)).FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Food>> GetByIngredients(string ingredient)
        {
            return await _context.foods.Include(c => c.Category).Where(f => f.Ingredients.ToLower().Contains(ingredient.ToLower())).ToListAsync();
        }

        public async Task<bool> Update(Food entity)
        {
            var food = await _context.foods.FirstOrDefaultAsync(f => f.Id == entity.Id);
            food.ImageUrl = entity.ImageUrl != default ? entity.ImageUrl : food.ImageUrl;
            food.Ingredients = entity.Ingredients != default ? entity.Ingredients : food.Ingredients;
            food.Name = entity.Name != default ? entity.Name : food.Name;
            food.Recipe = entity.Recipe != default ? entity.Recipe : food.Recipe;
            food.CategoryId = entity.CategoryId != default ? entity.CategoryId : food.CategoryId;
            food.UpdatedAt = DateTime.Now;
            var result = await _context.SaveChangesAsync();
            return result == 1 ? true : false;
        }
    }
}