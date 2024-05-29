using Poker12.Core.Jugadas;
namespace Poker12.Core.Test.Jugadas
{
    public class TrioTest
    {
        private IJugada _trioColor;
        public TrioTest() => _trioColor = new Trio();
        [Fact]
        public void FallaPorMenosDeTresCartas()
        {
            var jugada = new List<Carta>();
            Assert.Throws<ArgumentException>(() => _trioColor.Aplicar(jugada));
        }
        [Fact]
        public void CorrectoTrioColor()
        {
            var jugada = new List<Carta>
            {
                new(EPalo.Picas, EValor.As),
                new(EPalo.Trebol, EValor.As),
                new(EPalo.Corazon, EValor.As),
                new(EPalo.Diamante, EValor.Siete),
                new(EPalo.Picas, EValor.Cuatro)
            };
            var resultado = _trioColor.Aplicar(jugada);
            Assert.Equal(14, resultado.Valor); 
        }
        [Fact]
        public void IncorrectoTrioColor()
        {
            var jugada = new List<Carta>
            {
                new(EPalo.Corazon, EValor.As),
                new(EPalo.Diamante, EValor.Seis),
                new(EPalo.Picas, EValor.Siete),
                new(EPalo.Corazon, EValor.Cinco),
                new(EPalo.Corazon, EValor.Cinco)
            };
            Assert.Throws<InvalidOperationException>(() => _trioColor.Aplicar(jugada));

        }
    }
}

