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
	public class BrandManager : IBrandService
	{
		IBrandDal _brandDal;

		public BrandManager(IBrandDal brandDal) 
		{
			_brandDal = brandDal;
		}


		public IResult Update(Brand brand)
		{
			_brandDal.Update(brand);
			return new SuccessResult(Messages.BrandUpdated);
		}

		public IResult Delete(Brand brand)
		{
			if (brand.Id == 3)
			{
				return new ErrorResult(Messages.BrandNameInvalid);

			}

			_brandDal.Delete(brand);

			return new SuccessResult(Messages.BrandDeleted);
		}

		public IDataResult<List<Brand>> GetAll()
		{

			return new DataResult<List<Brand>>(_brandDal.GetAll(), true, Messages.BrandListed);


		}

		public IResult Add(Brand brand)
		{

			_brandDal.Add(brand);
			return new SuccessResult(Messages.BrandAdded);

		}


		public IDataResult<Brand> GetById(int brandId)
		{

			return new SuccessDataResult<Brand>(_brandDal.Get(p => p.Id == brandId));

		}
	}
}
