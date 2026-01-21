namespace ServidorCore.ExpressionTree
{
    // Representa un número en el árbol
    public class NodoOperando : Nodo
    {
        private double valor;       // Campo privado que almacena el valor numérico
        
        public NodoOperando(double valor)
        {
            this.valor = valor;
        }
        
        // Un número se evalúa a sí mismo
        // "override" indica que está sobrescribiendo el método abstracto de la clase base
        public override double Evaluar()
        {
            return valor;
        }
        
        public override string ToString()
        {
            return valor.ToString();
        }
    }
}