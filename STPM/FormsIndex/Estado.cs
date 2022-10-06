using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;//Para los tiempos de Stopwatch
using System.Net;
using System.IO.Ports;
using CapaNegocio;
using System.Threading;


namespace STPM.FormsIndex
{

    public partial class Estado : Form
    {
        int intArdu = 0;
        string centro = CNOEE.CCentro;//El centro debe obtenerse automaticamente 
                                 // int ParadaM; Variable para registrar la parada despues de un minuto

        //Calcular los tiemposen conjunto a los timers
        Stopwatch CronometroTT = new Stopwatch();
        Stopwatch CronometroTP = new Stopwatch();
        Stopwatch CronometroLast = new Stopwatch();
        //End Calcular los tiemposen conjunto a los timers
        CNParadasBatch EstadoParadas = new CNParadasBatch();// este objeto manejara las funciones para activar y desactivar las paraddas


        int changeimage = 0;//variable para el switch que cambia las imagenes
        //string puertoSeleccionar; variables para mostrar los puertos disponibles
        string datoArdu;//variable para guaradar el dato enviado por el arduino
        double min = 0; //Variable para verificar la duración minima de la parada. 
        double mintp = 0, segtp = 0;//mintp espera un minuto de estabilidad, y segtp evita que se inicie el cronometro tt y tp al mismo tiempo

        bool reset = false, inicio = true; //Para reiniciar el cronometro de espera (Last), e iniciar turno

        SerialPort serialPort = new SerialPort();

        public Estado()
        {
            InitializeComponent();

            //Mostrar los puertos disponibles del equipo
            /*string[] puertos = System.IO.Ports.SerialPort.GetPortNames();
            foreach (string mostrar in puertos)
            {
                cboxpuertos.Items.Add(mostrar);
            }
            spPuertoSerie.DataReceived += new SerialDataReceivedEventHandler(spPuertoSerie_DataReceived);*/

            //COM6 //M3
            //COM4 //M5
            serialPort.BaudRate = 9600;
            serialPort.PortName = "COM6";

            // Creamos el evento
            serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);

            // Controlamos que el puerto indicado esté operativo
            try
            {
                // Abrimos el puerto serie
                serialPort.Close();
                serialPort.Open();
            }
            catch
            {

            }

        }

        //---------------------------------------------------Conectarse al puerto sin combo box----------------------------------------

        // Nueva instancia de la clase


        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Obtenemos el puerto serie que lanza el evento
            SerialPort currentSerialPort = (SerialPort)sender;

