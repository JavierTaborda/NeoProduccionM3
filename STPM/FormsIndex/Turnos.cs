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

namespace STPM.FormsIndex
{
    public partial class Turnos : Form
    {

        //Arrastrar y mover ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        //Instanciar clase CNParadasBatch
        CNParadasBatch objetoCN = new CNParadasBatch();
        //EndInstanciar clase CNParadasBatch
        public Turnos()
        {
            InitializeComponent();
            //Cambiar formto de fecha a los date picker
            dateP1.Format = DateTimePickerFormat.Custom;
            dateP1.CustomFormat = "yyyy-MM-dd";
            dateP2.Format = DateTimePickerFormat.Custom;
            dateP2.CustomFormat = "yyyy-MM-dd";
            MostrarTurnoForm();
            comboBox1.Items.Add("Todos");
            comboBox1.Items.Add("1er Turno");
            comboBox1.Items.Add("2do Turno");
        }
        //Cargar turnos 
        private void MostrarTurnoForm()
        {
            string f1="";
                //BUSCAR TURNO CON FECHA DEL SIA SIGUIENTE
                if (int.Parse(DateTime.Now.ToString("HHMMss"))>180000)
                {
                    f1 = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                }
                else
                {
                     f1 = DateTime.Now.ToString("yyyy-MM-dd");
                }
            string f2 = "";
           
            dtgTurnos.DataSource = objetoCN.MostrarTurnos(f1, f2,"Todos");
            this.dtgTurnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            if (dtgTurnos.RowCount == 0)
            {
                MessageBox.Show("No hay Turnos Registrados el día de hoy");
            }

        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Turnos_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string f1= dateP1.Text;
            string f2 = dateP2.Text;
           if (comboBox1.Text!="")
            {
                try
                {

                    dtgTurnos.DataSource = objetoCN.MostrarTurnos(f1, f2, comboBox1.Text);
                    this.dtgTurnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    if (dtgTurnos.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("No hay Turnos Registrados");
                    }
                }
                catch
                {
                    MessageBox.Show("Ha ocurrido un error de conexión");
                }
            }
           else
            {
                MessageBox.Show("Seleccione un turno");
            }
            
        }

        private void lblcod_Click(object sender, EventArgs e)
        {

        }

        private void dateP1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnrango_Click(object sender, EventArgs e)
        {
            if (dateP2.Visible == false)
            {
                dateP2.Visible = true;
                lbldia.Text = "Desde:";
                label2.Visible = true;
                btnrango.Text = "Por Día";
            }
            else
            {
                dateP2.Visible = false;
                lbldia.Text = "Día:";
                label2.Visible = false;
                btnrango.Text = "Por Rango";
            }
        }

        private void btnsele_Click(object sender, EventArgs e)
        {
            if(dtgTurnos.Visible==true)
             {
                if (dtgTurnos.SelectedRows.Count > 0)
                {

                    int ID = int.Parse(dtgTurnos.CurrentRow.Cells["Batch"].Value.ToString());
                    dtgTurnos.Visible = false;
                    dtgParadas.Visible = true;
                    dtgParadas.DataSource = objetoCN.TurnoParadas(ID);
                    this.dtgParadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    btnsele.Text = "Ver Turnos";
                    label1.Text = "Paradas del Batch: " + ID;
                    dateP1.Enabled = false;
                    dateP2.Enabled = false;
                    btnrango.Enabled = false;
                    comboBox1.Enabled = false;
                    if (dtgParadas.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("No hay Paradas Registradas");
                    }
                }
                else
                {

                    MessageBox.Show("Debe seleccionar una fila");
                }
            }
            else
            {
                dateP1.Enabled = true;
                dateP2.Enabled = true;
                btnrango.Enabled = true;
                comboBox1.Enabled = true;
                dtgTurnos.Visible = true;
                dtgParadas.Visible = false;
                btnsele.Text = "Ver Paradas";
                label1.Text = "Turnos";
            }

                
        }
    }
}
