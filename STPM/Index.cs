using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CapaNegocio;

namespace STPM
{
    public partial class IndexForm : Form
    {
        //DECLARACIONES:
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
        [DllImport("user32.DLL", EntryPoint="SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void pnlbarra_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //End Arrastrar y mover ventana
                
        public IndexForm()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 12, 12));//Esquinas redondeadas

            //LLenar datos del Operador
            LlenarDatos();
         //EndLLEnar datos.
   
           // Configuraciones del formulario estado principal
            pnlNav.Height = btnEstado.Height;
            pnlNav.Top = btnEstado.Top;
            pnlNav.Left = btnEstado.Left;
            btnEstado.BackColor = Color.FromArgb(18, 71, 52);
            AbrirFormHijo(new FormsIndex.Estado());
            // End Configuraciones del formulario estado principal
            
        }
        
        public void LlenarDatos()
        {

            label1.Text = CNBatchPro.nombre + " " + CNBatchPro.apellido;
            label2.Text = CNBatchPro.cargo;
            label3.Text = CNBatchPro.depa;
            
        }
        private void IndexForm_Load(object sender, EventArgs e)
        {

        }
        //boton salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //End boton salir


        //BOTON ESTADO 
        private void btnEstado_Click(object sender, EventArgs e)
        {
            // Cambio de color de los botones con click 
            pnlNav.Height = btnEstado.Height;
            pnlNav.Top = btnEstado.Top;
            pnlNav.Left = btnEstado.Left;
            btnEstado.BackColor = Color.FromArgb(18, 71, 52);
            // End Cambio de color de los botones con click 

            //AbrirFormHijo(new FormsIndex.Estado());//Abrir formulario de estado
        }
        //END BOTON ESTADO

        //BOTON ESTADISTICA
        private void btnestadisti_Click(object sender, EventArgs e)
        {
            // Cambio de color de los botones con click
            //btnEstado.BackColor = Color.FromArgb(0, 120, 83);
           // pnlNav.Height = btnestadisti.Height;
            //pnlNav.Top = btnestadisti.Top;
            //pnlNav.Left = btnestadisti.Left;
           // btnestadisti.BackColor = Color.FromArgb(18, 71, 52);
            // EndCambio de color de los botones con click 
            //AbrirFormHijo(new FormsIndex.Estadisticas());//Abrir formulario de estadistica
            Form Estadisticas = new FormsIndex.Estadisticas();
            Estadisticas.Show();
        }
        //END BOTON ESTADISTICA
        //BOTON TURNOS
        private void btnturnos_Click(object sender, EventArgs e)
        {
            // Cambio de color de los botones con click
            //btnEstado.BackColor = Color.FromArgb(0, 120, 83);
            // pnlNav.Height = btnestadisti.Height;
            //pnlNav.Top = btnestadisti.Top;
            //pnlNav.Left = btnestadisti.Left;
            // btnestadisti.BackColor = Color.FromArgb(18, 71, 52);
            // EndCambio de color de los botones con click 
            //AbrirFormHijo(new FormsIndex.Estadisticas());//Abrir formulario de estadistica
            Form Turnos = new FormsIndex.Turnos();
            Turnos.Show();
        }
        //END BOTON TURNOS


        //BOTON ADMINISTRAR
        private void btnadmin_Click(object sender, EventArgs e)
        {
            // Cambio de color de los botones con click
            //btnEstado.BackColor = Color.FromArgb(0, 120, 83);
            //pnlNav.Height = btnadmin.Height;
            //pnlNav.Top = btnadmin.Top;
            //pnlNav.Left = btnadmin.Left;
            //btnadmin.BackColor = Color.FromArgb(18, 71, 52);
            // End Cambio de color de los botones con click 
           //Abrir con hijo
            //AbrirFormHijo(new FormsIndex.Administrar());//Abrir formulario de administrar
            //Abrir nueva ventana
            Form Administrar = new FormsIndex.Administrar();
            Administrar.Show();

        }
        //END BOTON ADMINISTRAR
        

        //Evento Leave Para los Botones
        private void btnEstado_Leave(object sender, EventArgs e)
        {
            btnEstado.BackColor = Color.FromArgb(0, 120, 83);
        }

        private void btnestadisti_Leave(object sender, EventArgs e)
        {
            btnestadisti.BackColor = Color.FromArgb(0, 120, 83);
        }
        private void btnturnos_Leave(object sender, EventArgs e)
        {
            btnturnos.BackColor = Color.FromArgb(0, 120, 83);
        }
        private void btnadmin_Leave(object sender, EventArgs e)
        {
            btnadmin.BackColor = Color.FromArgb(0, 120, 83);
        }
        //End Evento Leave para los botones

        //botones para manejar la ventana
        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnmax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 5, 5));//Esquinas redondeadas

            btnmax.Visible = false;
            btnresta.Visible = true;
        }

        private void btnresta_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 15, 15));//Esquinas redondeadas
            btnresta.Visible = false;
            btnmax.Visible = true;
        }

        private void btnmin_Click(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Minimized;
          
        }
            //Cambio de color cuando pasa el mouse
             private void btnmin_MouseHover(object sender, EventArgs e)
             {
                 btnmin.BackColor = Color.FromArgb(18, 71, 52);
             }

            private void btnmin_MouseLeave(object sender, EventArgs e)
            {
                 btnmin.BackColor = Color.FromArgb(0, 120, 83);
            }

            private void btnmax_MouseHover(object sender, EventArgs e)
            {
                btnmax.BackColor = Color.FromArgb(18, 71, 52);
            }
            private void btnmax_MouseLeave(object sender, EventArgs e)
            {
                btnmax.BackColor = Color.FromArgb(0, 120, 83);
            }
            
            private void btnresta_MouseHover(object sender, EventArgs e)
            {
                btnresta.BackColor = Color.FromArgb(18, 71, 52);
            }
            private void btnresta_MouseLeave(object sender, EventArgs e)
            {
                btnresta.BackColor = Color.FromArgb(0, 120, 83);
            }
         
            private void btncerrar_MouseHover_1(object sender, EventArgs e)
            {
                btncerrar.BackColor = Color.FromArgb(255, 128, 128);
            }

            private void btncerrar_MouseLeave(object sender, EventArgs e)
            {
                btncerrar.BackColor = Color.FromArgb(0, 120, 83);
            }

            
             //End cambio de colores
        //End botones para manejar la ventana


        // FORMULARIOS HIJOS ESTADO, ESTADISTICAS Y ADMINISTRAR
            private void AbrirFormHijo(Form childform)
            {
                if (this.pnlcontenedor.Controls.Count > 0) 
                {
                    this.pnlcontenedor.Controls.RemoveAt(0);
                }
                Form fhijo = childform as Form;
                fhijo.TopLevel = false;// Indicamos que un form scundario
                fhijo.Dock = DockStyle.Fill;//indicamos que se acople al panel contenedor
                this.pnlcontenedor.Controls.Add(fhijo);//se agrga al panel contenedor
                this.pnlcontenedor.Tag = fhijo;// Indicamos instancia que contendra los datos del form
                fhijo.Show();//mostramos
            }

            private void pnlcontenedor_Paint(object sender, PaintEventArgs e)
            {

            }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        // END FORMULARIOS HIJOS ESTADO, ESTADISTICAS Y ADMINISTRAR

    }
}
