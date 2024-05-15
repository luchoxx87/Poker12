namespace Poker12.Core.Jugadas;
public class Poker : IJugada
{
    public string Nombre => "Poker";
    public byte Prioridad => 3;
    public Resultado Aplicar(List<Carta> cartas)
    {
        if (cartas.Count == 0)
            throw new ArgumentException("No hay cartas");

        var numeros = cartas.
                        Select(c => (byte)c.Valor).
                        ToList();

        // Para obtener los números únicos
        var numerosDistintos = numeros.Distinct();

        // Para obtener la cantidad de números distintos
        int cantidadNumerosDistintos = numerosDistintos.Count();

        // Agrupar los números repetidos
        var numerosRepetidos = numeros.GroupBy(x => x)
                                        .Where(group => group.Count() > 1)
                                        .Select(group => group.Key)
                                        .ToList();

        var valor = numerosRepetidos[0];

        if (numerosRepetidos.Count == 1 && cantidadNumerosDistintos == 2)

            return new Resultado(Prioridad, valor);
        else 
            return new Resultado(Prioridad,0);
    }
}