using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace ServidorCore.ExpressionTree
{
    public class ConversorPostfijo
    {
        // Tabla de precedencia de operadores
        private static Dictionary<string, int> precedencia = new Dictionary<string, int>
        {
            { "~", 4 },  // NOT (más alta)
            { "**", 3 }, // Potencia
            { "*", 2 }, { "/", 2 }, { "%", 2 },
            { "+", 1 }, { "-", 1 },
            { "&", 0 }, { "|", 0 }, { "^", 0 } // Operadores lógicos
        };
        
        public static List<string> InfijoAPostfijo(string expresion)
        {
            List<string> resultado = new List<string>();
            Stack<string> pilaOperadores = new Stack<string>();
            
            List<string> tokens = Tokenizar(expresion);
            
            foreach (string token in tokens)
            {
                if (EsNumero(token))
                {
                    resultado.Add(token);
                }
                else if (token == "(")
                {
                    pilaOperadores.Push(token);
                }
                else if (token == ")")
                {
                    while (pilaOperadores.Count > 0 && pilaOperadores.Peek() != "(")
                    {
                        resultado.Add(pilaOperadores.Pop());
                    }
                    
                    if (pilaOperadores.Count > 0)
                        pilaOperadores.Pop();
                }
                else if (EsOperador(token))
                {
                    while (pilaOperadores.Count > 0 && 
                           pilaOperadores.Peek() != "(" && 
                           precedencia.ContainsKey(pilaOperadores.Peek()) &&
                           precedencia[pilaOperadores.Peek()] >= precedencia[token])
                    {
                        resultado.Add(pilaOperadores.Pop());
                    }
                    
                    pilaOperadores.Push(token);
                }
            }
            
            while (pilaOperadores.Count > 0)
            {
                resultado.Add(pilaOperadores.Pop());
            }
            
            return resultado;
        }
        
        private static List<string> Tokenizar(string expresion)
        {
            List<string> tokens = new List<string>();
            StringBuilder numeroActual = new StringBuilder();
            bool enNumero = false;
            
            for (int i = 0; i < expresion.Length; i++)
            {
                char c = expresion[i];
                
                // Verificar si es parte de un número (dígito o punto decimal)
                if (char.IsDigit(c) || c == '.')
                {
                    if (!enNumero && c == '.')
                    {
                        // Punto al inicio del número
                        numeroActual.Append("0.");
                        enNumero = true;
                    }
                    else
                    {
                        numeroActual.Append(c);
                        enNumero = true;
                    }
                }
                else if (char.IsWhiteSpace(c))
                {
                    // Finalizar número actual si existe
                    if (enNumero)
                    {
                        tokens.Add(numeroActual.ToString());
                        numeroActual.Clear();
                        enNumero = false;
                    }
                }
                else
                {
                    // Finalizar número actual si existe
                    if (enNumero)
                    {
                        tokens.Add(numeroActual.ToString());
                        numeroActual.Clear();
                        enNumero = false;
                    }
                    
                    // Verificar operadores de dos caracteres
                    if (i + 1 < expresion.Length)
                    {
                        string dosCaracteres = c.ToString() + expresion[i + 1];
                        if (dosCaracteres == "**")
                        {
                            tokens.Add(dosCaracteres);
                            i++; // Saltar siguiente carácter
                            continue;
                        }
                    }
                    
                    // Añadir operador de un carácter
                    tokens.Add(c.ToString());
                }
            }
            
            // Añadir último número si existe
            if (enNumero)
            {
                tokens.Add(numeroActual.ToString());
            }
            
            return tokens;
        }
        
        private static bool EsNumero(string token)
        {
            // Limpiar token: eliminar espacios
            token = token.Trim();
            
            // Verificar si es número válido
            if (string.IsNullOrEmpty(token))
                return false;
                
            // Verificar formato válido: dígitos opcionales + . + dígitos opcionales
            bool tienePunto = false;
            bool tieneDigito = false;
            
            foreach (char c in token)
            {
                if (char.IsDigit(c))
                {
                    tieneDigito = true;
                }
                else if (c == '.')
                {
                    if (tienePunto) // Doble punto -> inválido
                        return false;
                    tienePunto = true;
                }
                else
                {
                    return false; // Carácter inválido
                }
            }
            
            return tieneDigito; // Debe tener al menos un dígito
        }
        
        private static bool EsOperador(string token)
        {
            return precedencia.ContainsKey(token) || token == "(" || token == ")";
        }
    }
}