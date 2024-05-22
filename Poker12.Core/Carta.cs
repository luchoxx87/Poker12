namespace Poker12.Core;
public readonly record struct Carta(EPalo Palo, EValor Valor) : IComparable<Carta>
{
    public int CompareTo(Carta otra)
        => Valor.CompareTo(otra.Valor) != 0 ?
            Valor.CompareTo(otra.Valor) :
            -1; // No importa orden a mismo valor, distinto palo
}