using System;
using System.Windows;
using System.Threading;
using System.Text;
using System.Collections.Generic;

namespace ConsoleApp5
{
    /// <summary>
    /// Основной класс
    /// </summary>
    public class Programm
    {
        /// <summary>
        /// Метод точки входа в программу
        /// </summary>
        /// <param name="args">массив строк</param>
        static void Main(string[] args)
        {
            //Заполнение первой молочной продукции
            var dairyArrays1 = new Dairy_products[]
            {
                new Dairy_products { Name = "Молоко", Price = 90, Count = 2, Discount = 10 },
                new Dairy_products { Name = "Кефир", Price = 70, Count = 1, Discount = 5 }
            };

            //Заполнение второй молочной продукции
            var dairyArrays2 = new Dairy_products[]
            {
                new Dairy_products { Name = "Сыр Голландский", Price = 300, Count = 1, Discount = 0 },
                new Dairy_products { Name = "Сыр Чеддер", Price = 350, Count = 1, Discount = 5 }
            };

            //Заполнение категорий и партий
            var categories = new List<(string CategoryName, List<(string BathcName, string data, List<Dairy_products[]> dairy_Products)> Batches)>
            {
               ("Молочные напитки", new List<(string, string, List<Dairy_products[]>)>
                 {
                    (
                       "№1", "19 января", new List<Dairy_products[]> { dairyArrays1 }
                    ),

                    (
                       "№2", "12 февраля", new List<Dairy_products[]> {dairyArrays1}
                    ),

                    (
                       "№3", "21 марта", new List<Dairy_products[]> {dairyArrays1}
                    ),
                 }
               ),

               ("Сыры", new List<(string, string, List<Dairy_products[]>)>
                 {
                    (
                      "№1", "20 февраля",new List<Dairy_products[]> { dairyArrays2 }
                    ),

                    (
                      "№2", "30 марта",new List<Dairy_products[]> { dairyArrays2 }
                    ),

                    (
                      "№3", "24 апреля",new List<Dairy_products[]> { dairyArrays2 }
                    ),
                 }
               )
            };

            //Метод для работы со списком
            Dairy_products.InfoDiaryProducts(categories);

            //Вывод на консоль
            Console.ReadLine();

            //Первоначальный вариант вывода элементов на консоль
            //foreach (var (category, productsArrays) in categories)
            //{
            //    Console.WriteLine($"Категория: {category}");
            //    foreach (var productsArray in productsArrays)
            //    {
            //        foreach (var productes in productsArray)
            //        {
            //            Console.WriteLine($"{productes.Name} - {productes.GetTotalPrice():F2} руб.");
            //        }
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}