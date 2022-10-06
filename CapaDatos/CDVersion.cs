using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDVersion
    {
    
        public static string CCentro { get; set; } = "431103";//Variable  para asignar el molino
        public static string version { get; set; } = "M32022.10.06"; //Control de versión en la base de datos.
        public static string Ofic { get; set; } = "OFIC-237 "; // Ofic predeterminada del molino
        public static string Com { get; set; } = "COM1"; // Puerto de Comunicación Predeterminado

        //Equipos predeterminados
        public static string Equip1 { get; set; } = "855-278"; //Parada automatica

        ////Paradas rapidas
        //public static string Equip2 { get; set; } = "855-213 "; //Cambio de Crepe
        //public static string Equip3 { get; set; } = ""; //Limpieza Máq.
        //public static string Equip4 { get; set; } = ""; //Acumulacion de pasta
    }
}
