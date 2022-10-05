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
    public partial class Parada : Form
    {

        //Arrastrar y mover ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //End Arrastrar y mover ventana

        //Instanciar clase CNParadasBatch
        CNParadasBatch objetoCN = new CNParadasBatch();
        CNTipoParada objetoTP = new CNTipoParada();
        //EndInstanciar clase CNParadasBatch
        bool insertar = false;//insertar parada por endimiento o calidad

        string Centro; //centro a buscar los equipos
        public Parada(string sid)
        {
            InitializeComponent();
            lblid.Text = sid;
            insertar = false;
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Parada_MouseDown(object sender, MouseEventArgs e)
        {
              ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Parada_Load(object sender, EventArgs e)
        {
            MostrarParadasForm();
          
            
        }

        //Método o función para mostrar los datos de la base de datos.
        private void MostrarParadasForm() 
        {
            dtgParadas.DataSource = objetoCN.MostrarParadas(int.Parse(lblid.Text));
            this.dtgParadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        //Metodo para mostrar paradas por rendimiento y calidad
        private void RendCaliForm()
        {

            dtgrencali.DataSource = objetoCN.MostrarParadasRenCal(int.Parse(lblid.Text));
            this.dtgrencali.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void ListarCentro()
        {
            cboxCentro.DataSource = objetoTP.MostrarCentro();
            cboxCentro.ValueMember = "IdCentroEq";
            cboxCentro.DisplayMember = "CEDescrip";
            ListarParte();
        }

            private void ListarParte()
        {
            cboxparte.DataSource = objetoTP.ListarPartes();
            cboxparte.ValueMember = "IdParteE";
            cboxparte.DisplayMember = "PENombre";
            
            string par = cboxparte.SelectedValue.ToString();
            Centro = cboxCentro.SelectedValue.ToString();
            ListarEqui(par,Centro);
        }
        private void ListarEqui(string ca, string centro)
        {
           
            cboxEquipo.DataSource = objetoTP.ListarEquipos(ca, centro);
            cboxEquipo.ValueMember = "ECodEqu";
            cboxEquipo.DisplayMember = "Detalle";
            try
            {
               label3.Text =cboxEquipo.SelectedValue.ToString();
            }
            catch
            {
                label3.Text = "S/C";
            }

        }

        private void ListarCau()
        {

            cboxcausa.DataSource = objetoTP.ListarCausas();
            cboxcausa.ValueMember = "IdCausa";
            cboxcausa.DisplayMember = "CNombre";
            string cod=cboxcausa.SelectedValue.ToString();

            ListarCod(cod);
        }
        private void ListarCau2()
        {
            cboxcausa.DataSource = null;
            cboxcausa.Items.Clear();

            cboxcausa.Items.Add("Calidad");
            cboxcausa.Items.Add("Rendimiento");
            ListarCod("RC");

        }

        private void ListarCod(string ca)
        {
           
            
            cboxcod.DataSource = objetoTP.ListarCodigos(ca);
             cboxcod.ValueMember = "TPCodPar";
            cboxcod.DisplayMember= "Mostrar";
            try
            {
                lbldes.Text = cboxcod.SelectedValue.ToString();
            }
            catch
            {
                lbldes.Text = "S/C";
            }



        }
        public void Finish()
        {
            cboxCentro.Enabled = false;
            cboxparte.Enabled = false;
            cboxEquipo.Enabled = false;
            cboxcausa.Enabled = false;
            cboxcod.Enabled = false;
            txtdetalle.Enabled = false;
            button2.Text = "Editar";
            button2.BackColor = Color.DodgerBlue;
            button1.Enabled = false;
            lblEdi.Text = "";
            panel1.BackColor = Color.FromArgb(18, 71, 52);
            btnpar1.Enabled = true;

            btnpar2.Enabled = true;

            btnpar3.Enabled = true;
        }
        public void FinishRenCal()
        {
            button2.Text = "Editar";
            button2.BackColor = Color.DodgerBlue;
            panel1.BackColor = Color.FromArgb(18, 71, 52);
            cboxparte.Enabled = false;
            cboxEquipo.Enabled = false;
            cboxcausa.Enabled = false;
            cboxcod.Enabled = false;
            txtdetalle.Text = "";
            lblEdi.Text = "";
            txtdetalle.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dtgParadas.Visible == true)
            {
                //llenar paradas de tiempo perdido
                btnpar1.Enabled = false;

                btnpar2.Enabled = false;

                btnpar3.Enabled = false;
                if (dtgParadas.SelectedRows.Count > 0 & button2.Text == "Editar")
                {
                    if (dtgParadas.CurrentRow.Cells["Código"].Value.ToString() != "018078")
                    {
                        cboxCentro.Enabled = true;
                        cboxparte.Enabled = true;
                        cboxEquipo.Enabled = true;
                        cboxcausa.Enabled = true;
                        cboxcod.Enabled = true;
                        txtdetalle.Enabled = true;
                        button1.Enabled = true;
                        lblEdi.Text = "Editar Parada de:" + dtgParadas.CurrentRow.Cells["Hora Inicial"].Value.ToString() + " - " + dtgParadas.CurrentRow.Cells["Hora Final"].Value.ToString();
                        button2.Text = "Cancelar Edición";
                        button2.BackColor = Color.IndianRed;
                        panel1.BackColor = Color.FromArgb(61, 174, 43);
                        ListarCentro();
                        ListarCau();


                    }
                    else
                    {

                        MessageBox.Show("Esta parada no se puede modificar");
                        Finish();

                    }

                }
                else
                {

                    if (button2.Text == "Cancelar Edición")
                    {

                        Finish();
                    }
                    else MessageBox.Show("debe seleccionar una fila");
                }
            }
            else
            {
                //Rendimiento y calidad
                if (dtgrencali.SelectedRows.Count > 0 & button2.Text == "Editar")
                {
                    cboxparte.Enabled = true;
                    cboxEquipo.Enabled = true;
                    cboxcausa.Enabled = true;
                    cboxcod.Enabled = true;
                    txtdetalle.Enabled = true;
                    button3.Enabled = true;
                    ListarParte();
                    ListarCau2();
                    button2.BackColor = Color.IndianRed;
                    panel1.BackColor = Color.FromArgb(61, 174, 43);
                    lblEdi.Text = "Editar Falla ID:" +dtgrencali.CurrentRow.Cells["Falla ID"].Value.ToString();
                    button2.Text = "Cancelar Edición";
                    

                }
                else
                {
                    if (button2.Text == "Cancelar Edición")
                    {
                        FinishRenCal();
                       
                    }
                    else MessageBox.Show("Agregue una falla por rendimiento o calidad primero.");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                objetoTP._idpar = int.Parse(dtgParadas.CurrentRow.Cells["IdParBatch"].Value.ToString());
                objetoTP._equipo = cboxEquipo.SelectedValue.ToString();
                objetoTP._causa = cboxcausa.SelectedValue.ToString();
                objetoTP._codigo = cboxcod.SelectedValue.ToString();
                objetoTP._observ = txtdetalle.Text;
                try
                {
                    objetoTP.EditarTipoParada();
                    MessageBox.Show("Cambios actualizados");
                    Finish();
                    MostrarParadasForm();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR:" + ex);
                }
            
            

        }

        private void cboxcausa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ListarCod(cboxcausa.SelectedValue.ToString());
            }
            catch
            {
            }
            }


        private void cboxEquipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboxcod_TextChanged(object sender, EventArgs e)
        {
            lbldes.Text = cboxcod.SelectedValue.ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cboxEquipo_TextChanged(object sender, EventArgs e)
        {
            label3.Text = cboxEquipo.SelectedValue.ToString();
        }

        private void cboxparte_TextChanged(object sender, EventArgs e)
        {
            if (cboxCentro.SelectedValue.ToString() != null)
            {
                try
                {
                    ListarEqui(cboxparte.SelectedValue.ToString(), cboxCentro.SelectedValue.ToString());
                }
                catch
                {
                }
            }
        }

        private void dtgParadas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnpar1_Click(object sender, EventArgs e)
        {
            ParadaRapida(btnpar1.Text);
        }
        private void btnpar2_Click(object sender, EventArgs e)
        {
            ParadaRapida(btnpar2.Text);
        }

        private void btnpar3_Click(object sender, EventArgs e)
        {
            ParadaRapida(btnpar3.Text);
        }

        public void ParadaRapida(string parada)
        {
            txtdetalle.Enabled = true;
            string  equipo="", cod="";
           if (dtgParadas.CurrentRow.Cells["Código"].Value.ToString() != "018078")
            {
                if (dtgParadas.SelectedRows.Count > 0 & button2.Text == "Editar")
            {
                
                lblEdi.Text = "Editar Parada de:" + dtgParadas.CurrentRow.Cells["Hora Inicial"].Value.ToString() + " - " + dtgParadas.CurrentRow.Cells["Hora Final"].Value.ToString();
                button2.Text = "Cancelar Edición";
                button2.BackColor = Color.IndianRed;
                //panel1.BackColor = Color.FromArgb(61, 174, 43);
             



                ////////////////////////////
                if (parada == "Cambio de Crepe")
                {
                   
                    equipo = CNParadasBatch.Equip2;
                    cod = "018057 ";
                    
                }
                else
                {
                    if (parada == "Limpieza Máq.")
                    {
                        equipo = CNOEE.Ofic;
                        cod = "018028 ";
                    }
                    else
                    {
                            //Acumulación de pasta
                        equipo = CNOEE.Ofic;
                        cod = "018013 ";
                    }
                }
                ///////////////////////

            }
            else
            {
                if (button2.Text == "Cancelar Edición")
                {

                    Finish();
                }
                else MessageBox.Show("debe seleccionar una fila");
            }
            
                objetoTP._idpar = int.Parse(dtgParadas.CurrentRow.Cells["IdParBatch"].Value.ToString());
                objetoTP._equipo = equipo;
                objetoTP._codigo = cod;
                objetoTP._observ = txtdetalle.Text;
                try
                {
                    objetoTP.EditarTipoParada();
                    MessageBox.Show("Cambios actualizados");
                    Finish();
                    MostrarParadasForm();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR:" + ex);
                }
            }
            else
            {
                MessageBox.Show("Esta parada no se puede modificar");
            }

        }

        private void btntp_Click(object sender, EventArgs e)
        {
            btncalren.BackColor = Color.FromArgb(18, 71, 52);
            btntp.BackColor = Color.FromArgb(61, 174, 43);
            btnpar1.Visible = true;
            btnpar2.Visible = true;
            btnpar3.Visible = true;
            dtgParadas.Visible = true;
            dtgrencali.Visible = false;
            btnagregar.Visible = false;
            button3.Visible =false;
            button1.Visible = true;
        }

        private void btncalren_Click(object sender, EventArgs e)
        {
            btntp.BackColor = Color.FromArgb(18, 71, 52);
            btncalren.BackColor = Color.FromArgb(61, 174, 43);
            btnpar1.Visible = false;
            btnpar2.Visible = false;
            btnpar3.Visible = false;
            dtgParadas.Visible = false;
            dtgrencali.Visible = true;
            RendCaliForm();
            btnagregar.Visible = true;
            button1.Visible = false;
            button3.Visible = true;

        }


        private void btnagregar_Click_1(object sender, EventArgs e)
        {
            cboxparte.Enabled = true;
            cboxEquipo.Enabled = true;
            cboxcausa.Enabled = true;
            cboxcod.Enabled = true;
            txtdetalle.Enabled = true;
            ListarParte();
            ListarCau2();
            button2.BackColor = Color.IndianRed;
            panel1.BackColor = Color.FromArgb(61, 174, 43);
            button2.Text = "Cancelar Edición";
           
            insertar = true;

        }

        //registrar o insertar parada 
        private void button3_Click(object sender, EventArgs e)
        {
            int idbatch = int.Parse(lblid.Text), idpar;
             string eqp, cod, causa, obs;
            if (insertar==true)
            {

                try
                {
                    if (cboxcausa.Text != "")
                    {
                        eqp = cboxEquipo.SelectedValue.ToString();
                        causa = cboxcausa.Text;
                        cod = cboxcod.SelectedValue.ToString();
                        obs = txtdetalle.Text;
                        button3.Enabled = false;
                        objetoCN.InsertarParadaRenCal(idbatch, eqp, cod, causa, obs);
                        RendCaliForm();
                        insertar = false;
                        FinishRenCal();
                        MessageBox.Show("Registro exitoso.");
                    }
                    else
                    {
                        MessageBox.Show("Ingrese causa por rendimiento o calidad");
                    }
                }
                catch
                {
                    MessageBox.Show("Error al agregar falla, intente de nuevo.");
                }
            }
            else
            {
                
                
                try
                {
                    if(cboxcausa.Text != "")
                    {
                        idpar = int.Parse(dtgrencali.CurrentRow.Cells["Falla ID"].Value.ToString());
                        eqp = cboxEquipo.SelectedValue.ToString();
                        causa = cboxcausa.Text;
                        cod = cboxcod.SelectedValue.ToString();
                        obs = txtdetalle.Text;
                        objetoCN.EditarParadaRenCal(idpar, eqp, cod, causa, obs);
                        FinishRenCal();
                        RendCaliForm();
                        MessageBox.Show("Cambio exitoso.");
                    }
                    else
                    {
                        MessageBox.Show("Ingrese causa por rendimiento o calidad");
                    }
                 
                }
                catch
                {
                    MessageBox.Show("Error al editar falla, intente de nuevo.");
                }
            }
        
        
        }
    }
    
    }

