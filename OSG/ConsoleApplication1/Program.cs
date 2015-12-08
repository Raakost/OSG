
using System;
using System.Collections.Generic;
using Gateway.Facade;
using Gateway.DomainModel;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in new Facade().GetTrainerGateway().ReadAll())
            {
                Console.WriteLine("Trainer name: " + item.FirstName);
                if (item.Events != null)
                {
                    foreach (var thing in item.Events)
                    {
                        Console.WriteLine("     Event title: " + thing.Title);
                    }
                }
                
            }
            Console.WriteLine("");
            foreach (var item1 in new Facade().GetNewsGateway().ReadAll())
            {
                Console.WriteLine("News title: " + item1.Title);
            }

            Console.WriteLine();
            Console.WriteLine("Create new event with already existing trainer, ID 1");
            new Facade().GetEventGateway().Create(new Event()
            {
                Title = "Title jep",
                Description = "Disc jep",
                Trainers = new List<Trainer>() { new Facade().GetTrainerGateway().ReadById(1)}
            });

            foreach (var theThing in new Facade().GetEventGateway().ReadAll())
            {
                Console.WriteLine("Event title: " +theThing.Title);
                Console.WriteLine("Event discription: " + theThing.Description);
                foreach (var trainers in theThing.Trainers)
                {
                    Console.WriteLine("     Trainer name: " + trainers.FirstName);
                }
            }
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
