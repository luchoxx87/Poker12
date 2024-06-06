namespace Poker12.Core;

public class Jugador
{
    public string Nombre { get; set; }
    public Carta? carta1 { get; set; }
    public Carta? carta2 { get; set; }
    public ushort Fichas { get; private set; }

    public Jugador(string Nombre, ushort Fichas)
    {
        this.Nombre = Nombre;
        this.Fichas = Fichas;
    }
    public bool PuedeApostar(ushort FichasMesa)
        => Fichas >= FichasMesa;
    public void SacarFichas(ushort FichasMesa)
    {
        if (!PuedeApostar(FichasMesa))
            throw new InvalidOperationException();
            
        Fichas-=FichasMesa;
    }
    public void AcreditarFichas(ushort FichasMesa)
    =>Fichas+=FichasMesa;

    public void Jugarresto()
    =>Fichas=0;
    
}