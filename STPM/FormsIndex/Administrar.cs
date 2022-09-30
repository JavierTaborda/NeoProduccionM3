using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STPM.FormsIndex
{
    public partial class Administrar : Form
    {
        public Administrar()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
           button1.BackColor = Color.FromArgb(61, 174, 43);
           button1.ForeColor = Color.White;
            // End Cambio de color de los botones con click 
            //Abrir con hijo
            //AbrirFormHijo(new FormsIndex.Admin.AdParadas());//Abrir formulario r
        }
        private void button1_Leave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(0, 120, 83);
            button1.ForeColor = Color.White;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(61, 174, 43);
            button2.ForeColor = Color.White;
         
            //AbrirFormHijo(new FormsIndex.Admin.AdOperadores());
        }

        private void button2_Leave(object sender, EventArgs e)
        {

            button2.BackColor = Color.FromArgb(0, 120, 83);
            button2.ForeColor = Color.White;
        }
 

       
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

     

      

       

       
       
    }
}
