using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPracticoAgustin.enums;

namespace TrabajoPracticoAgustin.models
{
    public class DesarrolloWeb : Proyecto
    {
        public string TecnologiaAusar { get; set; }
        public DesarrolloWeb(string nombre, EstadoProyecto estado, int desarrolladores, DateTime fechaInicio, TipoProyecto tipoProyecto, string TecnologiaAusar)
            : base(nombre, estado, desarrolladores, fechaInicio, tipoProyecto)
        {
            this.TecnologiaAusar = TecnologiaAusar;
        }
        public override string ObtenerDatoEspecifico()
        {
            return TecnologiaAusar;
        }
    }
}