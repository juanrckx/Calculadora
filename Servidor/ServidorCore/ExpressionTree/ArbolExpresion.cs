using System;
using System.Collections.Generic;
using System.Globalization;

namespace ServidorCore.ExpressionTree
{
    public class ArbolExpresion
    {
        private Nodo raiz;
        
        public ArbolExpresion(string expresionInfija)
        {
            try
            {
                // 1. Convertir a postfijo
                List<string> postfijo = ConversorPostfijo.InfijoAPostfijo(expresionInfija);
                
                // 2. Construir árbol desde postfijo
                raiz = ConstruirDesdePostfijo(postfijo);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error al construir árbol: {ex.Message}", ex);
            }
        }
        
        private Nodo ConstruirDesdePostfijo(List<string> postfijo)
        {
            Stack<Nodo> pila = new Stack<Nodo>();       // Pila para construir el árbol
            
            foreach (string token in postfijo)
            {
                if (EsNumero(token))
                {
                    // Si es número, crear nodo operando
                    double valor = double.Parse(token, CultureInfo.InvariantCulture);
                    pila.Push(new NodoOperando(valor));
                }
                else
                {
                    NodoOperador nodoOperador = new NodoOperador(token);
                    
                    if (token == "~" || token == "u")
                    {
                        if (pila.Count < 1)
                            throw new ArgumentException("Expresión inválida: NOT sin operando");
                        
                        nodoOperador.Derecho = pila.Pop();      // El operador va en el hijo derecho
                    }
                    else        // Operadores binarios
                    {
                        if (pila.Count < 2)
                            throw new ArgumentException("Expresión inválida: faltan operandos");
                        
                        nodoOperador.Derecho = pila.Pop();      // Último operando en la pila = hijo derecho
                        nodoOperador.Izquierdo = pila.Pop();    // Penúltimo operando = hijo izquierdo
                    }
                    
                    pila.Push(nodoOperador);                    // Apilar el operador (que ahora es un nodo con hijos)
                }
            }
            
            if (pila.Count != 1)
                throw new ArgumentException($"Expresión inválida: {pila.Count} elementos en pila");
            
            return pila.Pop();      // La raíz del árbol es el último elemento de la pila
        }
        
        private bool EsNumero(string token)
        {
            // Verificar si el token es un número válido (entero o decimal)
            token = token.Trim();
            
            if (string.IsNullOrEmpty(token))
                return false;
                
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
                    if (tienePunto)     // Doble punto no permitido
                        return false;
                    tienePunto = true;
                }
                else
                {
                    return false;       // Carácter inválido
                }
            }
            
            return tieneDigito;         // Debe tener al menos un dígito
        }
        
        public double Evaluar()
        {
            if (raiz == null)
                throw new InvalidOperationException("Árbol vacío");
                
            try
            {
                return raiz.Evaluar();      // Evaluación recursiva
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al evaluar: {ex.Message}", ex);
            }
        }
        
        public string MostrarArbol()
        {
            if (raiz == null)
                return "Árbol vacío";
                
            return raiz.Mostrar();
        }
    }
}