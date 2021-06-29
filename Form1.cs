using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoTriqui
{
    public partial class Form1 : Form
    {
        string playerX = "";

        string playerO = "";
        bool cambio = true;
        int empate=0;
        int ganadasX = 0;
        int ganadasO = 0;
        public Form1()
        {
            InitializeComponent();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            OnoffBtn(false);
        }

        private void OnoffBtn(bool onoff)
        {
            a1.Enabled = onoff;
            a2.Enabled = onoff;
            a3.Enabled = onoff;
            b1.Enabled = onoff;
            b2.Enabled = onoff;
            b3.Enabled = onoff;
            c1.Enabled = onoff;
            c2.Enabled = onoff;
            c3.Enabled = onoff;


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Ingresar();
        }

        private void Ingresar()
        {
            if(txtPlayer1.Text=="" && txtPlayer2.Text == "")
            {
                MessageBox.Show("El nombre de los participantes no debe ir vacio","nombre no valido",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                if (txtPlayer1.Text=="")
                {
                    MessageBox.Show("El nombre de player 1 no debe ir vacio", "nombre no valido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (txtPlayer2.Text == "")
                {
                    MessageBox.Show("El nombre de player 2 no debe ir vacio", "nombre no valido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (txtPlayer1.Text !="" && txtPlayer2.Text != "")
            {
                if (rbtnPlayer1X.Checked && rbtnPlayer2O.Checked)
                {
                    playerX = txtPlayer1.Text;
                    playerO = txtPlayer2.Text;
                    rbtnPlayer1O.Checked = false;
                    rbtnPlayer2X.Checked = false;
                    EjecutarJuego();

                }
                if (rbtnPlayer1O.Checked && rbtnPlayer2X.Checked)
                {
                    playerX = txtPlayer1.Text;
                    playerO = txtPlayer2.Text;
                    rbtnPlayer1X.Checked = false;
                    rbtnPlayer2O.Checked = false;
                    EjecutarJuego();
                }
                if (rbtnPlayer1X.Checked && rbtnPlayer2X.Checked)
                {
                    MessageBox.Show("Solo un jugador puede elegir la X", "Vuelva a intentar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                if (rbtnPlayer1O.Checked && rbtnPlayer2O.Checked)
                {
                    MessageBox.Show("Solo un jugador puede elegir la O", "Vuelva a intentar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                if (rbtnPlayer1O.Checked==false && rbtnPlayer1X.Checked==false || rbtnPlayer2O.Checked == false && rbtnPlayer2X.Checked == false)
                {
                    MessageBox.Show("Ninguna letra fue escogida", "Vuelva a intentar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void EjecutarJuego()
        {
            lblPlayer1.Text = txtPlayer1.Text;
            lblPlayer2.Text = txtPlayer2.Text;
            groupBox1.Text = "Marcador";
           // btnRefresh.Visible = true;
            btnReiniciar.Visible = true;
            button9.Visible = false;
            txtPlayer1.Visible = false;
            txtPlayer2.Visible = false;
            MessageBox.Show("Empieza : "+playerX, "informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            OnoffBtn(true);

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Buttons_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (cambio)
            {
                b.Text = "X";

            }
            else
            {
                b.Text = "O";
            }
            cambio = !cambio;
            b.Enabled = false;
            Ganador();


        }

        private void Ganador()
        {
            if ((a1.Text==a2.Text)& (a2.Text==a3.Text) &&(!a1.Enabled))
            {
                Validacion(a1);
            }
            else if ((b1.Text == b2.Text) & (b2.Text == b3.Text) && (!b1.Enabled))
            {
                Validacion(b1);
            }
            else if ((c1.Text == c2.Text) & (c2.Text == c3.Text) && (!c1.Enabled))
            {
                Validacion(c1);
            }

            if ((a1.Text == b1.Text) & (b1.Text == c1.Text) && (!a1.Enabled))
            {
                Validacion(a1);
            }
            else if ((a2.Text == b2.Text) & (b2.Text == c2.Text) && (!a2.Enabled))
            {
                Validacion(a2);
            }
            else if ((a3.Text == b3.Text) & (b3.Text == c3.Text) && (!a3.Enabled))
            {
                Validacion(a3);
            }


             if ((a1.Text == b2.Text) & (b2.Text == c3.Text) && (!a1.Enabled))
            {
                Validacion(a1);
            }
             else if ((a3.Text == b2.Text) & (b2.Text == c1.Text) && (!a3.Enabled))
            {
                Validacion(a3);
            }

            empate++;
            if(empate==9)
            {
                MessageBox.Show("Empate", "Vuelva a intentar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                OnoffBtn(true);
                empate = 0;
            }

        }
        public void Validacion(Button b)
        {
            empate = -1;
            if (b.Text == "X")
            {
                MessageBox.Show("Gana " + playerX,"Felicidades", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ganadasX++;
            }
            else if (b.Text == "O")
            {
                MessageBox.Show("Gana " + playerO, "Felicidades", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ganadasO++;
            }

            if(rbtnPlayer1X.Checked && rbtnPlayer2O.Checked)
            {
                lblPoints1.Text = ganadasX.ToString();
                lblPoints2.Text = ganadasO.ToString();
            }
            if (rbtnPlayer1O.Checked && rbtnPlayer2X.Checked)
            {
                lblPoints2.Text = ganadasX.ToString();
                lblPoints1.Text = ganadasO.ToString();
            }
            Limpiar();
            OnoffBtn(true);

        }
        private void Limpiar()
        {
            a1.Text = "";
            a2.Text = "";
            a3.Text = "";
            b1.Text = "";
            b2.Text = "";
            b3.Text = "";
            c1.Text = "";
            c2.Text = "";
            c3.Text = "";

        }

      //  private void btnRefresh_Click(object sender, EventArgs e)
       // {
        //    Limpiar();
          //  OnoffBtn(true);
            //empate = 0;
        //}

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            Limpiar();
            OnoffBtn(false);
           // btnRefresh.Visible = false;
            btnReiniciar.Visible = false;
            button9.Visible = true;
            txtPlayer1.Visible = true;
            txtPlayer2.Visible = true;
            playerX = "";
            playerO = "";
            ganadasX = 0;
            ganadasO = 0;
            cambio = true;
            lblPoints1.Text = 0.ToString();
            lblPoints2.Text = 0.ToString();
            lblPlayer1.Text = "";
            lblPlayer2.Text = "";
            rbtnPlayer1X.Enabled = true;
            rbtnPlayer2O.Enabled = true;
            rbtnPlayer1O.Enabled = true;
            rbtnPlayer2X.Enabled = true;
            rbtnPlayer1X.Checked = false;
            rbtnPlayer2O.Checked = false;
            rbtnPlayer1O.Checked = false;
            rbtnPlayer2X.Checked = false;
        }
    }
}
