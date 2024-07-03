namespace Poker12.Core;
public class Jugador
{
    public string Nombre { get; set; }
    public Carta? Carta1 { get; set; }
    public Carta? Carta2 { get; set; }
    public ushort Fichas { get; private set; }
    public bool Activo { get; private set; } = true;
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

        Fichas -= FichasMesa;
    }
    public void AcreditarFichas(ushort FichasMesa)
        => Fichas += FichasMesa;

    public void JugarResto() => Fichas = 0;
    public void Retirarse() => Activo = false;
    public void Activar() => Activo = true;
    /// <summary>
    /// Asigna ambas cartas
    /// </summary>
    /// <param name="primera"></param>
    /// <param name="segunda"></param>
    public void EntregarCartas(Carta primera, Carta segunda)
    {
        //TODO
    }
    /// <summary>
    /// Asigna las cartas en orden, si la primera es null, asigna la segunda.
    /// </summary>
    /// <param name="carta"></param>
    public void EntregarCarta(Carta carta)
    {
        //TODO
    }
    public void Descartar()
        => Carta1 = Carta2 = null;
}