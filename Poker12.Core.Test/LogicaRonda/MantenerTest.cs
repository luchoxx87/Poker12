namespace Poker12.Core.LogicaRonda.Test;
public class MantenerTest() : RespuestaBase
{    
    [Fact]
    public void MantenerOk() 
    {        
        ApuestaInicial = 50;
        RespuestaJugadorARonda mantener = new Mantener (Tomy, ronda, ApuestaInicial);

        mantener.Ejecutar();

        Assert.Equal(50, Tomy.Fichas);
        Assert.Equal(50, ronda.ApuestaTotal);
    }
}
