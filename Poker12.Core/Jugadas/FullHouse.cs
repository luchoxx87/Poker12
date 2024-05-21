namespace Poker12.Core.Jugadas;

public class FullHouse : IJugada
{
    public string Nombre => "FullHouse";
    public byte Prioridad => 4;
public Resultado Aplicar(List<Carta> cartas)
{
    if (cartas.Count == 0)
        throw new ArgumentException("No hay cartas");
    if (cartas.Count != 5)
        throw new ArgumentException("Se deben ingresar 5 cartas");

    var valorCounts = cartas.GroupBy(carta => carta.Valor).ToDictionary(group => group.Key, group => group.Count());

    var valor = valorCounts.LastOrDefault(x => x.Value == 3).Key;
    
if (valor == EValor.As)
    valor = EValor.K+1;
    
    if (valor != 0 && valorCounts.ContainsValue(2) && valorCounts.ContainsValue(3))
        return new Resultado(Prioridad, (byte)valor);
    else
        return new Resultado(Prioridad, 0);
}
}
