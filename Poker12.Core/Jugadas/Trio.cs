namespace Poker12.Core.Jugadas;
public class Trio : JugadaAbs
{
    public Trio() : base ("Trio", 7) {}
    
    protected override Resultado Aplicar(CartasJugada cartas)
    {
        if(cartas.AgrupadasPorValor.Count==4)
        return ResultadoCon(cartas.MayorValorAbsoluto);
            return base.Aplicar(cartas);
    }
}