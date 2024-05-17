using Poker12.Core.Jugadas;

namespace Poker12.Core.Test.Jugadas
{
    public class TrioColorTest
    {
        private IJugada _trioColor;

        public TrioColorTest() => _trioColor = new TrioColor();

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
                new(EPalo.Corazon, EValor.Cinco),
                new(EPalo.Corazon, EValor.Cinco),
                new(EPalo.Corazon, EValor.Cinco)
            };

            var resultado = _trioColor.Aplicar(jugada);

            Assert.Equal(5, resultado.Valor); // El As vale 1, por lo que el resultado es 11
        }

        [Fact]
        public void IncorrectoTrioColor()
        {
            var jugada = new List<Carta>
            {
                new(EPalo.Corazon, EValor.As),
                new(EPalo.Diamante, EValor.Seis),
                new(EPalo.Picas, EValor.Siete)
            };

            var resultado = _trioColor.Aplicar(jugada);

            Assert.Equal(0, resultado.Valor); // Todas las cartas no son del mismo palo
        }
    }
}
