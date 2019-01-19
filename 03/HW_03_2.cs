using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_03
{
    class Program
    {
        static void Main(string[] args)
        {
            //Что-то я совсем не придумал, как тут прикрутить break и continue, 
            //может, показать владение ими на еще одном задании?
            Console.Write("Введите число: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Следующие числа - простые:");
            int counter = 0;
            while (counter<=number)
            {
                Check(counter);
                counter++;
            }
            Console.ReadKey();
        }

        static void Check(int number)
        {
            //Для проверки использует утверждение, что простое число 
            //должно делиться только на единицу и на самого себя.
            //Проверять будем до квадратного корня из самого числа
            //Вики:является ли n кратным целому числу от 2 до sqrt(n)
            int sqrtNumber = Convert.ToInt32(Math.Sqrt(number));
            for (int i = 2; i <= sqrtNumber; i++)
            {
                //Если находится хоть одно число, на которое number делится без остатка,
                //значит, number не простое число
                if (number % i == 0)
                    return;
            }
            Console.WriteLine(number);
        }
    }
}
