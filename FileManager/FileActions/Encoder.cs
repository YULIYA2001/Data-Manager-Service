using ConfigurationManager.Options;
using System;
using System.IO;

namespace FileManager.FileActions
{
    public class Encoder
    {
        public static string Encode(string text, int key)
        {
            //символы русской и латинской азбуки
            const string alfabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯABCDEFGHIJKLMNOPQRSTUVWXYZ";
            // реверсирование строки алфавита
            char[] alfabetarray = alfabet.ToCharArray();
            Array.Reverse(alfabetarray);
            string reversedalfabet = new string(alfabetarray);
            //добавляем в алфавит маленькие буквы (в противоположном порядке), цифры и знаки
            string fullAlfabet = alfabet + reversedalfabet.ToLower() + "/=7?!46:;985^<1+-03*%2.,'\"_>";
            int letterNum = fullAlfabet.Length;
            string resStr = "";
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                int index = fullAlfabet.IndexOf(c);
                if (index < 0)
                {
                    //если символ не найден, то добавляем его в неизменном виде
                    resStr += c.ToString();
                }
                else
                {
                    int codeIndex = (letterNum + index + key) % letterNum;
                    resStr += fullAlfabet[codeIndex];
                }
            }
            return resStr;
        }

        public static void Encrypt(string path)
        {
            string text = "";
            // прочесть содержимое файла
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8))
            {
                text = sr.ReadToEnd();
            }            
            string encryptedText = Encode(text, EncoderOptions.GetKey());
            // перезаписать в файл зашифрованный текст
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            {
                sw.WriteLine(encryptedText);
            }
        }
        public static void Decrypt(string path)
        {
            string text = "";

            // прочесть содержимое файла
            using (StreamReader sr = new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }
            string decryptedText = Encode(text, -EncoderOptions.GetKey());
            // перезаписать в файл расшифрованный текст
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            {
                sw.WriteLine(decryptedText);
            }
        }
    }
}
