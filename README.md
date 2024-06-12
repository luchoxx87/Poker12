# Poker12
```mermaid
classDiagram

    ConPilaCartas <|-- CartasMesa
    ConPilaCartas <|-- Mazo
    CartasMesa --* Mesa
    Mazo --* Mesa
    Mesa --* IMezclador
    Jugadores --o Mesa


    class Jugadores{
        string Nombre
        Carta : Carta1
        Carta : Carta2
        ushort : Fichas
        Jugadores : PuedeApostar(Monto) bool
        Jugadores : ApostarResto()
        Jugadores : Retirarse()
        Jugadores : Apostar(int Dinero)
    }

    class IMezclador{
        ObtenerCartas() IEnumerable~Carta~
        Mezclar (IEnumerable~Carta~)
    }

    class Mazo{
        Sacar() Carta
    }

    class CartasMesa{
        bocaArriba:List~Carta~
        CartasMesa : DarVuelta() Carta
    }

    class Mesa{
        ushort : ApuestaInicial
        ushort : ApuestaTotal
        jugadores: List~Jugador~
        Mazo : Mazo
        CartasMesa : CartasMesa
        Apostadores : List~Jugadores~
    }

    class ConPilaCartas{
        ~ Stack~Carta~ Pila
        ConPilaCartas : ~ ConPilaCartas(IEnumerable~Carta~)
    }


```