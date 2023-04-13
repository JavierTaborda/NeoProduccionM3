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
        public static string version { get; set; } = "M32023.01.25"; //Control de versión en la base de datos.
        public static string Ofic { get; set; } = "OFIC-237 "; // Ofic predeterminada del molino
        public static string Com { get; set; } = "COM6"; // Puerto de Comunicación Predeterminado

        //Equipos predeterminados
        //public static string Equip1 { get; set; } = "855-278"; //Parada automatica MO5
        public static string Equip1 { get; set; } = "OFIC-237 "; //Parada automaticaMO3

        ////Paradas rapidas
        public static string Equip2 { get; set; } = "OFIC-237 "; //Cambio de Crepe M5: "855-213 " M3 = "OFIC-237 "
        //public static string Equip3 { get; set; } = ""; //Limpieza Máq.
        //public static string Equip4 { get; set; } = ""; //Acumulacion de pasta


    }
}
