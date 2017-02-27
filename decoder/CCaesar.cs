using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Decoder {
    class CCaesar {
        public char[] aRussianAlphabet = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я' };

        /// <summary>
        /// декодирования по шифру цезаря
        /// </summary>
        /// <param name="sFileName">зашифрованный файл</param>
        /// <param name="nShiftN" default="1">сдвигя</param>
        /// <param name="sOutputName" default="output.txt">название выходного файла, по дефолту output.txt</param>
        /// <returns>массив "буква - количество"</returns>
        public void decode(string sFileName, int nShiftN = 1, string sOutputName = "output.txt") {
            StreamReader fileStream = null;
            StreamWriter fileWriter = null;
            string sFileContent;

            // пытаюсь загрузить файл
            try {
                fileStream = new StreamReader(sFileName);
            }
            catch (Exception fileLoadError) {
                Console.WriteLine(fileLoadError.ToString());
                return;
            }
            fileWriter = new StreamWriter(sOutputName);
            sFileContent = fileStream.ReadToEnd();
            for (int i = 0; i < sFileContent.Length; i++) {
                fileWriter.Write(this.charShifter(nShiftN, sFileContent[i]).ToString());
            }

            fileWriter.Close();
            fileStream.Close();
        }

        /// <summary>
        /// функция замен букв
        /// </summary>
        /// <param name="nShiftN">сдвиг</param>
        /// <param name="cCurrentChar">текущий символ</param>
        /// <returns>
        /// расшифрованный символ
        /// </returns>
        private char charShifter(int nShiftN, char cCurrentChar) {
            int nInnerCounterStart = 0;
            bool bCounterCheck = false;

            // проверяю сдвиг и беру в абсолют
            if (nShiftN != 0) {
                nShiftN = Math.Abs(nShiftN);
            }
            else {
                nShiftN = 1;
            }

            for (int i = 0; i <= aRussianAlphabet.Length - 1; i++) {
                if (aRussianAlphabet[i] == (System.Char.ToUpper(cCurrentChar))) {
                    nInnerCounterStart = i;
                    bCounterCheck = true;
                    break;
                }
            }

            if (!bCounterCheck) {
                return cCurrentChar;
            }

            if (nInnerCounterStart + nShiftN > aRussianAlphabet.Length - 1) {
                return aRussianAlphabet[(nInnerCounterStart + nShiftN) % 33];
            }
            else {
                return aRussianAlphabet[nInnerCounterStart + nShiftN - 1];
            }

        }
    }
}
