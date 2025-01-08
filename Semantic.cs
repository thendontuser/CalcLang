using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLang
{
    /// <summary>
    /// Реализует семантический анализатор
    /// </summary>
    internal class Semantic
    {
        // Данные о переменных и командах PRINT и TITLE
        private List<DataObject> DataObjects;

        /// <summary>
        /// Список ошибок
        /// </summary>
        public List<string> Errors { get; private set; }

        /// <summary>
        /// Инициализирует данные о переменных и командах
        /// </summary>
        /// <param name="dataObjects"> Данные о переменных и командах </param>
        public Semantic(List<DataObject> dataObjects)
        {
            DataObjects = dataObjects;
            Errors = new List<string>();
        }

        // Проверяет, существует ли переменаая name в программе
        private bool IsThereVariable(string name)
        {
            foreach (DataObject obj in DataObjects)
            {
                if (string.Equals(obj.Name, name))
                {
                    return true;
                }
            }
            return false;
        }

        // Проверка на неинициализированные переменные
        private void CheckInitsError()
        {
            foreach (DataObject obj in DataObjects)
            {
                if (obj.Value == null)
                {
                    Errors.Add($"the {obj.Name} variable is not initialized");
                }
            }
        }

        // Проверяет значения переменных в соответствии с их типом
        private void CheckDataTypesValues()
        {
            foreach (DataObject obj in DataObjects)
            {
                foreach (SToken value in obj.Value)
                {
                    if (value.Type == TokenType.ID || value.Type == TokenType.LIT)
                    {
                        if (obj.Type == TokenType.INT)
                        {
                            if (Lexer.CountOfChar(value.Value, '.') > 0)
                            {
                                Errors.Add($"The value of the variable {obj.Name} does not match its data type");
                            }
                        }
                        else if (obj.Type == TokenType.FLOAT)
                        {
                            if (Lexer.CountOfChar(value.Value, '.') == 0)
                            {
                                Errors.Add($"The value of the variable {obj.Name} does not match its data type");
                            }
                        }
                    }
                }
            }
        }

        // Проверяет, есть ли переменные в выражениях, которые не объявлены
        private void CheckVariables()
        {
            foreach (DataObject obj in DataObjects)
            {
                foreach (SToken value in obj.Value)
                {
                    if (value.Type == TokenType.ID)
                    {
                        if (!IsThereVariable(value.Value))
                        {
                            Errors.Add($"the variable {value.Value} does not exist");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Запускает семантический разбор
        /// </summary>
        public void Analyze()
        {
            CheckInitsError();
            if (Errors.Count > 0)
            {
                return;
            }
            CheckDataTypesValues();
            CheckVariables();
        }
    }
}