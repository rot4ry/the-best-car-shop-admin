using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Database_Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Context databaseContext = new Context();
            databaseContext.Database.EnsureCreated();

            Insert(databaseContext);
            
            databaseContext.SaveChanges();
        }

        static void Insert(Context context)
        {
            int rowsAmount;
            Console.WriteLine("How many products should I generate?");

            try
            {
                rowsAmount = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < rowsAmount; i++)
                {
                    context.Products.Add(InputBuilder.BuildProduct());
                }
            }
            catch (Exception d)
            {
                Console.WriteLine($"{d.Message} \n");
                Insert(context);
            }
        }
    }
}

