namespace Poker12.Core.Jugadas;
public class Escalera(JugadaAbs? siguiente = null)
    : JugadaAbs("Escalera", 6, siguiente)
{
    protected override Resultado Aplicar(CartasJugada cartas)
    {
        if (cartas.SonConsecutivas)
            return ResultadoCon(cartas.MayorValorAbsoluto);
        return base.Aplicar(cartas);
    }
}