using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Millionaire
{
    class Program
    {
        static void Main(string[] args)
        {
            const int goal = 1000000;
            Console.Write("Введите вашу зарплату (целое положительное число, копейки нам не нужны): ");
            int salary;
            try
            {
                salary = Math.Abs(Convert.ToInt32(Console.ReadLine()));
            }
            catch (Exception)
            {
                CurseYou();
                return;
            }
            Console.Write("Введите ваши ежемесячные расходы (аналогично): ");
            int expences;
            try
            {
                expences = Math.Abs(Convert.ToInt32(Console.ReadLine()));
            }
            catch (Exception)
            {
                CurseYou();
                return;
            }
            if (expences >= salary)
            {
                Console.WriteLine("Так вам никогда не стать миллионером! Измените свою жизнь!");
                Console.ReadKey();
                return;
            }
            int savings = 0;
            int monthsCount = 0;
            Console.WriteLine("Начинаем копить...");
            while (savings<=goal)
            {
                //Для красоты, наглядности и выпендрежа вставим графический процесс накопления денег
                Console.Write("*");
                System.Threading.Thread.Sleep(50);
                savings += (salary - expences);
                monthsCount++;
            }
            Console.WriteLine();
            Console.WriteLine("Поздравляю, вы миллионер! Вы накопили {0} рублей и это заняло у вас всего {1} месяцев!",savings,monthsCount);
            Console.ReadKey();
        }
        static void CurseYou()
        {
            Console.WriteLine("Ну я же вас просил...");
            Console.ReadKey();
        }
    }
}
