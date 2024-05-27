using Poker12.Core.Jugadas;
namespace Poker12.Core.Test.Jugadas
{
    public class DobleParTest
    {
        private IJugada _doblePar;
        public DobleParTest() => _doblePar = new DoblePar();
        [Fact]
        public void FallaPorMenosDeCuatroCartas()
        {
            var jugada = new List<Carta>();
            Assert.Throws<ArgumentException>(() => _doblePar.Aplicar(jugada));
        }
        [Fact]
        public void CorrectoDobleParConAs()
        {
            var jugada = new List<Carta>
            {
                new(EPalo.Picas, EValor.Siete),
                new(EPalo.Picas, EValor.Siete),
                new(EPalo.Corazon, EValor.Seis),
                new(EPalo.Picas, EValor.As),
                new(EPalo.Trebol, EValor.As),
            };
            var resultado = _doblePar.Aplicar(jugada);
            Assert.Equal(14, resultado.Valor);
        }
        [Fact]
        public void CorrectoPruebaDoblePar()
        {
            var jugada = new List<Carta>()
        {
            new(EPalo.Picas, EValor.Q),
            new(EPalo.Picas, EValor.Q),
            new(EPalo.Trebol, EValor.Seis),
            new(EPalo.Trebol, EValor.Seis),
            new(EPalo.Corazon, EValor.Cinco),
        };
            var resultado = _doblePar.Aplicar(jugada);

            Assert.Equal(6, resultado.Valor);
        }
        [Fact]
        public void IncorrectoDoblePar()
        {
            var jugada = new List<Carta>
            {
                new(EPalo.Corazon, EValor.Tres),
                new(EPalo.Picas, EValor.Tres),
                new(EPalo.Corazon, EValor.Seis),
                new(EPalo.Picas, EValor.Cinco),
                new(EPalo.Corazon, EValor.Ocho)
            };
            Assert.Throws<InvalidOperationException>(() => _doblePar.Aplicar(jugada));
        }
        
        [Fact]
        public void IncorrectoPruebaDoblePar()
        {
            var jugada = new List<Carta>()
    {
        new(EPalo.Picas, EValor.As),
        new(EPalo.Picas, EValor.As),
        new(EPalo.Trebol, EValor.Seis),
        new(EPalo.Trebol, EValor.Seis),
        new(EPalo.Corazon, EValor.Seis),
    };
            Assert.Throws<InvalidOperationException>(() => _doblePar.Aplicar(jugada));
        }
    }
}