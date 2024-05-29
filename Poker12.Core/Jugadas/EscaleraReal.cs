using System.Collections.Immutable;
using System.Runtime.InteropServices;
using Poker12.Core.Jugadas;
namespace Poker12.Core.Jugadas; 
public class EscaleraReal: JugadaAbs
{
    public EscaleraReal(): base("Escalera Real", 1) {}
    protected override Resultado Aplicar(CartasJugada cartas)
    {
        bool escaleraReal = cartas.MismoPalo && cartas.SonConsecutivas &&
            cartas.MenorOrdenada.Valor == EValor.As && cartas.MayorOrdenada.Valor == EValor.K;

        if (escaleraReal)
        {
            return ResultadoCon(cartas.MayorValorAbsoluto);
        }
        return base.Aplicar(cartas);
    }
}