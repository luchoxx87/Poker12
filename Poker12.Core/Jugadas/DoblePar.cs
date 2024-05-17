namespace Poker12.Core.Jugadas;
public class DoblePar : IJugada
{
    public string Nombre => "Doble Par";

    public byte Prioridad => 7; // Podemos asignarle una prioridad adecuada basada en las reglas del póker

    public Resultado Aplicar(List<Carta> cartas)
    {
        if (cartas.Count < 4)
            throw new ArgumentException("Necesitas al menos 4 cartas para jugar un Doble Par");

        var valores = cartas.Select(c => c.Valor).ToList();

        // Contar cuántas veces aparece cada valor
        var conteoValores = valores.GroupBy(v => v).ToDictionary(g => g.Key, g => g.Count());

        // Buscar los valores que aparecen exactamente dos veces
        var parejas = conteoValores.Where(p => p.Value == 2).Select(p => p.Key).ToList();

        if (parejas.Count!= 2)
            return new Resultado(Prioridad, 0); // No hay dos pares

        // Verificar si uno de los pares es de dos cartas del mismo rango
        var primerPar = parejas[0];
        var segundoPar = parejas[1];
        if (primerPar == segundoPar)
            return new Resultado(Prioridad, (byte)(primerPar + 9)); // Sumamos 9 porque el As vale 1 y queremos evitar conflictos

        // Si no cumplimos con el criterio de tener dos pares del mismo rango, retornamos 0
        return new Resultado(Prioridad, 0);
    }
}
