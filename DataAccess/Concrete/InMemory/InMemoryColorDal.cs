using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
	internal class InMemoryColorDal : IColorDal
	{

		List<Color> _color;

		public InMemoryColorDal()
		{
			_color = new List<Color>
			{
				new Color{Id=1,ColorName="Sarı" },
				new Color{Id=2,ColorName="Kırmızı"},
				new Color{Id=3,ColorName="Siyah"}

			};
		}

		public void Add(Color color)
		{
			throw new NotImplementedException();
		}

		public void Delete(Color color)
		{
			Color colorToDelete;

			colorToDelete = _color.SingleOrDefault(c => c.Id == color.Id);

			_color.Remove(colorToDelete);

		}

		public Color Get(Expression<Func<Color, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public List<Color> GetAll()
		{
			return _color;
		}

		public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public List<Color> GetById(int colorId)
		{
			return _color.Where(c => c.Id == colorId).ToList();
		}

		public void GetCarsByBrandId(int id)
		{
			throw new NotImplementedException();
		}

		public void GetCarsByColorId(int id)
		{
			throw new NotImplementedException();
		}

		public void Update(Color color)
		{
			Color colorToUpdate;

			colorToUpdate = _color.SingleOrDefault(c => c.Id == color.Id);

			colorToUpdate.ColorName = color.ColorName;

		}
	}
}
