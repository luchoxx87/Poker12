using Poker12.Core.Jugadas;
namespace Poker12.Core.Test.Jugadas
{
    public class DobleParTest
    {
        private IJugada _doblePar;
        public DobleParTest() => _doblePar = new DoblePar();
        [Fact]
        public void FallaCuandoNoHaySuficientesCartas()
        {
            var jugada = new List<Carta>() { new Carta(EPalo.Corazon, EValor.As) };
            Assert.Throws<ArgumentException>(() => _doblePar.Aplicar(jugada));
        }
        [Fact]
        public void FallaCuandoNoSePuedeFormarUnDoblePar()
        {
            var jugada = new List<Carta>()
            {
                new Carta(EPalo.Corazon, EValor.As),
                new Carta(EPalo.Corazon, EValor.Dos),
                new Carta(EPalo.Corazon, EValor.Tres),
                new Carta(EPalo.Corazon, EValor.Cuatro)
            };
            Assert.Throws<InvalidOperationException>(() => _doblePar.Aplicar(jugada));
        }
        [Fact]
        public void ExitoCuandoSePuedeFormarUnDoblePar()
        {
            var jugada = new List<Carta>()
            {
                new Carta(EPalo.Corazon, EValor.As),
                new Carta(EPalo.Corazon, EValor.As),
                new Carta(EPalo.Corazon, EValor.Dos),
                new Carta(EPalo.Corazon, EValor.Dos)
            };
            var resultado = _doblePar.Aplicar(jugada);
            Assert.Equal(4, resultado.Prioridad);
            Assert.Equal((byte)EValor.As, resultado.Valor);
        }
    }
}
