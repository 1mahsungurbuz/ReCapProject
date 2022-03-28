using Business.Abstract;
using Business.Contants;
using Core.Business;
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
	public  class CarManager:ICarService
	{
		ICarDal _carDal;
	

		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}

		public IResult Add(Car car)
		{
			if (car.DailyPrice<100)
			{
				return new ErrorResult(Messages.CarNameInvalid);

			}

			_carDal.Add(car);
			return new SuccessResult(Messages.CarAdded);


		}

		public IResult Update(Car car)
		{
			_carDal.Update(car);
			return new SuccessResult(Messages.CarUpdated);
		}

		public IResult Delete(Car car)
		{

			_carDal.Delete(car);

			return new SuccessResult(Messages.CarDeleted);
		}

		public IDataResult<List<Car>> GetAll()
		{

			return new DataResult<List<Car>>(_carDal.GetAll(), true, Messages.CarListed);


		}

		public IDataResult<Car> GetById(int carId) 
		{	
			return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == carId),Messages.CarListed); 
		}

		public IDataResult<List<Car>> GetByUnitPrice(decimal min, decimal max)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= min & p.DailyPrice <= max),Messages.CarListed);
		}

		public IDataResult<List<CarDetailDto>> GetCarDetails()
		{
			return new DataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), true, Messages.CarListed);
		}

		public IDataResult<List<Car>> GetCarsByBrandId(int id)
		{
			

			return new DataResult<List<Car>>(_carDal.GetAll(b => b.BrandId == id), true, Messages.CarListed);
		}

		public IDataResult<List<Car>> GetCarsByColorId(int id)
		{
			return new DataResult<List<Car>>(_carDal.GetAll(c => c.ColorId== id), true, Messages.CarListed);

		}

		
	}
}
