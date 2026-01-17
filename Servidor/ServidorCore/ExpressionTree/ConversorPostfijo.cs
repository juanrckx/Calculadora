using System;
using System.Collections.Generic;
using System.Text;

namespace ServidorCore.ExpressionTree
{
    // Convierte expresiones infijas (3+4) a postfijas (3 4 +)
    public class ConversorPostfijo
    {
        // Tabla de precedencia de operadores
        // Mayor número = mayor precedencia
        private static Dictionary<string, int> precedencia = new Dictionary<string, int>
        {
            { "~", 4 },  // NOT (más alta)
            { "**", 3 }, // Potencia
            { "*", 2 }, { "/", 2 }, { "%", 2 },
            { "+", 1 }, { "-", 1 },
            { "&", 0 }, { "|", 0 }, { "^", 0 } // Operadores lógicos (menor)
        };
        
        // Convierte expresión infija a postfija usando algoritmo Shunting Yard
        public static List<string> InfijoAPostfijo(string expresion)
        {
            List<string> resultado = new List<string>();
            Stack<string> pilaOperadores = new Stack<string>();
            
            // Primero tokenizamos la expresión
            List<string> tokens = Tokenizar(expresion);
            
            foreach (string token in tokens)
            {
                if (EsNumero(token))
                {
                    // Números van directo al resultado
                    resultado.Add(token);
                }
                else if (token == "(")
                {
                    // Paréntesis izquierdo va a la pila
                    pilaOperadores.Push(token);
                }
                else if (token == ")")
                {
                    // Sacamos operadores hasta encontrar el paréntesis izquierdo
                    while (pilaOperadores.Count > 0 && pilaOperadores.Peek() != "(")
                    {
                        resultado.Add(pilaOperadores.Pop());
                    }
                    
                    // Removemos el "("
                    if (pilaOperadores.Count > 0)
                        pilaOperadores.Pop();
                }
                else if (EsOperador(token))
                {
                    // Si es operador, sacamos operadores con mayor o igual precedencia
                    while (pilaOperadores.Count > 0 && 
                           pilaOperadores.Peek() != "(" && 
                           precedencia[pilaOperadores.Peek()] >= precedencia[token])
                    {
                        resultado.Add(pilaOperadores.Pop());
                    }
                    
                    // Pusheamos el nuevo operador
                    pilaOperadores.Push(token);
                }
            }
            
            // Sacamos todos los operadores restantes
            while (pilaOperadores.Count > 0)
            {
                resultado.Add(pilaOperadores.Pop());
            }
            
            return resultado;
        }
        
        // Separa la expresión en tokens (números, operadores, paréntesis)
        private static List<string> Tokenizar(string expresion)
        {
            List<string> tokens = new List<string>();
            StringBuilder numeroActual = new StringBuilder();
            
            for (int i = 0; i < expresion.Length; i++)
            {
                char c = expresion[i];
                
                if (char.IsDigit(c) || c == '.')
                {
                    // Es parte de un número
                    numeroActual.Append(c);
                }
                else
                {
                    // Si teníamos un número en construcción, lo agregamos
                    if (numeroActual.Length > 0)
                    {
                        tokens.Add(numeroActual.ToString());
                        numeroActual.Clear();
                    }
                    
                    // Si no es espacio, procesamos el carácter
                    if (!char.IsWhiteSpace(c))
                    {
                        // Verificamos si es un operador de dos caracteres
                        if (i + 1 < expresion.Length)
                        {
                            string dosCaracteres = c.ToString() + expresion[i + 1];
                            if (dosCaracteres == "**" || dosCaracteres == "||")
                            {
                                tokens.Add(dosCaracteres);
                                i++; // Saltamos el siguiente carácter
                                continue;
                            }
                        }
                        
                        // Operadores de un carácter
                        tokens.Add(c.ToString());
                    }
                }
            }
            
            // Si quedó un número al final
            if (numeroActual.Length > 0)
            {
                tokens.Add(numeroActual.ToString());
            }
            
            return tokens;
        }
        
        private static bool EsNumero(string token)
        {
            return double.TryParse(token, out _);
        }
        
        private static bool EsOperador(string token)
        {
            return precedencia.ContainsKey(token);
        }
    }
}