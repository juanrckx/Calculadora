using System;

namespace ServidorCore.ExpressionTree
{
    // Clase abstracta base para todos los nodos del árbol
    public abstract class Nodo
    {
        // Cada nodo puede tener hijos izquierdo y derecho
        public Nodo Izquierdo { get; set; }
        public Nodo Derecho { get; set; }
        
        // Método abstracto que cada tipo de nodo implementará
        public abstract double Evaluar();
        
        // Método para mostrar el árbol (útil para depurar)
        public virtual string Mostrar(int nivel = 0)
        {
            string espacio = new string(' ', nivel * 4);
            return espacio + ToString();
        }
    }
}