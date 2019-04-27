using StockPracticeWork27._04._2019;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPracticWork
{
    class Program
    {
        static void Main(string[] args)
        {
            AddProductToStock addProductToStock = new AddProductToStock();
            string removedProduct = null;
            string changedProduct = null;
            using (var context = new StockContext())
            {
                var stock = new Stock();
                while (true) {
                    Console.WriteLine("Что вы хотите?" +
                        "\n1 - Добавить товар на склад." +
                        "\n2 - Удалить товар со склада." +
                        "\n3 - Изменить товар на складе");
                    if (int.TryParse(Console.ReadLine(), out int number)) {
                        switch (number)
                        {
                            case 1:
                                addProductToStock.AddProduct(stock);
                                context.Stocks.Add(stock);
                                context.SaveChanges();
                                break;
                            case 2:
                                var stocks = context.Stocks.ToList();
                                Console.WriteLine("Что вы хотите удалить: ");
                                removedProduct = Console.ReadLine();
                                var resultOfDelete = context.Stocks.ToList().Where(x => x.Name == removedProduct);
                                foreach (var s in resultOfDelete)
                                {
                                    context.Stocks.Remove(s);
                                }
                                context.SaveChanges();
                                break;
                            case 3:
                                int i = 1;
                                Console.WriteLine("Какой продукт хотите изменить? Пишите название. ");
                                Console.WriteLine("Список продуктов: ");
                                foreach(var s in context.Stocks.ToList())
                                {
                                    Console.WriteLine(i++ + "." + s.Name);
                                }
                                changedProduct = Console.ReadLine();
                                var resultOfChange = context.Stocks.ToList().Where(s => s.Name == changedProduct);
                                Console.WriteLine("1 - Изменить название продукта" +
                                    "\n2 - Изменить количество продукта");
                                if (int.TryParse(Console.ReadLine(), out int result))
                                {
                                    switch (result)
                                    {
                                        case 1:
                                            Console.WriteLine("Новое название продукта: ");
                                            string nameOfNewProduct = Console.ReadLine();
                                            foreach (var s in resultOfChange)
                                            {
                                                s.Name = nameOfNewProduct;
                                            }
                                            context.SaveChanges();
                                            break;

                                        case 2:
                                            Console.WriteLine("Новое количество продукта: ");
                                            int countOfNewProduct = int.Parse(Console.ReadLine());
                                            foreach (var s in resultOfChange)
                                            {
                                                s.Count = countOfNewProduct;
                                            }
                                            break;
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Ошибка");
                                }
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка");
                    }
                }
            }

            }
        }
    }

