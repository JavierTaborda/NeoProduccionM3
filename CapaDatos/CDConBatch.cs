using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace CapaDatos
{
    public class CDConBatch
    {
                //Base de datos para BPCS
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

        //Base de dato0s de los operadores
        private SqlConnection ConOpe = new SqlConnection("Data Source=DCTDTDB02; Initial Catalog = PLST ;User ID=usrConSpi;Password=Spi2017**");
 

        public SqlConnection OpeAbrirConex()
        {
            if (ConOpe.State == ConnectionState.Closed)
                ConOpe.Open();
            return ConOpe;
        }

        public SqlConnection OpeCerrarConex()
        {
            if (ConOpe.State == ConnectionState.Open)
                ConOpe.Close();
            return ConOpe;
        }

        private SqlConnection ConCali = new SqlConnection("Data Source=DCTDTDB01; Initial Catalog =dbSisCali;User ID=vusrred;Password=");


        public SqlConnection CaliAbrirConex()
        {
            if (ConOpe.State == ConnectionState.Closed)
                ConOpe.Open();
            return ConOpe;
        }

        public SqlConnection CaliCerrarConex()
        {
            if (ConOpe.State == ConnectionState.Open)
                ConOpe.Close();
            return ConOpe;
        }
    }
}
