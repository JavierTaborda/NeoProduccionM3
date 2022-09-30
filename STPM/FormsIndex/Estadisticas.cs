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
using System.Collections;

namespace STPM.FormsIndex
{
    
    public partial class Estadisticas : Form
    {

        string tt, tp; //guardar tiempos perdios de consultas 
        SqlCommand comando = new SqlCommand();
        SqlDataReader dr;
        private SqlConnection Con = new SqlConnection("Data Source=10.20.1.60\\DESARROLLO; Initial Catalog = DbSiTiePer;User ID=UsrSiTiePer;Password=UsrIng2021*");

        //private SqlConnection Conex = new SqlConnection("Server=.;DataBase=STPMolino; User ID=sa; Password=12345678; Integrated Security= true");

        // Conexion para los centros y ordenes de producción
        public SqlConnection CodAbrirConex()
        {
            if (Con.State == ConnectionState.Closed)
                Con.Open();
            return Con;
        }

        public SqlConnection CodCerrarConex()
        {
            if (Con.State == ConnectionState.Open)
                Con.Close();
            return Con;
        }

        public Estadisticas()
        {
            InitializeComponent();
            dateP1.Format = DateTimePickerFormat.Custom;
            dateP1.CustomFormat = "yyyy-MM-dd";
            dateP2.Format = DateTimePickerFormat.Custom;
            dateP2.CustomFormat = "yyyy-MM-dd";
        }

        private void Estadisticas_Load(object sender, EventArgs e)
        {

            GrafTopParadas(DateTime.Now.ToString("yyyy-MM"), "");
            GrafDura(DateTime.Now.ToString("yyyy-MM"), "");
            GrafTiempo();
            
            GrafTiempoMes(DateTime.Now.ToString("yyyy-MM"), "");



        }
        //Paradas por ocurrencia
        ArrayList Nomparadas = new ArrayList();
        ArrayList Cantparadas = new ArrayList();
        //Paradas por duracion
        ArrayList deta = new ArrayList();
        ArrayList dura = new ArrayList();
        //Tiempo perdido por turno
        ArrayList CantTTTP = new ArrayList();
        ArrayList Titulos = new ArrayList();
        //Tiempo perdido por mes
        ArrayList MesTTTP = new ArrayList();
        ArrayList MesTit = new ArrayList();

        private void GrafTopParadas(string fecha1, string fecha2)
        {

            Nomparadas.Clear();
            Cantparadas.Clear();

            comando.Connection = CodAbrirConex();
          

            try
            {
                comando.Connection = CodAbrirConex();
                if (fecha2 == "")
                {
                    //comando.CommandText = "Select TOP 10 P.TPCodPar, TPDes as Parada, Count(P.TPCodPar) As Cantidad  from  Pro.ParBatch P JOIN Pro.TipoPar I ON P.TPCodPar = I.TPCodPar	group by P.TPCodPar, TPDes order by Count(2) desc";
                    comando.CommandText = "  Select TOP 10 P.TPCodPar, TPDes as Parada, Count(P.TPCodPar) As Cantidad  from  Pro.ParBatch P JOIN Pro.TipoPar I ON P.TPCodPar = I.TPCodPar JOIN MAe.BatchPro B ON P.BPIdBatchP = B.IdBatchPro Where B.BPFePro like '%" + fecha1 + "%' group by P.TPCodPar, TPDes order by Count(2) desc";

                }
                else
                {
                    comando.CommandText = "Select TOP 10 P.TPCodPar, TPDes as Parada, Count(P.TPCodPar) As Cantidad  from Pro.ParBatch P JOIN Pro.TipoPar I ON P.TPCodPar = I.TPCodPar JOIN MAe.BatchPro B ON P.BPIdBatchP = B.IdBatchPro Where B.BPFePro >= '" + fecha1 + "' and B.BPFePro <= '" + fecha2 + "' group by P.TPCodPar, TPDes order by Count(2) desc";
                }
                    dr   = comando.ExecuteReader();
                while (dr.Read())
                {
                    Nomparadas.Add(dr.GetValue(1));
                    Cantparadas.Add(dr.GetValue(2));

                }

                chartCantParadas.Series[0].Points.DataBindXY(Nomparadas, Cantparadas);
                dr.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show("Error en Top Paradas"+e);
            }
        }


