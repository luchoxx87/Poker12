using System.Collections.Immutable;

namespace Poker12.Core.Jugadas;
public class CartasJugada
{
    /// <summary>
    /// Representa la colección en base a la que se creo este objeto
    /// </summary>
    /// <value></value>
    public ImmutableList<Carta> Cartas { get; init; }
    /// <summary>
    /// Indica si todas las cartas son del mismo palo
    /// </summary>
    /// <value></value>
    public bool MismoPalo { get; init; }
    public CartasJugada(List<Carta> cartas)
    {
        Cartas = cartas.ToImmutableList();
        MismoPalo = cartas.All(c => c.Palo == cartas[0].Palo);
    }
    private ImmutableSortedSet<Carta>? _ordenadasPorValor;
    private ImmutableDictionary<EValor, ImmutableList<Carta>>? _agrupadasPorValor;
    /// <summary>
    /// Colección de cartas ordenadas por valor
    /// </summary>
    public ImmutableSortedSet<Carta> OrdenadasPorValor
        => _ordenadasPorValor ??= [.. Cartas];
    public ImmutableDictionary<EValor, ImmutableList<Carta>> AgrupadasPorValor
        => _agrupadasPorValor ??=
            Cartas.GroupBy(c => c.Valor).
            ToImmutableDictionary(g => g.Key, g => g.ToImmutableList());
    /// <summary>
    /// Carta de menor valor de la colección
    /// </summary>
    /// <returns>Devuelve la menor carta ordenada por valor</returns>
    public Carta MenorOrdenada => OrdenadasPorValor.First();
    /// <summary>
    /// Carta de mayor valor de la colección
    /// </summary>
    /// <returns>Devuelve la mayor carta ordenada por valor</returns>
    public Carta MayorOrdenada => OrdenadasPorValor.Last();
    /// <summary>
    /// Devuelve el mayor valor absoluto que cumple tener al menos la misma cantidad de cartas.
    /// </summary>
    /// <param name="nCartas">Cantidad de cartas</param>
    /// <returns>Devuelve el valor absoluto y cero en caso de no existir</returns>
    public byte MayorValorConNCartas(int nCartas)
    {
        var valoresOrdenados = AgrupadasPorValor.
                Where(g => g.Value.Count == nCartas).
                Select(g => (byte)g.Key).
                Order().
                DefaultIfEmpty((byte)0);

        return MayorValor(valoresOrdenados);
    }
    /// <summary>
    /// En base a una lista ordenada, devuelve el mayor valor absoluto
    /// </summary>
    /// <param name="listaOrdenada">Lista que tiene que estar en orden ascendente</param>
    /// <returns>Mayor valor absoluto. Para As es 14</returns>
    static public byte MayorValor(IEnumerable<byte> listaOrdenada)
        => listaOrdenada.First() == (byte)EValor.As ?
            (byte)14 :
            listaOrdenada.Last();
    /// <summary>
    /// En base a una lista ordenada, devuelve el mayor valor absoluto
    /// </summary>
    /// <param name="listaOrdenada">Lista que tiene que estar en orden ascendente</param>
    /// <returns>Mayor valor absoluto. Para As es 14</returns>
    static public byte MayorValor(IEnumerable<Carta> listaOrdenada)
        => MayorValor(listaOrdenada.Select(c => (byte)c.Valor));
    /// <summary>
    /// Devuelve el mayor valor absoluto de la colección. Si es As devuelve 14.
    /// </summary>
    public byte MayorValorAbsoluto => MayorValor(OrdenadasPorValor);
    /// <summary>
    /// Representa si las cartas cumplen un orden consecutivo
    /// </summary>
    public bool SonConsecutivas
    {
        get
        {
            byte i = (byte)MenorOrdenada.Valor;
            if (OrdenadasPorValor.All(c => (byte)c.Valor == i++))
                return true;
            i = (byte)EValor.Diez;
            return OrdenadasPorValor.Skip(1).All(c => (byte)c.Valor == i++);
        }
    }
}