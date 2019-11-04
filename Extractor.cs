using System;
using LingvoNET;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextEqualizer
{
    static class Extractor
    {
        // получаем три слова, возвращаем слова по указаному номеру начиная с 1
        public static string TextHandler(this string text, int num=1, bool firstCapitalLetter = false) //входная строка, номер слова если надо, делать ли первые буквы заглавными
        {
            try
            {
                text = Eraser(text, firstCapitalLetter); //выносим "мусор"
                string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); //делаем массив из слов и символов
                if (firstCapitalLetter) //делаем первые буквы заглавными если надо
                {
                    for (int i = 0; i < words.Length; i++) 
                    {
                        string word = words[i].ToLower(); //опускам в нижний регистр
                        if (!char.IsDigit(Convert.ToChar(word.Substring(0, 1)))) //если не цифра то делаем заглавными
                        {
                            words[i] = word.Substring(0, 1).ToUpper() + word.Substring(1, word.Length - 1);
                        }
                    }
                    return words[--num];
                }
                return string.Join(" ", words); //иначе объединяем массив в строку с разделением пробелами и возвращеам полный склееный текст

            }
            catch (Exception)
            {
                return "";
            }
        }

        public static string Eraser (string text, bool firstCapitalLetter = false) //удаляем всякие знаки из строки
        {
            if (firstCapitalLetter) text = Regex.Replace(text, @"\W", " "); //удаляем все кроме букв и цифр
            if(firstCapitalLetter) text = Regex.Replace(text, @"\d", " "); //удаляем цифры
            text = Regex.Replace(text, Environment.NewLine, " "); //удаляем разрывы строк вариант 1
            text = Regex.Replace(text, @"\n", " "); //удаляем разрывы строк вариант 2
            text = Regex.Replace(text, @"\t", " "); //удаляем знаки табуляции
            text = text.Trim(); //режем начальные и конечные пробелы
            return text;
        }

        public static string Declensions(string word, int pad) //существиельные и падеж
        {
            Noun text = Nouns.FindSimilar(word, animacy: Animacy.Animate);
            if (text != null)
            {
                switch (pad)
                {
                    case 0:
                        //word = text[Case.Nominative, Number.Singular]; //Nominative (Именительный -> (Кто? Что?) 
                        return word;
                    case 1:
                        word = text[Case.Genitive, Number.Singular]; //Genitiv (Родительный -> Кого? Чего?)
                        return word;
                    case 2:
                        word = text[Case.Dative, Number.Singular]; //Dative (Дательный -> Кому? Чему?)
                        return word;
                    case 3:
                        word = text[Case.Accusative, Number.Singular]; //Accusative (Винительный -> (Кого? Что?) 
                        return word;
                    case 4:
                        word = text[Case.Instrumental, Number.Singular]; //Instrumental (Творительный -> (Кем? Чем ?)
                        return word;
                    case 5:
                        word = text[Case.Locative, Number.Singular]; //Locative (Передложный -> (О ком? О чём? )
                        return word;
                    default:
                        break;
                }
            }
            return word;
        }
    }
}

