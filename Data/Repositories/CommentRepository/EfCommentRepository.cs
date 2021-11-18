using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Data.Repositories.CommentRepository
{
    public class EfCommentRepository : ICommentRepository
    {
        private readonly FoodApplicationDbContext _context;

        public EfCommentRepository(FoodApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(Comment entity)
        {
            entity.CreatedAt = DateTime.Now;
            _context.comments.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> Delete(Guid id)
        {
            var comment = await _context.comments.SingleOrDefaultAsync(c => c.Id == id);
            _context.comments.Remove(comment);
            var result = await _context.SaveChangesAsync();
            return result == 1 ? true : false;
        }

        public async Task<IEnumerable<Comment>> Get()
        {
            return await _context.comments.Include(f => f.Food).ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetByFoodName(string foodName)
        {
            return await _context.comments.Include(f => f.Food).Where(f => f.Food.Name.ToLower().Contains(foodName.ToLower())).ToListAsync();
        }

        public async Task<Comment> GetById(Guid id)
        {
            return await _context.comments.Include(f => f.Food).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> IsExist(Guid id)
        {
            return await _context.comments.AnyAsync(f => f.Id == id);
        }

        public async Task<bool> Update(Comment entity)
        {
            var comment = await _context.comments.SingleOrDefaultAsync(c => c.Id == entity.Id);
            comment.Status = entity.Status != default ? entity.Status : comment.Status;
            comment.UpdatedAt = DateTime.Now;
            var result = await _context.SaveChangesAsync();
            return result == 1 ? true : false;
        }
    }
}