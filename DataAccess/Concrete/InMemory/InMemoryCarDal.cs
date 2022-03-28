using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
	public class InMemoryCarDal:ICarDal
	{
		List<Car> _cars; 

		public InMemoryCarDal()

		{
			_cars=new List<Car>

			{

				new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=25000,ModelYear=2011,Description="Temiz Hatasız"},
				new Car{Id=2,BrandId=2,ColorId=2,DailyPrice=50000,ModelYear=2014,Description="sıfır Hatasız"},
				new Car{Id=3,BrandId=3,ColorId=2,DailyPrice=75000,ModelYear=2016,Description="az yakar Hatasız"}

			};

		}

		public List<Car> GetAll()
		{
			return _cars;
		}

		public List<Car> GetById(int carId)
		{
			return _cars.Where(c => c.Id == carId).ToList();

		}

		public void Add(Car car)
		{
			_cars.Add(car);

		}


		public void Update(Car car)
		{
			Car carToUpdate;
			carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);	

			carToUpdate.Description=car.Description;
			car.ColorId = car.ColorId;

		}

		public	void Delete(Car car)
		{
			Car carToDelete;

			carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);


			_cars.Remove(carToDelete);
		}

		public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public Car Get(Expression<Func<Car, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public void GetCarsByBrandId(int id)
		{
			throw new NotImplementedException();
		}

		public void GetCarsByColorId(int id)
		{
			throw new NotImplementedException();
		}

		public List<CarDetailDto> GetCarDetails()
		{
			throw new NotImplementedException();
		}
	}
}
