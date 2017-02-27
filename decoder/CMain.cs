using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Decoder {
    /// <summary>
    /// класс меню декодера
    /// </summary>
    class CMain {
        static String[] menuValues = { "1. Шифр Цезаря", "2. Цифры стат. анализа", "3. Выход" };
        public static bool exit = false;

        /// <summary>
        /// вывод меню
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args) {

            while (exit == false) {
                menuToConsole();
                int checkedMenu = Convert.ToInt32(Console.ReadLine());
                switch (checkedMenu) {
                    case 1:
                        // объект декодера
                        CCaesar decoder = new CCaesar();
                        Console.WriteLine("\nВыбран метод шифрования \"Шифр Цезаря\"... ");
                        for (int i = 33; i > 0; i--) {
                            decoder.decode("file.txt", i, "Caesar_output_" + i.ToString() + ".txt");
                        }
                        Console.WriteLine("Готово! \n=========\n");
                        break;
                    case 2:
                        CFrequencyAnalysis getShit = new CFrequencyAnalysis();
                        getShit.frequencyAnalysis();
                        break;
                    case 3:
                        exit = true;
                        break;
                    default : 
                        Console.WriteLine("Неправильно выбран пункт меню! Повторите ввод");
                        break;
                }
                
            }
        }
        /// <summary>
        /// вывод пунктов меню в консоль
        /// </summary>
        static void menuToConsole() {
            Console.WriteLine("Выберите метод шифрования: ");
            foreach (string menuPoint in menuValues) {
                Console.WriteLine(menuPoint);
            }
        }
    }
}
