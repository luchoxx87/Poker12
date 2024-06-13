# Poker12
```mermaid
classDiagram

    ConPilaCartas <|-- CartasMesa
    ConPilaCartas <|-- Mazo
    CartasMesa --* Ronda
    Mazo --* Ronda
    Ronda --* IMezclador
    Jugadores --o Ronda


    class Jugadores{
        string Nombre
        Carta Carta1
        Carta Carta2
        ushort Fichas
        PuedeApostar(Monto) bool
        SacarFichas(Monto)
        AcreditarFichas(Monto)
        JugarResto()
    }

    class IMezclador{
        ObtenerCartas() IEnumerable~Carta~
        Mezclar (IEnumerable~Carta~)
    }

    class Mazo{
        Sacar() Carta
    }

    class CartasMesa{
        List~Carta~ bocaArriba
        DarVuelta() Carta
    }

    class Ronda{
        ushort ApuestaInicial
        ushort ApuestaTotal
        jugadores List~Jugador~
        Mazo Mazo
        CartasMesa CartasMesa
        Apostadores List~Jugadores~
    }

    class ConPilaCartas{
        ~ Stack~Carta~ Pila
        ~ ConPilaCartas(IEnumerable~Carta~)
    }


```

Motor conoce una mesa,
ronda es mesa,
Hacer los cambios de josbert.
