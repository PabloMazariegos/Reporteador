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
        /// <param name="nombre_rpt">Nombre del reporte que deseas abrir, "COLOCAR la extension .rpt", "ejemplo.rpt"</param>
        public void AbrirReporte(String nombre_rpt)
        {
            Form_Visualizador vs = new Form_Visualizador(nombre_rpt);
            vs.Show();
        }
    }
}
