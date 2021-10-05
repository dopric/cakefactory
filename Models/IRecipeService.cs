using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cakefactory.Models
{
	public interface IRecipeService
	{
		Task DeleteAsync(long id);
		Recipe Find(long id);
		Task<Recipe> FindAsync(long id);
		IQueryable<Recipe> GetAll(int? count = null, int? page = null);
		Task<Recipe[]> GetAllAsync(int? count = null, int? page = null);
		Task SaveAsync(Recipe recipe);
	}
}
