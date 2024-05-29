using Poker12.Core.Jugadas;
namespace Poker12.Core.Jugadas
{
    public class DoblePar : JugadaAbs
    {
        public DoblePar() : base("Doble Par", 8) { }
        protected override Resultado Aplicar(CartasJugada cartas)
        {
            var gruposCon2 = cartas.AgrupadasPorValor
                .Where(g => g.Value.Count == 2)
                .Select(g => g.Key)
                .Order();
            
            if (gruposCon2.Count() != 2)
                return base.Aplicar(cartas);
            
            int valor = gruposCon2.First() == EValor.As ?
                            14 * 10 + (int)gruposCon2.Last() :
                            (int)gruposCon2.First() * 10 + (int)gruposCon2.Last() ;

            return ResultadoCon((byte)valor);
        }
    }
}