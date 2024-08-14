using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLang
{
    /// <summary>
    /// Перечисление типов токенов
    /// </summary>
    public enum TokenType
    {
        INT,
        FLOAT,
        PRINT,
        SEMICOLON,
        DOT,
        EQUAL,
        PLUS,
        MINUS,
        STAR,
        SLASH,
        LPAR,
        RPAR,
        ID,
        LIT,
        EXPR,
        EOF
    }
}