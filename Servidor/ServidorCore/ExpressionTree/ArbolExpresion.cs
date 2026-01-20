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
            Stack<Nodo> pila = new Stack<Nodo>();
            
            foreach (string token in postfijo)
            {
                if (EsNumero(token))
                {
                    // Usar CultureInfo.InvariantCulture para garantizar que . sea separador decimal
                    double valor = double.Parse(token, CultureInfo.InvariantCulture);
                    pila.Push(new NodoOperando(valor));
                }
                else
                {
                    NodoOperador nodoOperador = new NodoOperador(token);
                    
                    if (token == "~")
                    {
                        if (pila.Count < 1)
                            throw new ArgumentException("Expresión inválida: NOT sin operando");
                        
                        nodoOperador.Derecho = pila.Pop();
                    }
                    else
                    {
                        if (pila.Count < 2)
                            throw new ArgumentException("Expresión inválida: faltan operandos");
                        
                        nodoOperador.Derecho = pila.Pop();
                        nodoOperador.Izquierdo = pila.Pop();
                    }
                    
                    pila.Push(nodoOperador);
                }
            }
            
            if (pila.Count != 1)
                throw new ArgumentException($"Expresión inválida: {pila.Count} elementos en pila");
            
            return pila.Pop();
        }
        
        private bool EsNumero(string token)
        {
            // Usar el mismo método de validación que ConversorPostfijo
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
                    if (tienePunto)
                        return false;
                    tienePunto = true;
                }
                else
                {
                    return false;
                }
            }
            
            return tieneDigito;
        }
        
        public double Evaluar()
        {
            if (raiz == null)
                throw new InvalidOperationException("Árbol vacío");
                
            try
            {
                return raiz.Evaluar();
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