using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{   
    public class CDParadasBatch
    {
        private CDConexionSQL Conexion = new CDConexionSQL();

        SqlDataReader leer;
        SqlDataReader leer2;
        DataTable tabla = new DataTable();
        DataTable tabla2 = new DataTable();//Mostrar Paradas desde Formulario turnos
        DataTable tabla3 = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable MostrarParBatch(int id) 
        {
            try
            {
                comando.Connection = Conexion.AbrirConex();
                comando.CommandText = "SELECT IdParBatch, ECodEqu as 'Equipo', Pro.ParBatch.TPCodPar as 'Código', CNombre as 'Causa', TPDes as 'Falla', PBHorI as 'Hora Inicial', PBHorF as 'Hora Final', PBDet as 'Observación', ROUND(PBDura,0)  as 'Duración (min)', PBEsta as 'Finalizada' FROM  Pro.Causas, Pro.ParBatch , Pro.TipoPar WHERE TipoPar.TPCodPar = ParBatch.TPCodPar AND TipoPar.CIdCausa = Causas.IdCausa  AND PBDura>2  AND  BPIdBatchP  = " + id+ " Or TipoPar.TPCodPar = ParBatch.TPCodPar AND TipoPar.CIdCausa = Causas.IdCausa  AND PBDura is null AND BPIdBatchP ="+id;     
                //Procedimiento alamacenado= comando.CommandType = CommandType.StoredProcedure;
                leer = comando.ExecuteReader();
                tabla.Clear();
                tabla.Load(leer);
                Conexion.CerrarConex();
            }
            catch (System.Exception ex)
            {
                 // TODO
            }
            return tabla;
        }
        public DataTable MostrarParBatchRenCal(int id)
        {   
            try
            {
                comando.Connection = Conexion.AbrirConex();
                comando.CommandText = " SELECT IdParReCa as 'Falla ID' ,BPIdBatchP as 'Batch' ,ECodEqu as 'Equipo', Pro.TipoPar.TPCodPar as 'Código Falla',PRCTP as 'Tiempo Perdido' ,PRCCausa as 'Causa' ,Pro.TipoPar.TPDes as 'Detalle' ,PRCObs as 'Observación' from Pro.ParRenCal, Pro.TipoPar where   TipoPar.TPCodPar = ParRenCal.TPCodPar   and BPIdBatchP=" + id;
                //Procedimiento alamacenado= comando.CommandType = CommandType.StoredProcedure;
                leer2 = comando.ExecuteReader();
                tabla3.Clear();
                tabla3.Load(leer2);
                Conexion.CerrarConex();
            }
            catch (System.Exception ex)
            {
                 // TODO
            }
            return tabla3;
        }

        public DataTable Mostrarturnos(string fecha1, string fecha2,string  turno)
        {
            //Consultar por fecha
            try
            {
                comando.Connection = Conexion.AbrirConex();
                if (turno == "Todos")
                {
                    if (fecha2 == "") comando.CommandText = "Select IdBatchPro as 'Batch', BPFePro as 'Fecha', BPHoraIni as 'Hora de Inicio', BPHoraFin  as 'Hora de Cierre', BPOrdPro as 'N# de Orden', BPCenMaq as 'N# Centro', BPTurno as 'Turno', ROUND(BPTP,0) as 'Tiempo  Perdido (min)', ROUND(BPTT,0) as 'Tiempo Trabajado (min)', BPPar as '#Paradas', BPEsta	as 'Cerrado' from Mae.BatchPro where Mae.BatchPro.BPFePro='" + fecha1 + "'";
                    else comando.CommandText = "Select IdBatchPro as 'Batch', BPFePro as 'Fecha', BPHoraIni as 'Hora de Inicio', BPHoraFin  as 'Hora de Cierre', BPOrdPro as 'N# de Orden', BPCenMaq as 'N# Centro', BPTurno as 'Turno', ROUND(BPTP,0) as 'Tiempo  Perdido (min)', ROUND(BPTT,0) as 'Tiempo Trabajado (min)', BPPar as '#Paradas', BPEsta	as 'Cerrado' from Mae.BatchPro where BPFePro >='" + fecha1 + "' AND   Mae.BatchPro.BPFePro <= '" + fecha2 + "'";
                }
                else
                {
                    if (fecha2 == "") comando.CommandText = "Select IdBatchPro as 'Batch', BPFePro as 'Fecha', BPHoraIni as 'Hora de Inicio', BPHoraFin  as 'Hora de Cierre', BPOrdPro as 'N# de Orden', BPCenMaq as 'N# Centro', BPTurno as 'Turno', ROUND(BPTP,0) as 'Tiempo  Perdido (min)', ROUND(BPTT,0) as 'Tiempo Trabajado (min)', BPPar as '#Paradas', BPEsta	as 'Cerrado' from Mae.BatchPro where Mae.BatchPro.BPFePro='" + fecha1 + "' AND BPTurno='" + turno + "'";
                    else comando.CommandText = "Select IdBatchPro as 'Batch', BPFePro as 'Fecha', BPHoraIni as 'Hora de Inicio', BPHoraFin  as 'Hora de Cierre', BPOrdPro as 'N# de Orden', BPCenMaq as 'N# Centro', BPTurno as 'Turno', ROUND(BPTP,0) as 'Tiempo  Perdido', ROUND(BPTT,0) as 'Tiempo Trabajado', BPPar as '#Paradas', BPEsta	as 'Cerrado' from Mae.BatchPro where BPFePro >='" + fecha1 + "' AND   Mae.BatchPro.BPFePro <= '" + fecha2 + "' AND BPTurno='" + turno + "'";        
                }
                //Procedimiento alamacenado= comando.CommandType = CommandType.StoredProcedure;
                leer = comando.ExecuteReader();
                tabla.Clear();
                tabla.Load(leer);
                Conexion.CerrarConex();
            }
            catch (System.Exception ex)
            {
                 // TODO
            }
            return tabla;
        }
            //Mostrar Paradas desde turno
        public DataTable MostrarParturno(int id)
        {
            try
            {
                comando.Connection = Conexion.AbrirConex();
                comando.CommandText = "SELECT IdParBatch, ECodEqu as 'Equipo', Pro.ParBatch.TPCodPar as 'Código', CNombre as 'Causa', TPDes as 'Falla', PBHorI as 'Hora Inicial', PBHorF as 'Hora Final', PBDet as 'Observación', ROUND(PBDura,0) as 'Duración (min)', PBEsta as 'Finalizada' FROM  Pro.Causas, Pro.ParBatch , Pro.TipoPar WHERE TipoPar.TPCodPar = ParBatch.TPCodPar AND TipoPar.CIdCausa = Causas.IdCausa  AND  BPIdBatchP  = " + id;
                //Procedimiento alamacenado= comando.CommandType = CommandType.StoredProcedure;
                leer = comando.ExecuteReader();
                tabla2.Clear();
                tabla2.Load(leer);
                Conexion.CerrarConex();
            }
            catch (System.Exception ex)
            {
                 // TODO
            }
            return tabla2;
        }
        public void Insertar(int idbatch, string eqp,string cod , string h1, string det, int est)
        {
            try
            {
                comando.Connection = Conexion.AbrirConex(); 
                comando.CommandText = "Update Pro.ParBatch Set PBEsta=1 Where IdParBatch=(SELECT MAX(IdParBatch) FROM Pro.ParBatch Where PBEsta=0); INSERT INTO Pro.ParBatch (BPIdBatchP,ECodEqu, TPCodPar, PBHorI, PBDet, PBEsta) values( " + idbatch+",'"+eqp+"','" + cod + "','" + h1+ "','"+det+"'," +est+ "); update Mae.BatchPro set BPActivo=0 where IdBatchPro = "+idbatch;
                comando.CommandType = CommandType.Text;
                comando.ExecuteNonQuery();
                Conexion.CerrarConex();
            }
            catch (Exception e)
            {
                
            }
        }

        public void InsertarRenCal(int idbatch, string eqp, string cod, string causa, string obs)
        {
            try
            {
            comando.Connection = Conexion.AbrirConex();
            comando.CommandText = "INSERT INTO Pro.ParRenCal (BPIdBatchP,ECodEqu, TPCodPar, PRCCausa, PRCObs) values( " + idbatch + ",'" + eqp + "','" + cod + "','" + causa + "','" + obs + "')";
            comando.CommandType = CommandType.Text;
            comando.ExecuteNonQuery();
            Conexion.CerrarConex();
            }
            catch (Exception e)
            {

            }
        }

        public void Editar(int ID, string COD, string DET  )
        {
            try
            {
                comando.Connection = Conexion.AbrirConex();
                comando.CommandText = "Update Pro.ParBatch Set TPCodPar='"+COD+"', PBDet='"+DET+"', Where PBIdPar="+ID;
                comando.CommandType = CommandType.Text;
                comando.ExecuteNonQuery();
                Conexion.CerrarConex();
            }
            catch (Exception e)
            {

            }
        }

        public void Cerrar(string h2, string dur )
        {
            string dr = dur.Replace(",", "."); //cambiar las comas por puntos para evitar error en la bd sql server
            try
            {
                comando.Connection = Conexion.AbrirConex();
            //comando.CommandText = "Update Pro.ParBatch Set PBHorF='" + h2 + "', PBDura="+dr+ ", PBEsta=1 Where IdParBatch=(SELECT MAX(IdParBatch) FROM Pro.ParBatch Where PBEsta=0)";
                comando.CommandText = "update Mae.BatchPro set BPActivo=1 where IdBatchPro = (SELECT MAX(IdBatchPro) FROM Mae.BatchPro Where BPEsta=0);    declare @HoraF varchar (20)= '" + h2+"'; declare @dura float ="+dr+ "; If @dura<2 BEGIN Update Pro.ParBatch Set PBHorF=@HoraF, PBDura=@dura, ECodEqu='855-278', TPCodPar = '018076',PBDet='Parada Autómatica', PBEsta=1 Where IdParBatch=(SELECT MAX(IdParBatch) FROM Pro.ParBatch Where PBEsta=0); END Else BEGIN Update Pro.ParBatch Set PBHorF=@HoraF, PBDura=@dura, PBEsta=1 Where IdParBatch=(SELECT MAX(IdParBatch) FROM Pro.ParBatch Where PBEsta=0); END";
                comando.CommandType = CommandType.Text;
                comando.ExecuteNonQuery();
                Conexion.CerrarConex();
            }
            catch 
            {
                comando.Connection = Conexion.AbrirConex();
                //comando.CommandText = "Update Pro.ParBatch Set PBHorF='" + h2 + "', PBDura="+dr+ ", PBEsta=1 Where IdParBatch=(SELECT MAX(IdParBatch) FROM Pro.ParBatch Where PBEsta=0)";
                comando.CommandText = "update Mae.BatchPro set BPActivo=1 where IdBatchPro = (SELECT MAX(IdBatchPro) FROM Mae.BatchPro Where BPEsta=0); declare @HoraF varchar (20)= '" + h2 + "'; declare @dura float =" + dr + "; If @dura<2 BEGIN Update Pro.ParBatch Set PBHorF=@HoraF, PBDura=@dura, ECodEqu='855-278', TPCodPar = '018076',PBDet='Parada Autómatica', PBEsta=1 Where IdParBatch=(SELECT MAX(IdParBatch) FROM Pro.ParBatch Where PBEsta=0); END Else BEGIN Update Pro.ParBatch Set PBHorF=@HoraF, PBDura=@dura, PBEsta=1 Where IdParBatch=(SELECT MAX(IdParBatch) FROM Pro.ParBatch Where PBEsta=0); END";
                comando.CommandType = CommandType.Text;
                comando.ExecuteNonQuery();
                Conexion.CerrarConex();
            }
            finally
            {

            }
        }
    }
}
