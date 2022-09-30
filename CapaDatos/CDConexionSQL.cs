using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CDConexionSQL
    {


        private SqlConnection Conex = new SqlConnection("Data Source=10.20.1.60\\DESARROLLO; Initial Catalog = DbSiTiePer;User ID=UsrSiTiePer;Password=UsrIng2021*");

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
    }
}
