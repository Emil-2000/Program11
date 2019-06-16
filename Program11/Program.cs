using System;
using System.Collections.Generic;
using System.Linq;

namespace Program11
{
    class Program
    {
        static void Main(string[] args)
        {

            string signal = "1110000001100010001110001000111001110011000";
            Console.WriteLine("Исходное сообщение " + signal);

            // флаг подхода к концу строки
            bool NotEnd = true;

            // текущая позиция в строке
            int position = 0;

            // расшифрованное сообщение
            string Message = "";
            do
            {
                if ((position + 3) < signal.Length)
                {
                    string con = signal.Substring(position, 3);
                    char answer = Analyze(con);
                    Console.WriteLine(" " + con + " - " + answer);
                    Message += answer;
                    position += 3;
                }
                else
                {
                    NotEnd = false;
                }

            }
            while (NotEnd);

            Console.WriteLine("Расшифрованное сообщение " + Message);
            Console.ReadLine();

        }

        /// <summary>
        /// Возвращает символ который чаще всего встречается в переданной строке
        /// </summary>
        /// <param name="Signal">Строка из трех символов</param>
        /// <returns></returns>
        static char Analyze(string Signal)
        {
            // создаем коллкцию словарь
            Dictionary<char, int> rating = new Dictionary<char, int>();

            // пробежим по элементам
            for (int i = 0; i < Signal.Length; i++)
            {
                Char El = Signal[i];
                if (rating.ContainsKey(El))
                {
                    // если в словаре есть уже этот символ то его количество увеличиваем
                    rating[El]++;
                }
                else
                {
                    // если в словаре нет символа, то добавляем
                    rating.Add(El, 1);
                }
            }

            // максимальное число элементов в словаре
            int max = 0;

            // символ
            char result = rating.Keys.ToList()[0];

            foreach (char Key in rating.Keys)
            {
                if (rating[Key] > max)
                {
                    max = rating[Key];
                    result = Key;
                }
            }
            return result;
        }


    }
}
