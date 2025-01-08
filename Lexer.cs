using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLang
{
    /// <summary>
    /// Структура, описывающая токен
    /// </summary>
    public struct SToken
    {
        /// <summary>
        /// Тип токена
        /// </summary>
        public TokenType? Type;

        /// <summary>
        /// Значение токена
        /// </summary>
        public string Value;
    }

    /// <summary>
    /// Реализует лексический анализатор
    /// </summary>
    internal class Lexer
    {
        // Исходный текст программы на языке CalcLang
        private string Source;

        /// <summary>
        /// Сообщение о лексической ошибке
        /// </summary>
        public string Error { get; private set; }

        // Словарь ключевых слов языка
        private Dictionary<TokenType, string> KeyWords = new Dictionary<TokenType, string>()
        {
            { TokenType.INT, "int" },
            { TokenType.FLOAT, "float" },
            { TokenType.PRINT, "print" },
            { TokenType.TITLE, "title" }
        };

        // Словарь служебных символов языка
        private Dictionary<TokenType, char> SpecialSymbols = new Dictionary<TokenType, char>()
        {
            { TokenType.SEMICOLON, ';' },
            { TokenType.DOT, '.' },
            { TokenType.QMARK, '"' },
            { TokenType.EQUAL, '=' },
            { TokenType.PLUS, '+' },
            { TokenType.MINUS, '-' },
            { TokenType.STAR, '*' },
            { TokenType.SLASH, '/' },
            { TokenType.LPAR, '(' },
            { TokenType.RPAR, ')' }
        };

        /// <summary>
        /// Инициализирует исходный текст программы
        /// </summary>
        /// <param name="sourceCode"> Исходный текст </param>
        public Lexer(string sourceCode)
        {
            Source = sourceCode;
            Error = string.Empty;
        }

        // Поиск ключевого слово. Если keyWord есть в словаре, то возвращается его тип, иначе null
        private TokenType? GetTypeOfWords(string keyWord)
        {
            foreach (KeyValuePair<TokenType, string> pair in KeyWords)
            {
                if (string.Equals(pair.Value, keyWord))
                {
                    return pair.Key;
                }
            }
            return null;
        }

        // Поиск служебного символа. Если symbol есть в словаре, то возвращается его тип, иначе null
        private TokenType? GetTypeOfSymbols(char symbol)
        {
            foreach (KeyValuePair<TokenType, char> pair in SpecialSymbols)
            {
                if (pair.Value == symbol)
                {
                    return pair.Key;
                }
            }
            return null;
        }

        // Добавляет токен в результирующий список tokens
        private void AddToken(List<SToken> tokens, TokenType? type, string value)
        {
            SToken token;
            token.Type = type;
            token.Value = value;
            tokens.Add(token);
        }

        /// <summary>
        /// Определяет количество определенных символов в строке. В контексте анализатора данный метод нужен для информации о количестве точек в строке литерала
        /// </summary>
        /// <param name="source"> Исходная строка </param>
        /// <param name="ch"> Искомый символ </param>
        /// <returns> Количество ch, содержащихся в source </returns>
        public static int CountOfChar(string source, char ch)
        {
            int count = 0;
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == ch)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Реализует алгоритм лексического анализа исходного кода
        /// </summary>
        /// <returns> Возвращает список токенов в случе, если в исходном коде нет лексических ошибок, иначе null </returns>
        public List<SToken>? Analyze()
        {
            List<SToken> tokens = new List<SToken>();
            int index = -1;
            TokenType? type;

            while (++index < Source.Length)
            {
                string buff = string.Empty;
                if (char.IsLetter(Source[index]))
                {
                    while (index < Source.Length && char.IsLetterOrDigit(Source[index]))
                    {
                        buff += Source[index];
                        index++;
                    }
                    --index;
                    if ((type = GetTypeOfWords(buff.ToLower())) != null)
                    {
                        AddToken(tokens, type, buff.ToLower());
                        continue;
                    }
                    AddToken(tokens, TokenType.ID, buff);
                    continue;
                }
                else if (char.IsDigit(Source[index]))
                {
                    while (index < Source.Length && (char.IsDigit(Source[index]) || Source[index] == '.'))
                    {
                        buff += Source[index];
                        index++;
                    }
                    if (char.IsLetter(Source[index]))
                    {
                        Error = "The identifier cannot start with a digit";
                        return null;
                    }
                    if (CountOfChar(buff, '.') > 1)
                    {
                        Error = "There cannot be more than one dot character in a floating point number";
                        return null;
                    }
                    --index;
                    AddToken(tokens, TokenType.LIT, buff);
                    continue;
                }

                if (!char.IsWhiteSpace(Source[index]))
                {
                    if (Source[index] == '$')
                    {
                        while (Source[index] != '\n')
                        {
                            index++;
                        }
                        continue;
                    }
                    else if (Source[index] == '"')
                    {
                        AddToken(tokens, TokenType.QMARK, Source[index].ToString());
                        index++;
                        while (Source[index] !=  '"' && Source[index] != '\n' && Source[index] != ';')
                        {
                            buff += Source[index];
                            index++;
                        }
                        AddToken(tokens, TokenType.LIT, buff);
                    }

                    if ((type = GetTypeOfSymbols(Source[index])) != null)
                    {
                        AddToken(tokens, type, Source[index].ToString());
                        continue;
                    }
                    Error = $"The {Source[index]} symbol does not exist in the language";
                    return null;
                }
            }
            AddToken(tokens, TokenType.EOF, "\\0");
            return tokens;
        }
    }
}