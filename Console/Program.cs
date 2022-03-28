using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
	public class Program
	{
		static void Main(string[] args)

		{
			CarManager carManager =new CarManager(new InMemoryCarDal());


			foreach (var car in carManager.GetAll())
			{
				System.Console.WriteLine(car.Description);

			}




		}









	}
}
