

class Carta
{
    public string Nombre { get; set; }
    public string Pinta { get; set; }
    public int Valor { get; set; }

    public Carta(string n, string p, int v)
    {
        Nombre = n;
        Pinta = p;
        Valor = v;
    }

    public void Imprimir()
    {
        Console.WriteLine("Carta: {0} de {1}, Valor: {2}", Nombre, Pinta, Valor);
    }
}

class Mazo
{
    public List<Carta> Cartas {get; set;}
    public Mazo()
    {
        Cartas = new List<Carta>();
        string[] pintas = { "Diamantes", "Corazones", "Picas", "Treboles" };
        foreach (string pinta in pintas)
        {
            for (int v = 1; v <= 13; v++)
            {
                string nombre = ObtenerNombreCarta(v);
                Cartas.Add(new Carta(nombre, pinta, v));
            }
        }
    }

    static string ObtenerNombreCarta(int v)
    {
        switch (v)
        {
            case 1:
                return "As";
            case 11:
                return "Jota";
            case 12:
                return "Reina";
            case 13:
                return "Rey";
            default:
                return v.ToString();
        }
    }

    public Carta Repartir()
    {
        if (Cartas.Count > 0)
        {
            Random random = new();
            int indice = random.Next(Cartas.Count);
            Carta cartaRepartida = Cartas[indice];
            Cartas.RemoveAt(indice);
            return cartaRepartida;
        }
        else
        {
            Console.WriteLine("El mazo está vacío. No se pueden repartir más cartas :c.");
            return null;
        }
    }

    public void Reiniciar()
    {
        Cartas = new List<Carta>();
    }

    public void Barajar()
    {
        Random random = new();
        Cartas = Cartas.OrderBy(carta => random.Next()).ToList();
    }
}

class Jugador
{
    public string Nombre {get; set;}
    public List<Carta> Mano {get; set;}

    public Jugador(string nombre)
    {
        Nombre = nombre;
        Mano = new List<Carta>();
    }

    public Carta Robar(Mazo mazo)
    {
        Carta cRobada = mazo.Repartir();
        if (cRobada != null)
        {
            Mano.Add(cRobada);
        }
        return cRobada;
    }

    public Carta Descartar(int indice)
    {
        if (indice >= 0 && indice < Mano.Count)
        {
            Carta cartaDescartada = Mano[indice];
            Mano.RemoveAt(indice);
            return cartaDescartada;
        }
        else
        {
            Console.WriteLine("Índice de descarte no válido. No se pudo descartar la carta.");
            return null;
        }
    }

    public void MostrarMano()
    {
        Console.WriteLine("Mano de {0}:", Nombre);
        foreach (Carta carta in Mano)
        {
            carta.Imprimir();
        }
    }
}