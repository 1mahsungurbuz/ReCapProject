using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
	public class Program
	{ 
		static void Main(string[] args)
		{
			#region Entity Fonksiyonları
			//AracFonksiyonu();
			//ModelFonksiyonu();
			//RenkFonksiyonu();
			//MusteriFonksiyonu();
			//KullaniciFonksiyonu();
			RentalFonksiyonu();





			#endregion 

			Console.ReadLine();

		}



		#region  Araç (Car) Ekleme Silme Güncelleme Ve Listeleme Fonksiyonları

		private static void AracFonksiyonu()
		{
			CarManager carManager = new CarManager(new EfCarDal());


			Console.WriteLine($"" +
							$" Bilgi Listelemek için -->  1\n" +
							$" Bilgi Eklemek için -->  2\n" +
							$" Bilgi Silmek için -->  3\n" +
							$" Bilgi Güncelleme için -->  4\n" +
							$" Model Bilgisi için  -->  5\n" +
							$" Car Details Dto için  -->  6\n" +
							$" Fiyat Aralığı için  -->  7\n" +
							$" Çıkış -->  8\n");

			Console.WriteLine("---------------------------");

			Console.Write("İşlem numarasını gir: ");
			int islemNo = int.Parse(Console.ReadLine());


			switch (islemNo)
			{
				case 1:
					AracTumBilgileri(carManager);
					AracFonksiyonu();
					break;
				case 2:
					Console.WriteLine(carManager.Add(AracEkleme()).Message);
					AracFonksiyonu();
					break;
				case 3:
					AracSilme(carManager);
					AracFonksiyonu();
					break;
				case 4:
					AracBilgiGuncelleme(carManager);
					AracFonksiyonu();
					break;
				case 5:
					GetCarsByBrandId(carManager);
					AracFonksiyonu();
					break;
				case 6:
					CarDetailsDto(carManager);
					AracFonksiyonu();
					break;
				case 7:
					FiyatAraligi(carManager);
					AracFonksiyonu();
					break;

				case 8:
					break;

				default:
					Console.WriteLine("Hatalı İşlem");
					AracFonksiyonu();
					break;

					

			}


		}

		private static Car AracEkleme()
		{
			Console.WriteLine("**********   Araç Ekleme   **************");

			Car car1 = new Car();

			//Console.Write("Araç Id Gir: ");
			//car1.Id = int.Parse(Console.ReadLine());
			Console.Write("Araç Model Id Gir: ");
			car1.BrandId = int.Parse(Console.ReadLine());
			Console.Write("Araç Renk Id Gir: ");
			car1.ColorId = int.Parse(Console.ReadLine());
			Console.Write("Araç Model Yılı Gir: ");
			car1.ModelYear = int.Parse(Console.ReadLine());
			Console.Write("Araç Fiyat Bilgisi Gir: ");
			car1.DailyPrice = int.Parse(Console.ReadLine());
			Console.Write("Araç Açıklaması Gir: ");
			car1.Description = Console.ReadLine();
			return car1;

		}

		private static void AracSilme(CarManager carManager)
		{
			Console.WriteLine("   ***********   Araç Silme    ***************   ");

			Console.Write("Silincek araç id'si gir: ");
			int id = int.Parse(Console.ReadLine());
			var Result = carManager.GetById(id);
			Console.WriteLine(Result.Message);

			Console.WriteLine(carManager.Delete(Result.Data).Message);

		}

		private static void AracBilgiGuncelleme(CarManager carManager)
		{
			Console.WriteLine("**********   Araç Bilgi Güncelleme     *************");

			Console.Write("güncellenecek araç id'si gir: ");
			int id = int.Parse(Console.ReadLine());
			var Result = carManager.GetById(id);
			Console.WriteLine("Yeni BrandId gir: ");
			Result.Data.BrandId = int.Parse(Console.ReadLine());
			Console.WriteLine("Yeni ColorId gir: ");
			Result.Data.ColorId = int.Parse(Console.ReadLine());

			Console.WriteLine(carManager.Update(Result.Data).Message);

		}


		private static void AracTumBilgileri(CarManager carManager)
		{
			Console.WriteLine("***************   GetAll Aaraç Bilgi  Listleme    **********");

			Console.WriteLine();

			var result = carManager.GetAll();

			foreach (var item in result.Data)
			{
				Console.WriteLine($" Araç Id: {item.Id}\n" +
					$" Araç Model: {item.BrandId}\n Araç Rengi: {item.ColorId}\n" +
					$" Araç Üretim Yılı: {item.ModelYear}\n Araç Fiyatı: {item.DailyPrice}\n" +
					$" Araç Açıklaması: {item.Description}\n ");
				Console.WriteLine("-------------------------------------------");
			}
		}

		private static void GetCarsByBrandId(CarManager carManager)
		{
			Console.WriteLine("***************   Get Cars By BrandId ile Listeleme ***************");
			Console.WriteLine();

		 

			var result = carManager.GetCarsByBrandId(3);
			foreach (var bilgiler in result.Data)
			{
				Console.WriteLine($" Araç ID: {bilgiler.Id}\n Araç Model ID: {bilgiler.BrandId}\n" +
			$" Araç Rengi Id: {bilgiler.ColorId}\n Araç Fiyatı: {bilgiler.DailyPrice}\n");

			}
		}

		private static void CarDetailsDto(CarManager carManager)
		{
			Console.WriteLine("-----------  Araç Ayruntıları  ------------------");
			var result = carManager.GetCarDetails();

			foreach (var bilgiler in result.Data)
			{
				Console.WriteLine($"Araç ID: {bilgiler.Id} Araç Markası: {bilgiler.BrandName}" +
					$"Araç Rengi: {bilgiler.ColorName} Araç Fiyatı: {bilgiler.DailyPrice}");


			}

			Console.WriteLine(result.Message);
		}
		
		private static void FiyatAraligi(CarManager carManager )
		{
			Console.WriteLine("    ------      Fiyat Aralığı Bilgisi    ---------");
			foreach (var item1 in carManager.GetByUnitPrice(250000, 450000).Data)
			{
				Console.WriteLine($" Araç Id: {item1.Id}\n Fiyat: {item1.DailyPrice}\n Araç Açıklaması: {item1.Description}\n");

				Console.WriteLine("--------------------------------------");
			}
		}




		#endregion

		#region Model (Brand) Ekleme Silme Güncelleme Ve Listeleme Fonksiyonları


		private static void ModelFonksiyonu()
		{
			BrandManager brandManager = new BrandManager(new EfBrandDal());


			Console.WriteLine($"" +
							$" Bilgi Listelemek için -->  1\n" +
							$" Bilgi Eklemek için -->  2\n" +
							$" Bilgi Silmek için -->  3\n" +
							$" Bilgi Güncelleme için -->  4\n" +
							//$" Model Bilgisi için  -->  5\n" +
							//$" Car Details Dto için  -->  6\n" +
							//$" Fiyat Aralığı için  -->  7\n" +
							$" Çıkış -->  5\n");

			Console.WriteLine("---------------------------");

			Console.Write("İşlem numarasını gir: ");
			int islemNo = int.Parse(Console.ReadLine());


			switch (islemNo)
			{
				case 1:
					ModelListeleme(brandManager);
					ModelFonksiyonu();
					break;
				case 2:
					ModelEkleme(brandManager);
					ModelFonksiyonu();
					break;
				case 3:
					ModelSilme(brandManager);
					ModelFonksiyonu();
					break;
				case 4:
					ModelGuncelleme(brandManager);
					ModelFonksiyonu();
					break;

				case 5:
					break;

				default:
					Console.WriteLine("Hatalı İşlem");
					ModelFonksiyonu();
					break;



			}


		}





		private static void ModelEkleme(BrandManager brandManager)
		{
			Console.WriteLine(" ************   Model Ekleme    **********");
			Console.WriteLine();

			Brand brand = new Brand();

			//Console.Write("Model Id Gir: ");
			//brand.Id = int.Parse(Console.ReadLine());

			Console.Write("Model İsmi Gir: ");
			brand.BrandName = Console.ReadLine();

			Console.WriteLine(brandManager.Add(brand).Message);

		}

		private static void ModelSilme(BrandManager brandManager)
		{
			Console.WriteLine("  ************   Model Silme Ve Listeleme  ************* ");
			Console.WriteLine();
			int ModelId;
			Console.WriteLine("Silincek Modelin Id'sini Gir: ");
			ModelId = int.Parse(Console.ReadLine());
			var result = brandManager.GetById(ModelId);

			Console.WriteLine(brandManager.Delete(result.Data).Message);


		}

		

		private static void ModelGuncelleme(BrandManager brandManager)
		{
			Console.WriteLine("    **************  Model Güncelleme   **********  ");

			int brandId;
			Console.WriteLine("BrandId Bilgisi Gir: ");
			brandId = int.Parse(Console.ReadLine());

			var result = brandManager.GetById(brandId);

			Console.Write("Yeni Model İsmi Gir: ");
			result.Data.BrandName = Console.ReadLine();

			Console.WriteLine(brandManager.Update(result.Data).Message);
		}



		private static void ModelListeleme(BrandManager brandManager)
		{

			Console.WriteLine("**********    Model Bilgileri   **********");

			var result = brandManager.GetAll();

			foreach (var item in result.Data)
			{
				Console.WriteLine($" Araç Model Id: {item.Id}\n Araç Model İsmi: {item.BrandName}\n");

				Console.WriteLine("-------------------------------");
			}
			Console.WriteLine(result.Message);
		}



		#endregion

		#region Renk (Color) Ekleme Silme Güncelleme Ve Listeleme Fonksiyonları

		private static void RenkFonksiyonu()
		{
			ColorManager colorManager  = new ColorManager(new EfColorDal());


			Console.WriteLine($"" +
							$" Bilgi Listelemek için -->  1\n" +
							$" Bilgi Eklemek için -->  2\n" +
							$" Bilgi Silmek için -->  3\n" +
							$" Bilgi Güncelleme için -->  4\n" +
							//$" Model Bilgisi için  -->  5\n" +
							//$" Car Details Dto için  -->  6\n" +
							//$" Fiyat Aralığı için  -->  7\n" +
							$" Çıkış -->  5\n");

			Console.WriteLine("---------------------------");

			Console.Write("İşlem numarasını gir: ");
			int islemNo = int.Parse(Console.ReadLine());


			switch (islemNo)
			{
				case 1:
					RenkBilgileri(colorManager);
					RenkFonksiyonu();
					break;
				case 2:
					RenkEkleme(colorManager);
					RenkFonksiyonu();
					break;
				case 3:
					RenkSilme(colorManager);
					RenkFonksiyonu();
					break;
				case 4:
					RenkGuncellem(colorManager);
					RenkFonksiyonu();
					break;

				case 5:
					break;

				default:
					Console.WriteLine("Hatalı İşlem");
					RenkFonksiyonu();
					break;
			}


		}

		private static void RenkGuncellem(ColorManager colorManager)
		{
			Console.WriteLine("    **************  Renk Güncelleme   **********  ");

			int coloId;
			Console.WriteLine("ColoId Bilgisi Gir: ");
			coloId = int.Parse(Console.ReadLine());

			var result = colorManager.GetById(coloId);

			Console.Write("Yeni Renk İsmi Gir: ");
			result.Data.ColorName = Console.ReadLine();

			Console.WriteLine(colorManager.Update(result.Data).Message);
		}

		private static void RenkSilme(ColorManager colorManager)
		{
			Console.WriteLine("************   Renk Silme  *************");
			Console.WriteLine();

			int RenklId;
			Console.WriteLine("Silincek Rengin Id'sini Gir: ");
			RenklId = int.Parse(Console.ReadLine());
			var result = colorManager.GetById(RenklId);

			Console.WriteLine(colorManager.Delete(result.Data).Message);
		}

		private static void RenkEkleme(ColorManager colorManager)
		{
			Console.WriteLine("************   Renk Ekleme    **********");
			Console.WriteLine();

			Color color = new Color();

			//Console.Write("Model Id Gir: ");
			//brand.Id = int.Parse(Console.ReadLine());

			Console.Write("Renk İsmi Gir: ");
			color.ColorName = Console.ReadLine();

			Console.WriteLine(colorManager.Add(color).Message);
		}

		private static void RenkBilgileri(ColorManager colorManager)
		{
			Console.WriteLine("**********    Renk Bilgileri   **********");

			Console.WriteLine();

			var result = colorManager.GetAll();

			foreach (var item in result.Data)
			{
				Console.WriteLine($" Araç Renk Id: {item.Id}\n Araç Renk İsmi: {item.ColorName}\n");

				Console.WriteLine("--------------------------");
			}

			Console.WriteLine(result.Message);
		}


		#endregion

		#region Müşteri (Customer) Ekleme Silme Güncelleme Ve Listeleme Fonksiyonları


		private static void MusteriFonksiyonu()
		{
			CustomerManager customerManager = new CustomerManager(new EfCustomerDal());


			Console.WriteLine($"" +
							$" Bilgi Listelemek için -->  1\n" +
							$" Bilgi Eklemek için -->  2\n" +
							$" Bilgi Silmek için -->  3\n" +
							$" Bilgi Güncelleme için -->  4\n" +
							//$" Model Bilgisi için  -->  5\n" +
							//$" Car Details Dto için  -->  6\n" +
							//$" Fiyat Aralığı için  -->  7\n" +
							$" Çıkış -->  5\n");

			Console.WriteLine("---------------------------");

			Console.Write("İşlem numarasını gir: ");
			int islemNo = int.Parse(Console.ReadLine());


			switch (islemNo)
			{
				case 1:
					MusteriListeleme(customerManager);
					MusteriFonksiyonu();
					break;
				case 2:
					MusteriEkleme(customerManager);
					MusteriFonksiyonu();
					break;
				case 3:
					MusteriSilme(customerManager);
					MusteriFonksiyonu();
					break;
				case 4:
					MusteriGuncelleme(customerManager);
					MusteriFonksiyonu();
					break;

				case 5:
					break;

				default:
					Console.WriteLine("Hatalı İşlem");
					MusteriFonksiyonu();
					break;
			}


		}



		private static void MusteriEkleme(CustomerManager customerManager)
		{
			Console.WriteLine(" ************   Customer Ekleme    **********");
			Console.WriteLine();

			Customer customer = new Customer();

			//Console.Write("Customer Id Gir: ");
			//customer.Id = int.Parse(Console.ReadLine());
			//	
			Console.Write("UserId Gir: ");
			customer.UserId = int.Parse(Console.ReadLine());

			Console.Write("CompanyName İsmi Gir: ");
			customer.CompanyName = Console.ReadLine();

			Console.WriteLine(customerManager.Add(customer).Message);

		}

		private static void MusteriSilme(CustomerManager customerManager)
		{
			Console.WriteLine("  ************   Müşteri Silme   ************* ");
			Console.WriteLine();
			int MusteriId;
			Console.Write("Silincek Müşterinin Id'sini Gir: ");
			MusteriId = int.Parse(Console.ReadLine());
			var result = customerManager.GetById(MusteriId);

			Console.WriteLine(customerManager.Delete(result.Data).Message);


		}



		private static void MusteriGuncelleme(CustomerManager customerManager)
		{
			Console.WriteLine("    **************  Müşteri Güncelleme   **********  ");

			int MusteriId;
			Console.WriteLine("MüşteriId Bilgisi Gir: ");
			MusteriId = int.Parse(Console.ReadLine());

			var result = customerManager.GetById(MusteriId);

			Console.Write("Yeni CompanyName İsmi Gir: ");
			result.Data.CompanyName = Console.ReadLine();

			Console.WriteLine(customerManager.Update(result.Data).Message);
		}



		private static void MusteriListeleme(CustomerManager customerManager)
		{

			Console.WriteLine("**********    Müşteri Bilgileri   **********");

			var result = customerManager.GetAll();

			foreach (var item in result.Data)
			{
				Console.WriteLine($" Müşteri Id: {item.Id}\n Müşteri UserId: {item.UserId}\n Müşteri Şirket İsmi: {item.CompanyName}\n");

				Console.WriteLine("-------------------------------------");
			}
			Console.WriteLine(result.Message);
		}

		#endregion

		#region  Kullanıcı (User) Ekleme Silme Güncelleme Ve Listeleme Fonksiyonları


		private static void KullaniciFonksiyonu()
		{
			UserManager userManager = new UserManager(new EfUserDal());


			Console.WriteLine($"" +
							$" Bilgi Listelemek için -->  1\n" +
							$" Bilgi Eklemek için -->  2\n" +
							$" Bilgi Silmek için -->  3\n" +
							$" Bilgi Güncelleme için -->  4\n" +
							//$" Model Bilgisi için  -->  5\n" +
							//$" Car Details Dto için  -->  6\n" +
							//$" Fiyat Aralığı için  -->  7\n" +
							$" Çıkış -->  5\n");

			Console.WriteLine("---------------------------");

			Console.Write("İşlem numarasını gir: ");
			int islemNo = int.Parse(Console.ReadLine());


			switch (islemNo)
			{
				case 1:
					KullaniciListeleme(userManager);
					KullaniciFonksiyonu();
					break;
				case 2:
					KullaniciEkleme(userManager);
					KullaniciFonksiyonu();
					break;
				case 3:
					KullaniciSilme(userManager);
					KullaniciFonksiyonu();
					break;
				case 4:
					KullaniciGuncelleme(userManager);
					KullaniciFonksiyonu();
					break;

				case 5:
					break;

				default:
					Console.WriteLine("Hatalı İşlem");
					KullaniciFonksiyonu();
					break;
			}


		}


		private static void KullaniciEkleme(UserManager userManager)
		{
			Console.WriteLine(" ************   Kullanıcı Ekleme    **********");
			Console.WriteLine();

			User user = new User();

			//Console.Write("user Id Gir: ");
			//user.Id = int.Parse(Console.ReadLine());
			//

			Console.Write("FirsName Gir: ");
			user.FirstName = Console.ReadLine();

			Console.Write("LastName Gir: ");
			user.LastName = Console.ReadLine();

			Console.Write("Email Gir: ");
			user.Email = Console.ReadLine();

			Console.Write("Password Gir: ");
			user.Password = int.Parse(Console.ReadLine());


			Console.WriteLine(userManager.Add(user).Message);


			KullaniciListeleme(userManager);

		}

		private static void KullaniciSilme(UserManager userManager)
		{
			KullaniciListeleme(userManager);

			Console.WriteLine("  ************   Kullanıcı Silme   ************* ");
			Console.WriteLine();
			int UserId;
			Console.Write("Silincek Kullanıcı Id'sini Gir: ");
			UserId = int.Parse(Console.ReadLine());
			var result = userManager.GetById(UserId);

			Console.WriteLine(userManager.Delete(result.Data).Message);


		}

		private static void KullaniciGuncelleme(UserManager userManager)
		{
			KullaniciListeleme(userManager);


			Console.WriteLine("    **************  Kullanıcı Güncelleme   **********  ");

			int UserId;
			Console.WriteLine("KullanıcıId Bilgisi Gir: ");
			UserId = int.Parse(Console.ReadLine());

			var result = userManager.GetById(UserId);

			Console.Write("Yeni FirsName Gir: ");
			result.Data.FirstName = Console.ReadLine();

			Console.Write("Yeni LastName Gir: ");
			result.Data.LastName = Console.ReadLine();

			Console.Write("Yeni Email Gir: ");
			result.Data.Email = Console.ReadLine();

			Console.Write("Yeni Password Gir: ");
			result.Data.Password = int.Parse(Console.ReadLine());

			Console.WriteLine(userManager.Update(result.Data).Message);

		}

		private static void KullaniciListeleme(UserManager userManager) 
		{

			Console.WriteLine("**********    Kullanıcı Bilgileri   **********");

			var result = userManager.GetAll();

			foreach (var item in result.Data)
			{
				Console.WriteLine($" Kullanıcı Id: {item.Id}\n Kullanıcı FirsName: {item.FirstName}\n" +
					$" Kullanıcı LastName: {item.LastName}\n Kullanıcı Eposta: {item.Email}\n Kullanıcı Password: {item.Password}\n");

				Console.WriteLine("-------------------------------------");
			}
			Console.WriteLine(result.Message);
		}


		#endregion

		#region Kiralama (Rental) Ekleme Silme Güncelleme Ve Listeleme Fonksiyonları

		private static void RentalFonksiyonu()
		{
			RentalManager rentalManager = new RentalManager(new EfRentalDal());


			Console.WriteLine($"" +
							$" Bilgi Listelemek için -->  1\n" +
							$" Bilgi Eklemek için -->  2\n" +
							$" Bilgi Silmek için -->  3\n" +
							$" Bilgi Güncelleme için -->  4\n" +
							$" Ayrıntılı Kiralama Bilgisi için  -->  5\n" +
							//$" Car Details Dto için  -->  6\n" +
							//$" Fiyat Aralığı için  -->  7\n" +
							$" Çıkış -->  6\n");

			Console.WriteLine("---------------------------");

			Console.Write("İşlem numarasını gir: ");
			int islemNo = int.Parse(Console.ReadLine());


			switch (islemNo)
			{
				case 1:
					RentalListeleme(rentalManager);
					RentalFonksiyonu();
					break;
				case 2:
					RentalEkleme(rentalManager);
					RentalFonksiyonu();
					break;
				case 3:
					RentalSilme(rentalManager);
					RentalFonksiyonu();
					break;
				case 4:
					RentalGuncelleme(rentalManager);
					RentalFonksiyonu();
					break;

				case 5:
					RentalDetailDto(rentalManager);
					RentalFonksiyonu();
					break;

				case 6:
					break;

				default:
					Console.WriteLine("Hatalı İşlem");
					KullaniciFonksiyonu();
					break;
			}


		}
		private static void RentalEkleme(RentalManager rentalManager)
		{
			Console.WriteLine(" ************   Rental Ekleme    **********");
			Console.WriteLine();

			Rental rental = new Rental();

			//Console.Write("user Id Gir: ");
			//user.Id = int.Parse(Console.ReadLine());
			

			Console.Write("CarId Gir: ");
			rental.CarId = int.Parse(Console.ReadLine());

			Console.Write("CustomerId Gir: ");
			rental.CustomerId = int.Parse(Console.ReadLine());


			rental.RentDate = DateTime.Now.Date;

			//Console.Write("ReturnDate Gir: ");
			//rental.ReturnDate = int.Parse(Console.ReadLine());

			rental.ReturnDate = 0;


			Console.WriteLine(rentalManager.Add(rental).Message);


		}

		private static void RentalSilme(RentalManager rentalManager)
		{
		      RentalListeleme(rentalManager);

			Console.WriteLine("  ************   Rental Silme   ************* ");
			Console.WriteLine();
			int rentalId; 
			Console.Write("Silincek Rental Id'sini Gir: ");
			rentalId = int.Parse(Console.ReadLine());
			var result = rentalManager.GetById(rentalId);

			Console.WriteLine(rentalManager.Delete(result.Data).Message);

			
		}

		private static void RentalGuncelleme(RentalManager rentalManager)
		{
			RentalListeleme(rentalManager);


			Console.WriteLine("    **************  Rental Güncelleme   **********  ");

			int rentalId; 
			Console.WriteLine("Rental Id Gir: ");
			rentalId = int.Parse(Console.ReadLine());

			var result = rentalManager.GetById(rentalId);

			Console.Write("Yeni CarId Gir: ");
			result.Data.CarId = int.Parse(Console.ReadLine());

			Console.Write("Yeni CustomerId Gir: ");
			result.Data.CustomerId = int.Parse(Console.ReadLine());

			//Console.Write("Yeni RentDate Gir: ");
			//result.Data.RentDate = int.Parse(Console.ReadLine());

			result.Data.ReturnDate = DateTime.Now.Hour;
			

			//Console.Write("ReturnDate Gir: ");
			//result.Data.ReturnDate = int.Parse(Console.ReadLine());

			Console.WriteLine(rentalManager.Update(result.Data).Message);
			

		}

		private static void RentalListeleme(RentalManager rentalManager)
		{

			Console.WriteLine("**********    Rental Bilgileri   **********");

			var result = rentalManager.GetAll();

			foreach (var item in result.Data)
			{
				Console.WriteLine($" Id: {item.Id}\n Araç Id: {item.CarId}\n Customer Id: {item.CustomerId}\n" +
					$" Kiralama Tarihi: {item.RentDate}\n İade Tarihi: {item.ReturnDate}\n");

				Console.WriteLine("-------------------------------------");
			}
			Console.WriteLine(result.Message);
		}

		private static void RentalDetailDto(RentalManager rentalManager)
		{
			Console.WriteLine("*****   RentalDetailDto Kiralama Bilgisi Listeleme   *********");

			var result = rentalManager.RentalDetailDto();
			foreach (var item in result.Data)
			{
				Console.WriteLine($" Araç Id : {item.Id}\n Model İsmi : {item.BrandName}\n" +
					$" Renk İsmi : {item.ColorName}\n Şirket İsmi : {item.CompanyName}\n" +
					$" Araç Fiyatı : {item.DailyPrice}\n Müşteri Email'i : {item.Email}\n" +
					$" Müşteri İsmi : {item.FirstName}\n Müşteri Soyadı : {item.LastName}\n" +
					$" Araç Model Yılı : {item.ModelYear}\n Araç Kiralama Tarihi {item.RentDate}\n" +
					$" Aaraç Teslim Tarihi {item.ReturnDate}\n");

				Console.WriteLine("----------------------------------");
			}
		}

		#endregion

	

	
		
	}
}









