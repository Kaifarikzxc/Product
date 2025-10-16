using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp5
{
    /// <summary>
    /// Класс Молочной продукции
    /// </summary>
    public class Dairy_products
    {
        /// <summary>
        /// Название
        /// </summary>
        public string? Name { get; set; }
        
        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }
        
        /// <summary>
        /// Количество(продукта)
        /// </summary>
        public int Count { get; set; }
        
        /// <summary>
        /// Скидка
        /// </summary>
        public decimal Discount { get; set; }
        
        /// <summary>
        /// Название категории
        /// </summary>
        public string? CategoryName { get; set; }
        
        /// <summary>
        /// Партия
        /// </summary>
        public string? PartyName { get; set; }
        
        /// <summary>
        /// Дата, когда товар привезли
        /// </summary>
        public string? Data { get; set; }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Dairy_products()
        {

        }

        /// <summary>
        /// Конструктор с параметрами содержащий 
        /// (<param name="name">название</param>, <param name="price">цену</param>, <param name="count">количество(продуктов)</param>, 
        /// <param name="discount">скидку</param>, <param name="categoryName">название категории</param>, <param name="partyName">партию</param>, 
        /// <param name="data">дату привезения товара</param>)
        /// </summary>
        /// <param name="name">название</param>
        /// <param name="price">цена</param>
        /// <param name="count">количество(продуктов)</param>
        /// <param name="discount">скидка</param>
        /// <param name="categoryName">название категории</param>
        /// <param name="partyName">партия</param>
        /// <param name="data">дата привезения товара</param>
        public Dairy_products(string? name, decimal price, int count, decimal discount, string? categoryName, string? partyName, string? data)
        {
            Name = name;
            Price = price;
            Count = count;
            Discount = discount;
            CategoryName = categoryName;
            PartyName = partyName;
            Data = data;
        }

        /// <summary>
        /// Статический метод для вывода списка молочной продукции
        /// </summary>
        /// <param name="products2">Список продукции</param>
        public static void InfoDiaryProducts(List<(string categories, List<(string party_name, string data, List<Dairy_products[]> dairy_Products)> party)>? products2)
        {
            //Проверка списка на категории.
            if (products2 == null || products2.Count == 0)
            {
                //Оповещение что категорий не найдено
                Console.WriteLine("Список категорий пуст.");
                //Автоматическое завершение программы.
                return;
            }

            //Запуск цикла для работы с списком категорий молочной продукции.
            while (true)
            {
                Console.WriteLine("Выберите одну из категорий молочной продукции: ");

                //Вывод имеющихся категорий.
                for (int i = 0; i < products2.Count; i++)
                {
                    Console.WriteLine($"{i + 1}, {products2[i].categories}");
                }

                Console.WriteLine();

                //Просьба укзать одну из интересующих категорий
                Console.Write("Введите категорию: ");

                //Получение выбраной категории.
                int choiсe = GetCategoryChoice(products2.Count);

                //Выбраную категорию инедксируем с 0.
                var selected = products2[choiсe - 1];

                //Выбраная категория будет помечаться: 1 или n.
                Console.WriteLine($"\nКатегория: {selected.categories}");

                //Вывод информации для продукции
                Console.WriteLine("Информация о имеющей продукции: ");

                //Проверка на наличие партий в категории.
                if (selected.party == null || selected.party.Count == 0)
                {
                    //Оповещение что партий не найдено
                    Console.WriteLine("Нет доступных партий в этой категории.");
                    //Автоматическое завершение программы.
                    return;
                }

                //В ином случае продолжаем работу.
                else
                {
                    //Перебираем все имеющиеся партии.
                    foreach (var party in selected.party)
                    {
                        //Вывод партий продуктов.
                        PrintBatchInfo(party);
                    }

                    //Помечаем, что весь список выведен, и задача успешно выполнено.
                    Console.WriteLine("Весь список данной категории представлен");

                    //Уточняем у пользователя, хочет ли он изучить другую категорию.
                    Console.WriteLine("Хотите просмотреть другую категорию? (да/нет)\n");

                    //Запуск цикла, для повторного выполнения программы или завершения.
                    while (true)
                    {
                        Console.Write("Ваш выбор: ");
                        //Указываем хотим ли мы просмотреть иную категорию.
                        string? word_choise = Console.ReadLine();

                        //Завершаем или продолжаем работу программы.
                        switch (word_choise?.Trim().ToLower())
                        {
                            case "да":
                                //Используем goto для повторного запуска внешнего цикла при выборе "да" пользователем.
                                //Это позволяет избежать вложенных циклов или дублирования кода.
                                //Выходим из внутренних циклов, переходя по метке.
                                goto ContinueOuterLoop;
                            case "нет":
                                //Завершаем выполнение программы и выходим из метода.
                                return;
                            default:
                                Console.WriteLine("Непонятный ответ. Введите \"да\" или \"нет\".\n");
                                //Остаёмся во внутреннем цикле.
                                continue;
                        }
                    }
                }

                //Метка для выхода из внутренненего цикла.
                ContinueOuterLoop:;
            }

            //Первоначальный вариант реализации, через (switch-case) оставлено для истории.
            //switch (choise)
            //{
            //    case 1:
            //        Console.WriteLine("Информация о имеющей продукции: ");
            //        for(int i = 0; i<products2.Count; i++)
            //        {

            //        }
            //        break;
            //    case 2:
            //        Console.WriteLine("Информация о имеющей продукции: ");
            //        break;
            //}
        }

        /// <summary>
        /// Вспомогательный статический метод, для получения выбранной категории
        /// </summary>
        /// <param name="max">максимальное количество категорий</param>
        /// <returns>Выбраная категория</returns>
        private static int GetCategoryChoice(int max)
        {
            //Запуск цикла для выбора категории.
            while (true)
            {
                //Проверка, что пользователь ввёл корректный номер категории.
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= max)
                    //Выход из цикла, возвращение в основной метод.
                    return choice;

                //Остаёмся во внутреннем цикле.
                Console.WriteLine("Неверный выбор. Попробуйте снова\n");
            }
        }

        /// <summary>
        /// Вспомогательный статический метод для вывода информации о партии и продукции
        /// </summary>
        /// <param name="batch">Партии</param>
        private static void PrintBatchInfo((string party_name, string data, List<Dairy_products[]> dairy_Products) batch)
        {
            Console.WriteLine($"Партия: {batch.party_name}\nДата-{batch.data}");
            Console.WriteLine(new string('#', 15));

            //Проверка на наличие продуктов в партии
            if (batch.dairy_Products == null || batch.dairy_Products.Count == 0)
            {
                //Оповещение что продуктов в партии не найдено
                Console.WriteLine("Продукция в партии отсутствует.");
                //Автоматическое завершение программы.
                return;
            }

            //В ином случае продолжаем работу
            else
            {
                //Перебираем все имеющие объекты продукции партии
                foreach (var products1 in batch.dairy_Products)
                {
                    //Перебираем всю продукцию текущего объекта
                    foreach (var item in products1)
                    {
                        Console.WriteLine($"Название: {item.Name}\nСтоимость: {item.GetTotalPrice():F2} руб.");
                        Console.WriteLine($"Количество: {item.Count}");
                        Console.WriteLine($"Скидка: {item.Discount}%");
                        Console.WriteLine(new string('-', 30));
                    }
                }
            }
        }

        /// <summary>
        /// Метод для подсчёта стоимости продукта
        /// </summary>
        /// <returns>Стоимость продукта</returns>
        private double GetTotalPrice()
        {
            //Считаем общую стоимость
            decimal result = Price * Count * (1 - Discount / 100);
            
            //Возращаем результат подсчёта
            return (double)result;
        }
    }
}