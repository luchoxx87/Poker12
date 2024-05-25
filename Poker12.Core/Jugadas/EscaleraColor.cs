namespace Poker12.Core.Jugadas;

public class EscaleraColor : JugadaAbs
{
    public EscaleraColor() : base("Escalera Color", 2) { }

    protected override Resultado Aplicar(CartasJugada cartas)
    {
        bool escaleraColor = cartas.SonConsecutivas && cartas.MismoPalo;
        if (escaleraColor)
        {
            return ResultadoCon((byte)cartas.MayorOrdenada.Valor);
        }
        return base.Aplicar(cartas);
    }
}