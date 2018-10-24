using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrystalDecisions.CrystalReports.Engine;

namespace DLL__Reporteador
{
    /// <summary>
    /// Esta clase contiene los metodos para abrir el visualizador de reportes, con un reporte especifico.
    /// </summary>
    public class Visualizador
    {
        /// <summary>
        /// Este metodo abre el visualizador de reportes.
        /// </summary>
        /// <param name="codigoAplicacion"> Codigo de la aplicacion, para obtener el reporte asociado a dicha aplicacion. </param>

        public void AbrirReporte(int  codigoAplicacion)
        {
            //obtener ruta y nombre del doc asociado a la aplicacion
            
            Form_Visualizador vs = new Form_Visualizador(codigoAplicacion);
            vs.Show();
        }
    }
}