            // Leemos el dato recibido del puerto serie
            datoArdu = serialPort.ReadLine();//try
            intArdu = Convert.ToInt32(datoArdu);
        }





        //---------------------------------------------------------------------------------------------------------

        //Mostrar los datos del batch de produccion
        public void DatosDelBatch()
        {
            //MessageBox.Show("Actualizando");
            CNBatchPro d = new CNBatchPro();
            d.datosBatch(centro);


            lblcentro.Text = CNBatchPro.centrop;//No aplica para molino ya esta predefinido
            lblproduc.Text = CNBatchPro.orden;
            lblproducto.Text = CNBatchPro.producto;
            if (String.IsNullOrEmpty(CNBatchPro.producidos))
            {
                lblR.Text = "0 KG";
            }
            else
            {
                lblR.Text = Math.Round(Convert.ToDecimal(CNBatchPro.producidos)) + " KG";
            }

            if (String.IsNullOrEmpty(CNBatchPro.rechazos))
            {
                lblDV.Text = "0 KG";
            }
            else
            {
                lblDV.Text = Math.Round(Convert.ToDecimal(CNBatchPro.rechazos)) + " KG";

            }
            if (lblid.Text != "")
            {
                CNOEE oee = new CNOEE();
                oee.TiempoTurno();
                oee.DatosOEE();
                oee.CalculoOEE(lblid.Text);

                lblren.Text = Math.Round((CNOEE.Rendimiento.Sum() * 100)).ToString() + "%";
                lblcal.Text = Math.Round((CNOEE.Calidad * 100)).ToString() + "%";
                lbldis.Text = Math.Round((CNOEE.Disponibilidad * 100)).ToString() + "%";
                lbloee.Text = Math.Round((CNOEE.OEE * 100)).ToString() + "%";


            }


        }


        //Imagen a mostrar
        private void Estado_Load(object sender, EventArgs e)
        {
            //Buscar la imagen correspondiente al picturebox
            picestatus.Image = STPM.Properties.Resources.sinturno;

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }




        //Eventos de los timers
        private void timertt_Tick(object sender, EventArgs e)
        {

            //Tiempo perdido hasta el momento. 
            string h, m, s;
            TimeSpan tts = new TimeSpan(0, 0, 0, 0, (int)CronometroTT.ElapsedMilliseconds);

            //Colocar 0 antes del numero;
            h = tts.Hours.ToString().Length < 2 ? "0" + tts.Hours.ToString() : tts.Hours.ToString();
            m = tts.Minutes.ToString().Length < 2 ? "0" + tts.Minutes.ToString() : tts.Minutes.ToString();
            s = tts.Seconds.ToString().Length < 2 ? "0" + tts.Seconds.ToString() : tts.Seconds.ToString();
            ///Mostrar el tiempo trabajado
            lbltt.Text = h + ":" + m + ":" + s;
            //Cambiar las imagenes
            switch (changeimage)
            {
                case 0:
                    picestatus.Image = STPM.Properties.Resources.gear1;
                    timertt.Interval = 500;
                    changeimage = 1;
                    break;
                case 1:
                    picestatus.Image = STPM.Properties.Resources.gear2;
                    timertt.Interval = 500;
                    changeimage = 2;
                    break;
                case 2:
                    picestatus.Image = STPM.Properties.Resources.gear3;
                    timertt.Interval = 500;
                    changeimage = 0;
                    break;

            }
            //Cambiar las imagenes
        }


        private void timertp_Tick(object sender, EventArgs e)
        {
            string h, m, s;
            TimeSpan tps = new TimeSpan(0, 0, 0, 0, (int)CronometroTP.ElapsedMilliseconds);
            //Colocar 0 antes del numero;
            h = tps.Hours.ToString().Length < 2 ? "0" + tps.Hours.ToString() : tps.Hours.ToString();
            m = tps.Minutes.ToString().Length < 2 ? "0" + tps.Minutes.ToString() : tps.Minutes.ToString();
            s = tps.Seconds.ToString().Length < 2 ? "0" + tps.Seconds.ToString() : tps.Seconds.ToString();
            ///Mostrar el tiempo trabajado
            lbltp.Text = h + ":" + m + ":" + s;
            //En caso de que changeimagenes haya quedado en 2
            mintp = tps.Minutes;
            segtp = tps.Seconds;
            if (changeimage == 2)
            { changeimage = 0; }

            //Cambiar las imagenes
            switch (changeimage)
            {
                case 0:
                    picestatus.Image = STPM.Properties.Resources.parada1;
                    timertp.Interval = 1000;
                    changeimage = 1;
                    break;
                case 1:
                    picestatus.Image = STPM.Properties.Resources.parada2;
                    timertp.Interval = 1000;
                    changeimage = 0;
                    break;
            }
            //End Cambiar las imagenes
        }

        //timerlast para mostrar el tiempo desde la ultima parada, o el tiempo parado
        private void timerlast_Tick(object sender, EventArgs e)
        {
            string h, m, s;
            TimeSpan tls = new TimeSpan(0, 0, 0, 0, (int)CronometroLast.ElapsedMilliseconds);
            //Colocar 0 antes del numero;
            h = tls.Hours.ToString().Length < 2 ? "0" + tls.Hours.ToString() : tls.Hours.ToString();
            m = tls.Minutes.ToString().Length < 2 ? "0" + tls.Minutes.ToString() : tls.Minutes.ToString();
            s = tls.Seconds.ToString().Length < 2 ? "0" + tls.Seconds.ToString() : tls.Seconds.ToString();
            ///Mostrar el tiempo trabajado
            lbltiempo.Text = h + ":" + m + ":" + s;
            //Variable para verificar la duración minima de la parada.
            min = tls.Seconds; // moide el tiempo a espera de estabilización para contar tiempo efectivo.
        }
        //End Eventos de los timers


        //Función para abrir el formulario de paradas
        public void FormParadas()
        {
            if (lblid.Text != "")
            {
                Form Paradas = new Parada(lblid.Text);
                Paradas.Show();
            }
            else
            {
                MessageBox.Show("Debe iniciar turno primero.");
            }

        }

        private void btnOn_Click(object sender, EventArgs e)
        {

            /* try
         {

             serialPort.WriteLine("a");
        }
        catch (Exception)
        {

            MessageBox.Show("No se puede conectar al puerto");
        }

         try
           {
               if (!spPuertoSerie.IsOpen)
               { spPuertoSerie.Open(); }

               // MessageBox.Show("El puerto se abrió");
           }
           catch (Exception ex)
           {
               MessageBox.Show("Error: " + ex, "No hay ningun puerto disponible");
           }*/


            // lbltt.Text = "00:00:00";
            // lbltp.Text = "00:00:00";

            try//por si no hay conexion
            {
                //spPuertoSerie.WriteLine("a");

                // serialPort.WriteLine("a");
                lblabierto.Text = "TURNO ABIERTO";
                lblcerrado.Text = "-";

                Turno();

                CronometroTP.Reset(); CronometroTT.Reset();// CronometroLast.Reset(); 
                btnOn.Enabled = false;
                cboxpuertos.Enabled = false;
                btnselec.Enabled = true;

                DatosDelBatch();//Cargar datos de batch
                InsertarBatch();//Insertar los datos al abrir turno 
                GuardarTiempo();//Guardar tiempos
                lblhora.Text = DateTime.Now.ToString("HH:mm:ss ");

                //Seleccionar turno
            }
            catch
            {
                MessageBox.Show("Error al iniciar el turno, intente nuevamente. Si el problema persiste de click en salir y reabra el programa en unos minutos.");
            }

            if (lblid.Text != "")
            {
                btnOff.Enabled = true;
                timerT.Enabled = true;
                timerT.Start();
                timerDBatch.Enabled = true;
                timerDBatch.Start();
            }



        }
        /// <summary>
        /// seleccionar turno
        public void Turno()
        {
            string turno = "";
            int valfe = int.Parse(DateTime.Now.ToString("HHmmss"));
            if (valfe >= 50000 && valfe < 180000)
            {
                turno = "1";
            }
            else
            {
                if (valfe >= 174000 && valfe < 235959)
                {
                    turno = "2";


                }
                else
                {
                    if (valfe > 000000 && valfe < 60000)

                    { turno = "2"; }
                }
            }
            lbturno.Text = turno;
        }
        /// </summary>

        //Insertar los datos del batch con un nuevo turno
        public void InsertarBatch()
        {
            CNBatchPro b = new CNBatchPro();
            lblid.Text = b.InsertarTurno();
            lbabiertos.Text = b.TurnosAbiertos();

        }
        //Actualizar el tiempo trabajado y perdido 
        private void timerT_Tick(object sender, EventArgs e)
        {
            GuardarTiempo();
        }
        //Actualizar orde y productos

        private void timerDBatch_Tick(object sender, EventArgs e)
        {
            DatosDelBatch();
        }

        public void GuardarTiempo()
        {
            //MessageBox.Show("hOLA");
            CNBatchPro t = new CNBatchPro();
            t.Tiempo(int.Parse(lblid.Text), lbturno.Text, lbabiertos.Text);

        }
        //Cerrar turno
        public void CerrarTurno()
        {
            int idturno = int.Parse(lblid.Text);
            CNBatchPro t = new CNBatchPro();
            t.CerrarTurno(idturno, lbabiertos.Text);
        }



        private void btnOff_Click(object sender, EventArgs e)
        {

            if (lblabierto.Text == "TURNO ABIERTO")
            {
                DialogResult result = MessageBox.Show("¿Seguro que desea cerrar turno?", "Notificación", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    try
                    {

                        //spPuertoSerie
                        //serialPort.WriteLine("b");
                        //spPuertoSerie
                        serialPort.Close();

                        //CerrarTurno();

                        if (CronometroTP.IsRunning)
                        {
                            EstadoParadas.FinalizarParada(int.Parse(lblid.Text));
                            CerrarTurno();
                        }
                        else
                        {
                            CerrarTurno();
                        }
                        //End Establecer Conexion con el puerto serial
                        lblcerrado.Text = "TURNO CERRADO";
                        lblabierto.Text = "-";
                        timerlast.Stop(); timertt.Stop(); timertp.Stop(); timerT.Enabled = false; timerDBatch.Enabled = false;
                        CronometroTP.Reset(); CronometroTT.Reset(); CronometroLast.Reset(); timertp.Enabled = false; timertt.Enabled = false;// timerlast.Enabled = false;CronometroLast.Reset();
                        btnOn.Enabled = true;
                        btnOff.Enabled = false;
                        Form Cierre = new Cierre(lblid.Text);
                        Cierre.Show();
                    }
                    catch
                    {
                        MessageBox.Show("Ocurrió un error de conexión, Intente de nuevo. ");
                    }







                }

            }
            else
            {

                MessageBox.Show("No puede salir con un turno en curso", "Advertencia");
            }
            //Establecer Conexion con el puerto serial


        }

        private void cboxpuertos_MouseClick(object sender, MouseEventArgs e)
        {
            btnOn.Enabled = true;
        }

        //Tiempo Se coloca este codigo dentro del timer para que se ejecute en ese lapso d tiempo

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Cerrar turno aoutomat6icamente 

            /* }
             private void button1_Click(object sender, EventArgs e)
             {

                 if (button1.Text == "On")
                 {
                     Probar(1);
                     button1.Text = "Off";
                     label4.Text = "1";
                 }
                 else { Probar(0); button1.Text = "On"; label4.Text = "0"; }
             } public void Probar(int p) {  

                intArdu = p;*/

            //------------------------------------------------------------------------------------------------------------------------------------------

            int valhora = int.Parse(DateTime.Now.ToString("HHmmss"));

            //Invertido a partir de 22/06/2022: >0
            if (intArdu >0 && lblabierto.Text == "TURNO ABIERTO")
            {

                if (CronometroLast.IsRunning & CronometroTP.IsRunning & reset == true)
                {
                    CronometroLast.Reset();
                    CronometroLast.Start();
                    reset = false;
                }



                if (min >= 30 & mintp > 0)

                {
                    //MessageBox.Show("UNO");
                    //si el cronommtro de tiempo perdido esta activado , este se detiene. 
                    if (CronometroTP.IsRunning)
                    {
                        CronometroTP.Stop();
                        timerlast.Stop();
                        timertp.Stop();
                        CronometroLast.Reset();
                        EstadoParadas.FinalizarParada(int.Parse(lblid.Text));//Cerrar la última parada 

                    }

                    //Quitar el ! si no funciona

                    if (!CronometroTT.IsRunning)
                    {
                        //MessageBox.Show("DOS");
                        timertt.Enabled = true;
                        timerlast.Enabled = true;
                        CronometroTT.Start();
                        timertt.Start();
                        timerlast.Start();
                        CronometroLast.Start();
                        lbltitulo.Text = "Tiempo Sin Parada: ";
                        lbltiempo.ForeColor = Color.LimeGreen; lbltt.ForeColor = Color.LimeGreen; lbltp.ForeColor = Color.DarkRed;
                        lblreci.Text = "DATO: " + datoArdu;

                    }
                }
                else
                {
                    if (!CronometroTT.IsRunning & inicio == true & segtp==0)
                    {
                        inicio = false;
                        //MessageBox.Show("TRES");
                        timertt.Enabled = true;
                        timerlast.Enabled = true;
                        CronometroTT.Start();
                        timertt.Start();
                        timerlast.Start();
                        CronometroLast.Start();
                        lbltitulo.Text = "Tiempo Sin Parada: ";
                        lbltiempo.ForeColor = Color.LimeGreen; lbltt.ForeColor = Color.LimeGreen; lbltp.ForeColor = Color.DarkRed;
                        lblreci.Text = "DATO: " + datoArdu;
                    }


                }




            }

            
            if (intArdu <=0 && lblabierto.Text == "TURNO ABIERTO")
            {

                if (!CronometroLast.IsRunning)
                {
                    timerlast.Start(); CronometroLast.Start();
                }

                //if (min >= 1)

                //{
                if (CronometroTT.IsRunning)
                {
                    timerlast.Stop();
                    CronometroTT.Stop();
                    timertt.Stop();
                    CronometroLast.Reset();

                }
                if (!CronometroTP.IsRunning)
                {

                    timertp.Enabled = true;

                    timerlast.Enabled = true;
                    timertp.Start(); CronometroTP.Start(); timerlast.Start(); CronometroLast.Start();

                    lbltitulo.Text = "Tiempo De Parada: ";
                    lbltt.ForeColor = Color.FromArgb(5, 121, 84); lbltp.ForeColor = Color.Red; lbltiempo.ForeColor = Color.Red;


                    EstadoParadas.InsertarParada(int.Parse(lblid.Text));//registra parada
                    GuardarTiempo();//Atualizar datos del tiempo del batch 
                    reset = true;

                    //FormParadas();//Form para registrar las paradas
                }
                //}


            }

            //Cerrar turno aoutomat6icamente 
           /* if (valhora > 175900 & lblabierto.Text == "TURNO ABIERTO" & lbturno.Text == "1")
            {

                try
                {
                    //MessageBox.Show("Holaaa " + valhora);

                    //spPuertoSerie
                    serialPort.WriteLine("b");
                    //spPuertoSerie
                    serialPort.Close();
                }
                catch
                {

                }


                try
                {
                    if (CronometroTP.IsRunning)
                    {
                        EstadoParadas.FinalizarParada();
                    }

                    CerrarTurno();

                    //End Establecer Conexion con el puerto serial
                    lblcerrado.Text = "TURNO CERRADO";
                    lblabierto.Text = "-";
                    timerlast.Stop(); timertt.Stop(); timertp.Stop(); timerT.Enabled = false; timerDBatch.Enabled = false;
                    CronometroTP.Reset(); CronometroTT.Reset(); CronometroLast.Reset(); timertp.Enabled = false; timertt.Enabled = false;// timerlast.Enabled = false;CronometroLast.Reset();
                    btnOn.Enabled = true;
                    btnOff.Enabled = false;

                    //Form Cierre = new Cierre(lblid.Text);
                    // Cierre.Show();
                    //MessageBox.Show("Hola");

                }
                catch
                {
                    MessageBox.Show("error");
                }

                // CerrarTurno();




            }*/

        }//Probar
        
        //METODO PARA GUARDAR EL TIEMPO PP Y TP,y DATOS DEL BATCH
       
        //END METODO PARA GUARDAR EL TIEMPO PP Y TP

        private void btnselec_Click(object sender, EventArgs e)
        {
            cboxpuertos.Enabled = true;
        }

        private void cboxpuertos_SelectedValueChanged(object sender, EventArgs e)
        {
            
            cboxpuertos.Enabled = false;
        }

        private void pnldatosp_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnparadas_Click(object sender, EventArgs e)
        {
            if (lblabierto.Text=="TURNO ABIERTO")
            {
                FormParadas();
            }
            else
            {
                MessageBox.Show("Debe abrir un turno primero.");
            }
            
            


        }

       

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (lblabierto.Text !="TURNO ABIERTO")
            {
                DialogResult result = MessageBox.Show("¿Desea  salir del programa?", "Salir", MessageBoxButtons.YesNoCancel);
                
                if (result == DialogResult.Yes)
                {

                    //Application.Exit();
                    Process[] proc = System.Diagnostics.Process.GetProcessesByName("Neo Produccion");
                    proc[0].Kill();
                    proc[0].WaitForExit();
                }
                
            }
            else
            {
                MessageBox.Show("No puede salir con un turno en curso","Advertencia");
            }
        }

    }

}