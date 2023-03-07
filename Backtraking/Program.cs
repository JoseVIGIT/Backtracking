using System;

namespace BackTracking
{
    internal class Program
    {
        // Tamaño del tablero
        const int N = 8;

        /// <summary>
        /// El movimiento será válido si está dentro del tablero y la casilla == -1 --> no ha sido visitada
        /// </summary>
        /// <param name="celda">Celda que se comprobará si exite en el tablero y si no ha sido visitada aún</param>
        /// <param name="tablero">Tablero donde se comprueba la celda pasada a la función</param>
        /// <returns></returns>
        // 
        static bool movimientoValido((int x, int y) celda, int[,] tablero)
        {
            return (celda.x >= 0 && celda.x < N && celda.y >= 0 && celda.y < N && tablero[celda.x, celda.y] == -1);
        }

        /// <summary>
        /// Función recursiva - NOTA: podría implementarse usando Queue para evitar recursiones -
        /// Dada una posición y teniendo en cuenta el número de movimiento actual (movimiento i-esimo)
        /// se intenta mover el caballo a todas sus posibles posiciones (8 en total)
        /// Si el movimiento no es válido se descarta
        /// Si el movimiento es válido se marca la celda actual con el número de movimiento actual
        /// y se repite el proceso usando la posicion nueva y el número de movimiento nuevo (movimiento i-esimo + 1)
        /// Si el movimiento i-esimo es el N*N = total de celdas estamos en el último movimiento de la solución (TRUE)
        /// Si el movimiento no es el último y no hay movimientos válidos desde la casilla actual, no hay solución (FALSE)
        /// </summary>
        /// <param name="celda">Tupla con las coordenadas X, Y de la celda actual</param>
        /// <param name="mov_i">Movimiento i-esimo de la posible solución</param>
        /// <param name="tableroSolucion">Matriz que contendrá la solución final</param>
        /// <param name="movimientosPieza">Array de tuplas con todos los posibles movimientos de la pieza (desplazamiento en ejes x,y)</param>
        /// <returns></returns>
        static bool resolverTablero((int x, int y) celda, int mov_i, int[,] tableroSolucion, (int x, int y)[] movimientosPieza)
        {
            if (mov_i == N * N)
                return true;

            for (int m = 0; m < 8; m++)
            {
                (int x, int y) celdaSiguiente = (celda.x + movimientosPieza[m].x , celda.y + movimientosPieza[m].y);
                if (movimientoValido(celdaSiguiente, tableroSolucion))
                {
                    tableroSolucion[celdaSiguiente.x, celdaSiguiente.y] = mov_i;
                    if (resolverTablero(celdaSiguiente, mov_i + 1, tableroSolucion, movimientosPieza))
                        return true;
                    else
                        tableroSolucion[celdaSiguiente.x, celdaSiguiente.y] = -1; // Backtracking
                }
            }
            return false;
        }

        static void imprimirTablero(int[,] solucionTablero)
        {
            for (int x = 0; x < N; x++)
            {
                Console.WriteLine("+----+----+----+----+----+----+----+----+");
                for (int y = 0; y < N; y++)
                    Console.Write("| " + solucionTablero[x, y].ToString("D2") + " ");
                Console.WriteLine("|");
            }
            Console.WriteLine("+----+----+----+----+----+----+----+----+");
        }

        static void Main(string[] args)
        {
            // Posibles movimientos del caballo
            (int X, int Y)[] movPieza = { (2, 1), (1, 2), (-1, 2), (-2, 1), (-2, -1), (-1, -2), (1, -2), (2, -1) };
            
            // Matriz que guardará la solución con el número de salto en cada celda
            int[,] solucionTablero = new int[N, N]; 

            // Todas las celdas comienzan con -1 para marcarlas como no visitadas
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    solucionTablero[i, j] = -1;

            // Casilla de salida. Es la primera solución, el movimiento 0
            (int X, int Y) celda = (0, 0);
            solucionTablero[celda.X, celda.Y] = 0; 

            Console.WriteLine("Recorrido de tablero de ajedrez usando un caballo:\n");
            if (resolverTablero(celda, 1, solucionTablero, movPieza))
                imprimirTablero(solucionTablero);
            else
                Console.WriteLine("No hay solución");
            
            Console.WriteLine("\nPulsa ENTER para salir...");
            Console.ReadLine();
        }
    }
}
