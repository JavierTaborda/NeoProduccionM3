using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace CapaNegocio
{
    public class CNOEE
    {


        SqlCommand comando = new SqlCommand();
        OleDbCommand comando2 = new OleDbCommand();
        SqlDataReader leer;
        OleDbDataReader leer2;
        private CDConBatch ConBatch = new CDConBatch();
        private CDConexionSQL Conexion = new CDConexionSQL();
        string tt, tp;//obtener la consulta para convertirr a double
        public static double TT { get; set; }
        public static double TP { get; set; }
        public static string[] codigos { get; set; }//dIVIDE LOS CODIGOS DE LOS PRODUCTOS       
        public static string[] Orden { get; set; }//dIVIDE LOS ORDENES DE Producción       
        double[] kxm;//rendimiento teorico 
        public static double[] r { get; set; }//producción de ith
        public static double[] dv { get; set; }//Rechazos de producción
        double[] porc;//porcentaje de la produccion
        double[] rreal;//rendimiento real del turno
        double[] Rend;//rendimientos individuales

        public static double[] Rendimiento { get; set; }
        public static double Calidad { get; set; }
        public static double Disponibilidad { get; set; }
        public static double TPRend { get; set; }
        public static double OEE { get; set; }
        public static string Turno { get; set; }

        public static string Ofic { get; set; } = CDVersion.Ofic;

        public static string CCentro { get; set; } = CDVersion.CCentro;//Constante para asignar el molino



        //CALCULAR OEE un producto:

        //Consulta la hora de inicio del batch
        public void TiempoTurno()
        {
            try
            {
                
            comando.Connection = Conexion.AbrirConex();
            comando.CommandText = "select cast( BPTT as varchar), cast(BPTP as varchar), BPTurno from Mae.BatchPro where IdBatchPro = (select MAX(IdBatchPro) from Mae.BatchPro where BPCenMaq='" + CCentro + "');";
            leer = comando.ExecuteReader();
            if (leer.Read())
            {
                tt =  leer.GetString(0);
                tp = leer.GetString(1);
                Turno= leer.GetString(2);
                comando.Connection = Conexion.CerrarConex();

            }
            TT = Convert.ToDouble(tt.Replace(".", ","));
            TP = Convert.ToDouble(tp.Replace(".", ","));
            }
            catch 
            {
                 // TODO
            }
        }

        //buscar rendimiento de cada producto
        public void DatosOEE()
        {
            DateTime dtime = new DateTime();
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string fechacali = "", fechacali2 = "", turnocali ="";
            bool turno=false; //false 1ero, true 2do
            try
            {

                //int valfe = int.Parse(DateTime.Now.ToString("HHmmss"));

                if (Turno == "1er Turno")
                {
                    // "1er Turno"

                    fecha = DateTime.Now.ToString("yyyyMMdd");
                    fechacali = DateTime.Now.ToString("yyyyMMdd");
                    fechacali2 = DateTime.Now.ToString("yyyy");
                    turnocali = "1";


                }
                else
                {
                    if (Turno == "2do Turno")
                    {
                        //"2do Turno"

                        dtime = Convert.ToDateTime(fecha).AddDays(1);
                        fecha = dtime.ToString("yyyyMMdd");
                        fechacali = DateTime.Now.AddDays(-1).ToString("yyyyMMdd");
                        fechacali2 = DateTime.Now.AddDays(-1).ToString("yyyy");
                        turno = true;
                        turnocali = "2";
                    }
                    else
                    {
                        if (Turno == "2do Turno")

                        {
                            //2do Turno

                            dtime = Convert.ToDateTime(fecha).AddDays(1);
                            fecha = dtime.ToString("yyyyMMdd");
                            fechacali = DateTime.Now.AddDays(-1).ToString("yyyyMM");
                            fechacali2 = DateTime.Now.AddDays(-1).ToString("yyyy");
                            turnocali = "2";
                            turno = true;
                        }

                    }
                }

                string valor = "";
                //char delimitador = '-';
                try
                {
                    kxm = new double[codigos.Length - 1];
                    r = new double[codigos.Length - 1];
                    dv = new double[codigos.Length - 1];
                }
                catch
                {
                    codigos = new string[1];
                    Orden = new string[1];
                    kxm = new double[codigos.Length - 1];
                    r = new double[codigos.Length - 1];
                    dv = new double[codigos.Length - 1];
                }

                //codigos2 = CNBatchPro.producto.Split(delimitador);
                try
                {

                    for (int i = 0; i < codigos.Length - 1; i++)
                    {
                        /*AND (tb_ana_mol_cal.Orden='"+Orden[i]+ "')*/

                        try
                        {
                            comando.Connection = ConBatch.CaliAbrirConex();
                            comando.CommandText = @"Select AVG(PesoBase) AS 'Peso Base', AVG(Velocidad_Bob) AS
                                                    'Velocidad Reel',AVG(Ancho/39.37) AS 'Ancho 1 (metros)', AVG(Ancho1/39.37)
                                                    AS 'Ancho 2 (metros)' FROM dbSisCali.dbo.tb_ana_mol_cal tb_ana_mol_cal 
                                                    WHERE (tb_ana_mol_cal.IdPais=1) AND (tb_ana_mol_cal.Date like '" + fechacali + "%') " +
                                                    "and Ancho>0 and Velocidad_Bob>0 AND (tb_ana_mol_cal.centro_mol='" + CCentro + "') " +
                                                    "AND (tb_ana_mol_cal.Orden='" + Orden[i] + "')  AND (tb_ana_mol_cal.Turno='" + turnocali + "')";
                            leer = comando.ExecuteReader();
                            if (leer.Read())
                            {
                                //Obtiene KG*Minutros de esta orden pesobase*velreel*ancho*(1-rollcheck)/1000
                                kxm[i] = (Convert.ToDouble(leer.GetValue(0)) * Convert.ToDouble(leer.GetValue(1)) * ((Convert.ToDouble(leer.GetValue(2))) + (Convert.ToDouble(leer.GetValue(3)))) * (1 - 0.07)) / 1000;
                            }

                            comando.Connection = ConBatch.CaliCerrarConex();
                            ConBatch.CodCerrarConex();

                        }
                           // En caso de que la busqueda de calidad sea null, se calcula comn el promedio de todas las ordenes de calidad.
                        catch (Exception ex)
                        {
                            comando.Connection = ConBatch.CaliCerrarConex();
                            ConBatch.CodCerrarConex();

                            if (kxm[0] == 0)
                            {
                                comando.Connection = ConBatch.CaliAbrirConex();
                                comando.CommandText = @"Select AVG(PesoBase) AS 'Peso Base', AVG(Velocidad_Bob) AS 'Velocidad Reel',
                                                        AVG(Ancho/39.37) AS 'Ancho 1 (metros)', AVG(Ancho1/39.37) AS 'Ancho 2 (metros)'
                                                        FROM dbSisCali.dbo.tb_ana_mol_cal tb_ana_mol_cal WHERE (tb_ana_mol_cal.IdPais=1) 
                                                        AND (tb_ana_mol_cal.Date like '" + fechacali2 + "%') and Ancho>0 and " +
                                                        "Velocidad_Bob>0 AND (tb_ana_mol_cal.centro_mol='" + CCentro + "') " +
                                                        "AND (tb_ana_mol_cal.Turno='" + turnocali + "')";
                                leer = comando.ExecuteReader();
                                if (leer.Read())
                                {
                                    //Obtiene KG*Minutros de esta orden pesobase*velreel*ancho*(1-rollcheck)/1000
                                    kxm[0] = (Convert.ToDouble(leer.GetValue(0)) * Convert.ToDouble(leer.GetValue(1)) * ((Convert.ToDouble(leer.GetValue(2))) + (Convert.ToDouble(leer.GetValue(3)))) * (1 - 0.07)) / 1000;
                                }

                                comando.Connection = ConBatch.CaliCerrarConex();
                                ConBatch.CodCerrarConex();
                            }
                        }

                        // 1er Turno 
                        //Obtener Producción
                        try
                        {
                            if (turno == false)
                            {
                                comando2.Connection = ConBatch.CodAbrirConex();
                                comando2.CommandText = @"SELECT Sum(ITH.TQTY) FROM C20A237W.VENLX835F.ITH ITH WHERE(ITH.TTYPE = 'R') 
                                                    AND (ITH.TTDTE = '" + fecha + "' ) AND (ITH.THWRKC = " + CCentro + ") AND" +
                                                        "(ITH.THTIME >= 55959 And ITH.THTIME <= 180000) And (ITH.TPROD='" + codigos[i] + "')";
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
                                ConBatch.CodCerrarConex();
                                comando2.Connection = ConBatch.CodAbrirConex();
                                //comando2.CommandText = @"SELECT Sum(ITH.TQTY) FROM C20A237W.VENLX835F.ITH ITH WHERE(ITH.TTYPE = 'DV') AND
                                //                    (ITH.TTDTE = '" + fecha + "' ) AND (ITH.THWRKC = " + CCentro + ") AND(ITH.THTIME >= 55959 " +
                                //                        "And ITH.THTIME <= 180000) And (ITH.TPROD='" + codigos[i] + "') OR " +
                                //                        "((ITH.TTYPE = 'R') AND" +
                                //                        "  (ITH.TTDTE = '" + fecha + "') AND(ITH.THWRKC = " + CCentro + ") AND(ITH.THTIME >= 55959 " +
                                //                          "And ITH.THTIME <= 180000) And (ITH.TPROD='" + codigos[i] + "') AND (ITH.TQTY<0))";
                                
                                comando2.CommandText = @"SELECT Sum(ITH.TQTY) FROM C20A237W.VENLX835F.ITH ITH WHERE(ITH.TTYPE = 'DV')
                                            AND (ITH.TTDTE = '" + fecha + "' ) AND (ITH.THWRKC = " + CCentro + ") " +
                                            "AND(ITH.THTIME >= 55959 And ITH.THTIME <= 180000) And (ITH.TPROD='" + codigos[i] + "')";

                                leer2 = comando2.ExecuteReader();
                                if (leer2.Read())
                                {
                                    try
                                    {
                                        dv[i] = Convert.ToDouble(leer2.GetDecimal(0));
                                        if (dv[i] < 0)
                                        {
                                            dv[i] = (dv[i]) * (-1);//Multiplicar por -1 ya que hay dv que se contrarrestas con ex en bpcs

                                        }
                                        ConBatch.CodCerrarConex();
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

                                comando2.Connection = ConBatch.CodAbrirConex();
                                comando2.CommandText = @" SELECT Sum(ITH.TQTY)FROM C20A237W.VENLX835F.ITH ITH WHERE(ITH.THTIME < 55959) 
                                                   AND(ITH.TTYPE = 'R') AND(ITH.TTDTE = '" + fecha + "') AND(ITH.THWRKC = " + CCentro + ")" +
                                                       " OR(ITH.THTIME > 180000) AND(ITH.TTYPE = 'R') AND(ITH.TTDTE = '" + fecha + "') " +
                                                       "AND(ITH.THWRKC = " + CCentro + ") And (ITH.TPROD='" + codigos[i] + "')";
                                leer2 = comando2.ExecuteReader();
                                if (leer2.Read())
                                {

                                    r[i] = Convert.ToDouble(leer2.GetDecimal(0));


                                }
                                ConBatch.CodCerrarConex();

                                comando2.Connection = ConBatch.CodAbrirConex();
                                comando2.CommandText = @"SELECT Sum(ITH.TQTY)FROM C20A237W.VENLX835F.ITH ITH WHERE(ITH.THTIME < 55959) 
                                                    AND(ITH.TTYPE = 'DV') AND(ITH.TTDTE = '" + fecha + "') " +
                                                        "AND(ITH.THWRKC = " + CCentro + ") OR(ITH.THTIME > 180000) " +
                                                        "AND(ITH.TTYPE = 'DV') AND(ITH.TTDTE = '" + fecha + "') " +
                                                        "AND(ITH.THWRKC = " + CCentro + ") And (ITH.TPROD='" + codigos[i] + "') " +
                                                        "OR ((ITH.THTIME < 55959) " +
                                                        "AND(ITH.TTYPE = 'R') AND(ITH.TTDTE = '" + fecha + "') " +
                                                        "AND(ITH.THWRKC = " + CCentro + ") OR(ITH.THTIME > 180000) " +
                                                        "AND(ITH.TTYPE = 'R') AND(ITH.TTDTE = '" + fecha + "') " +
                                                        "AND(ITH.THWRKC = " + CCentro + ") And (ITH.TPROD='" + codigos[i] + "') AND (ITH.TQTY<0))";
                                leer2 = comando2.ExecuteReader();


                                if (leer2.Read())
                                {
                                    try
                                    {

                                        dv[i] = Convert.ToDouble(leer2.GetDecimal(0));
                                        if (dv[i] < 0)
                                        {
                                            dv[i] = (dv[i]) * (-1);//Multiplicar por -1 ya que hay dv que se contrarrestas con ex en bpcs

                                        }
                                        ConBatch.CodCerrarConex();
                                    }
                                    catch
                                    {
                                        dv[i] = 0;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            //catch del try de la produccion
                        }
                    }
                }
                catch (Exception ex)
                {
                    // TODO
                   Console.Write("Ocurrió un error de conexión, Intente de nuevo. "+ex);
                }
            }
            catch//intentar ejecutar 
            {
                DatosOEE();
            }
          
        }
           //double[] Rendimi;
        public void CalculoOEE(string id)
        {
            
            porc = new double[codigos.Length - 1];
            rreal = new double[codigos.Length - 1];
            Rend = new double[codigos.Length - 1];
            Rendimiento = new double[codigos.Length - 1];
            //porcentaje de la producción de cada producto
            for (int i = 0; i < codigos.Length-1; i++)
            {
               if(r[i]>0)
                {
                    porc[i] =  r[i]/(r.Sum()) ;
                }
               else
                {
                    porc[i] = 0;
                }
                

            }
            // obtener el rendimiento real 
            for (int i = 0; i < codigos.Length-1; i++)
            {
                if (TT>0)
                {
                    rreal[i] = (r[i]+dv[i]) / (TT* porc[i]);
                }
                else
                {
                    rreal[i] = 0;
                }
                
            }
            //Ontemner rendimiento de cada producto
            for (int i = 0; i < codigos.Length-1; i++)
            {
                if (kxm.Length > 1)
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
                else
                {
                    if (rreal[i] > 0)
                    {
                        Rend[i] = rreal[i] / kxm[0];
                    }
                    else
                    {
                        Rend[i] = 0;
                    }
                }
                    
            }
            //Rendimiento del turno
            for (int i = 0; i < codigos.Length - 1; i++)
            {
                Rendimiento[i] = Rend[i] * porc[i];
            }
           


            if (dv.Sum() > 1 )
            {
                Calidad = ((r.Sum()) / ((dv.Sum()) + (r.Sum())));
            }
            else
            {
                if (dv.Sum() == 0 & r.Sum() == 0)
                {
                    Calidad = 0;
                }
                else
                {
                    Calidad  = ((r.Sum()) / ((r.Sum()) - (dv.Sum()))); ;
                }

            }

            //Disponibilidad
            if (TT>0)
            {
                Disponibilidad = (TT / (TT + TP));
            }
            else
            {
                Disponibilidad = 0;
            }


            //TP por rendimiento

            TPRend = (1 - Rendimiento.Sum()) * TT;
            //OEE
            OEE = (Rendimiento.Sum()) * Calidad * Disponibilidad;
            InsertarOEE(id);

           /*for (int i = 0; i < codigos.Length - 1; i++)
            {
                Rendimi[i] = Rend[i] * porc[i];
            }*/
        }
        public void InsertarOEE(string id)
        {
            string insertar, insren, Disp,Cal, Rend;
            if (OEE>0)
            {
                insertar = Convert.ToString(string.Format("{0:0.000}", (OEE.ToString().Replace(",", "."))));
                Rend = Convert.ToString(string.Format("{0:0.000}", (Rendimiento.Sum().ToString().Replace(",", "."))));
                Cal =  Calidad.ToString().Replace(",", ".");
                Disp = Convert.ToString(string.Format("{0:0.000}", (Disponibilidad.ToString().Replace(",", "."))));
            }
            else
            {
                insertar = OEE.ToString();
                Rend = Rendimiento.Sum().ToString();
                Cal = Calidad.ToString();
                Disp = Disponibilidad.ToString();
            }

            if (TPRend > 0)
            {
                insren = Convert.ToString(string.Format("{0:0.000}",(TPRend.ToString().Replace(",", "."))));
            }
            else
            { 
                insren = TPRend.ToString();
            }

        
            try
            {
                comando.Connection = Conexion.AbrirConex();
                comando.CommandText = " update Pro.ParRenCal set PRCTP=" + insren + " where BPIdBatchP=" + id + " and PRCCausa='Rendimiento'; update Mae.BatchPro set BPOEE =" + insertar + ", BPDisp="+Disp+",BPCali="+Cal+", BPRend="+Rend+" where IdBatchPro=" + id;
                comando.CommandType = CommandType.Text;
                comando.ExecuteNonQuery();
                comando.Connection = Conexion.CerrarConex();
            }
            catch
            {

            }


        }
        
}
}
