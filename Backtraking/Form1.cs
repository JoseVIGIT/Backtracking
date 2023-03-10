using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackTracking
{
    public partial class Form1 : Form
    {
        // Movimientos posibles de la pieza en coordenadas (x,y) - valor inicial para coordenada 1..
        readonly (int X, int Y)[] movPieza = { (2, 1), (1, 2), (-1, 2), (-2, 1), (-2, -1), (-1, -2), (1, -2), (2, -1) };
        const int panelTamInicial = 285;
        int tamCelda;
        Tablero tablero;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Parent = panelTablero;
            numOrigenX.Maximum = numOrigenY.Maximum = numDimensionN.Value;
            prepararObjetos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void panelTablero_Paint(object sender, PaintEventArgs e)
        {
            Brush color = Brushes.Black;
            Brush colorCelda = Brushes.Black;
            for (int y = 0; y < tablero.N; y++)
            {
                color = (color == Brushes.Black) ? Brushes.White : Brushes.Black;
                colorCelda = color;
                for (int x = 0; x < tablero.N; x++)
                {
                    colorCelda = (colorCelda == Brushes.Black) ? Brushes.White : Brushes.Black;
                    e.Graphics.FillRectangle(colorCelda, x * tamCelda, y * tamCelda, tamCelda, tamCelda);
                }
            }
        }

        private void prepararObjetos()
        {
            panelTablero.Width = panelTablero.Height = panelTamInicial;
            tablero = new Tablero((int)numDimensionN.Value, movPieza, (int)numOrigenX.Value, (int)numOrigenX.Value);
            tamCelda = panelTablero.Width / tablero.N;
            pictureBox1.Width = tamCelda;
            pictureBox1.Height = tamCelda;
            moverPieza((int)numOrigenX.Value - 1, (int)numOrigenY.Value - 1);
        }

        private void moverPieza(int x=1, int y=1)
        {
            pictureBox1.Location = new Point(x * tamCelda, y * tamCelda);
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

        private void numOrigenX_ValueChanged(object sender, EventArgs e)
        {
            btnAceptaConfig.Enabled = true;
        }

        private void numOrigenY_ValueChanged(object sender, EventArgs e)
        {
            btnAceptaConfig.Enabled = true;
        }

        private void btnAceptaConfig_Click(object sender, EventArgs e)
        {
            textRecorrido.Text = "";
            btnAceptaConfig.Enabled = false;
            btnComenzar.Enabled = false;
            prepararObjetos();
            panelTablero.Refresh();
            btnResolver.Enabled = true;
            btnResolver.Focus();
        }

        private async void btnResolver_Click(object sender, EventArgs e)
        {
            btnResolver.Enabled = false;
            textRecorrido.Text = "...";
            txtAviso.Visible = true;
            tablero.solucionado = false;
            await Task.Run(() => { tablero.resolverTablero(); });
            if (tablero.solucionado)
            {
                string[] tmp = Array.ConvertAll(tablero.recorridoSolucion(tablero.tableroSolucion), t => $"({1 + t.Item1}, {1 + t.Item2})");
                string recorrido = String.Join(" -> ", tmp);
                textRecorrido.Text = recorrido;
                btnComenzar.Enabled = true;
            }
            else
            {
                textRecorrido.Text = "Sin solución...";
            }
            txtAviso.Visible = false;
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
                panelTablero.Refresh();
                await Task.Delay(int.Parse((textBox2.Text == "") ? "0" : textBox2.Text));
            }
            btnComenzar.Enabled = true;
            numDimensionN.Enabled = true;
            numOrigenX.Enabled = true;
            numOrigenY.Enabled = true;
            btnComenzar.Focus();
        }

    }
}