        private void GrafDura(string fecha1, string fecha2)
        {
            deta.Clear();
            dura.Clear();
            try
            {
                comando.Connection = CodAbrirConex();
                if (fecha2 == "")
                {
                    // comando.CommandText = "Select TOP 10 P.TPCodPar, TPDes as Parada, cast(SUM(PBDura) as float) As Minutos from Pro.ParBatch P JOIN Pro.TipoPar I ON P.TPCodPar = I.TPCodPar  where PBEsta=1 group by P.TPCodPar, TPDes  order by Minutos desc 	";

                    comando.CommandText = "  Select TOP 10 P.TPCodPar, TPDes as Parada, cast(SUM(PBDura) as float) As Minutos from Pro.ParBatch P JOIN Pro.TipoPar I ON P.TPCodPar = I.TPCodPar JOIN  MAe.BatchPro B ON P.BPIdBatchP = B.IdBatchPro where PBEsta=1 and   B.BPFePro Like '%" + fecha1+"%' group by P.TPCodPar, TPDes  order by Minutos desc";

                }
                else
                {
                    comando.CommandText = "  Select TOP 10 P.TPCodPar, TPDes as Parada, cast(SUM(PBDura) as float) As Minutos from Pro.ParBatch P JOIN Pro.TipoPar I ON P.TPCodPar = I.TPCodPar JOIN  MAe.BatchPro B ON P.BPIdBatchP = B.IdBatchPro where PBEsta=1 and   B.BPFePro>='" + fecha1 + "' and B.BPFePro<='" + fecha2 + "' group by P.TPCodPar, TPDes  order by Minutos desc";

                }
                //comando.CommandText = "Select TOP 10 P.TPCodPar, TPDes as Parada, cast(SUM(PBDura) as float) As Minutos from Pro.ParBatch P JOIN Pro.TipoPar I ON P.TPCodPar = I.TPCodPar  where PBEsta=1 group by P.TPCodPar, TPDes  order by Minutos desc 	";
                dr = comando.ExecuteReader();
                while (dr.Read())
                {

                    deta.Add(dr.GetValue(1));
                    dura.Add(Math.Round(Convert.ToDouble(dr.GetValue(2))));

                }
                dr.Close();
                comando.Connection = CodCerrarConex();
                chartDura.Series[0].Points.DataBindXY(deta, dura);
               

            }
            catch (Exception e)
            {
                //Habilitar para edición // MessageBox.Show("Error en Duración: " + e);
                 MessageBox.Show("Ocurrió un error, intente de nuevo. ");
            }
        }
        private void GrafTiempo()
        {
            try
            {
                comando.Connection = CodAbrirConex();
                comando.CommandText = "Select Cast(BPTT as varchar) as 'Tiempo Trabajado', Cast(BPTP as varchar) as 'Tiempo Perdido' from Mae.BatchPro where IdBatchPro =( SELECT MAX(IdBatchPro) 	from Mae.BatchPro); ";
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    CantTTTP.Add(Math.Round((Convert.ToDouble(dr.GetValue(0).ToString().Replace(".", ",")))));
                    CantTTTP.Add(Math.Round((Convert.ToDouble(dr.GetValue(1).ToString().Replace(".", ",")))));

                }
                //tiempos
                Titulos.Add("Tiempo Trabajado (min)");
                Titulos.Add("Tiempo Perdido (min)");

                dr.Close();
                try
                {
                    chartTurno.Series[0].Points.DataBindXY(Titulos, CantTTTP);
                }
                catch
                {
                    MessageBox.Show("No hay Batch registrados","No hay datos" ); 
                }               
                
            }
            catch (Exception e)
            {
                //Habilitar para edición // MessageBox.Show("Error en Duración: " + e);
                MessageBox.Show("Ocurrió un error, intente de nuevo. ");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GrafTiempoMes(dateP1.Text, dateP2.Text);
            GrafTopParadas(dateP1.Text, dateP2.Text);
            GrafDura(dateP1.Text, dateP2.Text);
        }

        private void chartTurno_Click(object sender, EventArgs e)
        {

        }

        private void GrafTiempoMes(string fecha1, string fecha2)
        {


            try
            {
                MesTit.Clear();
                MesTTTP.Clear();

                comando.Connection = CodAbrirConex();
                if (fecha2 == "")
                {
                    comando.CommandText = " Select SUM( ISNULL(BPTT,0)), SUM( ISNULL(BPTP,0)) from  Mae.BatchPro where BPFePro Like '%" + fecha1 + "%'";
                }
                else
                {
                    comando.CommandText = "Select SUM( ISNULL(BPTT,0)), SUM( ISNULL(BPTP,0)) from  Mae.BatchPro where BPFePro >='" + fecha1 + "' AND   BPFePro <= '" + fecha2 + "'";
                }
                //comando.CommandText = "  Select SUM( ISNULL(CAST (BPTT as float),0)), SUM( ISNULL(CAST (BPTP as float),0)) from Mae.BatchPro where BPFePro "+ fecha;
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                   // MesTTTP.Add((Convert.ToDouble(dr.GetValue(0))));
                    //MesTTTP.Add((Convert.ToDouble(dr.GetValue(1))));
                    MesTTTP.Add(Math.Round((Convert.ToDouble(dr.GetValue(0).ToString().Replace(".", ",")))));
                    MesTTTP.Add(Math.Round((Convert.ToDouble(dr.GetValue(1).ToString().Replace(".", ",")))));

                }
                MesTit.Add("Tiempo Trabajado (min)");
                MesTit.Add("Tiempo Perdido (min)");

                dr.Close();
                comando.Connection = CodCerrarConex();
                chartMes.Series[0].Points.DataBindXY(MesTit, MesTTTP);


            }
            catch (Exception e)
            {

                //Habilitar para edición // MessageBox.Show("Error en Duración: " + e);
                MessageBox.Show("Ocurrió un error, intente de nuevo. ");
            }
        }

    }
}
