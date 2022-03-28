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

	public class UserManager : IUserService

	{
		IUserDal _userDal;

		public UserManager(IUserDal userDal)
		{
			_userDal = userDal;
		}

		public IResult Add(User entity)
		{
			_userDal.Add(entity);
			return new SuccessResult(Messages.BrandAdded);
		}

		public IResult Delete(User entity)
		{
			if (entity.Id == 1)
			{
				return new ErrorResult(Messages.BrandNameInvalid);

			}

			_userDal.Delete(entity);

			return new SuccessResult(Messages.BrandDeleted);
		}

		public IDataResult<List<User>> GetAll()
		{
			return new DataResult<List<User>>(_userDal.GetAll(), true, Messages.BrandListed);
		}

		public IDataResult<User> GetById(int entityId)
		{
			return new SuccessDataResult<User>(_userDal.Get(p => p.Id == entityId));
		}

		public IResult Update(User entity)
		{
			_userDal.Update(entity);
			return new SuccessResult(Messages.BrandUpdated);
		}
	}
}
