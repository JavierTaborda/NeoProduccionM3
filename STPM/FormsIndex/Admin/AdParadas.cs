using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;


namespace STPM.FormsIndex.Admin
{
    public partial class AdParadas : Form
    {

        //Instanciar clase CNTipoParadas
        CNTipoParada objetoCN = new CNTipoParada();
        

        //EndInstanciar clase CNTipoParadas
        int operacion = 0;
        public AdParadas()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void AdParadas_Load(object sender, EventArgs e)
        {
            MostrarTipoPar();
        }
        private void MostrarTipoPar()
        {
           // dtgTipoPar.DataSource = objetoCN.MostrarTipoParada();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (operacion == 1)
            {
                //Crea un objeto de las entidades para asignarles un valor
              
               /* i.TPIdCodPar = textBox1.Text;
                i.TPDes = textBox2.Text;
                i.TPSecMol = textBox3.Text;
              */
            }
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            operacion = 1;
            btnactu.Enabled = false;
            btnborrar.Enabled = false;
            btnRegistrar.Enabled = true;
        }
    }
}
