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
using CircularProgressBar;
using System.Data.SqlClient;
using System.Collections;
using System.Drawing.Printing;
using System.Data.OleDb;
using System.Net;
using System.Net.Mail;



namespace STPM.FormsIndex
{ 
    public partial class OEE : Form
    {
        
        //Arrastrar y mover ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //End Arrastrar y mover ventana
        private OleDbConnection ConCodPro = new OleDbConnection("Provider=IBMDA400.DataSource.1;Data Source=APPN.VENEZUEL;Password=USRPC;User ID=USRPC");
        // Conexion para los centros y ordenes de producción
        public OleDbConnection CodAbrirConex()
        {
            if (ConCodPro.State == ConnectionState.Closed)
                ConCodPro.Open();
            return ConCodPro;
        }

        public OleDbConnection CodCerrarConex()
        {
            if (ConCodPro.State == ConnectionState.Open)
                ConCodPro.Close();
            return ConCodPro;
        }

        private SqlConnection Conex = new SqlConnection("Data Source=10.1.10.103\\desarrollo; Initial Catalog = DbSiTiePer;User ID=UsrSiTiePer;Password=UsrIng2021*");

        public SqlConnection AbrirConex()
        {
            if (Conex.State == ConnectionState.Closed)
                Conex.Open();
            return Conex;
        }

        public SqlConnection CerrarConex()
        {
            if (Conex.State == ConnectionState.Open)
                Conex.Close();
            return Conex;
        }
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;
        private SqlConnection Con = new SqlConnection("Data Source=10.1.10.103\\desarrollo; Initial Catalog = DbSiTiePer;User ID=UsrSiTiePer;Password=UsrIng2021*");

        OleDbCommand comando2 = new OleDbCommand();

        OleDbDataReader leer2;


        string tt, tp;//obtener la consulta para convertirr a double
        double TT { get; set; }
        double TP { get; set; }
        string[] codigos; //dIVIDE LOS CODIGOS DE LOS PRODUCTOS       
        double[] kxm;//rendimiento teorico 
        double[] r;//producción de ith
        double[] dv; //Rechazos de producción
        double[] porc;//porcentaje de la produccion
        double[] rreal;//rendimiento real del turno
        double[] Rend;//rendimientos individuales
        string orden, producto, centrop, producidos, rechazos;
        double[] Rendimiento;
        double Calidad;
        double Disponibilidad;
        double CalOEE;


