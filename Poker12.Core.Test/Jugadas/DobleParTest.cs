using Xunit;
using Poker12.Core;
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
                new(EPalo.Corazon, EValor.Ocho)
            };
            var resultado = _doblePar.Aplicar(jugada);
            Assert.Equal(6, resultado.Valor); // Esperamos que el valor más alto entre los pares sea 6
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
            Assert.Equal(6, resultado.Valor);
        }
    }
}
