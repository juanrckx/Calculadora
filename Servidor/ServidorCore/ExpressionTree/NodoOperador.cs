namespace ServidorCore.ExpressionTree
{
    // Representa un operador en el árbol
    public class NodoOperador : Nodo
    {
        private string operador;
        
        public NodoOperador(string operador)
        {
            this.operador = operador;
        }
        
        // Un operador evalúa sus hijos y luego aplica la operación
        public override double Evaluar()
        {
            // Primero evaluamos el hijo izquierdo (si existe)
            double valorIzquierdo = 0;
            if (Izquierdo != null)
                valorIzquierdo = Izquierdo.Evaluar();
            
            // Luego evaluamos el hijo derecho
            double valorDerecho = Derecho.Evaluar();
            
            // Aplicamos la operación correspondiente
            switch (operador)
            {
                case "+":
                    return valorIzquierdo + valorDerecho;
                    
                case "-":
                    return valorIzquierdo - valorDerecho;
                    
                case "*":
                    return valorIzquierdo * valorDerecho;
                    
                case "/":
                    if (valorDerecho == 0)
                        throw new DivideByZeroException("No se puede dividir entre cero");
                    return valorIzquierdo / valorDerecho;
                    
                case "%":
                    if (valorDerecho == 0)
                        throw new DivideByZeroException("No se puede dividir entre cero");
                    return valorIzquierdo % valorDerecho;
                    
                case "**":
                    // Potencia: 2**3 = 8
                    return Math.Pow(valorIzquierdo, valorDerecho);
                    
                case "&": // AND lógico
                    // Consideramos 0 como false, cualquier otro como true
                    bool izqBool = valorIzquierdo != 0;
                    bool derBool = valorDerecho != 0;
                    return (izqBool && derBool) ? 1 : 0;
                    
                case "|": // OR lógico
                    izqBool = valorIzquierdo != 0;
                    derBool = valorDerecho != 0;
                    return (izqBool || derBool) ? 1 : 0;
                    
                case "^": // XOR lógico
                    izqBool = valorIzquierdo != 0;
                    derBool = valorDerecho != 0;
                    return (izqBool ^ derBool) ? 1 : 0;
                    
                case "~": // NOT lógico (operador unario)
                    // Para NOT, solo usamos el hijo derecho
                    derBool = valorDerecho != 0;
                    return (!derBool) ? 1 : 0;
                    
                default:
                    throw new ArgumentException($"Operador desconocido: {operador}");
            }
        }
        
        public override string ToString()
        {
            return operador;
        }
        
        public override string Mostrar(int nivel = 0)
        {
            string espacio = new string(' ', nivel * 4);
            string resultado = espacio + $"Op({operador})\n";
            
            if (Izquierdo != null)
                resultado += Izquierdo.Mostrar(nivel + 1) + "\n";
            
            resultado += Derecho.Mostrar(nivel + 1);
            return resultado;
        }
    }
}