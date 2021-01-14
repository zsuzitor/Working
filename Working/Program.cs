using System;
using System.Collections.Generic;
using System.Threading;
using Working.Models.BL;
using Working.Models.BL.Handlers.Interfaces;
using Working.Models.BL.Repositories;

namespace Working
{
    class Program
    {
        static void Main(string[] args)
        {
            //есть сервис, в нем обработчики, которые что то делают с определенной периодичностью,
            //1 из обработчиков будет создавать задачу на выполнение


            var worker=new WorkerFactory(new WorkerRepository()).GetService();
            worker.AddTaskAsync(new Models.BO.NewTaskToWork("test", 50, false));
            List<ITaskWorkHandler> handlers = new List<ITaskWorkHandler>();

            while (true)
            {
                worker.StartActualTaskHandleAsync(handlers);
                Thread.Sleep(500);
                Console.WriteLine("write 'y' if stop else write anything");
                if (Console.ReadKey().KeyChar == 'y')
                {
                    break;
                }
            }

            Console.WriteLine("Hello World!");
        }
    }
}
