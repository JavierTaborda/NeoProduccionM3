using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class CDTipoParada
    {
        private CDConexionSQL Conexion = new CDConexionSQL();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();
        string CCentro = "431103";//Constante para asignar el molino


        public DataTable MostrarCentros()
        {
            try

            {
                comando.Connection = Conexion.AbrirConex();
                comando.CommandText = "Select * from CentroEq";
                //Procedimiento alamacenado= comando.CommandType = CommandType.StoredProcedure;
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                Conexion.CerrarConex();
            }
            catch (System.Exception ex)
            {
                // TODO
            }
            return tabla;
        }
        public DataTable MostrarTipoPar()
        {
            try
            {
                comando.Connection = Conexion.AbrirConex();
                comando.CommandText = "Select * from TipoPar";
                //Procedimiento alamacenado= comando.CommandType = CommandType.StoredProcedure;
                leer = comando.ExecuteReader();
                tabla.Load(leer);
                Conexion.CerrarConex();
            }
            catch (System.Exception ex)
            {
                 // TODO
            }
            return tabla;
        }

        public DataTable ListarP()
        {
            DataTable Tabla = new DataTable();
            try
            {
                
                comando.Connection = Conexion.AbrirConex();
                comando.CommandText = "select * from Pro.ParteEqp ";
                //comando.CommandType = CommandType.StoredProcedure;
                leer = comando.ExecuteReader();
                Tabla.Load(leer);
                leer.Close();
                Conexion.CerrarConex();
            }
            catch (System.Exception ex)
            {
                 // TODO
            }
            return Tabla;
        }

        public DataTable ListarEquipos(string ca, string centro)
        {
            DataTable Tabla = new DataTable();
            try
            {
               
                comando.Connection = Conexion.AbrirConex();
                comando.CommandText = "select PEIdParteE, ECodEqu, concat(ECodEqu, ' - ', ENombre) as Detalle from Pro.Equipos JOIN dbo.CentroEq ON Pro.Equipos.CEIdCenEq = dbo.CentroEq.IdCentroEq where PEIdParteE = " + ca + " and EEsta = 1 and IdCentroEq = " + centro + "  order by  PEIdParteE";

                      //comando.CommandType = CommandType.StoredProcedure;
                      leer = comando.ExecuteReader();
                Tabla.Load(leer);
                leer.Close();
                Conexion.CerrarConex();
            }
            catch (System.Exception ex)
            {
                 // TODO
            }
            return Tabla;
        }
        public DataTable ListarCausas()
        {
            DataTable Tabla = new DataTable();
            try
            {
               
                comando.Connection = Conexion.AbrirConex();
                comando.CommandText = " select IdCausa,CNombre from Pro.Causas order by CNombre asc";
                //comando.CommandType = CommandType.StoredProcedure;
                leer = comando.ExecuteReader();
                Tabla.Load(leer);
                leer.Close();
                Conexion.CerrarConex();
            }
            catch (System.Exception ex)
            {
                 // TODO
            }
            return Tabla;

        }

        public DataTable ListarCodigos(string causa)
        {
            DataTable Tabla = new DataTable();
            if (causa != "RC")
            {   
                try
                {
                    comando.Connection = Conexion.AbrirConex();
                    comando.CommandText = " select TPCodPar, concat(TPDes, ' - ' , TPCodPar) as Mostrar from Pro.TipoPar where CIdCausa=" + causa + " order by CIdCausa asc";
                    //comando.CommandType = CommandType.StoredProcedure;
                    leer = comando.ExecuteReader();
                    Tabla.Load(leer);
                    leer.Close();
                    Conexion.CerrarConex();
                }
                catch (System.Exception ex)
                {
                     // TODO
                }
            }
            else
            {
                if (causa == "RC")
                {
                    try
                    {
                        comando.Connection = Conexion.AbrirConex();
                        comando.CommandText = "  select TPCodPar, concat(TPDes, ' - ' , TPCodPar) as Mostrar from Pro.TipoPar where CIdCausa = 18 order by CIdCausa asc";
                        //comando.CommandType = CommandType.StoredProcedure;
                        leer = comando.ExecuteReader();
                        Tabla.Load(leer);
                        leer.Close();
                        Conexion.CerrarConex();
                    }
                    catch (System.Exception ex)
                    {
                         // TODO
                    }
                }
            }
            return Tabla;
        }
    }
}
