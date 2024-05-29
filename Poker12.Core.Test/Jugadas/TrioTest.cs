using Poker12.Core.Jugadas;
namespace Poker12.Core.Test.Jugadas
{
    public class TrioTest
    {
        private IJugada _trio;
        public TrioTest() => _trio = new Trio();
        [Fact]
        public void FallaPorMenosDeTresCartas()
        {
            var jugada = new List<Carta>();
            Assert.Throws<ArgumentException>(() => _trio.Aplicar(jugada));
        }
        [Fact]
        public void CorrectoTrioConAs()
        {
            var jugada = new List<Carta>
            {
                new(EPalo.Picas, EValor.As),
                new(EPalo.Picas, EValor.As),
                new(EPalo.Picas, EValor.As),
                new(EPalo.Diamante, EValor.Siete),
                new(EPalo.Picas, EValor.Cuatro)
            };
            var resultado = _trio.Aplicar(jugada);
            Assert.Equal(14, resultado.Valor);
        }
        [Fact]
        public void CorrectoTrio()
        {
            var jugada = new List<Carta>
            {
                new(EPalo.Picas, EValor.K),
                new(EPalo.Picas, EValor.K),
                new(EPalo.Picas, EValor.K),
                new(EPalo.Diamante, EValor.Siete),
                new(EPalo.Picas, EValor.Cuatro)
            };
            var resultado = _trio.Aplicar(jugada);
            Assert.Equal(13, resultado.Valor); 
        }
        [Fact]
        public void IncorrectoTrio()
        {
            var jugada = new List<Carta>
            {
                new(EPalo.Corazon, EValor.As),
                new(EPalo.Diamante, EValor.Seis),
                new(EPalo.Picas, EValor.Siete),
                new(EPalo.Corazon, EValor.Cinco),
                new(EPalo.Corazon, EValor.Cinco)
            };
            Assert.Throws<InvalidOperationException>(() => _trio.Aplicar(jugada));
        }
        [Fact]
        public void IncorrectoTrio2()
        {
            var jugada = new List<Carta>
            {
                new(EPalo.Corazon, EValor.K),
                new(EPalo.Diamante, EValor.Seis),
                new(EPalo.Picas, EValor.Ocho),
                new(EPalo.Corazon, EValor.Cinco),
                new(EPalo.Corazon, EValor.Cinco)
            };
            Assert.Throws<InvalidOperationException>(() => _trio.Aplicar(jugada));
        }
    }
}
