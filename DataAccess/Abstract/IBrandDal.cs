﻿using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
	public interface IBrandDal:IEntityRepository<Brand>
	{
		

	}
}


//List<Brand> GetAll();

//List<Brand> GetById(int brandId);

//void Add(Brand brand);

//void Update(Brand brand);

//void Delete(Brand brand);