using System;
using Working.Models.BL;

namespace Working
{
    class Program
    {
        static void Main(string[] args)
        {
            //есть сервис, в нем обработчики, которые что то делают с определенной периодичностью,
            //1 из обработчиков будет создавать задачу на выполнение


            new WorkerFactory().GetService();


            Console.WriteLine("Hello World!");
        }
    }
}
