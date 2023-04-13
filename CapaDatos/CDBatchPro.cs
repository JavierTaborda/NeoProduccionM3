using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class CDBatchPro
    {
       
        SqlCommand comando = new SqlCommand();
        SqlDataReader leer;
        DataTable tabla = new DataTable();


        private CDConexionSQL Conexion = new CDConexionSQL();
        private CDConBatch ConBatch = new CDConBatch();
         string CCentro = CDVersion.CCentro;//Constante para asignar el molino

        public string Insertar(string fecha, string HoraI,string centro, string Orden, string turno, string Operador, string rr, string ddv)
        {
            string IdBatch = "", hrturno = "06:00:00", dur = "";//hora de inicio de turno
            bool paradaturno=false;
            double dura=0;
            string r, dv, version= CDVersion.version;
            if (centro == null || centro.Length == 0)
            {
                centro = CDVersion.CCentro;
            }

            try
            {

            if (!String.IsNullOrEmpty(rr))
            {
                r = rr.Replace(",", ".");
            }
            else
            {
                r = "0";
            }
            if (!String.IsNullOrEmpty(ddv))
                {
                    dv = ddv.Replace(",", ".");
                }
                else
                {
                    dv = "0";
                }

            int valhora = int.Parse(DateTime.Now.ToString("HHmmss"));
                //Obtener retraso por inicio de turno 
                if (turno == "1er Turno")
                {
                    if (valhora > 60500)
                    {
                         dura = DateTime.Parse(HoraI).Subtract(DateTime.Parse(hrturno)).TotalMinutes;
                         dur = Convert.ToString(string.Format("{0:0.000}", dura)).Replace(",", ".");
                         paradaturno = true;
                    }

                }
                else
                {
                    hrturno = "18:00:00";
                    if (valhora > 180500)
                    {
                         dura = DateTime.Parse(HoraI).Subtract(DateTime.Parse(hrturno)).TotalMinutes;
                         dur = Convert.ToString(string.Format("{0:0.000}", dura)).Replace(",", ".");
                         paradaturno = true;
                    }
                }


                

                comando.Connection = Conexion.AbrirConex();
                if (paradaturno == false)
                {
                    comando.CommandText = @" update Pro.ParBatch set PBEsta=1 where  
                                            BPIdBatchP=(Select  B.IdBatchPro from Pro.ParBatch P JOIN Mae.BatchPro B ON P.BPIdBatchP = B.IdBatchPro 
                                            Where B.BPCenMaq='" + CCentro + "' and P.PBEsta=0);	" +
                                            "update Mae.BatchPro set BPEsta = 1 where BPEsta = 0 and BPCenMaq='" + CCentro + "'; " +
                                            "INSERT INTO Mae.BatchPro ( Mae.BatchPro.BPFePro, Mae.BatchPro.BPHoraIni, Mae.BatchPro.BPOrdPro, Mae.BatchPro.BPCenMaq, Mae.BatchPro.BPTurno," +
                                            " Mae.BatchPro.BPFicOpe,Mae.BatchPro.BPProdu, Mae.BatchPro.BPRecha, Mae.BatchPro.BPActivo,Mae.BatchPro.BPEsta,Mae.BatchPro.BPVers)" +
                                            " values('" + fecha + "','" + HoraI + "','" + Orden + "','" + centro + "','" + turno + "','" + Operador + "',"+r+","+dv+",1,0,'"+version+ "'); " +
                                            "declare @id2 int; select @id2 = (select Max(IdBatchPro) from Mae.BatchPro where BPEsta = 0 and BPCenMaq='"+ CCentro + "')" +
                                            " INSERT INTO Pro.ParRenCal(BPIdBatchP, ECodEqu, TPCodPar, PRCCausa) values(@id2, '" + CDVersion.Ofic + "', '001001', 'Rendimiento');";

                }
                else
                {
                comando.CommandText = @" update Pro.ParBatch set PBEsta=1 where BPIdBatchP=
                                       (Select  B.IdBatchPro from Pro.ParBatch P JOIN Mae.BatchPro B ON P.BPIdBatchP 
                                        = B.IdBatchPro Where B.BPCenMaq='" + CCentro + "' and P.PBEsta=0);" +
                                        "	update Mae.BatchPro set BPEsta = 1 where BPEsta=0 and " +
                                        "BPCenMaq='" + CCentro + "'; declare @fecha date ='" + fecha + "';" +
                                        " declare @turno varchar (20)='" + turno + "'; " +
                                        "declare @fdate date; " +
                                        "declare @trno varchar (20); " +
                                        "declare @cod varchar (10);" +
                                        " declare @iduno int; " +
                                        "select @iduno= (select Max(IdBatchPro) from Mae.BatchPro);" +
                                        " select @fdate= (select BPFePro from Mae.BatchPro where IdBatchPro=@iduno); " +
                                        "select @trno= (select BPTurno from Mae.BatchPro where IdBatchPro=@iduno); " +
                                        "select @cod=(select top 1 PBHorI from Pro.ParBatch where TPCodPar='018078' " +
                                        "and BPIdBatchP=@iduno)" +
                                        " INSERT INTO Mae.BatchPro ( Mae.BatchPro.BPFePro, Mae.BatchPro.BPHoraIni, Mae.BatchPro.BPOrdPro, " +
                                        "Mae.BatchPro.BPCenMaq, Mae.BatchPro.BPTurno, Mae.BatchPro.BPFicOpe,Mae.BatchPro.BPProdu," +
                                        " Mae.BatchPro.BPRecha,Mae.BatchPro.BPActivo, Mae.BatchPro.BPEsta, Mae.BatchPro.BPVers)" +
                                        " values(@fecha,'" + HoraI + "','" + Orden + "','" + CDVersion.CCentro + "',@turno,'" + Operador + "'," + r + "," + dv + ",1,0,'" + version + "'); " +
                                        "declare @id2 int; select @id2= (select Max(IdBatchPro) from Mae.BatchPro where BPEsta=0 and BPCenMaq='" + CDVersion.CCentro + "') " +
                                        "IF (@cod='06:00:00'or @cod='18:00:00' or @cod is null and @fdate=@fecha and @turno=@trno) print 'hola';" +
                                        " Else INSERT INTO Pro.ParBatch (BPIdBatchP,ECodEqu, TPCodPar, PBHorI, PBHorF,PBDura, PBDet, PBEsta)" +
                                        " values( @id2,'" + CDVersion.Ofic + "','018078','" + hrturno + "','" + HoraI + "'," + dur + ",'Tiempo de perdido por inicio/cierre del turno',1)" +
                                        "INSERT INTO Pro.ParRenCal(BPIdBatchP, ECodEqu, TPCodPar, PRCCausa) values(@id2, '" + CDVersion.Ofic + "', '001001', 'Rendimiento');";


                }
            comando.CommandType = CommandType.Text;
                comando.ExecuteNonQuery();
                Conexion.CerrarConex();
                //Consultar el ID
                comando.Connection = Conexion.AbrirConex();
                comando.CommandText = "SELECT MAX(IdBatchPro) 	from Mae.BatchPro where  BPEsta=0 and BPCenMaq='" + CDVersion.CCentro + "';";
                leer = comando.ExecuteReader();
                if (leer.Read())
                {
                    IdBatch = Convert.ToString( leer.GetInt32(0));
                    comando.Connection = Conexion.CerrarConex();

                }
            }
            catch (Exception ex)
            {
                
            }
            
         
            return IdBatch;
            
        }

        public void InsertarTiempo(string orden, string dur, string extra,string rr,string ddv,  int id)
        {
            string agregar = "";
            string dr = dur.Replace(",", "."); //cambiar las comas por puntos para evitar error en la bd sql server
            string r, dv;

            if (!String.IsNullOrEmpty(rr))
            {
                r = rr.Replace(",", ".");
            }
            else
            {
                r = "0";
            }

            if (!String.IsNullOrEmpty(ddv))
            {
                dv = ddv.Replace(",", ".");
            }
            else
            {
                dv = "0";
            }

            if (extra != "")
            {
                agregar = extra.Replace(",", ".");
            }
            else
            {
                agregar = "0";
            }

            try
            {
                comando.Connection = Conexion.AbrirConex();
                comando.CommandText = @"declare @r float =" + r + " " +
                                        "declare @dv float=" + dv + " " +
                                        "declare @Orden varchar (50)='" + orden + "' " +
                                        "declare @idbatch int = " + id + " " +
                                        "declare @dturno float  = " + dr + " " +
                                        "declare @tt float " +
                                        "declare @tp float " +
                                        "declare @agregar float 	=" + agregar + " " +
                                        "if (select count(*) from Pro.ParBatch where BPIdBatchP = @idbatch)>0 " +
                                        "IF (@agregar)>0.0 " +
                                        "select @tp = (select SUM(PBDura)  from Pro.ParBatch where BPIdBatchP = @idbatch)+@agregar;" +
                                        " ELSE select @tp = (select SUM(PBDura)  from Pro.ParBatch where BPIdBatchP = @idbatch); " +
                                        "Else IF (@agregar)>0.0 select @tp = @agregar ELSE select @tp = 0; if (@dturno - @tp) >1  " +
                                        "select @tt =(@dturno - @tp) " +
                                        "else    select @tt = 0; " +
                                        "if (select COUNT(*) from Pro.ParBatch where BPIdBatchP = @idbatch)  > 0 " +
                                        "AND(select TOP 1 PBDura from Pro.ParBatch where BPIdBatchP = @idbatch) is null " +
                                        "update Mae.BatchPro set BPTT = 0,BPTP = @tt, BPPar = (select COUNT(*) from Pro.ParBatch where BPIdBatchP = @idbatch), " +
                                        "BPOrdPro=@Orden, BPProdu=@r,BPRecha=@dv where IdBatchPro = @idbatch;" +
                                        " else update Mae.BatchPro set BPTT = @tt,BPTP = @tp," +
                                        " BPPar = (select COUNT(*) from Pro.ParBatch where BPIdBatchP = @idbatch),BPOrdPro=@Orden, " +
                                        "BPProdu=@r,BPRecha=@dv where IdBatchPro = @idbatch;";
                comando.CommandType = CommandType.Text;
                comando.ExecuteNonQuery();
                Conexion.CerrarConex();
            }
            catch
            {

            }

        }

        public string TurnosA(string turno, string fecha)//Función para contar cuantos turnos se han abierto en el dia, para calcular o no el retraso
        {
            string turnos="";
            //Consultar turnos abiertos
            try
            {
                comando.Connection = Conexion.AbrirConex();
                comando.CommandText = "select count(*) from Mae.BatchPro where BPTurno = '"+turno+ "' and BPCenMaq='" + CCentro + "' and BPFePro ='" + fecha+"'" ;
                leer = comando.ExecuteReader();
                if (leer.Read())
                {
                    turnos = Convert.ToString(leer.GetInt32(0));
                    comando.Connection = Conexion.CerrarConex();

                }
            }
            catch (System.Exception ex)
            {
                 // TODO
            }
            return turnos;
        }

        //public DataTable EnviarDatosLog()
        //{
        //    try
        //    {
        //        comando.Connection = Conexion.AbrirConex();
        //        comando.CommandText = "Select * from TipoPar";
        //        //Procedimiento alamacenado= comando.CommandType = CommandType.StoredProcedure;
        //        leer = comando.ExecuteReader();
        //        tabla.Load(leer);
        //        Conexion.CerrarConex();
        //    }
        //    catch (System.Exception ex)
        //    {
        //         // TODO
        //    }
        //    return tabla;
        //}

        public void Cerrarbatch(int id, string hf, string dur, string orden, string rr, string ddv, string turno)
        {
            string hrturno="" ;
            string dr = dur.Replace(",", "."); //cambiar las comas por puntos para evitar error en la bd sql server
            string r, dv;
            bool paradaturno = false;
            double dura = 0;
            string durparada="";

            if (!String.IsNullOrEmpty(rr))
            {
                r = rr.Replace(",", ".");
            }
            else
            {
                r = "0";
            }

            if (!String.IsNullOrEmpty(ddv))
            {
                dv = ddv.Replace(",", ".");
            }
            else
            {
                dv = "0";
            }

            int valhora = int.Parse(DateTime.Now.ToString("HHmmss"));
            //Obtener retraso por cierre de turno 
           
                 
                //if (turno== "1er Turno")
                //{
                if (  valhora > 160000 & valhora < 180000) { 
                    hrturno = DateTime.Now.ToString("dd/MM/yyyy") + " 18:00:00"; // hora de cierre
                    dura = DateTime.Parse(hrturno).Subtract(DateTime.Parse(hf)).TotalMinutes;
                    durparada = Convert.ToString(string.Format("{0:0.000}", dura)).Replace(",", ".");
                    paradaturno = true;
                    }
                //}

            
          //TODO: Errror ak cerrar turno despues e horario.
                //if (turno == "2do Turno")
                //{
                if (valhora>40000 & valhora < 60000  )
                {
                    hrturno = DateTime.Now.ToString("dd/MM/yyyy") + " 06:00:00";

                    dura = DateTime.Parse(hrturno).Subtract(DateTime.Parse(hf)).TotalMinutes;
                    durparada = Convert.ToString(string.Format("{0:0.000}", dura)).Replace(",", ".");
                    paradaturno = true;
                }
                //}
                
            

            
            try
            {
                comando.Connection = Conexion.AbrirConex();
                if (paradaturno == false)
                {
                         comando.CommandText = @"declare @r float =" + r + " " +
                        "declare @dv float=" + dv + " " +
                        "declare @ordenfinal varchar(50)='" + orden + "' " +
                        "declare @HF varchar(20) ='" + hf + "' " +
                        "declare @idbatch int =" + id + " " +
                        "declare @dturno float  = " + dr + " " +
                        "declare @tp float " +
                        "declare @tt float " +
                        "update Mae.BatchPro set BPOrdPro=@ordenfinal,BPProdu=@r,BPRecha=@dv  where IdBatchPro=@idbatch " +
                        "update Mae.BatchPro set BPHoraFin=@HF where IdBatchPro=@idbatch " +
                        "IF (select TOP 1 PBDura from Pro.ParBatch where BPIdBatchP=@idbatch) is not null " +
                        "select @tp = (select SUM(PBDura)  from Pro.ParBatch where BPIdBatchP=@idbatch);" +
                        " ELSE select @tp = 0;  " +
                        "if (@dturno - @tp >1) select @tt =(@dturno - @tp) " +
                        "else    select @tt = 0; " +
                        "update Mae.BatchPro set BPTT=@tt,BPTP=@tp, " +
                        "BPPar=(select COUNT(*) from Pro.ParBatch where BPIdBatchP=@idbatch), " +
                        "BPProdu=@r,BPRecha=@dv,BPEsta=1 where IdBatchPro=@idbatch";

                }
                else
                {
                        comando.CommandText = @"declare @r float =" + r + " " +
                        "declare @dv float=" + dv + " " +
                        "declare @ordenfinal varchar(50)='" + orden + "' " +
                        "declare @HF varchar(20) ='" + hf + "' " +
                        "declare @idbatch int =" + id + " " +
                        "declare @dturno float  = " + dr + " " +
                        "declare @tp float declare @tt float  " +
                        "INSERT INTO Pro.ParBatch (BPIdBatchP,ECodEqu, TPCodPar, PBHorI, PBHorF,PBDura, PBDet, PBEsta) " +
                        "values( @idbatch,'" + CDVersion.Ofic + "','018078','" + hf + "','" + hrturno + "'," + durparada + ",'Tiempo de perdido por inicio/cierre del turno',1); " +
                        "update Mae.BatchPro set BPOrdPro=@ordenfinal,BPProdu=@r,BPRecha=@dv  where IdBatchPro=@idbatch" +
                        " update Mae.BatchPro set BPHoraFin=@HF where IdBatchPro=@idbatch " +
                        "IF (select TOP 1 PBDura from Pro.ParBatch where BPIdBatchP=@idbatch) is not null " +
                        "select @tp = (select SUM(PBDura)  from Pro.ParBatch where BPIdBatchP=@idbatch); " +
                        "ELSE select @tp = 0;  if (@dturno - @tp >0) select @tt =(@dturno - @tp) " +
                        "else    select @tt = 0; update Mae.BatchPro set BPTT=@tt,BPTP=@tp," +
                        " BPPar=(select COUNT(*) from Pro.ParBatch where BPIdBatchP=@idbatch), " +
                        "BPProdu=@r,BPRecha=@dv,BPEsta=1 where IdBatchPro=@idbatch; ";

                }
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
