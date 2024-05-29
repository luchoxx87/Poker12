namespace Poker12.Core.Jugadas;
public class CartaAlta : JugadaAbs
{
    public CartaAlta() : base("Carta Alta", 10) { }
    protected override Resultado Aplicar(CartasJugada cartas)
        => ResultadoCon(cartas.MayorValorAbsoluto);
}
