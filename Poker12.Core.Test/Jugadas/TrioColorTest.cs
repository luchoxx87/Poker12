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
                new(EPalo.Picas, EValor.Cinco),
                new(EPalo.Trebol, EValor.Cinco),
                new(EPalo.Corazon, EValor.Cinco),
<<<<<<< HEAD
                new(EPalo.Diamante, EValor.Siete),
                new(EPalo.Picas, EValor.Cuatro)
=======
                new(EPalo.Corazon, EValor.Cinco),
                new(EPalo.Corazon, EValor.Cinco),
                new(EPalo.Corazon, EValor.Siete),
                new(EPalo.Corazon, EValor.Cuatro)
>>>>>>> 1a48fc8bac6aa35651033d70fdf34c326e8e47ce
            };
            var resultado = _trioColor.Aplicar(jugada);
            Assert.Equal(5, resultado.Valor); 
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
            var resultado = _trioColor.Aplicar(jugada);
            Assert.Equal(0, resultado.Valor); 
        }
    }
}