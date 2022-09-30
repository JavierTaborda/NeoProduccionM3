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
using CapaNegocio;
using System.Data.SqlClient;
using System.Collections;
using System.Drawing.Printing;




namespace STPM.FormsIndex
{
    public partial class Cierre : Form
    {

        CNOEE o = new CNOEE();
        
       
        public Cierre(string sid)
        {
            try
            {
                //listBox1.DataSource = null;
                //listBox1.Items.Clear();
                double ren;
            InitializeComponent();
            Paneles();
            //o.datosBatch();//Actualizar datos del batch
            o.TiempoTurno();
            o.DatosOEE();//
                //try
                //{
                    o.CalculoOEE(sid);

                //}
                //catch
                //{
                //    MessageBox.Show(" "+ CNOEE.OEE);
                //}
            ren = CNOEE.Rendimiento.Sum();
            lbldis.Text = Math.Round((CNOEE.Disponibilidad*100)).ToString()+"%";
            lblren.Text= Math.Round((ren*100)).ToString()+"%";
            lblcali.Text = Math.Round((CNOEE.Calidad*100)).ToString()+"%";
                //lblOEE.Text = Math.Round((CNOEE.OEE*100)).ToString()+"%";
            timer1.Start();
            circularProgressBar1.Value = 0;
            circularProgressBar1.Minimum = 0;
            Graficas();
            Datos();
            }
           catch (Exception e)
            {
                MessageBox.Show("Ocurrió el error: "+e, "Notificación");
            }
            
            //
        }
        
        
        public void Datos()
        {
            lblr.Text = CNOEE.r.Sum().ToString()+" KG";
            lbldv.Text = CNOEE.dv.Sum().ToString()+" KG";
            lblTT.Text = Math.Round(CNOEE.TT).ToString()+" min";
            lblTP.Text = Math.Round(CNOEE.TP).ToString() + " min";

            for (int i = 0; i < CNOEE.codigos.Length - 1; i++)
            {
               listBox1.Items.Add((i+01)+"- Producto: "+ CNOEE.codigos[i]+".  KG Producidos: "+CNOEE.r[i]+".  KG Rechazados: "+CNOEE.dv[i]);
            }

            
        }  
        public void Graficas()
        {
            if (Convert.ToInt32(Math.Round((CNOEE.Rendimiento.Sum() * 100)))>100)
            {
               circularProgressBar3.Maximum = Convert.ToInt32(Math.Round((CNOEE.Rendimiento.Sum() * 100)));
            }
            
            circularProgressBar2.Value = Convert.ToInt32(Math.Round((CNOEE.Disponibilidad * 100)));
            circularProgressBar3.Value = Convert.ToInt32(Math.Round((CNOEE.Rendimiento.Sum()) * 100));
            circularProgressBar4.Value = Convert.ToInt32(Math.Round((CNOEE.Calidad * 100)));
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

        public void Paneles()
        {
            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width,panel1.Height, 15, 15));
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 15, 15));
            panel3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 15, 15));
            panel4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel4.Width, panel4.Height, 15, 15));

        }

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

        private void btnAce_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(Math.Round((CNOEE.OEE * 100))) > 100 )
                {
                    CNOEE.OEE = 1;
                }
            }
            catch
            {

            }
            
           
            circularProgressBar1.Maximum = Convert.ToInt32(Math.Round((CNOEE.OEE * 100)));
          
                  if (circularProgressBar1.Value == Math.Round((CNOEE.OEE * 100)))
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
            memoryImage = new Bitmap(s.Width, 560, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);
        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
