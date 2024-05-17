namespace Poker12.Core.Jugadas;

public class TrioColor : IJugada
{
    public string Nombre => "Trio Color";

    public byte Prioridad => 8; // Podemos asignarle una prioridad adecuada basada en las reglas del póker

    public Resultado Aplicar(List<Carta> cartas)
    {
        if (cartas.Count < 3)
            throw new ArgumentException("Necesitas al menos 3 cartas para jugar un Trio Color");

        var palos = cartas.Select(c => c.Palo).Distinct().ToList();

        if (palos.Count!= 1)
            return new Resultado(Prioridad, 0); // Todas las cartas no son del mismo palo

        return new Resultado(Prioridad, (byte)(palos[0] + 10)); // Sumamos 10 porque el As vale 1 y queremos evitar conflictos
    }
}
