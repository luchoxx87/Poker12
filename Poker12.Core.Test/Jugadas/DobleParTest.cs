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
        public void CorrectoDobleParDelMismoRango()
        {
            var jugada = new List<Carta>
            {
                new(EPalo.Corazon, EValor.Tres),
                new(EPalo.Picas, EValor.Tres),
                new(EPalo.Corazon, EValor.Seis),
                new(EPalo.Picas, EValor.Seis),
                new(EPalo.Corazon, EValor.Siete)
            };

            var resultado = _doblePar.Aplicar(jugada);

            Assert.Equal(14, resultado.Valor); // El par de treses y seis suman 14
        }

        [Fact]
        public void IncorrectoDobleParDelMismoRango()
        {
            var jugada = new List<Carta>
            {
                new(EPalo.Corazon, EValor.Tres),
                new(EPalo.Picas, EValor.Tres),
                new(EPalo.Corazon, EValor.Seis),
                new(EPalo.Picas, EValor.Seis),
                new(EPalo.Corazon, EValor.Ocho)
            };

            var resultado = _doblePar.Aplicar(jugada);

            Assert.Equal(0, resultado.Valor); // No hay dos pares del mismo rango
        }

        [Fact]
        public void CorrectoDobleParDistintoRango()
        {
            var jugada = new List<Carta>
            {
                new(EPalo.Corazon, EValor.Tres),
                new(EPalo.Picas, EValor.Tres),
                new(EPalo.Corazon, EValor.Seis),
                new(EPalo.Picas, EValor.Seis),
                new(EPalo.Corazon, EValor.Siete)
            };

            var resultado = _doblePar.Aplicar(jugada);

            Assert.Equal(13, resultado.Valor); // El par de treses y seis suman 13
        }

        [Fact]
        public void IncorrectoDobleParDistintoRango()
        {
            var jugada = new List<Carta>
            {
                new(EPalo.Corazon, EValor.Tres),
                new(EPalo.Picas, EValor.Tres),
                new(EPalo.Corazon, EValor.Seis),
                new(EPalo.Picas, EValor.Seis),
                new(EPalo.Corazon, EValor.Nueve)
            };

            var resultado = _doblePar.Aplicar(jugada);

            Assert.Equal(0, resultado.Valor); // No hay dos pares del mismo rango
        }
    }
}
