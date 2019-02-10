using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Lab_1
{
    class Program
    {
        static SPASalonContext db = new SPASalonContext();

        static void Main(string[] args)
        {
            Initialization.InitializationDB(db);
            Process();
            ReadKey();
        }

        static void Process()
        {
            WriteLine("1) Выборка всех данных из таблицы, стоящей в схеме базы данных на стороне отношения «один» ");
            List<Action> actions = db.Actions.ToList();
            WriteLine("Акции:");
            foreach (Action a in actions)
            {
                WriteLine("Id:" + a.ActionID + " Название акции:" + a.Name + " Акция на какую услугу:" + a.ServiceID + " Цена на услугу с учётом акции" + a.DiscountPrice);
            }

            WriteLine("\n2) Выборка данных из таблицы, стоящей в схеме базы данных на стороне отношения «один», отфильтрованные по определенному условию, налагающему ограничения на одно или несколько полей ");
            actions = db.Actions.Where(p => p.DiscountPrice < 13).ToList();
            WriteLine("\nАкции со стоимостью не более 13:");
            foreach (Action a in actions)
            {
                WriteLine("Название акции: " + a.Name + " Стоимость:" + a.DiscountPrice);
            }

            WriteLine("\n3)Выборка данных, сгруппированных по любому из полей данных с выводом какого-либо итогового результата (min, max, avg, сount или др.) по выбранному полю из таблицы, стоящей в схеме базы данных на стороне отношения «многие» ");
            WriteLine("Самая низкая цена на услугу с id вида услуги=1:");
            WriteLine(db.Services.Where(p => p.TypeOfServiceID == 1).Min(p => p.Cost));

            WriteLine("\n4)	Выборка данных из двух полей двух таблиц, связанных между собой отношением «один-ко-многим» ");
            WriteLine("Услуга и её вид: ");
            var list = db.TypeOfServices.Join(db.Services, p => p.TypeOfServiceID, c => c.TypeOfServiceID, (p, c) => new { IdType = p.TypeOfServiceID, NameType = p.Name, Id = c.ServiceID, Name = c.Name });
            foreach (var l in list)
            {
                WriteLine("Id вида услуги: " + l.IdType + " Вид услуги:" + l.NameType + " Id услуги: " + l.Id + " Услуга: " + l.Name);
            }

            WriteLine("\n5)	Выборка данных из двух таблиц, связанных между собой отношением «один-ко-многим» и отфильтрованным по некоторому условию, налагающему ограничения на значения одного или нескольких полей ");
            WriteLine("Услуги с ценой > 15:");
            var list2 = db.TypeOfServices.Join(db.Services, p => p.TypeOfServiceID, c => c.TypeOfServiceID, (p, c) => new { NameType = p.Name, Name = c.Name, Cost = c.Cost }).Where(p => p.Cost > 15);
            foreach (var l in list2)
            {
                WriteLine("Вид услуги:" + l.NameType + " Услуга: " + l.Name + " Цена: " + l.Cost);
            }

            WriteLine("\n6) Вставка данных в таблицы, стоящей на стороне отношения «Один»");
            WriteLine("Вставка новой акции:");
            Service service = db.Services.Where(p => p.ServiceID == 2).First();
            Action action = new Action() { Name = "Новая скидка", DiscountPrice = 12, ServiceID = service.ServiceID };
            db.Actions.Add(action);
            db.SaveChanges();
            actions = db.Actions.ToList();
            foreach (Action a in actions)
            {
                WriteLine("Id акции: " + a.ActionID + " Название: " + a.Name + " Цена по акции: " + a.DiscountPrice);
            }

            WriteLine("\n7) Вставка данных в таблицы, стоящей на стороне отношения «Многие»");
            WriteLine("Вставка новой услуги:");
            TypeOfService typeOfService = db.TypeOfServices.Where(p => p.TypeOfServiceID == 1).First();
            service = new Service() { Name = " Новая услуга", Description = " Описание", Cost = 100, TypeOfService = typeOfService };
            db.Services.Add(service);
            db.SaveChanges();
            var services = db.Services.ToList();
            foreach (Service s in services)
            {
                WriteLine("Id: " + s.ServiceID + " Название услуги: " + s.Name + " Описание: " + s.Description + " Цена: " + s.Cost + " Id типа услуги:" + s.TypeOfServiceID);
            }
            WriteLine("8) Удаление данных из таблицы, стоящей на стороне отношения «Один»");
            WriteLine("Удаление акции из пункта 6:");
            db.Actions.Remove(action);
            db.SaveChanges();
            actions = db.Actions.ToList();
            foreach (Action a in actions)
            {
                WriteLine("Id акции: " + a.ActionID + " Название: " + a.Name + " Цена по акции: " + a.DiscountPrice);
            }

            WriteLine("9) Удаление данных из таблицы, стоящей на стороне отношения «Многие» ");
            WriteLine("Удаление услуги из пункта 7:");
            db.Services.Remove(service);
            db.SaveChanges();
            services = db.Services.ToList();
            foreach (Service s in services)
            {
                WriteLine("Id: " + s.ServiceID + " Название услуги: " + s.Name + " Цена: " + s.Cost + " Id типа услуги:" + s.TypeOfServiceID);
            }

            WriteLine("10) Обновление удовлетворяющих определенному условию записей в любой из таблиц базы данных ");
            WriteLine("Услуги до обновления: ");
            services = db.Services.ToList();
            foreach (Service s in services)
            {
                WriteLine("Id: " + s.ServiceID + " Название услуги: " + s.Name + " Цена: " + s.Cost);
            }
            services = db.Services.Where(p => p.TypeOfServiceID == 4).ToList();
            foreach (Service s in services)
            {
                s.Cost = 10;
            }
            db.SaveChanges();
            WriteLine("Услуги после обновления: ");
            services = db.Services.ToList();
            foreach (Service s in services)
            {
                WriteLine("Id: " + s.ServiceID + " Название услуги: " + s.Name + " Цена: " + s.Cost);
            }
        }
    }
}
