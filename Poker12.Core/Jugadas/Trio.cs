namespace Poker12.Core.Jugadas;
public class Trio : JugadaAbs
{
    public Trio() : base ("Trio", 7) {}
    
    protected override Resultado Aplicar(CartasJugada cartas)
    {
        var valorTrio = cartas.MayorValorConNCartas(3);
        if(valorTrio != 0)
            return ResultadoCon(valorTrio);
        
        return base.Aplicar(cartas);
        
    }
}