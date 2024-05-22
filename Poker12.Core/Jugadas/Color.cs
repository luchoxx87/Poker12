namespace Poker12.Core.Jugadas;
public class Color(JugadaAbs? siguiente = null)
    : JugadaAbs("Color", 5, siguiente)
{
    protected override Resultado Aplicar(CartasJugada cartas)
    {
        if (cartas.MismoPalo)
            return ResultadoCon(cartas.MayorValorAbsoluto);
        return base.Aplicar(cartas);
    }
}