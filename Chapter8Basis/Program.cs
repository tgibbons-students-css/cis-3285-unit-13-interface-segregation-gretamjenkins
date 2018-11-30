using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CrudImplementations;
using Model;

namespace Chapter8Basis
{
    class Program
    {
        static void Main(string[] args)
        {
            Order orderObj = new Order();
            orderObj.id = Guid.NewGuid();
            orderObj.product = "Nutcracker";
            orderObj.amount = 4;

            Item itemObj = new Item();
            itemObj.product = "Ornament";
            itemObj.cost = 10;

            Console.WriteLine("=========CreateSeparateServices=========");
            OrderController sep = CreateSeparateServices();
            sep.CreateOrder(orderObj);            // save order to database
            sep.DeleteOrder(orderObj);            // delete order from database

            Console.WriteLine("=========CreateSingleService=========");
            OrderController sing = CreateSingleService();
            sing.CreateOrder(orderObj);            // save order to database
            sing.DeleteOrder(orderObj);            // delete order from database

            Console.WriteLine("=========CreateSeparateItemServices=========");
            ItemController sepItm = CreateSeparateItemServices();
            sepItm.CreateItem(itemObj);            // save order to database
            sepItm.DeleteItem(itemObj);            // delete order from database

            Console.WriteLine("=========GenericController<Order>=========");
            // New "factory" type class to handle any type of entity
            GenericControllerServices<Order> genericServices = new GenericControllerServices<Order>();
            GenericController<Order> genericOrder = genericServices.CreateGenericTEntityServices();
            genericOrder.CreateEntity(orderObj);

            Console.WriteLine("=========GenericController<Item>=========");
            // New "factory" type class to handle any type of entity
            GenericControllerServices<Item> genericItemServices = new GenericControllerServices<Item>();
            GenericController<Item> genericItem = genericItemServices.CreateGenericTEntityServices();
            genericItem.CreateEntity(itemObj);

            Console.WriteLine("Hit any key to quit");
            Console.ReadKey();
        }

        static OrderController CreateSeparateServices()
        {
            var reader = new Reader<Order>();
            var saver = new Saver<Order>();
            var deleter = new Deleter<Order>();
            return new OrderController(reader, saver, deleter);
        }

        static OrderController CreateSingleService()
        {
            var crud = new Crud<Order>();
            return new OrderController(crud, crud, crud);
        }

        static ItemController CreateSeparateItemServices()
        {
            var reader = new Reader<Item>();
            var saver = new Saver<Item>();
            var deleter = new Deleter<Item>();
            return new ItemController(reader, saver, deleter);
        }
    }
}
