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
        OdbcConnection cnx = new OdbcConnection("DSN=ReportesBD");
        String msg_errorPath, msg_errorCambio;
        Boolean errorPath = false, errorCambio = false;
        protected internal String ObtenerPath()
        {
            String path = "";
            try{
                cnx.Open();
                OdbcCommand query = cnx.CreateCommand();
                query.CommandText = "SELECT path from reporteador;";
                OdbcDataReader dtr = query.ExecuteReader();
                dtr.Read();
                path = dtr.GetString(0);
                cnx.Close();
                errorPath = false;
            }catch (OdbcException ex) { 
                errorPath = true;
                msg_errorPath = ex.Message;
            }

            if (errorPath == true){
                errorPath = false;
                MessageBox.Show(msg_errorPath, "ERROR", MessageBoxButtons.OK);
                return null;
            }else{
                return path;
            }
        }

        protected internal Form_Visualizador(String nombre_rpt)
        {
            InitializeComponent();
            ReportDocument rpt = new ReportDocument();

            rpt.Load(ObtenerPath()+"/"+nombre_rpt);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }
    }
}
