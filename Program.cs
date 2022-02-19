using System;

namespace ROT13
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите номер операции:1 - зашифровать, 2 - расшифровать");
                int read;
                bool reading = int.TryParse(Console.ReadLine(), out read);
                if (!reading | (read != 1 & read != 2))
                {
                    Console.WriteLine("Похоже вы ввели что-то не так");
                    Console.WriteLine("Нажмите любую клавишу");
                    Console.ReadKey(true);
                    Console.Clear();
                    continue;
                }
                Console.WriteLine("Введите слово, которое хотите зашифровать.");
                string phrase = Console.ReadLine();
                //if (CheckString(phrase) == false)
                //{
                //    Console.WriteLine("Мы работаем только с кириллицой");
                //    return;
                //}
                Console.WriteLine("Введите ключ шифрования.");
                int key;
                bool keybourd = int.TryParse(Console.ReadLine(), out key);
                if (!keybourd | key <= 0)
                {
                    Console.WriteLine("Ключом должно быть число");
                    Console.WriteLine("Нажмите любую клавишу");
                    Console.ReadKey(true);
                    Console.Clear();
                    continue;
                }
                if (read == 1)
                {

                    Console.WriteLine($"Ваше зашифрованное слово {Encrypt(phrase, key)}");
                }
                else if (read == 2)
                {

                    Console.WriteLine($"Ваше расшифрованное слово {Unencrypt(phrase, key)}");
                }
                else
                {
                    Console.WriteLine("Ты дурак");
                    
                }
                Console.Clear();
            }
            
        }
        static string Encrypt(string phrase, int key)
        {
            char[] simvols = phrase.ToCharArray();
            for (int i = 0; i < simvols.Length; i++)
            {
                if (simvols[i] < 1040 | simvols[i] > 1103)
                {
                    continue;
                }
                simvols[i] += (char)key;
                if(simvols[i] > 1103)
                {
                    int diff = simvols[i] - 1103;
                    simvols[i] = (char)(1040 + diff);
                    
                }
                
            }
            string abc = new string(simvols);
            return abc;
        }
        static string Unencrypt(string phrase,int key)
        {
            char[] simvols = phrase.ToCharArray();
            for (int i = 0; i < simvols.Length; i++)
            {
                if (simvols[i] < 1040 | simvols[i] > 1103)
                {
                    continue;
                }
                simvols[i] -= (char)key;
                if(simvols[i] < 1040)
                {
                    int diff = 1040 - simvols[i];
                    simvols[i] = (char)(1103 - diff);
                }

            }
            string abc = new string(simvols);
            return abc;
        }
        static bool CheckString(string phrase)
        {
            char[] simvols = phrase.ToCharArray();
            for (int i = 0; i < simvols.Length; i++)
            {
                
                if(simvols[i] < 1040 | simvols[i] > 1103)
                {
                    return false;
                }
                
            }
            return true;
        }
        
    }
}
