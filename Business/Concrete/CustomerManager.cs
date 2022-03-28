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
	public class CustomerManager : ICustomerService
	{
		ICustomerDal _customerDal;

		public CustomerManager(ICustomerDal customerDal)
		{
			_customerDal = customerDal;
		}

		public IResult Add(Customer entity)
		{

			_customerDal.Add(entity);
			return new SuccessResult(Messages.BrandAdded);
		}

		public IResult Delete(Customer entity)
		{


			_customerDal.Delete(entity);

			return new SuccessResult(Messages.BrandDeleted);
		}

		public IDataResult<List<Customer>> GetAll()
		{
			return new DataResult<List<Customer>>(_customerDal.GetAll(), true, Messages.BrandListed);
		}

		public IDataResult<Customer> GetById(int entityId)
		{
			return new SuccessDataResult<Customer>(_customerDal.Get(p => p.Id == entityId));
		}

		public IResult Update(Customer entity)
		{
			_customerDal.Update(entity);
			return new SuccessResult(Messages.BrandUpdated);
		}
	}
}
