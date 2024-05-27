namespace Poker12.Core.Jugadas;
public class Trio : JugadaAbs
{
    public Trio() : base("Trio", 7) { } 
    protected override Resultado Aplicar(CartasJugada cartas)
    {
        var grupos = cartas.AgrupadasPorValor;
        var conteoTrios = grupos.Count(g => g.Value.Count == 3);
        if (conteoTrios == 1)
        {
            var valorMaximo = grupos.First(g => g.Value.Count == 3).Key;
            return ResultadoCon(valorMaximo == EValor.As ? (byte)14 : (byte)valorMaximo);
        }
        else
        {
            throw new InvalidOperationException("No se encontró un trio.");
        }
    }
}
