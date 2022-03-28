using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class RentalManager : IRentalService
	{

		IRentalDal _rentalDal;

		public RentalManager(IRentalDal rentalDal)
		{
			_rentalDal = rentalDal;
		}

		public IResult Add(Rental entity)
		{
			var result= GetById(entity.CarId);

			if (result.Data==null) 
			{
				_rentalDal.Add(entity);
				return new SuccessResult(Messages.SuccesRanted);
			}
			return new ErrorResult(Messages.ErorAdded);
			
		}

		
		public IResult Delete(Rental entity)
		{

			_rentalDal.Delete(entity);

			return new SuccessResult(Messages.BrandDeleted);
		}

		public IDataResult<List<Rental>> GetAll()
		{
			return new DataResult<List<Rental>>(_rentalDal.GetAll(), true, Messages.BrandListed);

		}

		public IDataResult<Rental> GetById(int entityId)
		{
			return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == entityId));

		}

		public IDataResult<List<RentalDetailDto>> RentalDetailDto()
		{
			  return new DataResult<List<RentalDetailDto>>(_rentalDal.RentalDetailDto(),true,Messages.CarListed);
		}

		public IResult Update(Rental entity)
		{
			_rentalDal.Update(entity);
			return new SuccessResult(Messages.BrandUpdated);
		}
	}
}
