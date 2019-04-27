using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPracticWork
{
    public class AddProductToStock
    {
        public void AddProduct(Stock stock)
        {
            Console.WriteLine("Введите название продукта: ");
            string nameOfProduct = Console.ReadLine();
            Console.WriteLine("Введите количество продукта: ");
            int.TryParse(Console.ReadLine(), out int countOfProducts);
            stock.Name = nameOfProduct;
            stock.Count = countOfProducts;
        }
    }
}
