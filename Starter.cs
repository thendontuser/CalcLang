using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLang
{
    /// <summary>
    /// Реализует запуск всех анализаторов
    /// </summary>
    internal class Starter
    {
        // Исходный код
        private string SourceCode;

        /// <summary>
        /// Лексическая ошибка
        /// </summary>
        public string LexerError {  get; private set; }

        /// <summary>
        /// Список синтаксических ошибок
        /// </summary>
        public List<string> ParserErrors {  get; private set; }

        /// <summary>
        /// Список семантических ошибок
        /// </summary>
        public List<string> SemanticErrors { get; private set; }

        /// <summary>
        /// Список ошибок генерации кода
        /// </summary>
        public List<string> GenerateErrors { get; private set; }

        /// <summary>
        /// Инициализицрует строку с исходным кодом
        /// </summary>
        /// <param name="sourceCode"> Исходный код </param>
        public Starter(string sourceCode)
        {
            SourceCode = sourceCode;
            LexerError = string.Empty;
            ParserErrors = new List<string>();
            SemanticErrors = new List<string>();
            GenerateErrors = new List<string>();
        }

        /// <summary>
        /// Зпускает лексический анализатор
        /// </summary>
        /// <returns> Список полученных токенов </returns>
        public List<SToken>? StartLexer()
        {
            Lexer lexer = new Lexer(SourceCode);
            List<SToken>? result = lexer.Analyze();
            if (lexer.Error != string.Empty)
            {
                LexerError = lexer.Error;
                return null;
            }
            return result;
        }

        /// <summary>
        /// Запускает синтаксический анализатор
        /// </summary>
        /// <returns> Список структур DataObject </returns>
        public List<DataObject>? StartParser(List<SToken> tokens)
        {
            Parser parser = new Parser(tokens);
            parser.Parse();
            if (parser.Errors.Count > 0)
            {
                ParserErrors = parser.Errors;
                return null;
            }
            return parser.GetDataObjects();
        }

        /// <summary>
        /// Запускает семантический анализатор
        /// </summary>
        /// <param name="objects"> Список объектов DataObject </param>
        /// <returns> Список объектов DataObject </returns>
        public List<DataObject>? StartSemantic(List<DataObject> objects)
        {
            Semantic semantic = new Semantic(objects);
            semantic.Analyze();
            if (semantic.Errors.Count > 0)
            {
                SemanticErrors = semantic.Errors;
                return null;
            }
            return objects;
        }

        /// <summary>
        /// Запускает генерацию кода
        /// </summary>
        /// <param name="expressions"> Список объектов с выражениями </param>
        /// <returns> Список выводов программы </returns>
        public List<string>? StartCodeGenerator(List<DataObject> expressions)
        {
            CodeGenerator generator = new CodeGenerator(expressions);
            List<string>? outputs = generator.Generate();
            if (outputs == null)
            {
                GenerateErrors = generator.Errors;
                return null;
            }
            return outputs;
        }
    }
}