        public OEE()
        {
            InitializeComponent();
            dateP1.Format = DateTimePickerFormat.Custom;
            dateP1.CustomFormat = "yyyy-MM-dd";
            comboBox1.Items.Add("1er Turno");
            comboBox1.Items.Add("2do Turno");
            comboBox1.Items.Add("Todos");
            circularProgressBar1.Value = 0;
            circularProgressBar2.Value = 0;
            circularProgressBar3.Value = 0;
            circularProgressBar4.Value = 0;
            lbldis.Text = "-----";
            lblren.Text = "-----";
            lblcali.Text = "-----";

        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        public void Cargar()
        {

            if (comboBox1.Text != "")
            {
                //try
                //{
                
                listBox1.DataSource = null;
                listBox1.Items.Clear();
                circularProgressBar1.Value = 0;
                circularProgressBar1.Minimum = 0;

                    datosBatch();//Actualizar datos del batch
                    TiempoTurno();
                    DatosOEE();//
                    CalculoOEE();           
                    timer1.Start();   
                    Graficas();
                    Datos();
                    lbldis.Text = Math.Round((Disponibilidad * 100)).ToString() + "%";
                    lblren.Text = Math.Round(((Rendimiento.Sum()) * 100)).ToString() + "%";
                    lblcali.Text = Math.Round((Calidad * 100)).ToString() + "%";
                /*}
                catch (Exception e)
                {
                    MessageBox.Show("Ocurrió el error: " + e, "Notificación");
                }*/
            }
            else
            {
                MessageBox.Show("Seleccione un turno");
            }

        }
        public void Datos()
        {
            lblr.Text =r.Sum().ToString() + " KG";
            lbldv.Text = dv.Sum().ToString() + " KG";
            lblTT.Text = Math.Round(TT).ToString() + " min";
            lblTP.Text = Math.Round(TP).ToString() + " min";

            for (int i = 0; i < codigos.Length - 1; i++)
            {
                listBox1.Items.Add((i + 01) + "- Producto: " + codigos[i] + ".  KG Producidos: " + r[i] + ".  KG Rechazados: " + dv[i]);
            }


        }
        public void Graficas()
        {
            if (Convert.ToInt32(Math.Round((Rendimiento.Sum() * 100))) > 100)
            {
                circularProgressBar3.Maximum = Convert.ToInt32(Math.Round((Rendimiento.Sum() * 100)));
            }

            circularProgressBar2.Value = Convert.ToInt32(Math.Round((Disponibilidad * 100)));
            circularProgressBar3.Value = Convert.ToInt32(Math.Round((Rendimiento.Sum()) * 100));
            circularProgressBar4.Value = Convert.ToInt32(Math.Round((Calidad * 100)));

            if (circularProgressBar2.Value <= 30)
            {
                circularProgressBar2.ProgressColor = Color.FromArgb(254, 30, 30);
            }
            else
            {
                if (circularProgressBar2.Value > 30 & circularProgressBar2.Value <= 50)
                {
                    circularProgressBar2.ProgressColor = Color.FromArgb(255, 152, 1);
                }
                else
                {
                    if (circularProgressBar2.Value > 50 & circularProgressBar2.Value <= 80)
                    {
                        circularProgressBar2.ProgressColor = Color.FromArgb(227, 244, 12);
                    }
                    else
                    {
                        circularProgressBar2.ProgressColor = Color.FromArgb(0, 153, 1);
                    }
                }
            }

            if (circularProgressBar3.Value <= 30)
            {
                circularProgressBar3.ProgressColor = Color.FromArgb(254, 30, 30);
            }
            else
            {
                if (circularProgressBar3.Value > 30 & circularProgressBar3.Value <= 50)
                {
                    circularProgressBar3.ProgressColor = Color.FromArgb(255, 152, 1);
                }
                else
                {
                    if (circularProgressBar3.Value > 50 & circularProgressBar3.Value <= 80)
                    {
                        circularProgressBar3.ProgressColor = Color.FromArgb(227, 244, 12);
                    }
                    else
                    {
                        circularProgressBar3.ProgressColor = Color.FromArgb(0, 153, 1);
                    }
                }
            }

           

            if (circularProgressBar4.Value <= 30)
            {
                circularProgressBar4.ProgressColor = Color.FromArgb(254, 30, 30);
            }
            else
            {
                if (circularProgressBar4.Value > 30 & circularProgressBar4.Value <= 50)
                {
                    circularProgressBar4.ProgressColor = Color.FromArgb(255, 152, 1);
                }
                else
                {
                    if (circularProgressBar4.Value > 50 & circularProgressBar4.Value <= 80)
                    {
                        circularProgressBar4.ProgressColor = Color.FromArgb(227, 244, 12);
                    }
                    else
                    {
                        circularProgressBar4.ProgressColor = Color.FromArgb(0, 153, 1);
                    }
                }
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            


            circularProgressBar1.Maximum = 100;

            if (circularProgressBar1.Value == Math.Round((CalOEE * 100)))
            {
                timer1.Stop();

            }
            else
            {
                circularProgressBar1.Value += 1;

            }


            circularProgressBar1.Text = circularProgressBar1.Value.ToString() + "%";

            if (circularProgressBar1.Value <= 30)
            {
                circularProgressBar1.ProgressColor = Color.FromArgb(254, 30, 30);
            }
            else
            {
                if (circularProgressBar1.Value > 30 & circularProgressBar1.Value <= 50)
                {
                    circularProgressBar1.ProgressColor = Color.FromArgb(255, 152, 1);
                }
                else
                {
                    if (circularProgressBar1.Value > 50 & circularProgressBar1.Value <= 80)
                    {
                        circularProgressBar1.ProgressColor = Color.FromArgb(227, 244, 12);
                    }
                    else
                    {
                        circularProgressBar1.ProgressColor = Color.FromArgb(0, 153, 1);
                    }
                }
            }



        }


        public void datosBatch()
        {
            int i = 0;
            CodCerrarConex();
            string Fecha = dateP1.Text;
            DateTime dtime = Convert.ToDateTime(Fecha);
            Fecha = dtime.ToString("yyyyMMdd");
            producto = null;
            comando2.Connection = CodAbrirConex();
            if (comboBox1.Text == "1er Turno")
            {
                comando2.CommandText = "SELECT ITH.THORD, ITH.TPROD FROM C20A237W.VENLX835F.ITH ITH WHERE(ITH.THWRKC = 431105 And ITH.THWRKC = 431105) AND(ITH.TTYPE = 'R ') AND (ITH.TTDTE = '" + Fecha + "')  AND(ITH.THTIME >= 55959 And ITH.THTIME <= 180000) ORDER BY ITH.TPROD";
            }//Obtener orden de producción en curso y el producto
            else
            {
                if (comboBox1.Text == "2do Turno")
                {
                    comando2.CommandText = "SELECT ITH.THORD, ITH.TPROD FROM C20A237W.VENLX835F.ITH ITH WHERE(ITH.THWRKC = 431105) AND(ITH.TTYPE = 'R ') AND (ITH.TTDTE = '" + Fecha + "')  AND(ITH.THTIME<55959) OR (ITH.THTIME>180000) AND (ITH.TTYPE='R') AND (ITH.TTDTE='" + Fecha + "') AND (ITH.THWRKC=431105) ORDER BY ITH.TPROD";
                }
                else
                {
                    comando2.CommandText = "SELECT ITH.THORD, ITH.TPROD FROM C20A237W.VENLX835F.ITH ITH WHERE(ITH.THWRKC = 431105 And ITH.THWRKC = 431105) AND(ITH.TTYPE = 'R ') AND (ITH.TTDTE = '" + Fecha + "')  ORDER BY ITH.TPROD";
                }


            }
            leer2 = comando2.ExecuteReader();
            while (leer2.Read())
            {

                if (String.IsNullOrEmpty(producto))
                {
                    orden = Convert.ToString(leer2.GetDecimal(0));
                    producto = leer2.GetString(1) + "-";
                    centrop = "431105";
                    //ConBatch.CodCerrarConex();
                }
                else
                {
                    //try
                    //{
                    char delimitador = '-';
                    codigos = producto.Split(delimitador);


                    if (leer2.GetString(1) != codigos[i])
                    {
                        orden = orden + "-" + Convert.ToString(leer2.GetDecimal(0));
                        producto =producto + leer2.GetString(1) + "-";
                        centrop = "431105";
                        i++;
                    }

                    //}
                    //catch
                    //{
                    //}

                }

            }
           CodCerrarConex();
           



            if (comboBox1.Text == "1er Turno")
            {
                // 1er Turno 
                comando2.Connection = CodAbrirConex();
                comando2.CommandText = "SELECT Sum(ITH.TQTY) FROM C20A237W.VENLX835F.ITH ITH WHERE(ITH.TTYPE = 'R') AND (ITH.TTDTE = '" + Fecha + "' ) AND (ITH.THWRKC = 431105) AND(ITH.THTIME >= 55959 And ITH.THTIME <= 180000)";
                leer2 = comando2.ExecuteReader();
                if (leer2.Read())
                {

                    producidos = Convert.ToString(leer2.GetValue(0));
                    CodCerrarConex();

                }
                //rechazos
                comando2.Connection = CodAbrirConex();
                comando2.CommandText = "SELECT Sum(ITH.TQTY) FROM C20A237W.VENLX835F.ITH ITH WHERE(ITH.TTYPE = 'DV') AND (ITH.TTDTE = '" + Fecha + "' ) AND (ITH.THWRKC = 431105) AND(ITH.THTIME >= 55959 And ITH.THTIME <= 180000)";
                leer2 = comando2.ExecuteReader();
                if (leer2.Read())
                {

                    rechazos = Convert.ToString(leer2.GetValue(0));
                    CodCerrarConex();

                }

            }

            else
            {
                if (comboBox1.Text == "2do Turno")
                {
                    //sSegundo Turno
                    comando2.Connection = CodAbrirConex();
                    comando2.CommandText = "SELECT Sum(ITH.TQTY) FROM C20A237W.VENLX835F.ITH ITH WHERE (ITH.THTIME<55959) AND (ITH.TTYPE='R') AND (ITH.TTDTE='" + Fecha + "') AND (ITH.THWRKC=431105) OR (ITH.THTIME>180000) AND (ITH.TTYPE='R') AND (ITH.TTDTE='" + Fecha + "') AND (ITH.THWRKC=431105)";
                    leer2 = comando2.ExecuteReader();
                    if (leer2.Read())
                    {

                        producidos = Convert.ToString(leer2.GetValue(0));
                        CodCerrarConex();

                    }
                    //rechazos
                    comando2.Connection = CodAbrirConex();
                    comando2.CommandText = "SELECT Sum(ITH.TQTY) FROM C20A237W.VENLX835F.ITH ITH WHERE(ITH.THTIME < 55959) AND(ITH.TTYPE = 'DV') AND(ITH.TTDTE = '" + Fecha + "') AND(ITH.THWRKC = 431105) OR(ITH.THTIME > 180000) AND(ITH.TTYPE = 'DV') AND(ITH.TTDTE = '" + Fecha + "') AND(ITH.THWRKC = 431105)";
                    leer2 = comando2.ExecuteReader();
                    if (leer2.Read())
                    {

                        rechazos = Convert.ToString(leer2.GetValue(0));
                        CodCerrarConex();

                    }
                }
                else
                {
                    comando2.Connection = CodAbrirConex();
                    comando2.CommandText = "SELECT Sum(ITH.TQTY) FROM C20A237W.VENLX835F.ITH ITH WHERE  (ITH.TTYPE='R') AND (ITH.TTDTE='" + Fecha + "') AND (ITH.THWRKC=431105) ";
                    leer2 = comando2.ExecuteReader();
                    if (leer2.Read())
                    {

                        producidos = Convert.ToString(leer2.GetValue(0));
                        CodCerrarConex();

                    }
                    //rechazos
                    comando2.Connection = CodAbrirConex();
                    comando2.CommandText = "SELECT Sum(ITH.TQTY) FROM C20A237W.VENLX835F.ITH ITH WHERE (ITH.TTYPE = 'DV') AND(ITH.TTDTE = '" + Fecha + "') AND(ITH.THWRKC = 431105) ";
                    leer2 = comando2.ExecuteReader();
                    if (leer2.Read())
                    {

                        rechazos = Convert.ToString(leer2.GetValue(0));
                        CodCerrarConex();

                    }
                }
            }




        }

        //CALCULAR OEE un producto:

        //Consulta la hora de inicio del batch
        public void TiempoTurno()
        {
            string Fecha = dateP1.Text;
            DateTime dtime = Convert.ToDateTime(Fecha);
            Fecha = dtime.ToString("yyyy-MM-dd");
           
            comando.Connection = AbrirConex();
            if (comboBox1.Text != "Todos")
            {
                comando.CommandText = "select cast( Sum(BPTT) as varchar), cast(Sum(BPTP) as varchar) from Mae.BatchPro where BPFePro='" + Fecha + "' and BPTurno='" + comboBox1.Text + "'";
            }
            else
            {
                comando.CommandText = "select cast( Sum(BPTT) as varchar), cast(Sum(BPTP) as varchar) from Mae.BatchPro where BPFePro='" + Fecha + "'";
            }
            leer = comando.ExecuteReader();
            if (leer.Read())
            {
               try
                { tt = leer.GetString(0);
                tp = leer.GetString(1); }
                catch
                {
                    tt = "0"; tp = "0";

                }
                  
                comando.Connection = CerrarConex();

            }
           
            comando.Connection = CerrarConex(); CodCerrarConex();
            try
            {
                TT = Convert.ToDouble(tt.Replace(".", ","));
                TP = Convert.ToDouble(tp.Replace(".", ","));
            }
            catch
            {
                TT = Convert.ToDouble(tt);
                TP = Convert.ToDouble(tp);
            }
            
        }

        //buscar rendimiento de cada producto
        public void DatosOEE()
        {

            string Fecha = dateP1.Text;
            DateTime dtime = Convert.ToDateTime(Fecha);
            Fecha = dtime.ToString("yyyyMMdd");
            bool turno;
            if (comboBox1.Text == "1er Turno")
            {
                turno = false;
            }
            else
            {
                turno = true;
            }
            //false 1ero, true 2do

            string valor = "";
            //char delimitador = '-';

            //codigos2 = CNBatchPro.producto.Split(delimitador);
            try
            {
                kxm = new double[codigos.Length - 1];
                r = new double[codigos.Length - 1];
                dv = new double[codigos.Length - 1];
            }
            catch
            {   codigos= new string[1];
                kxm = new double[codigos.Length - 1];
                r = new double[codigos.Length - 1];
                dv = new double[codigos.Length - 1];
            }



            for (int i = 0; i < codigos.Length - 1; i++)
            {

                comando.Connection = AbrirConex();
                comando.CommandText = "select cast( KGMMin as varchar) from dbo.KGM where KGMCod='" + codigos[i] + "'";
                leer = comando.ExecuteReader();
                if (leer.Read())
                {
                    valor = leer.GetString(0);
                }
                kxm[i] = Convert.ToDouble(valor.Replace(".", ","));
                comando.Connection = CerrarConex();

                CodCerrarConex();
                // 1er Turno 

                if (turno == false)
                {
                    comando2.Connection = CodAbrirConex();
                    comando2.CommandText = "SELECT Sum(ITH.TQTY) FROM C20A237W.VENLX835F.ITH ITH WHERE(ITH.TTYPE = 'R') AND (ITH.TTDTE = '" + Fecha + "' ) AND (ITH.THWRKC = 431105) AND(ITH.THTIME >= 55959 And ITH.THTIME <= 180000) And (ITH.TPROD='" + codigos[i] + "')";
                    leer2 = comando2.ExecuteReader();
                    if (leer2.Read())
                    {
                        try
                        {
                            r[i] = Convert.ToDouble(leer2.GetValue(0));
                        }
                        catch
                        {
                            r[i] = 0;
                        }



                    }
                    CodCerrarConex();

                    comando2.Connection = CodAbrirConex();
                    comando2.CommandText = "SELECT Sum(ITH.TQTY) FROM C20A237W.VENLX835F.ITH ITH WHERE(ITH.TTYPE = 'DV') AND (ITH.TTDTE = '" + Fecha + "' ) AND (ITH.THWRKC = 431105) AND(ITH.THTIME >= 55959 And ITH.THTIME <= 180000)";
                    leer2 = comando2.ExecuteReader();
                    if (leer2.Read())
                    {
                        try
                        {
                            dv[i] = Convert.ToDouble(leer2.GetDecimal(0));
                            CodCerrarConex();
                        }
                        catch
                        {
                            dv[i] = 0;
                        }



                    }
                }
                //segundo turno
                else
                {
                    if (comboBox1.Text == "2do Turno")
                    {
                        comando2.Connection = CodAbrirConex();
                        comando2.CommandText = " SELECT Sum(ITH.TQTY)FROM C20A237W.VENLX835F.ITH ITH WHERE(ITH.THTIME < 55959) AND(ITH.TTYPE = 'R') AND(ITH.TTDTE = '" + Fecha + "') AND(ITH.THWRKC = 431105) OR(ITH.THTIME > 180000) AND(ITH.TTYPE = 'R') AND(ITH.TTDTE = '" + Fecha + "') AND(ITH.THWRKC = 431105) And (ITH.TPROD='" + codigos[i] + "')";
                        leer2 = comando2.ExecuteReader();
                        if (leer2.Read())
                        {

                            r[i] = Convert.ToDouble(leer2.GetDecimal(0));


                        }
                        CodCerrarConex();

                        comando2.Connection = CodAbrirConex();
                        comando2.CommandText = "SELECT Sum(ITH.TQTY)FROM C20A237W.VENLX835F.ITH ITH WHERE(ITH.THTIME < 55959) AND(ITH.TTYPE = 'DV') AND(ITH.TTDTE = '" + Fecha + "') AND(ITH.THWRKC = 431105) OR(ITH.THTIME > 180000) AND(ITH.TTYPE = 'DV') AND(ITH.TTDTE = '" + Fecha + "') AND(ITH.THWRKC = 431105) ";
                        leer2 = comando2.ExecuteReader();
                        if (leer2.Read())
                        {
                            try
                            {
                                dv[i] = Convert.ToDouble(leer2.GetDecimal(0));
                                CodCerrarConex();
                            }
                            catch
                            {
                                dv[i] = 0;
                            }



                        }
                    }
                    else
                    {
                        comando2.Connection = CodAbrirConex();
                        comando2.CommandText = " SELECT Sum(ITH.TQTY)FROM C20A237W.VENLX835F.ITH ITH WHERE (ITH.TTYPE = 'R') AND(ITH.TTDTE = '" + Fecha + "') AND(ITH.THWRKC = 431105) And (ITH.TPROD='" + codigos[i] + "')";
                        leer2 = comando2.ExecuteReader();
                        if (leer2.Read())
                        {

                            r[i] = Convert.ToDouble(leer2.GetDecimal(0));


                        }
                        CodCerrarConex();

                        comando2.Connection = CodAbrirConex();
                        comando2.CommandText = "SELECT Sum(ITH.TQTY)FROM C20A237W.VENLX835F.ITH ITH WHERE (ITH.TTYPE = 'DV') AND(ITH.TTDTE = '" + Fecha + "') AND(ITH.THWRKC = 431105)";
                        leer2 = comando2.ExecuteReader();
                        if (leer2.Read())
                        {
                            try
                            {
                                dv[i] = Convert.ToDouble(leer2.GetDecimal(0));
                                CodCerrarConex();
                            }
                            catch
                            {
                                dv[i] = 0;
                            }
                        }

                    }

                }
            }
        }
        //double[] Rendimi;
        public void CalculoOEE()
        {

            porc = new double[codigos.Length - 1];
            rreal = new double[codigos.Length - 1];
            Rend = new double[codigos.Length - 1];
            Rendimiento = new double[codigos.Length - 1];
            //porcentaje de la producción de cada producto
            for (int i = 0; i < codigos.Length - 1; i++)
            {
                if (r[i] > 0)
                {
                    porc[i] = r[i] / (r.Sum());
                }
                else
                {
                    porc[i] = 0;
                }


            }
            // obtener el rendimiento real 
            for (int i = 0; i < codigos.Length - 1; i++)
            {
                if (TT > 0)
                {
                    rreal[i] = r[i] / (TT * porc[i]);
                }
                else
                {
                    rreal[i] = 0;
                }

            }
            //Ontemner rendimiento de cada producto
            for (int i = 0; i < codigos.Length - 1; i++)
            {
                if (rreal[i] > 0)
                {
                    Rend[i] = rreal[i] / kxm[i];
                }
                else
                {
                    Rend[i] = 0;
                }

            }
            //Rendimiento del turno
            for (int i = 0; i < codigos.Length - 1; i++)
            {
                Rendimiento[i] = Rend[i] * porc[i];
            }
            //Calidad
            if (dv.Sum() > 0)
            {
                Calidad = (r.Sum() / (dv.Sum() + r.Sum()));
            }
            else
            {
                if (dv.Sum() == 0 & r.Sum()==0 )
                {
                    Calidad = 0;
                }
                else
                {
                    Calidad = 1;
                }
                
            }

            //Disponibilidad
            if (TT > 0)
            {
                Disponibilidad = (TT / (TT + TP));
            }
            else
            {
                Disponibilidad = 0;
            }


            //OEE
            CalOEE = (Rendimiento.Sum()) * Calidad * Disponibilidad;
            try
            {
                if (Convert.ToInt32(Math.Round((CalOEE * 100))) > 100)
                {
                    CalOEE = 1;
                }
            }
            catch
            {

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            circularProgressBar1.Value = 0;
            circularProgressBar1.Text = "0%";
            circularProgressBar2.Value = 0;
            circularProgressBar3.Value = 0;
            circularProgressBar4.Value = 0;
            listBox1.Items.Clear();
            Cargar();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

     

        //Print
        private void btnPrint_Click(object sender, EventArgs e)
        {

            CaptureScreen();
            printDocument1.Print();
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
        }

        Bitmap memoryImage;

        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(730, 570, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        public void Correo()
        {
           

            var fromAddress = new MailAddress("OEEM5@paveca.com.ve", "OEE Molino 5");
            var toAddress = new MailAddress("javier.taborda@paveca.com.ve", "Hola Javier");
            const string fromPassword = "12345";
            const string subject = "OEE Molino 5";
            const string body = "Body";

            var smtp = new SmtpClient
            {
                Host = "vepvinf08.papeleslatinos.com",
                Port = 25,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body + memoryImage
            })
            {
                smtp.Send(message);
            }
            MessageBox.Show("Correo Enviado");
        }
        private void btnCorreo_Click(object sender, EventArgs e)
        {
            Correo();
        }

    }
}

