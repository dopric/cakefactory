using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace cakefactory.Models
{
	public class Recipe
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Ingredients { get; set; }
		public string Directions { get; set; }

		public IEnumerable<string> DirectionsList
		{
			get { return (Directions ?? string.Empty).Split(System.Environment.NewLine); }
		}

		public IEnumerable<string> IngredientsList
		{
			get { return (Ingredients ?? string.Empty).Split(System.Environment.NewLine); }
		}

		public byte[] Image { get; set; }
		public string ImageContentType { get; set; }

		public string GetInlineImageSrc()
		{
			if (Image == null || string.IsNullOrEmpty(ImageContentType))
			{
				return null;
			}

			var base64Image = System.Convert.ToBase64String(Image);
			return $"data:{ImageContentType};base64,{base64Image}";
		}

		public void SetImage(IFormFile file)
		{
			if (file == null)
			{
				return;
			}

			ImageContentType = file.ContentType;
			using (var stream = new MemoryStream())
			{
				file.CopyTo(stream);
				Image = stream.ToArray();
			}
		}
	}

	
}
