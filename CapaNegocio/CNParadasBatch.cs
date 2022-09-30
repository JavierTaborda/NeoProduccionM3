using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    public class CNParadasBatch
    {
        SqlCommand comando = new SqlCommand();
        
        SqlDataReader read;
        private CDConexionSQL Conexion = new CDConexionSQL();
        private CDParadasBatch objetoCD = new CDParadasBatch();

        public static string HoraIn { get; set; }
        public static string HoraFn { get; set; }
        public static string Hre { get; set; }

        private string codparada;
        private string horaI;
        private string horaF;
        private string dura;
        private string detalles;
        private int estado;

        public string _codparada
        {
            get { return codparada; }
            set { codparada = value; }
        }

        public string _horaI
        {
            get { return horaI; }
            set { horaI = value; }
        }
        public string _horaF
        {
            get { return horaF; }
            set { horaF = value; }
        }
        public string _dura
        {
            get { return dura; }
            set { dura = value; }
        }
        public string _detalles
        {
            get { return detalles; }
            set { detalles = value; }
        }
        public int _estado
        {
            get { return estado; }
            set { estado = value; }
        }
    


        //Mostrar paradas
        public DataTable MostrarParadas(int id) 
        {
            DataTable tabla = new DataTable();
            tabla=objetoCD.MostrarParBatch(id);
            return tabla;
        }
        public DataTable MostrarParadasRenCal(int id)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarParBatchRenCal(id);
            return tabla;
        }
        //Mostrar turnos
        public DataTable MostrarTurnos(string f1, string f2, string turno)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrarturnos(f1,f2,turno);
            return tabla;
        }
        public DataTable TurnoParadas(int id)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarParturno(id);
            return tabla;
        }

        //Se activa cuando ocurre una parada, y registra los datos por defecto.
        public void InsertarParada(int idbatch)
        {
            string eqp= "OFIC-237 ", sdt = "001001", deta="Sin observación";
            //_horaI = DateTime.Now.AddMinutes(-1).ToString("HH:mm:ss ");//Agregar un minuto de espera
            _horaI = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            _estado = 0;
            objetoCD.Insertar(idbatch,eqp,sdt, _horaI, deta,_estado);
        }
        public void InsertarParadaRenCal(int idbatch, string eqp, string cod, string causa, string obs)
        { 
            
            objetoCD.InsertarRenCal(idbatch, eqp, cod, causa,  obs);
        }
       


        //Solo se accede a esta funcion desde el formulario de paradas, el operador agrega el cod y detalles
        public void EditarParada()
        {
            //objetoCD.Editar();
        }
        //Se activa cuando ocurre se reanuda la maquina sy se activa el cronometro de tiempo trabajado, y registra los datos por defecto.
        public void FinalizarParada()
        {
            string hi = "00:00:00";
            string hf = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            //Consulta la hora de inicio del batch
            try
            {
            comando.Connection = Conexion.CerrarConex();
            comando.Connection = Conexion.AbrirConex();
                comando.CommandText = "SELECT  PBHorI from Pro.ParBatch where  PBEsta=0;";
                read = comando.ExecuteReader();
                if (read.Read())
                {
                    hi = read.GetString(0);
                    comando.Connection = Conexion.CerrarConex();

                }

                /*TimeSpan ti = TimeSpan.Parse(hi);
                TimeSpan tf = TimeSpan.Parse(hf);*/
                

                // double dura = (DateTime.Parse(hf)-DateTime.Parse(hi)).TotalMinutes;// Obtener los minutos de diferencia entre las horas.
                double dura = DateTime.Parse(hf).Subtract(DateTime.Parse(hi)).TotalMinutes;
                string dur = Convert.ToString(string.Format("{0:0.000}", dura));// se convietrte a string en formado con tres decimales 
                objetoCD.Cerrar(hf, dur);
            }
            catch (System.Exception ex)
            {
                // TODO
            }
        }

        //editar paradas de rendimiento y calidad
        public void EditarParadaRenCal(int idpar, string eqp, string cod, string causa,string obs)
        {
            try
            {
                comando.Connection = Conexion.AbrirConex();
                comando.CommandText = "update Pro.ParRenCal set ECodEqu ='" + eqp + "',TPCodPar='" + cod + "',  PRCCausa='" + causa + "', PRCObs='" + obs + "' WHERE IdParReCa=" + idpar;
                comando.CommandType = CommandType.Text;
                comando.ExecuteNonQuery();
                Conexion.CerrarConex();
            }
            catch (System.Exception ex)
            {
                 // TODO
            }
        }

    }


    }

