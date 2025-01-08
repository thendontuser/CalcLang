using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLang
{
    /// <summary>
    /// Реализует генерацию кода
    /// </summary>
    internal class CodeGenerator
    {
        // Список выражений
        private List<DataObject> Expressions;

        /// <summary>
        /// Список ошибок
        /// </summary>
        public List<string> Errors;

        /// <summary>
        /// Инициализирует список выражений
        /// </summary>
        /// <param name="expressions"> Список выражений </param>
        public CodeGenerator(List<DataObject> expressions)
        {
            Expressions = expressions;
            Errors = new List<string>();
        }

        /// <summary>
        /// Запускает генерацию кода
        /// </summary>
        /// <returns> Список выводов на экран </returns>
        public List<string>? Generate()
        {
            List<string>? result = new List<string>();
            Dictionary<string, string>? vars = SaveValuesOfVars();
            if (vars != null)
            {
                result = Generate(vars);
                return result;
            }
            return null;
        }

        // Подсчёт значений
        private void K(Stack<string> operands, TokenType? op)
        {
            if (operands.Count < 2 && op == TokenType.MINUS)
            {
                double value = Convert.ToDouble(operands.Pop(), new NumberFormatInfo());
                operands.Push((-value).ToString());
                return;
            }
            if (operands.Count < 2)
            {
                return;
            }

            CultureInfo culture = CultureInfo.InvariantCulture;
            double second = Convert.ToDouble(operands.Pop(), culture);
            double first = Convert.ToDouble(operands.Pop(), culture);
            switch (op)
            {
                case TokenType.PLUS:
                    operands.Push((first + second).ToString(culture));
                    break;
                case TokenType.MINUS:
                    operands.Push((first - second).ToString(culture));
                    break;
                case TokenType.STAR:
                    operands.Push((first * second).ToString(culture));
                    break;
                case TokenType.SLASH:
                    operands.Push((first / second).ToString(culture));
                    break;
            }
        }

        // Считает значения переменных и сохраняет их
        private Dictionary<string, string>? SaveValuesOfVars()
        {
            Dictionary<string, string> vars = new Dictionary<string, string>();
            Stack<string> operands;
            Stack<TokenType?> sign;

            for (int i = 0; Expressions[i].Type != TokenType.PRINT && Expressions[i].Type != TokenType.TITLE; i++)
            {
                operands = new Stack<string>();
                sign = new Stack<TokenType?>();
                int ind = 0;
                SToken token;

                while (ind != Expressions[i].Value.Count)
                {
                    token = Expressions[i].Value[ind];

                    if (token.Type == TokenType.ID)
                    {
                        string val = string.Empty;
                        if (vars.TryGetValue(token.Value, out val))
                        {
                            operands.Push(val);
                            ind++;
                        }
                        else
                        {
                            Errors.Add($"The variable {token.Value} is not initialized");
                            return null;
                        }
                    }
                    else if (token.Type == TokenType.LIT)
                    {
                        operands.Push(token.Value);
                        ind++;
                    }
                    else
                    {
                        if (sign.Count == 0)
                        {
                            if (token.Type == TokenType.EOF)
                            {
                                break;
                            }
                            else if (token.Type == TokenType.LPAR || token.Type == TokenType.PLUS || token.Type == TokenType.MINUS ||
                                token.Type == TokenType.STAR || token.Type == TokenType.SLASH)
                            {
                                sign.Push(token.Type);
                                ind++;
                                continue;
                            }
                            else if (token.Type == TokenType.RPAR)
                            {
                                Errors.Add("Error in the expression");
                                return null;
                            }
                        }
                        if (sign.Peek() == TokenType.LPAR)
                        {
                            if (token.Type == TokenType.EOF)
                            {
                                Errors.Add("Error in the expression");
                                return null;
                            }
                            else if (token.Type == TokenType.LPAR || token.Type == TokenType.PLUS || token.Type == TokenType.MINUS ||
                                token.Type == TokenType.STAR || token.Type == TokenType.SLASH)
                            {
                                sign.Push(token.Type);
                                ind++;
                                continue;
                            }
                            else if (token.Type == TokenType.RPAR)
                            {
                                sign.Pop();
                                ind++;
                            }
                        }
                        else if (sign.Peek() == TokenType.PLUS || sign.Peek() == TokenType.MINUS)
                        {
                            if (token.Type == TokenType.EOF || token.Type == TokenType.RPAR)
                            {
                                K(operands, sign.Pop());
                            }
                            else if (token.Type == TokenType.LPAR || token.Type == TokenType.STAR || token.Type == TokenType.SLASH)
                            {
                                sign.Push(token.Type);
                                ind++;
                                continue;
                            }
                            else if (token.Type == TokenType.PLUS || token.Type == TokenType.MINUS)
                            {
                                K(operands, sign.Pop());
                                sign.Push(token.Type);
                                ind++;
                            }
                        }
                        else if (sign.Peek() == TokenType.STAR || sign.Peek() == TokenType.SLASH)
                        {
                            if (token.Type == TokenType.EOF || token.Type == TokenType.RPAR || token.Type == TokenType.PLUS || token.Type == TokenType.MINUS)
                            {
                                K(operands, sign.Pop());
                            }
                            else if (token.Type == TokenType.LPAR)
                            {
                                sign.Push(token.Type);
                                ind++;
                                continue;
                            }
                            else if (token.Type == TokenType.STAR || token.Type == TokenType.SLASH)
                            {
                                K(operands, sign.Pop());
                                sign.Push(token.Type);
                                ind++;
                            }
                        }
                    }
                }
                if (operands.Count != 0)
                {
                    vars.Add(Expressions[i].Name, operands.Pop());
                }
            }
            return vars;
        }
        
        // Метод генерации
        private List<string>? Generate(Dictionary<string, string> vars)
        {
            List<string> output = new List<string>();
            Stack<string> operands;
            Stack<TokenType?> sign;
            int i = -1;

            while (Expressions[++i].Type != TokenType.PRINT && Expressions[i].Type != TokenType.TITLE)
                ;

            for ( ; i < Expressions.Count; i++)
            {
                if (Expressions[i].Type == TokenType.TITLE)
                {
                    output.Add(Expressions[i].Value[0].Value);
                    continue;
                }
                operands = new Stack<string>();
                sign = new Stack<TokenType?>();
                int ind = 0;
                SToken token;

                while (ind != Expressions[i].Value.Count)
                {
                    token = Expressions[i].Value[ind];

                    if (token.Type == TokenType.ID)
                    {
                        string val = string.Empty;
                        if (vars.TryGetValue(token.Value, out val))
                        {
                            operands.Push(val);
                            ind++;
                        }
                        else
                        {
                            Errors.Add($"The variable {token.Value} is not initialized");
                            return null;
                        }
                    }
                    else if (token.Type == TokenType.LIT)
                    {
                        operands.Push(token.Value);
                        ind++;
                    }
                    else
                    {
                        if (sign.Count == 0)
                        {
                            if (token.Type == TokenType.EOF)
                            {
                                break;
                            }
                            else if (token.Type == TokenType.LPAR || token.Type == TokenType.PLUS || token.Type == TokenType.MINUS ||
                                token.Type == TokenType.STAR || token.Type == TokenType.SLASH)
                            {
                                sign.Push(token.Type);
                                ind++;
                                continue;
                            }
                            else if (token.Type == TokenType.RPAR)
                            {
                                Errors.Add("Error in the expression");
                                return null;
                            }
                        }
                        if (sign.Peek() == TokenType.LPAR)
                        {
                            if (token.Type == TokenType.EOF)
                            {
                                Errors.Add("Error in the expression");
                                return null;
                            }
                            else if (token.Type == TokenType.LPAR || token.Type == TokenType.PLUS || token.Type == TokenType.MINUS ||
                                token.Type == TokenType.STAR || token.Type == TokenType.SLASH)
                            {
                                sign.Push(token.Type);
                                ind++;
                                continue;
                            }
                            else if (token.Type == TokenType.RPAR)
                            {
                                sign.Pop();
                                ind++;
                            }
                        }
                        else if (sign.Peek() == TokenType.PLUS || sign.Peek() == TokenType.MINUS)
                        {
                            if (token.Type == TokenType.EOF || token.Type == TokenType.RPAR)
                            {
                                K(operands, sign.Pop());
                            }
                            else if (token.Type == TokenType.LPAR || token.Type == TokenType.STAR || token.Type == TokenType.SLASH)
                            {
                                sign.Push(token.Type);
                                ind++;
                                continue;
                            }
                            else if (token.Type == TokenType.PLUS || token.Type == TokenType.MINUS)
                            {
                                K(operands, sign.Pop());
                                sign.Push(token.Type);
                                ind++;
                            }
                        }
                        else if (sign.Peek() == TokenType.STAR || sign.Peek() == TokenType.SLASH)
                        {
                            if (token.Type == TokenType.EOF || token.Type == TokenType.RPAR || token.Type == TokenType.PLUS || token.Type == TokenType.MINUS)
                            {
                                K(operands, sign.Pop());
                            }
                            else if (token.Type == TokenType.LPAR)
                            {
                                sign.Push(token.Type);
                                ind++;
                                continue;
                            }
                            else if (token.Type == TokenType.STAR || token.Type == TokenType.SLASH)
                            {
                                K(operands, sign.Pop());
                                sign.Push(token.Type);
                                ind++;
                            }
                        }
                    }
                }
                if (operands.Count != 0)
                {
                    output.Add(operands.Pop());
                }
            }
            return output;
        }
    }
}