using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTwo
{
	internal class Program
	{
		static void Main(string[] args)
		{
			AddCategory(new Category(2, "Холодильники"));
			GetAllCategory();
			MyTransaction();

			Console.ReadLine();
		}

		static void AddCategory(Category item) 
		{
			using (StoreEntities storeEntities = new StoreEntities())
			{
				Category exist = storeEntities.Category.Where((x) => x.Id == item.Id && x.Name == item.Name).FirstOrDefault();
				if (exist == null)
				{
					storeEntities.Category.Add(item);
					storeEntities.SaveChanges();
				}
			}
		}
		static void GetAllCategory()
		{
			using (StoreEntities storeEntities = new StoreEntities())
			{
				List<Category> list = storeEntities.Category.ToList();
				foreach (Category item in list)
				{ 
					Console.WriteLine(item);
				}
			}
		}
		static void MyTransaction()
		{
			using (StoreEntities storeEntities = new StoreEntities())
			{
				using (System.Data.Entity.DbContextTransaction tran = storeEntities.Database.BeginTransaction())
				{
					try
					{
						Category cat = new Category(2, "холодильник");
						storeEntities.Category.Add(cat);
						storeEntities.Category.Remove(cat);
						storeEntities.SaveChanges();
						tran.Commit();

					}
					catch (Exception ex)
					{
						tran.Rollback();
					}
				}
			}
		}
	}
}
