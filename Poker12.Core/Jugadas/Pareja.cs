namespace Poker12.Core.Jugadas;
public class Pareja : IJugada
{
    public string Nombre => "Pareja";
    public byte Prioridad => 9;
    public Resultado Aplicar(List<Carta> cartas)
    {
        if (cartas.Count == 0)
            throw new ArgumentException("No hay cartas");
        if (cartas.Count != 5)
            throw new ArgumentException("Tienen que ser 5 cartas >:V");

        var par = cartas.GroupBy(c => c.Valor)
                .Where(g => g.Count() == 2)
                .Select(g => g.Key)
                .Order()
                .ToList();

        if (par.Count < 0)
            return new Resultado(Prioridad, 0);

        var valor = par.First() == EValor.As ?
                    (byte)14 : // Aca use el valor 'Alto' del As
                    (byte)par.Last(); // Como estan ordenadas, la ultima es la mayor 

        return new Resultado(Prioridad, valor);
    }
}
