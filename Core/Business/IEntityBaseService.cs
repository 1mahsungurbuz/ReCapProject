using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
	public interface IEntityBaseService<T>
	{
		IResult Add(T entity); 
		IResult Update(T entity);
		IResult Delete(T entity); 

		IDataResult<T> GetById(int entityId); 
		IDataResult<List<T>> GetAll();


	}
}
