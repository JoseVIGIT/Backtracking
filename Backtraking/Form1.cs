using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BackTracking
{
    public partial class Form1 : Form
    {
        // Celdas del tablero NxN
        // Movimientos posibles de la pieza en coordenadas (x,y) - valor inicial para coordenada 1..
        int celdas;
        readonly (int X, int Y)[] movPieza = { (2, 1), (1, 2), (-1, 2), (-2, 1), (-2, -1), (-1, -2), (1, -2), (2, -1) };
        Tablero tablero;
        Task<Tablero> tareaTablero;
        int tamCelda;

        public Form1()
        {
            InitializeComponent();
            btnComenzar.Enabled = false;
            celdas = (int)(numDimensionN.Value);            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            DibujaTablero(e.Graphics, panel1.ClientSize, 8, 8);
        }

        private async void DibujaTablero(Graphics g, Size Tam, int X, int Y)
        {
            if (tablero == null)
                tablero = await tareaTablero;

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
        private async void prepararObjetos()
        {
            pictureBox1.Parent = panel1;
            tareaTablero = Task.Run(() =>
            {
                // Inicializar tablero para tamaño dado, pieza concreta y coordenadas de la celda inicial
                tablero = new Tablero((int)numDimensionN.Value, movPieza, (int)numOrigenX.Value, (int)numOrigenX.Value);
                tamCelda = panel1.Width / tablero.N;
                //tablero.resolverTablero();
                return tablero;
            });
            await tareaTablero;
            moverPieza((int)numOrigenX.Value - 1, (int)numOrigenY.Value - 1);
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            numOrigenX.Maximum = numOrigenY.Maximum = numDimensionN.Value;
            prepararObjetos();
        }

        private async void btnComenzar_Click(object sender, EventArgs e)
        {
            btnComenzar.Enabled = false;
            btnAceptaConfig.Enabled = false;
            btnResolver.Enabled = false;
            numDimensionN.Enabled = false;
            numOrigenX.Enabled = false;
            numOrigenY.Enabled = false;
            foreach (var item in tablero.recorridoSolucion(tablero.tableroSolucion))
            {
                moverPieza(item.Item1, item.Item2);
                panel1.Refresh();
                await Task.Delay(int.Parse((textBox2.Text=="")?"0":textBox2.Text));
            }
            btnComenzar.Enabled = true;
            numDimensionN.Enabled = true;
            numOrigenX.Enabled = true;
            numOrigenY.Enabled = true;
            btnComenzar.Focus();
        }

        private void moverPieza(int x=1, int y=1)
        {
            pictureBox1.Location = new Point(x * tamCelda, y * tamCelda);
        }

        private void btnAceptaConfig_Click(object sender, EventArgs e)
        {
            //tablero = null;
            textBox1.Text = "";
            btnAceptaConfig.Enabled = false;
            btnComenzar.Enabled = false;
            prepararObjetos();
            panel1.Refresh();
            btnResolver.Enabled = true;
            btnResolver.Focus();
        }

        private void numDimensionN_ValueChanged(object sender, EventArgs e)
        {
            numOrigenX.Maximum = numOrigenY.Maximum = numDimensionN.Value;
            if (numOrigenX.Value > numDimensionN.Value)
                numOrigenX.Value = numDimensionN.Value;
            if (numOrigenY.Value > numDimensionN.Value)
                numOrigenY.Value = numDimensionN.Value;
            btnAceptaConfig.Enabled = true;
        }

        private async void btnResolver_Click(object sender, EventArgs e)
        {
            btnResolver.Enabled = false;
            textBox1.Text = "...";
            txtAviso.Visible = true;
            tablero.solucionado = false;
            await Task.Run(() => { tablero.resolverTablero(); });
            if (tablero.solucionado)
            {
                string[] tmp = Array.ConvertAll(tablero.recorridoSolucion(tablero.tableroSolucion), t => $"({1 + t.Item1}, {1 + t.Item2})");
                string recorrido = String.Join(" -> ", tmp);
                textBox1.Text = recorrido;
                btnComenzar.Enabled = true;
            }
            else
            {
                textBox1.Text = "Sin solución...";
            }
            txtAviso.Visible = false;
        }

        private void numOrigenX_ValueChanged(object sender, EventArgs e)
        {
            btnAceptaConfig.Enabled = true;
        }

        private void numOrigenY_ValueChanged(object sender, EventArgs e)
        {
            btnAceptaConfig.Enabled = true;
        }
    }
}
