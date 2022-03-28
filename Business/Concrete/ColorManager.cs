using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class ColorManager : IColorService
	{
		IColorDal _colorDal;

		public ColorManager(IColorDal colorDal)
		{
			_colorDal = colorDal;
		}

		public IResult Add(Color color)
		{
			if (color.ColorName.Length < 0)
			{
				return new ErrorResult(Messages.ColorNameInvalid);

			}

			_colorDal.Add(color);
			return new SuccessResult(Messages.ColorAdded);
		}

		public IResult Delete(Color color)
		{
			if (color.Id == 1)
			{
				return new ErrorResult(Messages.MaintenenceTime);

			}

			_colorDal.Delete(color);

			return new SuccessResult(Messages.ColorDeleted);
		}

		public IDataResult<List<Color>> GetAll()
		{
			return new DataResult<List<Color>>(_colorDal.GetAll(), true, Messages.ColorListed);
		}

		public IDataResult<Color> GetById(int colorId)
		{

			return new SuccessDataResult<Color>(_colorDal.Get(p => p.Id == colorId), Messages.ColorListed);
		}

		public IResult Update(Color color)
		{
			_colorDal.Update(color);
			return new SuccessResult(Messages.ColorUpdated);
		}
	}
}
