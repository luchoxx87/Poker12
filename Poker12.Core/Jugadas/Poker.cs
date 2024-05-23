namespace Poker12.Core.Jugadas;
public class Poker : JugadaAbs
{
    public Poker(string nombre, byte prioridad) : base("Poker", 3)
    {
    }
    protected override Resultado Aplicar(CartasJugada cartas)
    {
        var valorCon4 = cartas.MayorValorConNCartas(4);
        if (valorCon4 != 0 )
        return ResultadoCon(valorCon4);
        
        return base.Aplicar(cartas);
    }
}
