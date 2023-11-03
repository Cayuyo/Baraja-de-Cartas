// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

Mazo mazo = new();
Jugador jugador = new("jugadopr 1");

Console.WriteLine("Cartas en el mazo:");
foreach (Carta carta in mazo.Cartas)
{
    carta.Imprimir();
}
for (int i = 0; i < 5; i++)
{
    Carta cartaRobada = jugador.Robar(mazo);
    if (cartaRobada != null)
    {
        Console.WriteLine($"Carta robada por {jugador.Nombre}: {cartaRobada.Nombre} de {cartaRobada.Pinta}");
    }
}
Console.WriteLine();
jugador.MostrarMano();
jugador.Descartar(1);
jugador.MostrarMano();
