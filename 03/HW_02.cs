using System;
using System.Globalization;

namespace HW_02_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Узнаем системный разделитель целой и дробной части
            NumberFormatInfo numberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
            string decimalSeparator = numberFormatInfo.NumberDecimalSeparator;
            double credit, percentage;
            const int monthsInYear=12;
            //Не стал заморачиваться и высчитывать точное число дней в году, принял равным 365
            const int daysInYear = 365;
            Console.Write("Введите желаемую сумму кредита: ");
            //Проверяем корректность ввода
            try
            {
                string input = Console.ReadLine();
                //В зависимости от системных настроек,разделителем целой и дробной частей может быть
                //как запятая, так и точка. При попытке преобразования строки в double может вылететь
                //эксепшен. Поэтому приходится заменять точку или запятую в строке
                //на системный разделитель целой и дробной частей
                input=input.Replace(".",decimalSeparator);
                input = input.Replace(",", decimalSeparator);
                credit = Convert.ToDouble(input);
            }
            catch (Exception)
            {
                Console.WriteLine("Введите корректную сумму!");
                Console.ReadKey();
                return;
            }
            Console.Write("Введите желаемый процент: ");
            try
            {
                string input = Console.ReadLine();
                //Аналогично предыдущему комментарию
                input = input.Replace(".", decimalSeparator);
                input = input.Replace(",", decimalSeparator);
                percentage = Convert.ToDouble(input);
            }
            catch (Exception)
            {
                Console.WriteLine("Введите корректный процент!");
                Console.ReadKey();
                return;
            }
            //Берем по модулю для избавления от возможного отрицательного числа
            credit = Math.Abs(credit);
            percentage = Math.Abs(percentage);
            percentage /= 100;
            //Округлим до копеек
            double loanBody = Math.Round(credit / monthsInYear,2);
            //Для интереса посчитаем общую выплаченную сумму
            double totalPayment = 0;
            //Потребуется для вычисления количества дней в месяце
            int currentYear = Convert.ToInt32(DateTime.Now.Year);
            //Начинаем с единицы, поскольку индекс месяца в DateTime идет с единицы
            for (int i = 1; i <= 12; i++)
            {
                //Получаем число дней в месяце
                int daysInMonth = DateTime.DaysInMonth(currentYear, i);
                //Высчитаем платеж в данном месяце, округлив до копеек
                double monthlyPayment = Math.Round(credit * percentage * daysInMonth / daysInYear + loanBody,2);
                totalPayment += monthlyPayment;
                credit -= loanBody;
                Console.WriteLine("Вы должны заплатить {0} рублей в конце месяца {1}.",monthlyPayment,DateTimeFormatInfo.CurrentInfo.GetMonthName(i));
            }
            Console.WriteLine("Всего вы заплатили {0} рублей.",totalPayment);
            Console.ReadKey();
        }
    }
}
