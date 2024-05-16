namespace Poker12.Core.Jugadas
{
    public class DoblePar : IJugada
    {
        public string Nombre => "Doble Par";
        public byte Prioridad => 4;
        public Resultado Aplicar(List<Carta> cartas)
        {
            if (cartas.Count < 4)
                throw new ArgumentException("No hay suficientes cartas para formar un Doble Par");
            var conteoValores = new Dictionary<EValor, int>();
            foreach (var carta in cartas)
            {
                if (conteoValores.ContainsKey(carta.Valor))
                {
                    //Si el valor de la carta ya existe en el diccionario entonces se incrementa el valor asociado a esa clave en uno Esto significa que cada vez que se encuentra una carta con un valor que ya ha sido contado, se aumenta el conteo de esa carta en uno.
                    conteoValores[carta.Valor]++;
                }
                else
                {
                    //Si el valor de la carta no existe en el diccionario retorna false), entonces se añade una nueva entrada al diccionario con ese valor como clave y 1 como valor asociado. Esto registra por primera vez el conteo de esa carta.
                    conteoValores[carta.Valor] = 1;
                }
            }
            var pares = new List<(EValor, int)>();
            foreach (var valor in conteoValores.Keys)
            {
                // es igual a 2. Esto significa que se está buscando valores que aparezcan exactamente dos veces en la lista original de cartas, ya que estos son los criterios para formar un par.
                if (conteoValores[valor] == 2)
                {
                    pares.Add((valor, conteoValores[valor]));
                }
            }
            if (pares.Count!= 2)
                throw new InvalidOperationException("No se pudo formar un Doble Par");
            // Ordenamos los pares por valor para determinar cuál es el par más alto
            pares.Sort((a, b) => b.Item2.CompareTo(a.Item2));
            // Devolvemos el par más alto como el resultado de la jugada
            return new Resultado(Prioridad, (byte)pares[0].Item1);
        }
    }
}


