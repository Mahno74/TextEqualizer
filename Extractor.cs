using LingvoNET;
using System;
using System.Text.RegularExpressions;


namespace TextEqualizer
{
    static class Extractor
    {
        public static string NameExtractor(string threeWords, int wordNumber)
        {
            threeWords = TrashOut(threeWords, true); //выносим "мусор"
            string[] wordsArray = threeWords.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); //делаем массив из слов и символов игнорируя множественные пробелы
            if (wordsArray.Length < wordNumber) return "";
            string word = wordsArray[--wordNumber].ToLower(); //опускам в нижний регистр
            word = word.Substring(0, 1).ToUpper() + word.Substring(1, word.Length - 1); //делаем первую букву заглавной
            return word;
        }

        public static (string last, string first, string middle) LastFirstMiddle(string threeWords)
        {
            threeWords = TrashOut(threeWords, true); //выносим "мусор"
            string[] wordsArray = threeWords.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); //делаем массив из слов и символов игнорируя множественные пробелы
            for (int i = 0; i < wordsArray.Length; i++)
            {
                wordsArray[i] = wordsArray[i].ToLower();
                wordsArray[i] = wordsArray[i].Substring(0, 1).ToUpper() + wordsArray[i].Substring(1, wordsArray[i].Length - 1);
            }
            return (wordsArray[0], wordsArray[1], wordsArray[2]);
        }

        public static string TextHandler(this string text) //чистим любой текст
        {
            text = TrashOut(text); //выносим "мусор"
            string[] wordsArray = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); //делаем массив из слов и символов игнорируя множественные пробелы
            return string.Join(" ", wordsArray); //иначе объединяем массив в строку с разделением пробелами и возвращеам полный склееный текст
        }

        public static string TrashOut(string text, bool fio = false) //удаляем всякие знаки из строки
        {
            if (fio) text = Regex.Replace(text, @"\W", " "); //удаляем все кроме букв и цифр
            if (fio) text = Regex.Replace(text, @"\W", " "); //удаляем все кроме букв и цифр
            if (fio) text = Regex.Replace(text, @"\d", " "); //удаляем цифры
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

