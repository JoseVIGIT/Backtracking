using System;
using BackTracking;

internal class Program
{
    static void Main(string[] args)
    {
        // Celdas del tablero NxN
        // Movimientos posibles de la pieza en coordenadas (x,y) - valor inicial para coordenada 1..
        int celdas = 8;
        (int X, int Y)[] movPieza = { (2, 1), (1, 2), (-1, 2), (-2, 1), (-2, -1), (-1, -2), (1, -2), (2, -1) };

        // Inicializar tablero para tamaño dado, pieza concreta y coordenadas de la celda inicial
        Tablero tablero = new Tablero(celdas, movPieza, 1, 1);

        Console.WriteLine("Recorrido de tablero de ajedrez usando un caballo:\n");
        if (tablero.resolverTablero())
            tablero.imprimirTablero();
        else
            Console.WriteLine("No hay solución");
        Console.WriteLine("\nPulsa ENTER para salir...");
        Console.ReadLine();
    }
}
