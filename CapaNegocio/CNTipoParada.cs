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
    public class CNTipoParada
    {
        private CDConexionSQL Conexion = new CDConexionSQL();

       
        SqlCommand comando = new SqlCommand();

        private string equipo;
        private string causa;
        private string codigo;
        private string observ;
        private int idpar;

        public string _equipo
        {
            get { return equipo; }
            set { equipo = value; }
        }
        public string _causa
        {
            get { return causa; }
            set { causa = value; }
        }
        public string _codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public string _observ
        {
            get { return observ; }
            set { observ = value; }
        }

        public int _idpar
        {
            get { return idpar; }
            set { idpar = value; }
        }


        private CDTipoParada objetoCD = new CDTipoParada();


        public DataTable MostrarCentro()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarCentros();
            return tabla;
        }

        public DataTable MostrarTipoParada()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarTipoPar();
            return tabla;
        }
        public DataTable ListarPartes()
        {
            DataTable Tabla = new DataTable();
            Tabla = objetoCD.ListarP();
            return Tabla;
        }
        public DataTable ListarEquipos(string ca, string centro)
        {
            DataTable Tabla = new DataTable();
            Tabla = objetoCD.ListarEquipos(ca, centro);
            return Tabla;
        }
        public DataTable ListarCausas()
        {
            DataTable Tabla = new DataTable();
            Tabla = objetoCD.ListarCausas();
            return Tabla;
        }
        public DataTable ListarCodigos(string ca)
        {
            DataTable Tabla = new DataTable();
            Tabla = objetoCD.ListarCodigos(ca);
            return Tabla;
        }
      


        public void EditarTipoParada()
        {
            try
            {
                comando.Connection = Conexion.AbrirConex();
                comando.CommandText = "update Pro.ParBatch set ECodEqu ='"+_equipo+"',TPCodPar='" + _codigo + "', PBDet='"+_observ+ "' WHERE IdParBatch=" + _idpar;
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
