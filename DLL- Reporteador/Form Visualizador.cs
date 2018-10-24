using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.Odbc;

namespace DLL__Reporteador
{

     partial class Form_Visualizador : Form
    {
        public OdbcConnection cnx = new OdbcConnection("DSN=colchoneria");
        protected internal Form_Visualizador(int CodigoAplicacion)
        {
            InitializeComponent();
            OdbcDataReader rd;
            OdbcCommand odbc = new OdbcCommand();
            odbc.CommandText = "SELECT nombre_doc, ruta FROM TBL_Doc_Asociado WHERE aplicacion_api_codigo = " + CodigoAplicacion+";";
            cnx.Open();
            odbc.Connection = cnx;
            rd = odbc.ExecuteReader();
            rd.Read();
            String nombreDoc = rd.GetString(0);
            String rutaDoc = rd.GetString(1);
            

            ReportDocument rpt = new ReportDocument();
            rpt.Load(rutaDoc+"/"+nombreDoc+".rpt");
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }
    }
}
