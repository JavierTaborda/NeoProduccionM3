using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using CapaNegocio;

namespace STPM
{
    public partial class Login : Form
    {
        //Libreria y codigo para borde de las ventanas 
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
                int nLeftRect,
                int nTopRect,
                int nRightRect,
                int nBottomRect,
                int nWidthEllipse,
                int nHeightEllipse
            );

        //End Libreria y codigos para borde de las ventanas 
        //Arrastrar y mover ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
   
        //End Arrastrar y mover ventana

        public Login()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 30, 30));//Esquinas redondeadas
            this.AcceptButton = this.button1;
          
        }

        // Funcion para validar ficha.

        private void button1_Click(object sender, EventArgs e)
        {  
          
            //LA Clase para el login es CNBatchPro
            string ficha=txtficha.Text.ToString().Trim(); 
            CNBatchPro l = new CNBatchPro();
            
            if (txtficha.Text.Length >= 5) { 
            string ini=l.LoginFicha(ficha);
             if (ini!= "Verifique la ficha")
            {
                Form Index = new IndexForm();
                Index.Show();
                Hide();
            }
             else
            {
                MessageBox.Show(ini);
            }
            }
            else
            {
                MessageBox.Show("Vuelva a intentarlo");
            }

        }
       //End Funcion validar ficha

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        public void VaciarTexto()
        {
            txtficha.ForeColor = Color.White;

            if (txtficha.Text == "Ingrese ficha...")
            {
                txtficha.Text = "";
            }
        }
        private void txtficha_Click(object sender, EventArgs e)
        {
            VaciarTexto();
           

        }
        private void txtficha_KeyPress(object sender, KeyPressEventArgs e)
        {
            VaciarTexto();
           
        }
        private void txtficha_KeyDown(object sender, KeyEventArgs e)
        {
            VaciarTexto();
        }

        private void pnlcon_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtficha_MouseLeave(object sender, EventArgs e)
        {

            txtficha.ForeColor=Color.DarkGray;
            
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtficha_Enter(object sender, EventArgs e)
        {
            if (txtficha.Text=="Ingrese ficha...")
            {
                txtficha.Text = "";
                txtficha.UseSystemPasswordChar = true;
            }
        }

        private void txtficha_Leave(object sender, EventArgs e)
        {
            if (txtficha.Text == "")
            {
                txtficha.Text = "Ingrese ficha...";
                txtficha.UseSystemPasswordChar = false;
            }
        }
    }
}
