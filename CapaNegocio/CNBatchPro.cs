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
    public class CNBatchPro
    {

        SqlCommand comando = new SqlCommand();
        OleDbCommand comando2 = new OleDbCommand();
        SqlDataReader leer;
        OleDbDataReader leer2;
        //OleDbDataReader leer3;
        private CDConBatch ConBatch = new CDConBatch();
        private CDConexionSQL Conexion = new CDConexionSQL();
        string cdep, ccar;
        string CCentro = CDVersion.CCentro;//Constante para asignar el molino

        //string[] codigos;
        public static string nombre { get; set; }
        public static string apellido { get; set; }
        public static string cargo { get; set; }
        public static string depa { get; set; }
        public static string ficha { get; set; }
        public static string centrop { get; set; } //Para Molino no aplica ya que ya se predefine el centro en el sistema
        public static string orden { get; set; }
        public static string producto { get; set; }
        public static string fechai { get; set; }
        public static string fechaf { get; set; }
        public static string producidos { get; set; }
        public static string rechazos { get; set; }
        public static string fechaturnos { get; set; }
        public static string tipoturnos { get; set; }


    

        //Consultar  la ficha para ingresar


        //Insertar
        private CDBatchPro objetoCD = new CDBatchPro();
       


        public string LoginFicha(string log)
        {
            try
            {
                
            comando.Connection = ConBatch.OpeAbrirConex();

            comando.CommandText = "DECLARE @ficha nvarchar(255) = '%"+ log + "%'; SELECT MAESTRO_TRABAJADOR.NOMFI1, MAESTRO_TRABAJADOR.APEFI1, MAESTRO_TRABAJADOR.CODFIC,MAESTRO_TRABAJADOR.DPTFIC, MAESTRO_TRABAJADOR.CGOFIC FROM MAESTRO_TRABAJADOR Where CODFIC LIKE @ficha AND MAESTRO_TRABAJADOR.DPTFIC = '3205' OR CODFIC LIKE @ficha AND MAESTRO_TRABAJADOR.DPTFIC = '3203' OR CODFIC LIKE @ficha AND MAESTRO_TRABAJADOR.DPTFIC = '3206' OR CODFIC LIKE @ficha AND MAESTRO_TRABAJADOR.DPTFIC = '3503' OR   CODFIC LIKE @ficha AND MAESTRO_TRABAJADOR.DPTFIC = '3208'";
            
            leer = comando.ExecuteReader();
            //Procedimiento alamacenado= comando.CommandType = CommandType.StoredProcedure;

            if (leer.Read())
            {
                nombre = leer.GetString(0);
                apellido = leer.GetString(1);
                ficha = leer.GetString(2);
                cdep = leer.GetString(3);
                ccar = leer.GetString(4);
                ConBatch.OpeCerrarConex();
                Buscarcargo();

            }
            else
            {
                ficha = "Verifique la ficha";
                ConBatch.OpeCerrarConex();
                //No hay ficha
            } 
            }
            catch (System.Exception ex)
            {
                 // TODO
            }
            return ficha;
        }

        public void Buscarcargo()
        {
            // Buscamos el Cargo y el departamento
            try
            {
                
            comando.Connection = ConBatch.OpeAbrirConex();
            comando.CommandText = "SELECT TOP 1 CARGOS.DESCGO, DEPARTAMENTOS.DESDPT FROM CARGOS INNER JOIN  DEPARTAMENTOS ON CARGOS.CODCGO='" + ccar + "' AND CODDPT='" + cdep + "'";
            leer = comando.ExecuteReader();
           if (leer.Read())
            {
               
                cargo = leer.GetString(0);
                depa = leer.GetString(1);
                ConBatch.OpeCerrarConex();

            }
           else
            {
                cargo = "No disponible";
                depa = "No disponible";
                ConBatch.OpeCerrarConex();
            }
            }
            catch (System.Exception ex)
            {
                 // TODO
            }
        }
        //Buscar datos del batch
        public string datosBatch(string centro)
        {
            
            string prod, ord, rpro, dvrecha;

            //Fecha para buscar los datos en BPCS , si es segundo turno se le suma 1 dia
            

            DateTime dtime = new DateTime();
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string turno="";
          
            

            int valfe = int.Parse(DateTime.Now.ToString("HHmmss"));

         
            if (valfe >= 50000 && valfe < 170000)
            {
                CNBatchPro.tipoturnos = "1er Turno";
            }
            else
            {
                if (valfe >= 170000 && valfe < 235959)
                {
                    CNBatchPro.tipoturnos = "2do Turno";


                }
                else
                {
                    if (valfe > 000000 && valfe < 60000)

                    {
                        CNBatchPro.tipoturnos = "2do Turno";
                    
                      
                    }
                }
            }

            if (CNBatchPro.tipoturnos== "1er Turno")
            {
                // "1er Turno"

                fecha = DateTime.Now.ToString("yyyyMMdd");
                
            }
            else
            {
                if (CNBatchPro.tipoturnos == "2do Turno" && valfe >= 180000 && valfe < 235959)
                {
                    //"2do Turno"

                    dtime = Convert.ToDateTime(fecha).AddDays(1);
                    fecha = dtime.ToString("yyyyMMdd");
                    
                }
                else
                {
                    if (CNBatchPro.tipoturnos == "2do Turno" && valfe > 000000 && valfe < 60000)

                    {
                        //2do Turno

                        fecha = DateTime.Now.ToString("yyyyMMdd");
                    
                    }
                 
                }
            }

            int i = 0;
            //Obtener los productos y ordenes de producción del turno
            //CNBatchPro.producto = "S1HIUS01-"; //Para prueba
            prod = CNBatchPro.producto;
            ord = CNBatchPro.orden;
            rpro = CNBatchPro.producidos;
            dvrecha= CNBatchPro.rechazos;
           
            try
            {
            CNBatchPro.producto = null;
            CNBatchPro.orden = null;
            comando2.Connection = ConBatch.CodAbrirConex();
                //comando2.CommandText = "SELECT ITH.THORD, ITH.TPROD FROM C20A237W.VENLX835F.ITH ITH WHERE(ITH.THWRKC = 431105) AND (ITH.TTYPE = 'R ') AND(ITH.TTDTE = '" + fecha + "') ORDER BY ITH.TPROD";
                if (tipoturnos == "1er Turno")
                {
                    comando2.CommandText = @"SELECT ITH.THORD, ITH.TPROD FROM C20A237W.VENLX835F.ITH ITH 
                                            WHERE(ITH.THWRKC = " + CCentro + " And ITH.THWRKC = " + CCentro + ") " +
                                            "AND(ITH.TTYPE = 'R ') AND (ITH.TTDTE = '" + fecha + "') " +
                                            " AND(ITH.THTIME >= 55959 And ITH.THTIME <= 180000) ORDER BY ITH.TPROD";
                }//Obtener orden de producción en curso y el producto
                else
                {
                    if (tipoturnos == "2do Turno")
                    {
                        comando2.CommandText = @"SELECT ITH.THORD, ITH.TPROD FROM C20A237W.VENLX835F.ITH ITH 
                         WHERE(ITH.THWRKC = " + CCentro + ") AND(ITH.TTYPE = 'R ') AND (ITH.TTDTE = '" + fecha + "')  " +
                         "AND(ITH.THTIME<55959) OR (ITH.THTIME>180000) AND (ITH.TTYPE='R') AND (ITH.TTDTE='" + fecha + "')" +
                         " AND (ITH.THWRKC=" + CCentro + ") ORDER BY ITH.TPROD";
                    }
                }
                //Obtener orden de producción en curso y el producto
                leer2 = comando2.ExecuteReader();
            while (leer2.Read())
            {

                if (String.IsNullOrEmpty(CNBatchPro.producto))
                {
                    CNBatchPro.orden = Convert.ToString(leer2.GetDecimal(0)) + "-" ;
                    CNBatchPro.producto = leer2.GetString(1) + "-";
                    CNBatchPro.centrop =  CCentro;
                   
                }
                else
                {
                    try
                    {
                            //LLena los arrayus con los codigos.
                    char delimitador = '-';
                    CNOEE.codigos = CNBatchPro.producto.Split(delimitador);
                    CNOEE.Orden = CNBatchPro.orden.Split(delimitador);
              


                    if (leer2.GetString(1) != CNOEE.codigos[i])
                    {
                        CNBatchPro.orden = CNBatchPro.orden + "" + Convert.ToString(leer2.GetDecimal(0)) + "-";
                        CNBatchPro.producto = CNBatchPro.producto + leer2.GetString(1) + "-";
                        CNBatchPro.centrop =CCentro;
                        i++;
                    }

                    }
                    catch
                    {
                        
                    }
                        CNBatchPro.centrop = CCentro ;

                    }

            }
            ConBatch.CodCerrarConex();
            }
            catch(Exception e)
            {
                
         
                CNBatchPro.orden = ord+ "";
                 CNBatchPro.producto = prod + "";
                 CNBatchPro.centrop =  CCentro;
                 ConBatch.CodCerrarConex();
            }


            //Obtener los Kg producidos y rechazados segun la hora Y TURNO


            if (tipoturnos == "1er Turno" )
            {
                rpro = CNBatchPro.producidos;
                dvrecha = CNBatchPro.rechazos;
                try
                {
                    // 1er Turno 
                    comando2.Connection = ConBatch.CodAbrirConex();
                    comando2.CommandText = @"SELECT Sum(ITH.TQTY) FROM C20A237W.VENLX835F.ITH ITH WHERE(ITH.TTYPE = 'R')
                                            AND (ITH.TTDTE = '" + fecha + "' ) AND (ITH.THWRKC = " + CCentro + ") AND(ITH.THTIME >= 55959 " +
                                            "And ITH.THTIME <= 180000)";
                    leer2 = comando2.ExecuteReader();
                    if (leer2.Read())
                    {

                        CNBatchPro.producidos = Convert.ToString(leer2.GetValue(0));
                        ConBatch.CodCerrarConex();

                    }
                    //rechazos
                    comando2.Connection = ConBatch.CodAbrirConex();
                    comando2.CommandText = @"SELECT Sum(ITH.TQTY) FROM C20A237W.VENLX835F.ITH ITH WHERE(ITH.TTYPE = 'DV')
                                            AND (ITH.TTDTE = '" + fecha + "' ) AND (ITH.THWRKC = " + CCentro + ") " +
                                            "AND(ITH.THTIME >= 55959 And ITH.THTIME <= 180000)";
                    leer2 = comando2.ExecuteReader();
                    if (leer2.Read())
                    {

                        CNBatchPro.rechazos = Convert.ToString(leer2.GetValue(0));
                        ConBatch.CodCerrarConex();

                    }
                }
                catch
                {
                    //en caso de error se le asigna el valñor anterior
                    CNBatchPro.producidos = rpro;
                    CNBatchPro.rechazos = dvrecha;
                }

            }

            else
            {

                rpro = CNBatchPro.producidos;
                dvrecha = CNBatchPro.rechazos;
                try
                {
                    //sSegundo Turno
                    comando2.Connection = ConBatch.CodAbrirConex();
                    comando2.CommandText = @"SELECT Sum(ITH.TQTY) FROM C20A237W.VENLX835F.ITH ITH WHERE (ITH.THTIME<55959) 
                                            AND (ITH.TTYPE='R') AND (ITH.TTDTE='" + fecha + "') AND " +
                                            "(ITH.THWRKC=" + CCentro + ") OR (ITH.THTIME>180000) AND (ITH.TTYPE='R') AND " +
                                            "(ITH.TTDTE='" + fecha + "') AND (ITH.THWRKC=" + CCentro + ")";
                    leer2 = comando2.ExecuteReader();
                    if (leer2.Read())
                    {

                        CNBatchPro.producidos = Convert.ToString(leer2.GetValue(0));
                        ConBatch.CodCerrarConex();

                    }
                    //rechazos
                    comando2.Connection = ConBatch.CodAbrirConex();
                    comando2.CommandText = @"SELECT Sum(ITH.TQTY) FROM C20A237W.VENLX835F.ITH ITH WHERE(ITH.THTIME < 55959) 
                                               AND(ITH.TTYPE = 'DV') AND(ITH.TTDTE = '" + fecha + "') AND(ITH.THWRKC = " + CCentro + ") " +
                                               "OR(ITH.THTIME > 180000) AND(ITH.TTYPE = 'DV') AND(ITH.TTDTE = '" + fecha + "')" +
                                               " AND(ITH.THWRKC = " + CCentro + ")";
                    leer2 = comando2.ExecuteReader();
                    if (leer2.Read())
                    {

                        CNBatchPro.rechazos = Convert.ToString(leer2.GetValue(0));
                        ConBatch.CodCerrarConex();

                    }
                }
                catch
                {
                    CNBatchPro.producidos = rpro;
                    CNBatchPro.rechazos = dvrecha;
                }
                }
              
           
            return centro;
        }


        //metodo para insertar los datos del turno
        public string InsertarTurno()
        {
           // string turno = "";//turno para obtener calculos de hora
            DateTime dtime = new DateTime();
            string idbatch, fecha = DateTime.Now.ToString("yyyy-MM-dd"), hora = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), opebatch=nombre+" "+apellido;
            int valfe = int.Parse(DateTime.Now.ToString("HHmmss"));
            if (valfe >= 50000 && valfe < 170000)
            {
                CNBatchPro.tipoturnos = "1er Turno";
            }
            else
            {
                if (valfe >= 170000 && valfe < 235959)
                {
                    CNBatchPro.tipoturnos = "2do Turno";
                   
                     dtime= Convert.ToDateTime(fecha).AddDays(1);
                    fecha = dtime.ToString("yyyy-MM-dd");

                }
                else
                {
                    if (valfe > 000000 && valfe <60000)

                    {
                        CNBatchPro.tipoturnos = "2do Turno";

                        dtime = Convert.ToDateTime(fecha);
                        fecha = dtime.ToString("yyyy-MM-dd");
                    }
                }
            }
            fechaturnos = fecha;
            idbatch =objetoCD.Insertar(fecha,hora, CNBatchPro.centrop,orden, CNBatchPro.tipoturnos, ficha, CNBatchPro.producidos, CNBatchPro.rechazos);
            return idbatch;
        }

        //consultar cuantos turnos se han abierto para evitar calcular la duracion desde las   6am o   6pm      
        public string TurnosAbiertos()
        {
            string turnos;
            turnos = objetoCD.TurnosA(CNBatchPro.tipoturnos,fechaturnos);
            return turnos;
        }


        //metodo para actualizar el tiempo del batch cada tiempo fijado
        public void Tiempo(int id,string turno, string turnosa)
        {
            int ta = int.Parse(turnosa);
            string agregar = "0", hi = fechaI(id,turno,ta), hoi=HoraI(id),hf = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            double extra;//añadir tiempo perdido

            if (hoi!="1" & hoi !="")
            {
                extra = DateTime.Parse(hf).Subtract(DateTime.Parse(hoi)).TotalMinutes;
                agregar = Convert.ToString(string.Format("{0:0.000}", extra));
            }
            else
            {
                agregar = "0";
            }
            

            //TimeSpan ti = TimeSpan.Parse(hi);
            //TimeSpan tf = TimeSpan.Parse(hf);
            double dura = DateTime.Parse(hf).Subtract(DateTime.Parse(hi)).TotalMinutes;


            string dur = Convert.ToString(string.Format("{0:0.000}", dura));// se convietrte a string en formado con tres decimales 
            objetoCD.InsertarTiempo(orden,dur,agregar, CNBatchPro.producidos, CNBatchPro.rechazos, id);
        }


        //metodo para cerrar el turno.

        public void CerrarTurno(int id, string turnosa)
        {
            int ta = int.Parse(turnosa);
            string turno = "", t="", hf = "", hcierre= DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");//turno para obtener calculos de hora
            int valfe = int.Parse(DateTime.Now.ToString("HHmmss"));
            //Hora para el cierre de turno
            if (CNBatchPro.tipoturnos == "1er Turno")
            {
                
                t = "1";
                hf= DateTime.Now.ToString("dd/MM/yyyy") + " 18:00:00";
            }
            else
            {

               //TODO: error  
                if (CNBatchPro.tipoturnos == "2do Turno")
                {
                    t = "2";
                    if (valfe > 180000 && valfe < 235959)
                    {
                        hf = DateTime.Now.AddDays(1).ToString("dd/MM/yyyy") + " 06:00:00";
                    }
                    else
                    {
                        hf = DateTime.Now.ToString("dd/MM/yyyy") + " 06:00:00";
                    }
                }
               
            }
            datosBatch(id.ToString());

            string hi = fechaI(id, CNBatchPro.tipoturnos, ta ); 


            // TimeSpan ti = TimeSpan.Parse(hi);
            //TimeSpan tf = TimeSpan.Parse(hf);
            //double dura = tf.Subtract(ti).TotalMinutes;// Obtener los minutos de diferencia entre las horas.
            double dura = DateTime.Parse(hf).Subtract(DateTime.Parse(hi)).TotalMinutes;
            string dur = Convert.ToString(string.Format("{0:0.000}", dura));// se convietrte a string en formado con tres decimales    
            objetoCD.Cerrarbatch(id,hcierre,dur,CNBatchPro.orden,CNBatchPro.producidos,CNBatchPro.rechazos, CNBatchPro.tipoturnos);
        }

        // No se usa por las paradas por inicio de turno 
        public string fechaI(int id, string turno, int ta)
        {
            string hi="";
            if (ta < 1)
            {
                if (CNBatchPro.tipoturnos == "1er Turno")
                {
                    hi = DateTime.Now.ToString("dd/MM/yyyy") + " 06:00:00";
                }
                else
                {
                    if (CNBatchPro.tipoturnos == "2do Turno")
                    {
                        hi = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy") + " 18:00:00";
                    }
                }
            }

            else
            {
                //Consulta la hora de inicio del batch 
                /*string hi = "00:00:00";*/
                try
                {
                    comando.Connection = Conexion.AbrirConex();
                    comando.CommandText = "declare @idbatch int =" + id + " select BPHoraIni from Mae.BatchPro where IdBatchPro = @idbatch";
                    leer = comando.ExecuteReader();
                    if (leer.Read())
                    {
                        hi = leer.GetString(0);
                        comando.Connection = Conexion.CerrarConex();

                    }
                }
                catch (System.Exception ex)
                {
                     // TODO
                }
            }


            return hi;
        }
        
        //Buscar minutos duracion de la parada actual
        public string HoraI(int id)
        {
            string hoi = "";
            try
            {
                comando.Connection = Conexion.AbrirConex();
                comando.CommandText = "declare @idbatch int =" + id + " declare @con varchar(5) IF (select PBHorI from Pro.ParBatch where BPIdBatchP=@idbatch and PBEsta=0)is not null select PBHorI from Pro.ParBatch where BPIdBatchP = @idbatch and PBEsta = 0; ELSE  print '1'; ";
                leer = comando.ExecuteReader();
                if (leer.Read())
                {
                    hoi = leer.GetString(0);
                    comando.Connection = Conexion.CerrarConex();

                }
            }
            catch (System.Exception ex)
            {
                 // TODO
            }
            return hoi;
        }
    }
}
