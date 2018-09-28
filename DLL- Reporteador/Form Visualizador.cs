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
    //**************HECHO POR PABLO MAZARIEGOS******************
     partial class Form_Visualizador : Form
    {
        OdbcConnection cnx = new OdbcConnection("Driver ={MySQL ODBC 5.2 ANSI Driver}; Server=104.154.63.216; Database=colchoneria;" + //DATOS DEL SERVIDOR
            "User=pruebas; Password=umg; Option=3");
        String msg_errorPath;
        Boolean errorPath = false;
        protected internal String ObtenerPath() //obtiene la ruta actual de la carpeta donde se encuentran los reportes
        {
            String path = "";
            try{
                cnx.Open();
                OdbcCommand query = cnx.CreateCommand();
                query.CommandText = "SELECT path from reporteador;";
                OdbcDataReader dtr = query.ExecuteReader();
                dtr.Read();
                path = dtr.GetString(0);// se guarda la ruta del servidor
                cnx.Close();
                errorPath = false;
            }catch (OdbcException ex) { 
                errorPath = true;
                msg_errorPath = ex.Message;
            }

            if (errorPath == true){ //errorPath= true, quiere decir que hubo un error al obtener la ruta de la base de datos
                errorPath = false;
                MessageBox.Show(msg_errorPath, "ERROR", MessageBoxButtons.OK);
                return null;
            }else{
                return path; // si no hubo error, retorna el string con la ruta
            }
        }

        protected internal Form_Visualizador(String nombre_rpt)
        {
            InitializeComponent();
            ReportDocument rpt = new ReportDocument(); //nuevo documento de reporte

            rpt.Load(ObtenerPath()+"/"+nombre_rpt); //se carga el reporte con:  (1) la ruta obtenida del servidor + (2)el nombre del reporte que envia el programador
            crystalReportViewer1.ReportSource = rpt;//se carga al visualizador
            crystalReportViewer1.Refresh(); //se abre el visualizador
        }
    }
}
