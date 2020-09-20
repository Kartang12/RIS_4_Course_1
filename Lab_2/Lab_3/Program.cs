using System;
using System.Collections.Generic;

namespace Lab_3
{
    class Program
    {
        delegate void Method();
        static void Main(string[] args)
        {
            Dictionary<int, Method> methods = new Dictionary<int, Method>()
            {
                {1, Reporter.CreateReport},
                {2, Reporter.ShowReport},
                {3, Reporter.OpenReport }

                
                // {4, }
            };
            while (true)
            {
                Console.WriteLine("Выберите действие:\n" +
                                  "1.Создать отчет по лекции\n" +
                                  "2.Просмотреть посещаемость\n" +
                                  "3.Изменить отчет");
                int a = Int32.Parse(Console.ReadLine());
                methods[a].Invoke();
            }
        }
    }
}
