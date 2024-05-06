namespace Poker12.Core;
public class Carta (EPalo palo, EValor valor)
{
    public EPalo Palo { get; private set; } = palo;
    public EValor Valor { get; private set; } = valor;
    public override string ToString() => $"{Valor} {Palo}";
}
