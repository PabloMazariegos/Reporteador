using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.Odbc;
using System.Windows.Forms;

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
        /// <param name="codigoAplicacion"> Codigo de la aplicacion(form), para obtener el reporte asociado a dicha aplicacion. </param>

        public void AbrirReporte(int  codigoAplicacion)
        {
            //obtener ruta y nombre del doc asociado a la aplicacion
            OdbcConnection cnx = new OdbcConnection("DSN=colchoneria");
            OdbcDataReader rd;
            OdbcCommand odbc = new OdbcCommand();
            odbc.CommandText = "SELECT nombre_doc, ruta FROM tbl_doc_asociado WHERE FK_Api_codigo = " + codigoAplicacion + ";";
            cnx.Open();
            odbc.Connection = cnx;
            rd = odbc.ExecuteReader();
            if (rd.Read())
            {
                String nombreDoc = rd.GetString(0);
                String rutaDoc = rd.GetString(1);
                String rutaRPT = rutaDoc + "/" + nombreDoc + ".rpt";
                Form_Visualizador vs = new Form_Visualizador(rutaRPT);
                vs.Show();
            }
            else
            {
                MessageBox.Show("Codigo de Aplicacion incorrecto");
            }

           
        }
    }
}
