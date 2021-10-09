using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace cakefactory.Models
{
	public class RecipesService : IRecipeService
	{
		private readonly RecipesDbContext _context;

		public RecipesService()
		{
			var options = new DbContextOptionsBuilder<RecipesDbContext>()
				.UseInMemoryDatabase("TopsyTurvyCakes")
				.Options;

			_context = new RecipesDbContext(options);
		}
		public RecipesService(RecipesDbContext context)
		{
			_context = context;
		}

		public async Task DeleteAsync(long id)
		{
			var entity = await _context.Recipes.FirstOrDefaultAsync(p => p.Id == id);
			if (entity != null)
			{
				_context.Remove(entity);
				 await _context.SaveChangesAsync();
			}
			
		}

		public Recipe Find(long id)
		{
			return _context.Recipes.FirstOrDefault(p => p.Id == id);
		}

		public Task<Recipe> FindAsync(long id)
		{
			return _context.Recipes.FirstOrDefaultAsync(p => p.Id == id);
		}

		public IQueryable<Recipe> GetAll(int? count = null, int? page = null)
		{
			var maxAllowed = count.GetValueOrDefault(25);
			return _context.Recipes
				.Skip(maxAllowed * page.GetValueOrDefault(0))
				.Take(maxAllowed);
		}

		public Task<Recipe[]> GetAllAsync(int? count = null, int? page = null)
		{
			return GetAll(count, page).ToArrayAsync();
		}

		public async Task SaveAsync(Recipe recipe)
		{
			var isNew = recipe.Id == default(long);

			_context.Entry(recipe).State = isNew ? EntityState.Added : EntityState.Modified;

			await _context.SaveChangesAsync();
		}
	}
}
