using System;
using System.Collections.Generic;

namespace ServidorCore.ExpressionTree
{
    // Clase principal que representa el árbol de expresión
    public class ArbolExpresion
    {
        private Nodo raiz;
        
        // Constructor: crea el árbol a partir de una expresión infija
        public ArbolExpresion(string expresionInfija)
        {
            // 1. Convertir a postfijo
            List<string> postfijo = ConversorPostfijo.InfijoAPostfijo(expresionInfija);
            
            // 2. Construir árbol desde postfijo
            raiz = ConstruirDesdePostfijo(postfijo);
        }
        
        // Construye el árbol a partir de una expresión postfija
        private Nodo ConstruirDesdePostfijo(List<string> postfijo)
        {
            Stack<Nodo> pila = new Stack<Nodo>();
            
            foreach (string token in postfijo)
            {
                if (double.TryParse(token, out double valor))
                {
                    // Es un número: crear nodo operando y pushear
                    pila.Push(new NodoOperando(valor));
                }
                else
                {
                    // Es un operador: crear nodo operador
                    NodoOperador nodoOperador = new NodoOperador(token);
                    
                    if (token == "~")
                    {
                        // NOT es un operador unario: solo necesita un operando
                        if (pila.Count < 1)
                            throw new ArgumentException("Expresión inválida: NOT sin operando");
                        
                        nodoOperador.Derecho = pila.Pop();
                    }
                    else
                    {
                        // Operadores binarios: necesitan dos operandos
                        if (pila.Count < 2)
                            throw new ArgumentException("Expresión inválida");
                        
                        nodoOperador.Derecho = pila.Pop();
                        nodoOperador.Izquierdo = pila.Pop();
                    }
                    
                    pila.Push(nodoOperador);
                }
            }
            
            // Al final, debe quedar exactamente un nodo en la pila
            if (pila.Count != 1)
                throw new ArgumentException("Expresión inválida");
            
            return pila.Pop();
        }
        
        // Evalúa la expresión
        public double Evaluar()
        {
            if (raiz == null)
                return 0;
                
            return raiz.Evaluar();
        }
        
        // Muestra el árbol (útil para depurar)
        public string MostrarArbol()
        {
            if (raiz == null)
                return "Árbol vacío";
                
            return raiz.Mostrar();
        }
    }
}