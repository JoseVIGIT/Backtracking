using System;

namespace BackTracking
{
    internal class Tablero
    {
        // Tamaño del tablero. No está pensado para que sea cambiado. Se trata de un tablero de ajedrez de 8x8
        public int N; // = 8;
        public int[,] tableroSolucion;
        // Casilla de salida. Es la primera solución, el movimiento 0
        public (int X, int Y) celda; // = (0, 0);
        // Posibles movimientos del caballo
        (int X, int Y)[] movPieza; // = { (2, 1), (1, 2), (-1, 2), (-2, 1), (-2, -1), (-1, -2), (1, -2), (2, -1) };
        public bool solucionado; // = false;

        /// <summary>
        /// Tablero se inicia con celdas (NxN), movimientos de la pieza a usar, coordenada X y coordenada Y de la celda de inicio
        /// </summary>
        /// <param name="celdas">Dimensiones del tablero (NxN)</param>
        /// <param name="movimientos">Posibles movimientos de la pieza</param>
        /// <param name="x">Coordenada X de celda de origen</param>
        /// <param name="y">Coordenada Y de celda de origen</param>
        public Tablero (int celdas, (int X, int Y)[] movimientos , int x, int y)
        {
            N = celdas;
            celda = (x-1, y-1); // -1 para poder comenzar en 1,1 en vez de en 0,0 al llamar al constructor
            movPieza = movimientos;
            tableroSolucion = new int[N, N];
            solucionado = false;

            iniciarTableroSoluciones();
        }

        /// <summary>
        /// El movimiento será válido si está dentro del tablero y la casilla == -1 --> no ha sido visitada
        /// </summary>
        /// <param name="celda">Celda que se comprobará si exite en el tablero y si no ha sido visitada aún</param>
        /// <param name="tablero">Tablero donde se comprueba la celda pasada a la función</param>
        /// <returns>Indica si es el movimiento es vaído (true) o no (false)</returns> 
        bool movimientoValido((int x, int y) celda, int[,] tablero)
        {
            return (celda.x >= 0 && celda.x < N && celda.y >= 0 && celda.y < N && tablero[celda.x, celda.y] == -1);
        }

        void iniciarTableroSoluciones ()
        {
            // Todas las celdas comienzan con -1 para marcarlas como no visitadas
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    tableroSolucion[i, j] = -1;
            tableroSolucion[celda.X, celda.Y] = 0; // Primera solución - punto de partida -
        }

        public bool resolverTablero()
        {
            iniciarTableroSoluciones();
            solucionado = (resolverTablero_pri(celda, 1, tableroSolucion));
            return solucionado;
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
        /// <returns>Devuelve si se resolvió (true) o no (false)</returns>
        public bool resolverTablero_pri((int x, int y) celda, int mov_i, int[,] tableroSolucion)
        {
            if (mov_i == N * N)
                return true;

            for (int m = 0; m < movPieza.Length; m++)
            {
                (int x, int y) celdaSiguiente = (celda.x + movPieza[m].X, celda.y + movPieza[m].Y);
                if (movimientoValido(celdaSiguiente, tableroSolucion))
                {
                    tableroSolucion[celdaSiguiente.x, celdaSiguiente.y] = mov_i;
                    if (resolverTablero_pri(celdaSiguiente, mov_i + 1, tableroSolucion))
                        return true;
                    else
                        tableroSolucion[celdaSiguiente.x, celdaSiguiente.y] = -1; // Backtracking
                }
            }
            return false;
        }

        /// <summary>
        /// Dado un tablero con pasos en cada celda, se devuelve un array de tuplas ordenadas de primer a último paso
        /// </summary>
        /// <param name="tableroSolucion">Tablero con pasos completados</param>
        /// <returns>Array ordenado de las coordenadas de los pasos dados para solucionar el caso</returns>
        public (int, int)[] recorridoSolucion(int[,] tableroSolucion)
        {
            (int x, int y)[] recorridoSolucion = new (int, int)[N * N];
            bool encontrado;
            for (int movimiento = 0; movimiento < N * N; movimiento++)
                for (int y = 0; y < N; y++)
                {
                    encontrado = false;
                    for (int x = 0; x < N; x++)
                        if (tableroSolucion[x, y] == movimiento)
                        {
                            recorridoSolucion[movimiento] = (y, x);
                            encontrado = true;
                            break;
                        }
                    if (encontrado) break;
                }
            return recorridoSolucion;
        }

        public void imprimirTablero()
        {
            if (!solucionado)
                return;

            string separador = "";
            for (int NCeldas = 0; NCeldas < N; NCeldas++)
                separador += "+----";
            separador += "+";

            for (int x = 0; x < N; x++)
            {
                Console.WriteLine(separador);
                for (int y = 0; y < N; y++)
                    Console.Write("| " + tableroSolucion[x, y].ToString("D2") + " ");
                Console.WriteLine("|");
            }
            Console.WriteLine(separador);

            Console.WriteLine("\nRecorrido realizado:\n");
            int movimiento = 0;
            foreach ((int x, int y) celda in recorridoSolucion(tableroSolucion))
            {
                if (++movimiento > N)
                {
                    Console.WriteLine();
                    movimiento = 1;
                }
                Console.Write("(" + (1+celda.x).ToString() + ", " + (1+celda.y).ToString() + ")  ");
            }
            Console.WriteLine();
        }
    }
}
