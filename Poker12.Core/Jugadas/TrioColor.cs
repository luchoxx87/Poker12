namespace Poker12.Core.Jugadas
{
    public class TrioColor : IJugada
    {
        public string Nombre => "Trío de Color";
        public byte Prioridad => 30; // Prioridad ajustada para un Trío de Color
        public Resultado Aplicar(List<Carta> cartas)
        {
            if (cartas.Count != 3)
                throw new ArgumentException("Se requieren exactamente 3 cartas para un Trío de Color.");
            // Verifica que todas las cartas tengan el mismo palo
            if (cartas.Select(c => c.Palo).Distinct().Count() != 1)
                return new Resultado(Prioridad); // No es Trío de Color
            // Ordena las cartas por valor y verifica si son iguales (es decir, un trío)
            var ordenadasPorValor = cartas.OrderBy(cartas => cartas.Valor).ToList();
            if (ordenadasPorValor[0].Valor == ordenadasPorValor[1].Valor &&
                ordenadasPorValor[1].Valor == ordenadasPorValor[2].Valor)
            {
                var valor = (byte)ordenadasPorValor[0].Valor;
                return new Resultado(Prioridad, valor);
            }
            return new Resultado(Prioridad); // No es Trío de Color
        }
    }
}
