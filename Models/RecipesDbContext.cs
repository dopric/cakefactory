using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using cakefactory.Extensions;

namespace cakefactory.Models
{
	public class RecipesDbContext : DbContext
	{
		public DbSet<Recipe> Recipes { get; set; }

		public RecipesDbContext(DbContextOptions<RecipesDbContext> options)
			: base(options)
		{
			this.EnsureSeedData();
		}
	}
}
