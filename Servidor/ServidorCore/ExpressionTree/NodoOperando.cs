namespace ServidorCore.ExpressionTree
{
    // Representa un número en el árbol
    public class NodoOperando : Nodo
    {
        private double valor;
        
        public NodoOperando(double valor)
        {
            this.valor = valor;
        }
        
        // Un número se evalúa a sí mismo
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