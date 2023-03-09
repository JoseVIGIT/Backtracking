using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackTracking
{
    public partial class Form1 : Form
    {
        // Celdas del tablero NxN
        // Movimientos posibles de la pieza en coordenadas (x,y) - valor inicial para coordenada 1..
        int celdas = 3;
        (int X, int Y)[] movPieza = { (2, 1), (1, 2), (-1, 2), (-2, 1), (-2, -1), (-1, -2), (1, -2), (2, -1) };
        Tablero tablero;
        Task<Tablero> tareaTablero;
        int tamCelda;

        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
            celdas = int.Parse(txtDimensionN.Text);            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            DibujaTablero(e.Graphics, panel1.ClientSize, 8, 8);
        }

        private async void DibujaTablero(Graphics g, Size Tam, int X, int Y)
        {
            if (tablero == null)
                tablero = await tareaTablero;

            tamCelda = Tam.Width / tablero.N;
            panel1.Width = tamCelda * tablero.N;
            panel1.Height = panel1.Width;
            Brush color = Brushes.Black;
            Brush colorCelda = Brushes.Black;
            for (int y = 0; y < tablero.N; y++)
            {
                color = (color == Brushes.Black) ? Brushes.White : Brushes.Black;
                colorCelda = color;
                for (int x = 0; x < tablero.N; x++)
                {
                    colorCelda = (colorCelda == Brushes.Black) ? Brushes.White : Brushes.Black;
                    g.FillRectangle(colorCelda, x * tamCelda, y * tamCelda, tamCelda, tamCelda);
                }
            }
            pictureBox1.Width = tamCelda;
            pictureBox1.Height = tamCelda;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            txtAviso.Text = "Generando tablero y solución...";
            pictureBox1.Parent = panel1;            
            Task tareaTablero = Task.Run(() =>
            {
                // Inicializar tablero para tamaño dado, pieza concreta y coordenadas de la celda inicial
                tablero = new Tablero(celdas, movPieza, 1, 1);
                tablero.resolverTablero();
                return tablero;
            });
            await tareaTablero;
            if (tablero.solucionado)
            {
                string[] tmp = Array.ConvertAll(tablero.recorridoSolucion(tablero.tableroSolucion), t => $"({1 + t.Item1}, {1 + t.Item2})");
                string recorrido = String.Join(" -> ", tmp);
                textBox1.Text = recorrido;

                button1.Enabled = true;
            } else
            {
                textBox1.Text = "Sin solución...";
            }
            moverPieza(0, 0); //TODO : mover a la celda de inicio
            txtAviso.Text = "";
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            foreach (var item in tablero.recorridoSolucion(tablero.tableroSolucion))
            {
                moverPieza(item.Item1 * tamCelda, item.Item2 * tamCelda);
                panel1.Refresh();
                await Task.Delay(int.Parse(textBox2.Text));
            }
            button1.Enabled = true;
        }

        private void moverPieza(int x=1, int y=1)
        {
            pictureBox1.Location = new Point(x, y);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //TODO : llamar a contructor con datos formulario
            // Inicializar tablero para tamaño dado, pieza concreta y coordenadas de la celda inicial
            tablero = new Tablero(int.Parse(txtDimensionN.Text), movPieza, int.Parse(txtOrigenX.Text), int.Parse(txtOrigenY.Text));
            tablero.resolverTablero();
            panel1.Refresh();
        }
    }
}
