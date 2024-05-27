namespace Poker12.Core.Jugadas;
public class DoblePar : JugadaAbs
{
    public DoblePar() : base("Doble Par", 7) { }
    protected override Resultado Aplicar(CartasJugada cartas)
    {
        var grupos = cartas.AgrupadasPorValor;
        var conteoPares = grupos.Where(g => g.Value.Count == 2).Count();
        if (conteoPares == 2)
        {
            var valor1 = grupos.First(g => g.Value.Count == 2).Key == EValor.As? (byte)14 : (byte)grupos.First(g => g.Value.Count == 2).Key;
            var valor2 = grupos.FirstOrDefault(g => g.Value.Count == 2).Key == EValor.As? (byte)14 : (byte)grupos.FirstOrDefault(g => g.Value.Count == 2).Key;
            return ResultadoCon(Math.Max(valor1, valor2));
        }
        else
        {
            throw new InvalidOperationException("No se encontraron exactamente dos pares.");
        }
    }
}
