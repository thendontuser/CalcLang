using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLang
{
    /// <summary>
    /// Структура для хранения объекта переменной, команды PRINT и TITLE для последующей работы семантического анализатора
    /// </summary>
    public struct DataObject
    {
        /// <summary>
        /// Тип токена
        /// </summary>
        public TokenType? Type;

        /// <summary>
        /// Имя идентификатора. Данное поле нужно в том случае, если данный объект - переменная
        /// </summary>
        public string Name;

        /// <summary>
        /// Значение переменной или в случае, если объект - команда PRINT или TITLE, значение или строка, которое нужно напечатать
        /// </summary>
        public List<SToken>? Value;

        /// <summary>
        /// Поиск объекта по имени
        /// </summary>
        /// <param name="objects"> Список объектов </param>
        /// <param name="name"> Имя объекта </param>
        /// <returns> В случае найденного объекта возвращает его индекс в списке, иначе -1 </returns>
        public static int SearchWithName(List<DataObject> objects, string name)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                if (objects[i].Name == name)
                {
                    return i;
                }
            }
            return -1;
        }
    }

    /// <summary>
    /// Реализует синтаксический анализатор
    /// </summary>
    internal class Parser
    {
        // Список токенов, полученный лексическим анализатором
        private List<SToken> Tokens;

        // Индексирует элементы в списке токенов
        private int Index;

        // Текущий тип токена
        private TokenType? CurrentType;

        // Текущее значение токена
        private string CurrentValue;

        /// <summary>
        /// Список ошибок в исходной программе
        /// </summary>
        public List<string> Errors { get; private set; }

        // Список объектов переменных и команд PRINT, нужный для семантического анализатора
        private List<DataObject> DataObjects;

        // Объект, предназначенный для заполнения и добавляемый с список объектов
        private DataObject Object;

        // Строка для присваивания арифметического выражения в строковом виде
        private List<SToken>? Expr;

        /// <summary>
        /// Инициализирует все поля для дальнейшей работы анализатора
        /// </summary>
        /// <param name="tokens"> Список токенов </param>
        public Parser(List<SToken> tokens)
        {
            Tokens = tokens;
            Index = 0;
            CurrentType = Tokens[Index].Type;
            CurrentValue = Tokens[Index].Value;
            Errors = new List<string>();
            DataObjects = new List<DataObject>();
            Object = new DataObject();
            Expr = new List<SToken>();
        }

        // Заменяет объект в списке. Это нужно для добавления значения в конкретный объект, в котором этого значения не было
        private void ReplaceObject(string name, List<SToken> value)
        {
            int ind = DataObject.SearchWithName(DataObjects, name);
            if (ind != -1)
            {
                DataObject newObject = new DataObject();
                newObject.Type = DataObjects[ind].Type;
                newObject.Name = DataObjects[ind].Name;
                newObject.Value = value;
                DataObjects[ind] = newObject;
            }
            return;
        }

        /// <summary>
        /// Получает спиок объектов
        /// </summary>
        /// <returns> Список структур DataObject </returns>
        public List<DataObject> GetDataObjects()
        {
            return DataObjects;
        }

        // Перемещает индекс списка токенов, а также изменяет значение текущего токена
        private void Next()
        {
            if (Index < Tokens.Count - 1)
            {
                Index++;
                CurrentType = Tokens[Index].Type;
                CurrentValue = Tokens[Index].Value;
            }
        }

        /// <summary>
        /// Запускает синтаксический анализатор
        /// </summary>
        public void Parse()
        {
            Program();
        }

        // Метод в соответствии с правилом <программа> в грамматике языка
        private void Program()
        {
            if (CurrentType == TokenType.INT || CurrentType == TokenType.FLOAT)
            {
                ListOfDeclarations();
                Next();
                ListOfInits();
                Next();
                ListOfPrints();
            }
            else if (CurrentType == TokenType.PRINT || CurrentType == TokenType.TITLE)
            {
                ListOfPrints();
            }
            else
            {
                Errors.Add($"The data type or PRINT command was expected, but the {CurrentValue} was encountered");
            }
        }

        // Метод в соответствии с правилом <спис. объявл.> в грамматике языка
        private void ListOfDeclarations()
        {
            Declaration();
            Next();
            A();
        }

        // Метод в соответствии с правилом <объявление> в грамматике языка
        private void Declaration()
        {
            DataType();
            Next();
            if (CurrentType != TokenType.ID)
            {
                Errors.Add($"The identifier was expected, but {CurrentValue} was encountered");
            }
            else
            {
                Object.Name = CurrentValue;
                DataObjects.Add(Object);
            }
            Next();
            if (CurrentType != TokenType.SEMICOLON)
            {
                Errors.Add($"The ; was expected, but the {CurrentValue} was encountered");
            }
        }

        // Метод в соответствии с правилом <тип данных> в грамматике языка
        private void DataType()
        {
            if (CurrentType != TokenType.INT && CurrentType != TokenType.FLOAT)
            {
                Errors.Add($"The int or float was expected, but {CurrentValue} was encountered");
            }
            else
            {
                Object.Type = CurrentType;
            }
        }

        // Метод в соответствии с правилом <A> в грамматике языка
        private void A()
        {
            if (CurrentType == TokenType.INT || CurrentType == TokenType.FLOAT)
            {
                ListOfDeclarations();
            }
            else if (CurrentType == TokenType.ID)
            {
                Index--;
                return;
            }
            else
            {
                Errors.Add($"The data type or identifier was expected, but {CurrentValue} was encountered");
            }
        }

        // Метод в соответствии с правилом <спис. иниц.> в грамматике языка
        private void ListOfInits()
        {
            Init();
            Next();
            B();
        }

        // Метод в соответствии с правилом <инициализация> в грамматике языка
        private void Init()
        {
            if (CurrentType != TokenType.ID)
            {
                Errors.Add($"The identifier was expected, but {CurrentValue} was encountered");
            }
            string value = CurrentValue;
            Next();
            if (CurrentType != TokenType.EQUAL)
            {
                Errors.Add($"The = was expected, but {CurrentValue} was encountered");
            }
            Next();
            Expr = Expression();
            if (Expr == null)
            {
                Errors.Add($"The ; was expected, but {CurrentValue} was encountered");
                return;
            }
            ReplaceObject(value, Expr);
            if (CurrentType != TokenType.SEMICOLON)
            {
                Errors.Add($"The ; was expected, but {CurrentValue} was encountered");
            }
        }

        // Метод в соответствии с правилом <B> в грамматике языка
        private void B()
        {
            if (CurrentType == TokenType.ID)
            {
                ListOfInits();
            }
            else if (CurrentType == TokenType.PRINT || CurrentType == TokenType.TITLE)
            {
                Index--;
                return;
            }
            else
            {
                Errors.Add($"The identifier or PRINT command was expected, but {CurrentValue} was encountered");
            }
        }

        // Метод в соответствии с правилом <спис. выводов> в грамматике языка
        private void ListOfPrints()
        {
            Print();
            Next();
            C();
        }

        // Метод в соответствии с правилом <вывод> в грамматике языка
        private void Print()
        {
            if (CurrentType == TokenType.PRINT)
            {
                Object.Type = CurrentType;
                Object.Name = string.Empty;
                Next();
                Expr = Expression();
                if (Expr == null)
                {
                    Errors.Add($"The ; was expected, but {CurrentValue} was encountered");
                    return;
                }
                Object.Value = Expr;
                DataObjects.Add(Object);
                if (CurrentType != TokenType.SEMICOLON)
                {
                    Errors.Add($"The ; was expected, but {CurrentValue} was encountered");
                }
            }
            else if (CurrentType == TokenType.TITLE)
            {
                Object.Type = CurrentType;
                Object.Name = string.Empty;
                Next();
                if (CurrentType != TokenType.QMARK)
                {
                    Errors.Add($"The \" was expected, but {CurrentValue} was encountered");
                    return;
                }
                Next();

                List<SToken> title = new List<SToken>();
                SToken titleString = new SToken();
                titleString.Type = TokenType.LIT;
                titleString.Value = CurrentValue;
                title.Add(titleString);
                Object.Value = title;

                DataObjects.Add(Object);
                Next();
                if (CurrentType != TokenType.QMARK)
                {
                    Errors.Add($"The \" was expected, but {CurrentValue} was encountered");
                    return;
                }
                Next();
                if (CurrentType != TokenType.SEMICOLON)
                {
                    Errors.Add($"The ; was expected, but {CurrentValue} was encountered");
                }
            }
            else
            {
                Errors.Add($"The PRINT command was expected, but {CurrentValue} was encountered");
            }
        }

        // Метод в соответствии с правилом <C> в грамматике языка
        private void C()
        {
            if (CurrentType == TokenType.PRINT || CurrentType == TokenType.TITLE)
            {
                ListOfPrints();
            }
            else if (CurrentType == TokenType.EOF)
            {
                return;
            }
            else
            {
                Errors.Add($"The PRINT command was expected, but {CurrentValue} was encountered");
            }
        }

        // Проходит арифмеческое выражение и записывает его в список токенов
        private List<SToken>? Expression()
        {
            List<SToken> result = new List<SToken>();

            while (CurrentType != TokenType.SEMICOLON && CurrentType != TokenType.EOF && CurrentType != TokenType.PRINT && CurrentType != TokenType.TITLE)
            {
                result.Add(Tokens[Index]);
                Next();
            }
            if (CurrentType == TokenType.EOF || CurrentType == TokenType.PRINT || CurrentType == TokenType.TITLE)
            {
                return null;
            }
            SToken end = new SToken();
            end.Type = TokenType.EOF;
            end.Value = string.Empty;
            result.Add(end);
            return result;
        }
    }
}