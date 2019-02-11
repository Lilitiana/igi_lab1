using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_1
{
    public static class Initialization
    {
        public static void InitializationDB(SPASalonContext db)
        {
            db.Database.EnsureCreated();
            if(db.TypeOfServices.Any())
            {
                return;
            }
            TypeOfService typeOfService1 = new TypeOfService() { Name="Парикмахерские услуги", Description="Стрижки, укладки и прочее"};
            TypeOfService typeOfService2 = new TypeOfService() { Name = "Услуги визажиста", Description = "Макияж любой сложности" };
            TypeOfService typeOfService3 = new TypeOfService() { Name = "Услуги косметолога", Description = "Маски, пиллинг, чистка лица" };
            TypeOfService typeOfService4 = new TypeOfService() { Name = "Услуги массажиста", Description = "Тайский массаж, иглоукалывание, релаксирующий массаж" };
            TypeOfService typeOfService5 = new TypeOfService() { Name = "Маникюр", Description = "Покрытие гель-лаком, наращивание и др." };
            db.TypeOfServices.AddRange(new TypeOfService[] { typeOfService1, typeOfService2, typeOfService3, typeOfService4, typeOfService5 });
            db.SaveChanges();

            Service service1 =new Service { Name="Стрижка", Description="Стрижки на любую длину волос", Cost=20, TypeOfService= typeOfService1 };
            Service service2 = new Service { Name = "Покраска", Description = "Покраска волос", Cost = 40, TypeOfService = typeOfService1 };
            Service service3 = new Service { Name = "Колорирование", Description = "Покраска прядей", Cost = 50, TypeOfService = typeOfService1 };
            Service service4 = new Service { Name = "Омбре", Description = "Постепенное осветление (Снизу волосы светлее чем сверху )", Cost = 50, TypeOfService = typeOfService1 };
            Service service5 = new Service { Name = "Повседневный макияж", Description = "Простой макияж на каждый день", Cost = 10, TypeOfService = typeOfService2 };
            Service service6 = new Service { Name = "Праздничный макияж", Description = "Макияж на свадьбу/выпускной/другие праздники", Cost = 15, TypeOfService = typeOfService2 };
            Service service7 = new Service { Name = "Маска", Description = "Маска для лица из водорослей/глины/шоколада", Cost = 9, TypeOfService = typeOfService3 };
            Service service8 = new Service { Name = "Пиллинг", Description = "Химический пиллинг", Cost = 15, TypeOfService = typeOfService3 };
            Service service9 = new Service { Name = "Чистка лица", Description = "Механическая чистка лица", Cost = 21, TypeOfService = typeOfService3 };
            Service service10 = new Service { Name = "Тайский массаж", Description = "Просто тайский массаж, ничего такого", Cost = 26, TypeOfService = typeOfService4 };
            Service service11 = new Service { Name = "Иглоукалывание", Description = "Или почувствуй себя дикообразом", Cost = 30, TypeOfService = typeOfService4 };
            Service service12 = new Service { Name = "Релаксирующий массаж ", Description = "Классический массаж с аромомаслами", Cost = 25, TypeOfService = typeOfService4 };
            Service service13 = new Service { Name = "Наращивание ногтей ", Description = "Наращивание ногдей любой формы и длины", Cost = 10, TypeOfService = typeOfService5 };
            Service service14 = new Service { Name = "Покрытие гель-лаком ", Description = "Покрытие ногтей стойким гель-лаком с декоративными элементами на выбор", Cost = 12, TypeOfService = typeOfService5 };
            Service service15 = new Service { Name = "Коррекция", Description = "Коррекция нарощенных ногтей", Cost = 10, TypeOfService = typeOfService5 };
            db.Services.AddRange(new Service[] { service1, service2, service3, service4, service5, service6, service7, service8, service9, service10, service11, service12, service13, service14, service15 });
            db.SaveChanges();

            Customer customer1 = new Customer { FullName = "Александрова Екатерина Анатольевна", PhoneNumber = "375447856245 ", TotalCost = 60 };
            Customer customer2 = new Customer { FullName = "Попичева Арина Валерьевна", PhoneNumber = "37544788145 ", TotalCost = 26 };
            Customer customer3 = new Customer { FullName = "Мазиков Максим Викторович", PhoneNumber = "375447126205 ", TotalCost = 36 };
            db.Customers.AddRange(new Customer[] { customer1, customer2, customer3 });
            db.SaveChanges();

            DateTime date = new DateTime(2019, 7, 20);
            CustomerService customerService1 = new CustomerService { Service = service1, Customer = customer1, Date = date };
            CustomerService customerService2 = new CustomerService { Service = service2, Customer = customer1, Date = date };
            date = new DateTime(2019, 3, 11);
            CustomerService customerService3 = new CustomerService { Service = service10, Customer = customer2, Date = date };
            date = new DateTime(2019, 4, 22);
            CustomerService customerService4 = new CustomerService { Service = service8, Customer = customer3, Date = date };
            CustomerService customerService5 = new CustomerService { Service = service9, Customer = customer3, Date = date };
            db.CustomerServices.AddRange(new CustomerService[] { customerService1, customerService2, customerService3, customerService4, customerService5 });
            db.SaveChanges();
        }
    }
}
