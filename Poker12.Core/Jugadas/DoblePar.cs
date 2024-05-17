namespace Poker12.Core.Jugadas;
public class DoblePar : IJugada
{
    public string Nombre => "Doble Par";
    public byte Prioridad => 8; // Podemos asignarle una prioridad adecuada basada en las reglas del póker
    public Resultado Aplicar(List<Carta> cartas)
    {
        if (cartas.Count < 4)
            throw new ArgumentException("Necesitas al menos 4 cartas para jugar un Doble Par");

        var ordenadaPorValor = cartas.OrderBy(x => x.Valor).ToList();
        var cartaByte = cartas.Select(x => (byte)x.Valor);
        var LastValue = (byte)ordenadaPorValor.Last().Valor;
        int esPar1 = 0;
        int esPar2 = 0;
        int esPar3 = 0;

        foreach (var item in cartaByte)
        {
            foreach (var numero in cartaByte)
            {
                if (esPar2 == 2)
                {
                    break;
                }
                if (esPar1 == 2)
                {
                    esPar2++;
                }
                if (item == numero)
                {
                    esPar1++;
                }
            }
        }

        foreach (var item in cartaByte)
        {
            if (LastValue == item)
            {
                esPar3++;
            }
        }

        if (esPar1 == 2 && esPar2 == 2)
        {
            if (esPar3 == 2)
            {
                var valor1 = ordenadaPorValor.First().Valor == EValor.As ? (byte)14 : (byte)ordenadaPorValor.Last().Valor;
                return new Resultado(Prioridad, valor1);                
            }
            ordenadaPorValor.Remove(ordenadaPorValor.Last());
            var valor2 = ordenadaPorValor.First().Valor == EValor.As ? (byte)14 : (byte)ordenadaPorValor.Last().Valor;
                return new Resultado(Prioridad, valor2);   
        }
    
        return new Resultado(Prioridad, (byte)0);
    }
}