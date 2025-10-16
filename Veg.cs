using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    internal class Veg

    {
        public string[] Info = { 
            "Морковь",
            "Огурец",
            "Помидор" };

        public void ShowInfo()
        {
            Console.WriteLine("Список овощей:");
            foreach (var Veg in Info)
            {
                Console.WriteLine(Veg);
            }
        }
    }
}
