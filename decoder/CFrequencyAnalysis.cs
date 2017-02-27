using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Decoder {
    /// <summary>
    /// класс частотного анализа: анализ, сравнение, замена
    /// </summary>
    class CFrequencyAnalysis {

        /// <summary>
        /// частотный анализ с указанными зашифрованным файлом и файлом-примером текста
        /// </summary>
        /// <param name="sCiphedText">зашифрованный текст</param>
        /// <param name="sCompareText">пример текста для построения процента появления букв для нормального текста</param>
        public void frequencyAnalysis(string sCiphedText = "file.txt", string sCompareText = "rus_file.txt") {

            char [,] 
                cCiphedText  = getCharCount(sCiphedText),
                cCompareText = getCharCount(sCompareText);

            getPercentage(cCiphedText);
            Console.WriteLine("===");
            getPercentage(cCompareText);


            Console.WriteLine("\nEND\n");
        }

        /// <summary>
        /// подсчет количества различных символов (А- 23, Б-33 и т.п.)
        /// </summary>
        /// <param name="sFileName" default="file.txt">Считываемый файл, по дефолту выбран</param>
        /// <param name="bNeedConsoleReturn" default="false">вывод в консоль. отладочная</param>
        /// <returns>массив "буква - количество"</returns>
        private char[,] getCharCount(string sFileName = "file.txt", bool bNeedConsoleReturn = false) {
            
            StreamReader srFileReader = new StreamReader(sFileName);
            String sFileContent = srFileReader.ReadToEnd();

            // формирование массива А-Я и "другой символ (_)"
            char[,] message = new char[2, 33];
            int count = 0;            
            for (int x = 'А'; x <= 'Я'; x++) {
                message[0, count] = (char)x;
                count++;
            }
            message[0, count] = '_';

            // подсчет символов
            foreach (char cFileChar in sFileContent) {
                count = 0;
                for (int x = 'А'; x <= 'Я'; x++) {
                    if (cFileChar == x) {
                        message[1, count]++;
                    }
                    count++;
                }
                if (cFileChar == ' ' || cFileChar == ',' || cFileChar == '—') {
                    message[1, count]++;
                }
            }

            // вывод результата
            if (bNeedConsoleReturn) {
                for (int x = 0; x <= 32; x++) {
                    Console.Write(message[0, x] + " = " + (int)message[1, x] + "\n");
                }
            }

            return message;
        }

        /// <summary>
        /// процентное количество от общего числа
        /// </summary>
        /// <param name="cSymbolsCount">подсчет процентов</param>
        /// <returns>список подсчитанных значений"</returns>
        private List<float> getPercentage(char[,] cSymbolsCount) {
            List<float> fPercentage = new List<float>();
            
            int nTotalCount = 0;
            for (int x = 0; x <= 32; x++) {
                nTotalCount += (int)cSymbolsCount[1, x];
            }

            for (int x = 0; x <= 32; x++) {
                fPercentage.Add(cSymbolsCount[1, x] / (float)nTotalCount * 100);
            }

            // дебаг
            if (false) {
                for (int x = 0; x <= 32; x++) {
                    Console.WriteLine(cSymbolsCount[0, x] + " " + fPercentage[x]);
                }
            }

            return fPercentage;
        }

        /// <summary>
        /// заготовка функции сравнения
        /// </summary>
        /// <param name="fCiphedList">зашифрованный текст</param>
        /// <param name="fExampleList">сравниваемый текст</param>
        /// <returns>массив значений "А(зашифрованнйы) - Ы(расшифрованный)</returns>
        private char[,] comparePercentages(List<float> fCiphedList, List<float> fExampleList) {
            char[,] cToReplace = new char[2,33];

            return cToReplace;
        }
    }
}
